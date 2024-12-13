using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RoomAreaPlugin
{
    public partial class MainForm : Form
    {
        public string ?GroupingParameter1 { get; private set; }
        public string ?GroupingParameter2 { get; private set; }
        public string ?GroupingParameter3 { get; private set; }

        public bool Grouping1 { get; private set; }
        public bool Grouping2 { get; private set; }
        public bool Grouping3 { get; private set; }

        public static int NumAftComma = 2;


        public static readonly Dictionary<RoomType, double> MultiplicatorsSystem = new Dictionary<RoomType, double>()
        {
            {RoomType.ResidentialRoom, 1},
            {RoomType.NonResidentialRoom, 1},
            {RoomType.Loggia, 0.5},
            {RoomType.Balcony, 0.3},
            {RoomType.NonResidentialPublicRoom, 1},
            {RoomType.Office, 1 },
            {RoomType.WarmLoggia, 1 },
            {RoomType.Invalid, 0}
        };

        public static Dictionary<RoomType, double> Multiplicators = new Dictionary<RoomType, double>()
        {
            {RoomType.ResidentialRoom, 1},
            {RoomType.NonResidentialRoom, 1},
            {RoomType.Loggia, 0.5},
            {RoomType.Balcony, 0.3},
            {RoomType.NonResidentialPublicRoom, 1},
            {RoomType.Office, 1 },
            {RoomType.WarmLoggia, 1 },
            {RoomType.Invalid, 0}
        };

        public delegate void Calculate(RoomInfo[] rooms, MainForm form);
        public event Calculate ChoseRooms;

        public List<RoomInfo> ListOfRooms;

        public bool UseSystemCoeff { get; private set; } = false;
        public bool DontUseCoeff { get; private set; } = false;

        public MainForm()
        {
            InitializeComponent();
            numericUpDown1.Value = NumAftComma;
        }


        void SendRooms()
        {
            NumAftComma = (int)numericUpDown1.Value;
            var rooms = Logic.GetCheckedNodes(trvRooms.Nodes);
            ChoseRooms(rooms.ToArray(), this);
        }

        #region Btns
        private void btnOk_Click(object sender, EventArgs e)
        {
            SendRooms();
            this.Close();
        }

        private void btnCoefSettings_Click(object sender, EventArgs e) => new CoefficientSettingsForm().ShowDialog();

        private void btnCheckAll_Click(object sender, EventArgs e) => Logic.SetTreeViewNodesChecked(trvRooms.Nodes, true);

        private void btnUnchkAll_Click(object sender, EventArgs e) => Logic.SetTreeViewNodesChecked(trvRooms.Nodes, false);

        private void btnShowAll_Click(object sender, EventArgs e) => trvRooms.ExpandAll();

        private void btnUnshowAll_Click(object sender, EventArgs e) => trvRooms.CollapseAll();
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rooms"></param>
        public void UpdateListOfRooms(List<RoomInfo> rooms)
        {
            ListOfRooms = rooms;

            cmbNumFlat.Items.Clear();
            cmbRoomType.Items.Clear();
            cmbGroupBy1.Items.Clear();
            cmbGroupBy2.Items.Clear();
            cmbGroupBy3.Items.Clear();

            foreach (var e in RoomInfo.SharedParameters)
            {
                cmbNumFlat.Items.Add(e);
                cmbRoomType.Items.Add(e);
                cmbGroupBy1.Items.Add(e);
                cmbGroupBy2.Items.Add(e);
                cmbGroupBy3.Items.Add(e);
            }

            UpdateTreeView();
            CoefficientResultOutputForm.UpdateParameters(RoomInfo.SharedParameters);
        }

        private void chkGroupBy2_CheckedChanged(object sender, EventArgs e)
        {
            Grouping2 = !Grouping2;
            UpdateTreeView();
        }

        private void cmbNumFlat_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in ListOfRooms)
            {
                item.ChangeApartmentParameter(cmbNumFlat.Text);
            }
            UpdateTreeView();
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in ListOfRooms)
            {
                item.ChangeTypeParameter(cmbRoomType.Text);
            }
            UpdateTreeView();
        }

        private void cmbGroupBy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupingParameter1 = cmbGroupBy1.Text;
            UpdateTreeView();
        }

        private void cmbGroupBy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupingParameter2 = cmbGroupBy2.Text;
            UpdateTreeView();
        }

        private void cmbGroupBy3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupingParameter3 = cmbGroupBy3.Text;
            UpdateTreeView();
        }

        private void chkGroupBy1_CheckedChanged_1(object sender, EventArgs e)
        {
            Grouping1 = !Grouping1;
            UpdateTreeView();
        }

        private void chkGroupBy3_CheckedChanged_1(object sender, EventArgs e)
        {
            Grouping3 = !Grouping3;
            UpdateTreeView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CoefficientResultOutputForm();
            form.ShowDialog();
        }

        private void chkUseSysAreaParam_CheckedChanged(object sender, EventArgs e)
        {
            UseSystemCoeff = !UseSystemCoeff;
        }

        private void trvRooms_AfterCheck(object sender, TreeViewEventArgs e) 
        {
            if (e.Action != TreeViewAction.Unknown)
                Logic.CheckAllChildren(e.Node);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumAftComma = (int)numericUpDown1.Value;
            UpdateTreeView();
        }

        void UpdateTreeView()
        {
            var parameters = new List<string>();
            if (GroupingParameter1 != null && Grouping1)
                parameters.Add(GroupingParameter1);
            if (GroupingParameter2 != null && Grouping2)
                parameters.Add(GroupingParameter2);
            if (GroupingParameter3 != null && Grouping3)
                parameters.Add(GroupingParameter3);
            Logic.GroupByParameters(this, parameters);
        }
    }
}
