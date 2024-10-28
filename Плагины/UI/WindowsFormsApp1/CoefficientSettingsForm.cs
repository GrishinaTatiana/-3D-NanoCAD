using System;
using System.Windows.Forms;

namespace RoomAreaPlugin
{
    public partial class CoefficientSettingsForm : Form
    {
        public CoefficientSettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Настройка коэффициента";
            this.Width = 300;
            this.Height = 400;

            // Создаем поля и метки для каждого типа помещения
            Label lblResidential = new Label { Text = "Жилые помещения квартиры", Left = 10, Top = 20, Width = 200 };
            TextBox txtResidential = new TextBox { Left = 220, Top = 20, Width = 50, Text = "1" };

            Label lblNonResidential = new Label { Text = "Нежилые помещения квартиры", Left = 10, Top = 60, Width = 200 };
            TextBox txtNonResidential = new TextBox { Left = 220, Top = 60, Width = 50, Text = "1" };

            Label lblLoggias = new Label { Text = "Лоджии", Left = 10, Top = 100, Width = 200 };
            TextBox txtLoggias = new TextBox { Left = 220, Top = 100, Width = 50, Text = "0.5" };

            Label lblBalconies = new Label { Text = "Балконы, Террасы", Left = 10, Top = 140, Width = 200 };
            TextBox txtBalconies = new TextBox { Left = 220, Top = 140, Width = 50, Text = "0.3" };

            Label lblPublicSpaces = new Label { Text = "Нежилые помещения, общественные (МОП)", Left = 10, Top = 180, Width = 200 };
            TextBox txtPublicSpaces = new TextBox { Left = 220, Top = 180, Width = 50, Text = "1" };

            Label lblOffices = new Label { Text = "Офисы", Left = 10, Top = 220, Width = 200 };
            TextBox txtOffices = new TextBox { Left = 220, Top = 220, Width = 50, Text = "1" };

            Label lblWarmLoggias = new Label { Text = "Теплые лоджии", Left = 10, Top = 260, Width = 200 };
            TextBox txtWarmLoggias = new TextBox { Left = 220, Top = 260, Width = 50, Text = "1" };

            // Кнопка "Сохранить"
            Button btnSave = new Button { Text = "Сохранить", Left = 100, Top = 320, Width = 100 };
            btnSave.Click += BtnSave_Click;

            // Добавление элементов на форму
            this.Controls.Add(lblResidential);
            this.Controls.Add(txtResidential);
            this.Controls.Add(lblNonResidential);
            this.Controls.Add(txtNonResidential);
            this.Controls.Add(lblLoggias);
            this.Controls.Add(txtLoggias);
            this.Controls.Add(lblBalconies);
            this.Controls.Add(txtBalconies);
            this.Controls.Add(lblPublicSpaces);
            this.Controls.Add(txtPublicSpaces);
            this.Controls.Add(lblOffices);
            this.Controls.Add(txtOffices);
            this.Controls.Add(lblWarmLoggias);
            this.Controls.Add(txtWarmLoggias);
            this.Controls.Add(btnSave);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // TODO Логика сохранения коэффициентов
            this.Close();
            throw new NotImplementedException("Логика сохранения коэффициентов");
        }
    }
}
