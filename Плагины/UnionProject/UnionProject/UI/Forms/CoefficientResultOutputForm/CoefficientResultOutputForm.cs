using HostMgd.EditorInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomAreaPlugin
{
    public partial class CoefficientResultOutputForm : Form
    {
        public static bool IsSaved { get; private set; } = false;

        public static string AreaCoef { get; private set; }
        public static string AreaWithCoef { get; private set; }
        public static string FlatAreaWtBalcAndLogWoCoeff { get; private set; }
        public static string FlatArea { get; private set; }
        public static string FlatCount { get; private set; }
        public static string GeneralFlatArea { get; private set; }
        public static string LiveFlatArea { get; private set; }


        public CoefficientResultOutputForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IsSaved = true;
            this.Close();
        }

        public void UpdateParameters(HashSet<string> parameters)
        {
            cmbAreaCoef.Items.Clear();
            cmbAreaWithCoef.Items.Clear();
            cmbFlatAreaWtBalcAndLogWoCoeff.Items.Clear();
            cmbFlatArea.Items.Clear();
            cmbFlatCount.Items.Clear();
            cmbGeneralFlatArea.Items.Clear();
            cmbLiveFlatArea.Items.Clear();
            foreach (var e in parameters)
            {
                cmbAreaCoef.Items.Add(e);
                cmbAreaWithCoef.Items.Add(e);
                cmbFlatAreaWtBalcAndLogWoCoeff.Items.Add(e);
                cmbFlatArea.Items.Add(e);
                cmbFlatCount.Items.Add(e);
                cmbGeneralFlatArea.Items.Add(e);
                cmbLiveFlatArea.Items.Add(e);
            }
        }

        private void cmbAreaCoef_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaCoef = (string)cmbAreaCoef.Items[cmbAreaCoef.SelectedIndex];
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage(AreaCoef);
        }

        private void cmbAreaWithCoef_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaWithCoef = (string)cmbAreaWithCoef.Items[cmbAreaWithCoef.SelectedIndex];
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage(AreaWithCoef);
        }

        private void cmbLiveFlatArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiveFlatArea = (string)cmbLiveFlatArea.Items[cmbLiveFlatArea.SelectedIndex];
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage(LiveFlatArea);
        }

        private void cmbFlatArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlatArea = (string)cmbFlatArea.Items[cmbFlatArea.SelectedIndex];
        }

        private void cmbGeneralFlatArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralFlatArea = (string)cmbGeneralFlatArea.Items[cmbGeneralFlatArea.SelectedIndex];
        }

        private void cmbFlatAreaWtBalcAndLogWoCoeff_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlatAreaWtBalcAndLogWoCoeff = (string)cmbFlatAreaWtBalcAndLogWoCoeff.Items[cmbFlatAreaWtBalcAndLogWoCoeff.SelectedIndex];
        }

        private void cmbFlatCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlatCount = (string)cmbFlatArea.Items[cmbFlatCount.SelectedIndex];
        }
    }
}
