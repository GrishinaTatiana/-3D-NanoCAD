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
        public List<TreeNode> LastActiveNode; //плохо, наверное заменить позже
        public PropertyInfo LastlyGroupedBy;

        List<RoomInfo> ListOfRooms;

        public MainForm()
        {
            InitializeComponent();
            var items = new string[] { "Этаж", "Квартира", "Тип" };
            foreach (var item in items) 
            {
                cmbGroupBy1.Items.Add(item);
                cmbGroupBy2.Items.Add(item);
                cmbGroupBy3.Items.Add(item);
            }

            chkGroupBy2.Enabled = false;
            chkGroupBy3.Enabled = false;

            Logic.InitializeTreeView(this, trvRooms.Nodes);
        }

        #region Btns
        private void btnOk_Click(object sender, EventArgs e)
        {
            CoefficientResultOutputForm secondForm = new CoefficientResultOutputForm();
            secondForm.FormClosed += (s, args) => { if(secondForm.IsSaved) this.Close(); };
            secondForm.ShowDialog();
        }

        private void btnCoefSettings_Click(object sender, EventArgs e) => new CoefficientSettingsForm().ShowDialog();

        private void btnCheckAll_Click(object sender, EventArgs e) => Logic.SetTreeViewNodesChecked(trvRooms.Nodes,true);

        private void btnUnchkAll_Click(object sender, EventArgs e) => Logic.SetTreeViewNodesChecked(trvRooms.Nodes, false);

        private void btnShowAll_Click(object sender, EventArgs e) => trvRooms.ExpandAll();

        private void btnUnshowAll_Click(object sender, EventArgs e) => trvRooms.CollapseAll();
        #endregion

        private void txtbFloatParam_TextChanged(object sender, EventArgs e)
        {
            int decimalPlaces = 0;
            _ = int.TryParse(txtbFloatParam.Text, out decimalPlaces);
            Logic.UpdateTreeView(trvRooms.Nodes, decimalPlaces);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rooms"></param>
        public void UpdateListOfRooms(List<RoomInfo> rooms)
        {
            ListOfRooms = rooms;
            NodeHelper.UpdateNodes(rooms); // Доставать ноды отсюда и пихать их в зависмости от группировки
        }

        private void chkGroupBy1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void chkGroupBy2_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void chkGroupBy3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
