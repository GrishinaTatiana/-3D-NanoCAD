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
        public bool IsSaved { get; private set; } = false;

        public CoefficientResultOutputForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IsSaved = true;
            this.Close();
        }
    }
}
