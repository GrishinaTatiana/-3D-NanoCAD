using HostMgd.EditorInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

        static HashSet<string> Parameters;


        public CoefficientResultOutputForm()
        {
            InitializeComponent();

            foreach (var e in Parameters)
            {
                cmbAreaCoef.Items.Add(e);
                cmbAreaWithCoef.Items.Add(e);
                cmbFlatAreaWtBalcAndLogWoCoeff.Items.Add(e);
                cmbFlatArea.Items.Add(e);
                cmbFlatCount.Items.Add(e);
                cmbGeneralFlatArea.Items.Add(e);
                cmbLiveFlatArea.Items.Add(e);
            }
             
            if(AreaCoef != null)
                cmbAreaCoef.SelectedIndex = cmbAreaCoef.FindString(AreaCoef);
            if(AreaWithCoef != null)
                cmbAreaWithCoef.SelectedIndex = cmbAreaWithCoef.FindString(AreaWithCoef);
            if(FlatAreaWtBalcAndLogWoCoeff != null)
                cmbFlatAreaWtBalcAndLogWoCoeff.SelectedIndex = cmbFlatAreaWtBalcAndLogWoCoeff.FindString(FlatAreaWtBalcAndLogWoCoeff);
            if(FlatArea != null)
                cmbFlatArea.SelectedIndex = cmbFlatArea.FindString(FlatArea);
            if(FlatCount != null)
                cmbFlatCount.SelectedIndex = cmbFlatCount.FindString(FlatCount);
            if(GeneralFlatArea != null)
                cmbGeneralFlatArea.SelectedIndex = cmbGeneralFlatArea.FindString(GeneralFlatArea);
            if(LiveFlatArea != null)
                cmbLiveFlatArea.SelectedIndex = cmbLiveFlatArea.FindString(LiveFlatArea);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IsSaved = true;
            this.Close();
        }

        public static void UpdateParameters(HashSet<string> parameters)
        {
            if(!parameters.Contains(AreaCoef))
                AreaCoef = null;
            if(!parameters.Contains(AreaWithCoef))
                AreaWithCoef = null;
            if(!parameters.Contains(FlatAreaWtBalcAndLogWoCoeff))
                FlatAreaWtBalcAndLogWoCoeff = null;
            if(!parameters.Contains(FlatArea))
                FlatArea = null;
            if(!parameters.Contains(FlatCount))
                FlatCount = null;
            if(!parameters.Contains(GeneralFlatArea))
                GeneralFlatArea = null;
            if(!parameters.Contains(LiveFlatArea))
                LiveFlatArea = null;

            Parameters = parameters;
        }

        private void cmbAreaCoef_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaCoef = (string)cmbAreaCoef.Items[cmbAreaCoef.SelectedIndex];
        }

        private void cmbAreaWithCoef_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaWithCoef = (string)cmbAreaWithCoef.Items[cmbAreaWithCoef.SelectedIndex];
        }

        private void cmbLiveFlatArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiveFlatArea = (string)cmbLiveFlatArea.Items[cmbLiveFlatArea.SelectedIndex];
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
