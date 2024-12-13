using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomAreaPlugin
{
    public partial class CoefficientSettingsForm : Form
    {
        public CoefficientSettingsForm()
        {
            InitializeComponent();

            txtbResidential.Text = MainForm.Multiplicators[RoomType.ResidentialRoom].ToString(CultureInfo.InvariantCulture);
            txtbBalconies.Text = MainForm.Multiplicators[RoomType.Balcony].ToString(CultureInfo.InvariantCulture);
            txtbLoggias.Text = MainForm.Multiplicators[RoomType.Loggia].ToString(CultureInfo.InvariantCulture);
            txtbNonResidential.Text = MainForm.Multiplicators[RoomType.NonResidentialRoom].ToString(CultureInfo.InvariantCulture);
            txtbOffices.Text = MainForm.Multiplicators[RoomType.Office].ToString(CultureInfo.InvariantCulture);
            txtbPublicSpaces.Text = MainForm.Multiplicators[RoomType.NonResidentialPublicRoom].ToString(CultureInfo.InvariantCulture);
            txtbWarmLoggias.Text = MainForm.Multiplicators[RoomType.WarmLoggia].ToString(CultureInfo.InvariantCulture);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.Multiplicators[RoomType.ResidentialRoom] = double.Parse(txtbResidential.Text, CultureInfo.InvariantCulture);
                MainForm.Multiplicators[RoomType.Balcony] = double.Parse(txtbBalconies.Text, CultureInfo.InvariantCulture);
                MainForm.Multiplicators[RoomType.Loggia] = double.Parse(txtbLoggias.Text, CultureInfo.InvariantCulture);
                MainForm.Multiplicators[RoomType.NonResidentialRoom] = double.Parse(txtbNonResidential.Text, CultureInfo.InvariantCulture);
                MainForm.Multiplicators[RoomType.Office] = double.Parse(txtbOffices.Text, CultureInfo.InvariantCulture);
                MainForm.Multiplicators[RoomType.NonResidentialPublicRoom] = double.Parse(txtbPublicSpaces.Text, CultureInfo.InvariantCulture);
                MainForm.Multiplicators[RoomType.WarmLoggia] = double.Parse(txtbWarmLoggias.Text, CultureInfo.InvariantCulture);
            }
            catch 
            {
                MessageBox.Show("Неправильный формат числа","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }


        private void txtbResidential_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
