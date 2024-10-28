using System;
using System.Windows.Forms;

namespace RoomAreaPlugin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Основная форма
            this.Text = "Площади помещений";
            this.Width = 600;
            this.Height = 600;

            // Checkbox "Групп-вать"
            CheckBox chkGroupBy = new CheckBox { Text = "Групп-вать", Left = 10, Top = 10, Width = 100 };
            ComboBox cmbGroupBy = new ComboBox { Left = 120, Top = 10, Width = 150 };

            // Checkbox "Затем по"
            CheckBox chkFilter1 = new CheckBox { Text = "Затем по", Left = 10, Top = 40, Width = 100 };
            ComboBox cmbFilter1 = new ComboBox { Left = 120, Top = 40, Width = 150 };

            // Второй Checkbox "Затем по"
            CheckBox chkFilter2 = new CheckBox { Text = "Затем по", Left = 10, Top = 70, Width = 100 };
            ComboBox cmbFilter2 = new ComboBox { Left = 120, Top = 70, Width = 150 };

            // TreeView для этажей
            TreeView treeViewFloors = new TreeView { Left = 10, Top = 100, Width = 200, Height = 300 };

            // Параметры справа
            ComboBox cmbApartmentNumber = new ComboBox { Left = 300, Top = 40, Width = 200 };
            ComboBox cmbRoomType = new ComboBox { Left = 300, Top = 80, Width = 200 };
            TextBox txtDecimalPlaces = new TextBox { Left = 300, Top = 120, Width = 50 };

            // CheckBox для дополнительных параметров
            CheckBox chkIncludeStorage = new CheckBox { Text = "Включить кладовые квартиры", Left = 300, Top = 160, Width = 200 };
            CheckBox chkDisableCoefficient = new CheckBox { Text = "Убрать расчет с коэффициентом", Left = 300, Top = 190, Width = 200 };
            
            CheckBox chkUseSystemArea = new CheckBox { Text = "Использовать системный параметр площади", Left = 300, Top = 220, Width = 250, Checked = true };
            ComboBox cmbUseSystemArea = new ComboBox { Left = 300, Top = 250, Width = 250 };

            // Кнопки управления
            Button btnSelectAll = new Button { Text = "Выбрать все", Left = 10, Top = 420, Width = 100 };
            Button btnReset = new Button { Text = "Сбросить", Left = 120, Top = 420, Width = 100 };
            Button btnExpandAll = new Button { Text = "Раскрыть все", Left = 10, Top = 460, Width = 100 };
            Button btnCollapseAll = new Button { Text = "Спрятать все", Left = 120, Top = 460, Width = 100 };
            Button btnSettings = new Button { Text = "Настройка коэффициента", Left = 300, Top = 290, Width = 200 };
            Button btnOk = new Button { Text = "OK", Left = 350, Top = 500, Width = 100 };

            // Добавление событий
            btnSettings.Click += BtnSettings_Click;
            btnSelectAll.Click += BtnSelectAll_Click;
            btnReset.Click += BtnReset_Click;
            btnOk.Click += BtnOk_Click;

            // Добавление элементов на форму

            this.Controls.Add(chkGroupBy);
            this.Controls.Add(cmbGroupBy);
            this.Controls.Add(chkFilter1);
            this.Controls.Add(cmbFilter1);
            this.Controls.Add(chkFilter2);
            this.Controls.Add(cmbFilter2);
            this.Controls.Add(treeViewFloors);
            this.Controls.Add(cmbApartmentNumber);
            this.Controls.Add(cmbRoomType);
            this.Controls.Add(txtDecimalPlaces);
            this.Controls.Add(chkIncludeStorage);
            this.Controls.Add(chkDisableCoefficient);
            this.Controls.Add(chkUseSystemArea);
            this.Controls.Add(cmbUseSystemArea);
            this.Controls.Add(btnSelectAll);
            this.Controls.Add(btnReset);
            this.Controls.Add(btnExpandAll);
            this.Controls.Add(btnCollapseAll);
            this.Controls.Add(btnSettings);
            this.Controls.Add(btnOk);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            // TODO Логика сохранения
            throw new NotImplementedException("Логика сохранения");
            this.Close();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new CoefficientSettingsForm();
            settingsForm.ShowDialog();
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            // TODO Логика выбора всех элементов TreeView
            throw new NotImplementedException("Логика выбора всех элементов TreeView");
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // TODO Логика сброса параметров
            throw new NotImplementedException("Логика сброса параметров");
        }
    }
}
