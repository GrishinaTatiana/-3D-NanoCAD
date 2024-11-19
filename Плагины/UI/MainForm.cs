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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CoefficientResultOutputForm secondForm = new CoefficientResultOutputForm();
            secondForm.FormClosed += (s, args) => { if(secondForm.IsSaved) this.Close(); };
            secondForm.ShowDialog();
        }

        private void btnCoefSettings_Click(object sender, EventArgs e)
        {
            CoefficientSettingsForm secondForm = new CoefficientSettingsForm();
            secondForm.ShowDialog();
        }
    }
}
