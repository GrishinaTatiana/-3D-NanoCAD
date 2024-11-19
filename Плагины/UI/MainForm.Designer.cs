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
            this.chkGroupBy1 = new System.Windows.Forms.CheckBox();
            this.trvRooms = new System.Windows.Forms.TreeView();
            this.lblNumFlat = new System.Windows.Forms.Label();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.txtbFloatParam = new System.Windows.Forms.TextBox();
            this.cmbGroupBy1 = new System.Windows.Forms.ComboBox();
            this.cmbGroupBy2 = new System.Windows.Forms.ComboBox();
            this.chkGroupBy2 = new System.Windows.Forms.CheckBox();
            this.cmbGroupBy3 = new System.Windows.Forms.ComboBox();
            this.chkGroupBy3 = new System.Windows.Forms.CheckBox();
            this.cmbNumFlat = new System.Windows.Forms.ComboBox();
            this.lblFloatParam = new System.Windows.Forms.Label();
            this.chkEnableStash = new System.Windows.Forms.CheckBox();
            this.chkDisableCoefCalc = new System.Windows.Forms.CheckBox();
            this.chkUseSysAreaParam = new System.Windows.Forms.CheckBox();
            this.cmbIDK = new System.Windows.Forms.ComboBox();
            this.btnUnchkAll = new System.Windows.Forms.Button();
            this.btnUnshowAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCoefSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkGroupBy1
            // 
            this.chkGroupBy1.AutoSize = true;
            this.chkGroupBy1.Location = new System.Drawing.Point(12, 12);
            this.chkGroupBy1.Name = "chkGroupBy1";
            this.chkGroupBy1.Size = new System.Drawing.Size(75, 17);
            this.chkGroupBy1.TabIndex = 0;
            this.chkGroupBy1.Text = "Груп-вать";
            this.chkGroupBy1.UseVisualStyleBackColor = true;
            // 
            // trvRooms
            // 
            this.trvRooms.CheckBoxes = true;
            this.trvRooms.Location = new System.Drawing.Point(12, 89);
            this.trvRooms.Name = "trvRooms";
            this.trvRooms.Size = new System.Drawing.Size(207, 242);
            this.trvRooms.TabIndex = 1;
            // 
            // lblNumFlat
            // 
            this.lblNumFlat.AutoSize = true;
            this.lblNumFlat.Location = new System.Drawing.Point(225, 13);
            this.lblNumFlat.Name = "lblNumFlat";
            this.lblNumFlat.Size = new System.Drawing.Size(151, 13);
            this.lblNumFlat.TabIndex = 2;
            this.lblNumFlat.Text = "Параметр номера квартиры";
            this.lblNumFlat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(12, 342);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(99, 29);
            this.btnCheckAll.TabIndex = 3;
            this.btnCheckAll.Text = "Выбрать все";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // txtbFloatParam
            // 
            this.txtbFloatParam.Location = new System.Drawing.Point(352, 99);
            this.txtbFloatParam.Name = "txtbFloatParam";
            this.txtbFloatParam.Size = new System.Drawing.Size(48, 20);
            this.txtbFloatParam.TabIndex = 4;
            this.txtbFloatParam.Text = "2";
            this.txtbFloatParam.TextChanged += new System.EventHandler(this.txtbFloatParam_TextChanged);
            // 
            // cmbGroupBy1
            // 
            this.cmbGroupBy1.FormattingEnabled = true;
            this.cmbGroupBy1.Location = new System.Drawing.Point(98, 10);
            this.cmbGroupBy1.Name = "cmbGroupBy1";
            this.cmbGroupBy1.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupBy1.TabIndex = 5;
            // 
            // cmbGroupBy2
            // 
            this.cmbGroupBy2.FormattingEnabled = true;
            this.cmbGroupBy2.Location = new System.Drawing.Point(98, 37);
            this.cmbGroupBy2.Name = "cmbGroupBy2";
            this.cmbGroupBy2.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupBy2.TabIndex = 7;
            // 
            // chkGroupBy2
            // 
            this.chkGroupBy2.AutoSize = true;
            this.chkGroupBy2.Location = new System.Drawing.Point(12, 39);
            this.chkGroupBy2.Name = "chkGroupBy2";
            this.chkGroupBy2.Size = new System.Drawing.Size(73, 17);
            this.chkGroupBy2.TabIndex = 6;
            this.chkGroupBy2.Text = "Затем по";
            this.chkGroupBy2.UseVisualStyleBackColor = true;
            // 
            // cmbGroupBy3
            // 
            this.cmbGroupBy3.FormattingEnabled = true;
            this.cmbGroupBy3.Location = new System.Drawing.Point(98, 64);
            this.cmbGroupBy3.Name = "cmbGroupBy3";
            this.cmbGroupBy3.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupBy3.TabIndex = 9;
            // 
            // chkGroupBy3
            // 
            this.chkGroupBy3.AutoSize = true;
            this.chkGroupBy3.Location = new System.Drawing.Point(12, 66);
            this.chkGroupBy3.Name = "chkGroupBy3";
            this.chkGroupBy3.Size = new System.Drawing.Size(73, 17);
            this.chkGroupBy3.TabIndex = 8;
            this.chkGroupBy3.Text = "Затем по";
            this.chkGroupBy3.UseVisualStyleBackColor = true;
            // 
            // cmbNumFlat
            // 
            this.cmbNumFlat.FormattingEnabled = true;
            this.cmbNumFlat.Location = new System.Drawing.Point(228, 29);
            this.cmbNumFlat.Name = "cmbNumFlat";
            this.cmbNumFlat.Size = new System.Drawing.Size(185, 21);
            this.cmbNumFlat.TabIndex = 10;
            // 
            // lblFloatParam
            // 
            this.lblFloatParam.AutoSize = true;
            this.lblFloatParam.Location = new System.Drawing.Point(225, 102);
            this.lblFloatParam.Name = "lblFloatParam";
            this.lblFloatParam.Size = new System.Drawing.Size(121, 13);
            this.lblFloatParam.TabIndex = 13;
            this.lblFloatParam.Text = "Знаков после запятой";
            // 
            // chkEnableStash
            // 
            this.chkEnableStash.AutoSize = true;
            this.chkEnableStash.Location = new System.Drawing.Point(228, 125);
            this.chkEnableStash.Name = "chkEnableStash";
            this.chkEnableStash.Size = new System.Drawing.Size(172, 17);
            this.chkEnableStash.TabIndex = 14;
            this.chkEnableStash.Text = "Включить кладовые квартир";
            this.chkEnableStash.UseVisualStyleBackColor = true;
            // 
            // chkDisableCoefCalc
            // 
            this.chkDisableCoefCalc.AutoSize = true;
            this.chkDisableCoefCalc.Location = new System.Drawing.Point(228, 148);
            this.chkDisableCoefCalc.Name = "chkDisableCoefCalc";
            this.chkDisableCoefCalc.Size = new System.Drawing.Size(186, 17);
            this.chkDisableCoefCalc.TabIndex = 15;
            this.chkDisableCoefCalc.Text = "Убрать расчёт коэффициентом";
            this.chkDisableCoefCalc.UseVisualStyleBackColor = true;
            // 
            // chkUseSysAreaParam
            // 
            this.chkUseSysAreaParam.Location = new System.Drawing.Point(228, 171);
            this.chkUseSysAreaParam.Name = "chkUseSysAreaParam";
            this.chkUseSysAreaParam.Size = new System.Drawing.Size(186, 31);
            this.chkUseSysAreaParam.TabIndex = 16;
            this.chkUseSysAreaParam.Text = "Использовать системный параметр площади";
            this.chkUseSysAreaParam.UseVisualStyleBackColor = true;
            // 
            // cmbIDK
            // 
            this.cmbIDK.FormattingEnabled = true;
            this.cmbIDK.Location = new System.Drawing.Point(228, 208);
            this.cmbIDK.Name = "cmbIDK";
            this.cmbIDK.Size = new System.Drawing.Size(185, 21);
            this.cmbIDK.TabIndex = 17;
            // 
            // btnUnchkAll
            // 
            this.btnUnchkAll.Location = new System.Drawing.Point(120, 342);
            this.btnUnchkAll.Name = "btnUnchkAll";
            this.btnUnchkAll.Size = new System.Drawing.Size(99, 29);
            this.btnUnchkAll.TabIndex = 21;
            this.btnUnchkAll.Text = "Сбросить";
            this.btnUnchkAll.UseVisualStyleBackColor = true;
            this.btnUnchkAll.Click += new System.EventHandler(this.btnUnchkAll_Click);
            // 
            // btnUnshowAll
            // 
            this.btnUnshowAll.Location = new System.Drawing.Point(120, 377);
            this.btnUnshowAll.Name = "btnUnshowAll";
            this.btnUnshowAll.Size = new System.Drawing.Size(99, 29);
            this.btnUnshowAll.TabIndex = 23;
            this.btnUnshowAll.Text = "Спрятать все";
            this.btnUnshowAll.UseVisualStyleBackColor = true;
            this.btnUnshowAll.Click += new System.EventHandler(this.btnUnshowAll_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(12, 377);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(99, 29);
            this.btnShowAll.TabIndex = 22;
            this.btnShowAll.Text = "Расскрыть все";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(225, 377);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(32, 29);
            this.btnInfo.TabIndex = 24;
            this.btnInfo.Text = "i";
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(228, 69);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(185, 21);
            this.cmbRoomType.TabIndex = 27;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new System.Drawing.Point(225, 53);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(146, 13);
            this.lblRoomType.TabIndex = 26;
            this.lblRoomType.Text = "Параметр типа помещения";
            this.lblRoomType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(315, 377);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(99, 29);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCoefSettings
            // 
            this.btnCoefSettings.Location = new System.Drawing.Point(228, 235);
            this.btnCoefSettings.Name = "btnCoefSettings";
            this.btnCoefSettings.Size = new System.Drawing.Size(148, 23);
            this.btnCoefSettings.TabIndex = 29;
            this.btnCoefSettings.Text = "Настройка коэффициента";
            this.btnCoefSettings.UseVisualStyleBackColor = true;
            this.btnCoefSettings.Click += new System.EventHandler(this.btnCoefSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(426, 418);
            this.Controls.Add(this.btnCoefSettings);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnUnshowAll);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnUnchkAll);
            this.Controls.Add(this.cmbIDK);
            this.Controls.Add(this.chkUseSysAreaParam);
            this.Controls.Add(this.chkDisableCoefCalc);
            this.Controls.Add(this.chkEnableStash);
            this.Controls.Add(this.lblFloatParam);
            this.Controls.Add(this.cmbNumFlat);
            this.Controls.Add(this.cmbGroupBy3);
            this.Controls.Add(this.chkGroupBy3);
            this.Controls.Add(this.cmbGroupBy2);
            this.Controls.Add(this.chkGroupBy2);
            this.Controls.Add(this.cmbGroupBy1);
            this.Controls.Add(this.txtbFloatParam);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.lblNumFlat);
            this.Controls.Add(this.trvRooms);
            this.Controls.Add(this.chkGroupBy1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Площади помещений";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkGroupBy1;
        private System.Windows.Forms.TreeView trvRooms;
        private System.Windows.Forms.Label lblNumFlat;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.TextBox txtbFloatParam;
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
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.CheckBox chkUseSysAreaParam;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCoefSettings;
    }
}

