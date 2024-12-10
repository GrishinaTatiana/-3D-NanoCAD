namespace RoomAreaPlugin
{
    partial class CoefficientResultOutputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOk = new Button();
            cmbAreaCoef = new ComboBox();
            lblAreaCoef = new Label();
            cmbAreaWithCoef = new ComboBox();
            lblAreaWithCoef = new Label();
            cmbFlatArea = new ComboBox();
            lblFlatArea = new Label();
            cmbLiveFlatArea = new ComboBox();
            lblLiveFlatArea = new Label();
            cmbFlatAreaWtBalcAndLogWoCoeff = new ComboBox();
            lblFlatAreaWtBalcAndLogWoCoeff = new Label();
            cmbGeneralFlatArea = new ComboBox();
            lblGeneralFlatArea = new Label();
            cmbFlatCount = new ComboBox();
            lblFlatCount = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(57, 355);
            btnOk.Margin = new Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(115, 33);
            btnOk.TabIndex = 29;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // cmbAreaCoef
            // 
            cmbAreaCoef.FormattingEnabled = true;
            cmbAreaCoef.Location = new Point(18, 29);
            cmbAreaCoef.Margin = new Padding(4, 3, 4, 3);
            cmbAreaCoef.Name = "cmbAreaCoef";
            cmbAreaCoef.Size = new Size(196, 23);
            cmbAreaCoef.TabIndex = 33;
            cmbAreaCoef.SelectedIndexChanged += cmbAreaCoef_SelectedIndexChanged;
            // 
            // lblAreaCoef
            // 
            lblAreaCoef.AutoSize = true;
            lblAreaCoef.Location = new Point(14, 10);
            lblAreaCoef.Margin = new Padding(4, 0, 4, 0);
            lblAreaCoef.Name = "lblAreaCoef";
            lblAreaCoef.Size = new Size(138, 15);
            lblAreaCoef.TabIndex = 32;
            lblAreaCoef.Text = "Коэффициент площади";
            lblAreaCoef.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbAreaWithCoef
            // 
            cmbAreaWithCoef.FormattingEnabled = true;
            cmbAreaWithCoef.Location = new Point(18, 75);
            cmbAreaWithCoef.Margin = new Padding(4, 3, 4, 3);
            cmbAreaWithCoef.Name = "cmbAreaWithCoef";
            cmbAreaWithCoef.Size = new Size(196, 23);
            cmbAreaWithCoef.TabIndex = 35;
            cmbAreaWithCoef.SelectedIndexChanged += cmbAreaWithCoef_SelectedIndexChanged;
            // 
            // lblAreaWithCoef
            // 
            lblAreaWithCoef.AutoSize = true;
            lblAreaWithCoef.Location = new Point(14, 57);
            lblAreaWithCoef.Margin = new Padding(4, 0, 4, 0);
            lblAreaWithCoef.Name = "lblAreaWithCoef";
            lblAreaWithCoef.Size = new Size(163, 15);
            lblAreaWithCoef.TabIndex = 34;
            lblAreaWithCoef.Text = "Площадь с коэффициентом";
            lblAreaWithCoef.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbFlatArea
            // 
            cmbFlatArea.FormattingEnabled = true;
            cmbFlatArea.Location = new Point(18, 167);
            cmbFlatArea.Margin = new Padding(4, 3, 4, 3);
            cmbFlatArea.Name = "cmbFlatArea";
            cmbFlatArea.Size = new Size(196, 23);
            cmbFlatArea.TabIndex = 39;
            cmbFlatArea.SelectedIndexChanged += cmbFlatArea_SelectedIndexChanged;
            // 
            // lblFlatArea
            // 
            lblFlatArea.AutoSize = true;
            lblFlatArea.Location = new Point(14, 149);
            lblFlatArea.Margin = new Padding(4, 0, 4, 0);
            lblFlatArea.Name = "lblFlatArea";
            lblFlatArea.Size = new Size(115, 15);
            lblFlatArea.TabIndex = 38;
            lblFlatArea.Text = "Площадь квартиры";
            lblFlatArea.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbLiveFlatArea
            // 
            cmbLiveFlatArea.FormattingEnabled = true;
            cmbLiveFlatArea.Location = new Point(18, 121);
            cmbLiveFlatArea.Margin = new Padding(4, 3, 4, 3);
            cmbLiveFlatArea.Name = "cmbLiveFlatArea";
            cmbLiveFlatArea.Size = new Size(196, 23);
            cmbLiveFlatArea.TabIndex = 37;
            cmbLiveFlatArea.SelectedIndexChanged += cmbLiveFlatArea_SelectedIndexChanged;
            // 
            // lblLiveFlatArea
            // 
            lblLiveFlatArea.AutoSize = true;
            lblLiveFlatArea.Location = new Point(14, 103);
            lblLiveFlatArea.Margin = new Padding(4, 0, 4, 0);
            lblLiveFlatArea.Name = "lblLiveFlatArea";
            lblLiveFlatArea.Size = new Size(153, 15);
            lblLiveFlatArea.TabIndex = 36;
            lblLiveFlatArea.Text = "Площадь квартиры жилая";
            lblLiveFlatArea.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbFlatAreaWtBalcAndLogWoCoeff
            // 
            cmbFlatAreaWtBalcAndLogWoCoeff.FormattingEnabled = true;
            cmbFlatAreaWtBalcAndLogWoCoeff.Location = new Point(18, 278);
            cmbFlatAreaWtBalcAndLogWoCoeff.Margin = new Padding(4, 3, 4, 3);
            cmbFlatAreaWtBalcAndLogWoCoeff.Name = "cmbFlatAreaWtBalcAndLogWoCoeff";
            cmbFlatAreaWtBalcAndLogWoCoeff.Size = new Size(196, 23);
            cmbFlatAreaWtBalcAndLogWoCoeff.TabIndex = 43;
            cmbFlatAreaWtBalcAndLogWoCoeff.SelectedIndexChanged += cmbFlatAreaWtBalcAndLogWoCoeff_SelectedIndexChanged;
            // 
            // lblFlatAreaWtBalcAndLogWoCoeff
            // 
            lblFlatAreaWtBalcAndLogWoCoeff.Location = new Point(14, 241);
            lblFlatAreaWtBalcAndLogWoCoeff.Margin = new Padding(4, 0, 4, 0);
            lblFlatAreaWtBalcAndLogWoCoeff.Name = "lblFlatAreaWtBalcAndLogWoCoeff";
            lblFlatAreaWtBalcAndLogWoCoeff.Size = new Size(201, 33);
            lblFlatAreaWtBalcAndLogWoCoeff.TabIndex = 42;
            lblFlatAreaWtBalcAndLogWoCoeff.Text = "Площадь квартиры с лоджией и балконом без коэффициентов";
            lblFlatAreaWtBalcAndLogWoCoeff.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbGeneralFlatArea
            // 
            cmbGeneralFlatArea.FormattingEnabled = true;
            cmbGeneralFlatArea.Location = new Point(18, 213);
            cmbGeneralFlatArea.Margin = new Padding(4, 3, 4, 3);
            cmbGeneralFlatArea.Name = "cmbGeneralFlatArea";
            cmbGeneralFlatArea.Size = new Size(196, 23);
            cmbGeneralFlatArea.TabIndex = 41;
            cmbGeneralFlatArea.SelectedIndexChanged += cmbGeneralFlatArea_SelectedIndexChanged;
            // 
            // lblGeneralFlatArea
            // 
            lblGeneralFlatArea.AutoSize = true;
            lblGeneralFlatArea.Location = new Point(14, 195);
            lblGeneralFlatArea.Margin = new Padding(4, 0, 4, 0);
            lblGeneralFlatArea.Name = "lblGeneralFlatArea";
            lblGeneralFlatArea.Size = new Size(155, 15);
            lblGeneralFlatArea.TabIndex = 40;
            lblGeneralFlatArea.Text = "Площадь квартиры общая";
            lblGeneralFlatArea.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbFlatCount
            // 
            cmbFlatCount.FormattingEnabled = true;
            cmbFlatCount.Location = new Point(18, 324);
            cmbFlatCount.Margin = new Padding(4, 3, 4, 3);
            cmbFlatCount.Name = "cmbFlatCount";
            cmbFlatCount.Size = new Size(196, 23);
            cmbFlatCount.TabIndex = 45;
            cmbFlatCount.SelectedIndexChanged += cmbFlatCount_SelectedIndexChanged;
            // 
            // lblFlatCount
            // 
            lblFlatCount.AutoSize = true;
            lblFlatCount.Location = new Point(14, 306);
            lblFlatCount.Margin = new Padding(4, 0, 4, 0);
            lblFlatCount.Name = "lblFlatCount";
            lblFlatCount.Size = new Size(85, 15);
            lblFlatCount.TabIndex = 44;
            lblFlatCount.Text = "Число комнат";
            lblFlatCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CoefficientResultOutputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 403);
            Controls.Add(cmbFlatCount);
            Controls.Add(lblFlatCount);
            Controls.Add(cmbFlatAreaWtBalcAndLogWoCoeff);
            Controls.Add(lblFlatAreaWtBalcAndLogWoCoeff);
            Controls.Add(cmbGeneralFlatArea);
            Controls.Add(lblGeneralFlatArea);
            Controls.Add(cmbFlatArea);
            Controls.Add(lblFlatArea);
            Controls.Add(cmbLiveFlatArea);
            Controls.Add(lblLiveFlatArea);
            Controls.Add(cmbAreaWithCoef);
            Controls.Add(lblAreaWithCoef);
            Controls.Add(cmbAreaCoef);
            Controls.Add(lblAreaCoef);
            Controls.Add(btnOk);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CoefficientResultOutputForm";
            Text = "Сохранить в...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbAreaCoef;
        private System.Windows.Forms.Label lblAreaCoef;
        private System.Windows.Forms.ComboBox cmbAreaWithCoef;
        private System.Windows.Forms.Label lblAreaWithCoef;
        private System.Windows.Forms.ComboBox cmbFlatArea;
        private System.Windows.Forms.Label lblFlatArea;
        private System.Windows.Forms.ComboBox cmbLiveFlatArea;
        private System.Windows.Forms.Label lblLiveFlatArea;
        private System.Windows.Forms.ComboBox cmbFlatAreaWtBalcAndLogWoCoeff;
        private System.Windows.Forms.Label lblFlatAreaWtBalcAndLogWoCoeff;
        private System.Windows.Forms.ComboBox cmbGeneralFlatArea;
        private System.Windows.Forms.Label lblGeneralFlatArea;
        private System.Windows.Forms.ComboBox cmbFlatCount;
        private System.Windows.Forms.Label lblFlatCount;
    }
}