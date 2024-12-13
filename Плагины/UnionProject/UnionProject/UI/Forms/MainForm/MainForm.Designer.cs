namespace RoomAreaPlugin
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            chkGroupBy1 = new CheckBox();
            trvRooms = new TreeView();
            lblNumFlat = new Label();
            btnCheckAll = new Button();
            cmbGroupBy1 = new ComboBox();
            cmbGroupBy2 = new ComboBox();
            chkGroupBy2 = new CheckBox();
            cmbGroupBy3 = new ComboBox();
            chkGroupBy3 = new CheckBox();
            cmbNumFlat = new ComboBox();
            lblFloatParam = new Label();
            chkEnableStash = new CheckBox();
            chkDisableCoefCalc = new CheckBox();
            chkUseSysAreaParam = new CheckBox();
            cmbIDK = new ComboBox();
            btnUnchkAll = new Button();
            btnUnshowAll = new Button();
            btnShowAll = new Button();
            cmbRoomType = new ComboBox();
            lblRoomType = new Label();
            btnOk = new Button();
            btnCoefSettings = new Button();
            mainFormBindingSource = new BindingSource(components);
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)mainFormBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // chkGroupBy1
            // 
            chkGroupBy1.AutoSize = true;
            chkGroupBy1.Location = new Point(14, 14);
            chkGroupBy1.Margin = new Padding(4, 3, 4, 3);
            chkGroupBy1.Name = "chkGroupBy1";
            chkGroupBy1.Size = new Size(80, 19);
            chkGroupBy1.TabIndex = 0;
            chkGroupBy1.Text = "Груп-вать";
            chkGroupBy1.UseVisualStyleBackColor = true;
            chkGroupBy1.CheckedChanged += chkGroupBy1_CheckedChanged_1;
            // 
            // trvRooms
            // 
            trvRooms.CheckBoxes = true;
            trvRooms.Location = new Point(14, 103);
            trvRooms.Margin = new Padding(4, 3, 4, 3);
            trvRooms.Name = "trvRooms";
            trvRooms.Size = new Size(241, 279);
            trvRooms.TabIndex = 1;
            trvRooms.AfterCheck += trvRooms_AfterCheck;
            // 
            // lblNumFlat
            // 
            lblNumFlat.AutoSize = true;
            lblNumFlat.Location = new Point(262, 15);
            lblNumFlat.Margin = new Padding(4, 0, 4, 0);
            lblNumFlat.Name = "lblNumFlat";
            lblNumFlat.Size = new Size(163, 15);
            lblNumFlat.TabIndex = 2;
            lblNumFlat.Text = "Параметр номера квартиры";
            lblNumFlat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCheckAll
            // 
            btnCheckAll.Location = new Point(14, 395);
            btnCheckAll.Margin = new Padding(4, 3, 4, 3);
            btnCheckAll.Name = "btnCheckAll";
            btnCheckAll.Size = new Size(115, 33);
            btnCheckAll.TabIndex = 3;
            btnCheckAll.Text = "Выбрать все";
            btnCheckAll.UseVisualStyleBackColor = true;
            btnCheckAll.Click += btnCheckAll_Click;
            // 
            // cmbGroupBy1
            // 
            cmbGroupBy1.FormattingEnabled = true;
            cmbGroupBy1.Location = new Point(114, 12);
            cmbGroupBy1.Margin = new Padding(4, 3, 4, 3);
            cmbGroupBy1.Name = "cmbGroupBy1";
            cmbGroupBy1.Size = new Size(140, 23);
            cmbGroupBy1.TabIndex = 5;
            cmbGroupBy1.SelectedIndexChanged += cmbGroupBy1_SelectedIndexChanged;
            // 
            // cmbGroupBy2
            // 
            cmbGroupBy2.FormattingEnabled = true;
            cmbGroupBy2.Location = new Point(114, 43);
            cmbGroupBy2.Margin = new Padding(4, 3, 4, 3);
            cmbGroupBy2.Name = "cmbGroupBy2";
            cmbGroupBy2.Size = new Size(140, 23);
            cmbGroupBy2.TabIndex = 7;
            cmbGroupBy2.SelectedIndexChanged += cmbGroupBy2_SelectedIndexChanged;
            // 
            // chkGroupBy2
            // 
            chkGroupBy2.AutoSize = true;
            chkGroupBy2.Location = new Point(14, 45);
            chkGroupBy2.Margin = new Padding(4, 3, 4, 3);
            chkGroupBy2.Name = "chkGroupBy2";
            chkGroupBy2.Size = new Size(76, 19);
            chkGroupBy2.TabIndex = 6;
            chkGroupBy2.Text = "Затем по";
            chkGroupBy2.UseVisualStyleBackColor = true;
            chkGroupBy2.CheckedChanged += chkGroupBy2_CheckedChanged;
            // 
            // cmbGroupBy3
            // 
            cmbGroupBy3.FormattingEnabled = true;
            cmbGroupBy3.Location = new Point(114, 74);
            cmbGroupBy3.Margin = new Padding(4, 3, 4, 3);
            cmbGroupBy3.Name = "cmbGroupBy3";
            cmbGroupBy3.Size = new Size(140, 23);
            cmbGroupBy3.TabIndex = 9;
            cmbGroupBy3.SelectedIndexChanged += cmbGroupBy3_SelectedIndexChanged;
            // 
            // chkGroupBy3
            // 
            chkGroupBy3.AutoSize = true;
            chkGroupBy3.Location = new Point(14, 76);
            chkGroupBy3.Margin = new Padding(4, 3, 4, 3);
            chkGroupBy3.Name = "chkGroupBy3";
            chkGroupBy3.Size = new Size(76, 19);
            chkGroupBy3.TabIndex = 8;
            chkGroupBy3.Text = "Затем по";
            chkGroupBy3.UseVisualStyleBackColor = true;
            chkGroupBy3.CheckedChanged += chkGroupBy3_CheckedChanged_1;
            // 
            // cmbNumFlat
            // 
            cmbNumFlat.FormattingEnabled = true;
            cmbNumFlat.Location = new Point(266, 33);
            cmbNumFlat.Margin = new Padding(4, 3, 4, 3);
            cmbNumFlat.Name = "cmbNumFlat";
            cmbNumFlat.Size = new Size(215, 23);
            cmbNumFlat.TabIndex = 10;
            cmbNumFlat.SelectedIndexChanged += cmbNumFlat_SelectedIndexChanged;
            // 
            // lblFloatParam
            // 
            lblFloatParam.AutoSize = true;
            lblFloatParam.Location = new Point(262, 118);
            lblFloatParam.Margin = new Padding(4, 0, 4, 0);
            lblFloatParam.Name = "lblFloatParam";
            lblFloatParam.Size = new Size(128, 15);
            lblFloatParam.TabIndex = 13;
            lblFloatParam.Text = "Знаков после запятой";
            // 
            // chkEnableStash
            // 
            chkEnableStash.AutoSize = true;
            chkEnableStash.Location = new Point(266, 144);
            chkEnableStash.Margin = new Padding(4, 3, 4, 3);
            chkEnableStash.Name = "chkEnableStash";
            chkEnableStash.Size = new Size(184, 19);
            chkEnableStash.TabIndex = 14;
            chkEnableStash.Text = "Включить кладовые квартир";
            chkEnableStash.UseVisualStyleBackColor = true;
            // 
            // chkDisableCoefCalc
            // 
            chkDisableCoefCalc.AutoSize = true;
            chkDisableCoefCalc.Location = new Point(266, 171);
            chkDisableCoefCalc.Margin = new Padding(4, 3, 4, 3);
            chkDisableCoefCalc.Name = "chkDisableCoefCalc";
            chkDisableCoefCalc.Size = new Size(199, 19);
            chkDisableCoefCalc.TabIndex = 15;
            chkDisableCoefCalc.Text = "Убрать расчёт коэффициентом";
            chkDisableCoefCalc.UseVisualStyleBackColor = true;
            // 
            // chkUseSysAreaParam
            // 
            chkUseSysAreaParam.Location = new Point(266, 197);
            chkUseSysAreaParam.Margin = new Padding(4, 3, 4, 3);
            chkUseSysAreaParam.Name = "chkUseSysAreaParam";
            chkUseSysAreaParam.Size = new Size(217, 36);
            chkUseSysAreaParam.TabIndex = 16;
            chkUseSysAreaParam.Text = "Использовать системный параметр площади";
            chkUseSysAreaParam.UseVisualStyleBackColor = true;
            chkUseSysAreaParam.CheckedChanged += chkUseSysAreaParam_CheckedChanged;
            // 
            // cmbIDK
            // 
            cmbIDK.FormattingEnabled = true;
            cmbIDK.Location = new Point(266, 240);
            cmbIDK.Margin = new Padding(4, 3, 4, 3);
            cmbIDK.Name = "cmbIDK";
            cmbIDK.Size = new Size(215, 23);
            cmbIDK.TabIndex = 17;
            // 
            // btnUnchkAll
            // 
            btnUnchkAll.Location = new Point(140, 395);
            btnUnchkAll.Margin = new Padding(4, 3, 4, 3);
            btnUnchkAll.Name = "btnUnchkAll";
            btnUnchkAll.Size = new Size(115, 33);
            btnUnchkAll.TabIndex = 21;
            btnUnchkAll.Text = "Сбросить";
            btnUnchkAll.UseVisualStyleBackColor = true;
            btnUnchkAll.Click += btnUnchkAll_Click;
            // 
            // btnUnshowAll
            // 
            btnUnshowAll.Location = new Point(140, 435);
            btnUnshowAll.Margin = new Padding(4, 3, 4, 3);
            btnUnshowAll.Name = "btnUnshowAll";
            btnUnshowAll.Size = new Size(115, 33);
            btnUnshowAll.TabIndex = 23;
            btnUnshowAll.Text = "Спрятать все";
            btnUnshowAll.UseVisualStyleBackColor = true;
            btnUnshowAll.Click += btnUnshowAll_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(14, 435);
            btnShowAll.Margin = new Padding(4, 3, 4, 3);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(115, 33);
            btnShowAll.TabIndex = 22;
            btnShowAll.Text = "Расскрыть все";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(266, 80);
            cmbRoomType.Margin = new Padding(4, 3, 4, 3);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(215, 23);
            cmbRoomType.TabIndex = 27;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Location = new Point(262, 61);
            lblRoomType.Margin = new Padding(4, 0, 4, 0);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(159, 15);
            lblRoomType.TabIndex = 26;
            lblRoomType.Text = "Параметр типа помещения";
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(368, 435);
            btnOk.Margin = new Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(115, 33);
            btnOk.TabIndex = 28;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCoefSettings
            // 
            btnCoefSettings.Location = new Point(266, 271);
            btnCoefSettings.Margin = new Padding(4, 3, 4, 3);
            btnCoefSettings.Name = "btnCoefSettings";
            btnCoefSettings.Size = new Size(173, 27);
            btnCoefSettings.TabIndex = 29;
            btnCoefSettings.Text = "Настройка коэффициента";
            btnCoefSettings.UseVisualStyleBackColor = true;
            btnCoefSettings.Click += btnCoefSettings_Click;
            // 
            // mainFormBindingSource
            // 
            mainFormBindingSource.DataSource = typeof(MainForm);
            // 
            // button1
            // 
            button1.Location = new Point(266, 304);
            button1.Name = "button1";
            button1.Size = new Size(173, 27);
            button1.TabIndex = 30;
            button1.Text = " Указать параметры";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(397, 115);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(53, 23);
            numericUpDown1.TabIndex = 31;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(497, 482);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(btnCoefSettings);
            Controls.Add(btnOk);
            Controls.Add(cmbRoomType);
            Controls.Add(lblRoomType);
            Controls.Add(btnUnshowAll);
            Controls.Add(btnShowAll);
            Controls.Add(btnUnchkAll);
            Controls.Add(cmbIDK);
            Controls.Add(chkUseSysAreaParam);
            Controls.Add(chkDisableCoefCalc);
            Controls.Add(chkEnableStash);
            Controls.Add(lblFloatParam);
            Controls.Add(cmbNumFlat);
            Controls.Add(cmbGroupBy3);
            Controls.Add(chkGroupBy3);
            Controls.Add(cmbGroupBy2);
            Controls.Add(chkGroupBy2);
            Controls.Add(cmbGroupBy1);
            Controls.Add(btnCheckAll);
            Controls.Add(lblNumFlat);
            Controls.Add(trvRooms);
            Controls.Add(chkGroupBy1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Площади помещений";
            ((System.ComponentModel.ISupportInitialize)mainFormBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox chkGroupBy1;
        public System.Windows.Forms.TreeView trvRooms; //Тоже надо как то без публика
        private System.Windows.Forms.Label lblNumFlat;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.ComboBox cmbGroupBy1;
        private System.Windows.Forms.ComboBox cmbGroupBy2;
        private System.Windows.Forms.CheckBox chkGroupBy2;
        private System.Windows.Forms.ComboBox cmbGroupBy3;
        private System.Windows.Forms.CheckBox chkGroupBy3;
        private System.Windows.Forms.ComboBox cmbNumFlat;
        private System.Windows.Forms.Label lblFloatParam;
        private System.Windows.Forms.CheckBox chkEnableStash;
        private System.Windows.Forms.CheckBox chkDisableCoefCalc;
        private System.Windows.Forms.ComboBox cmbIDK;
        private System.Windows.Forms.Button btnUnchkAll;
        private System.Windows.Forms.Button btnUnshowAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.CheckBox chkUseSysAreaParam;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCoefSettings;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
        private Button button1;
        private NumericUpDown numericUpDown1;
    }
}

