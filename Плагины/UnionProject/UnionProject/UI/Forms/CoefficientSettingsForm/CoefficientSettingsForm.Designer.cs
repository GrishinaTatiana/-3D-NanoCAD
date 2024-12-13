namespace RoomAreaPlugin
{
    partial class CoefficientSettingsForm
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
            lblResidential = new Label();
            txtbResidential = new TextBox();
            lblPublicSpaces = new Label();
            txtbPublicSpaces = new TextBox();
            lblNonResidential = new Label();
            txtbNonResidential = new TextBox();
            lblLoggias = new Label();
            txtbLoggias = new TextBox();
            lblBalconies = new Label();
            txtbBalconies = new TextBox();
            lblOffices = new Label();
            txtbOffices = new TextBox();
            lblWarmLoggias = new Label();
            txtbWarmLoggias = new TextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(293, 220);
            btnOk.Margin = new Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(115, 33);
            btnOk.TabIndex = 29;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblResidential
            // 
            lblResidential.AutoSize = true;
            lblResidential.Location = new Point(14, 10);
            lblResidential.Margin = new Padding(4, 0, 4, 0);
            lblResidential.Name = "lblResidential";
            lblResidential.Size = new Size(172, 15);
            lblResidential.TabIndex = 33;
            lblResidential.Text = "Жилые помещения квартиры";
            // 
            // txtbResidential
            // 
            txtbResidential.Location = new Point(293, 10);
            txtbResidential.Margin = new Padding(4, 3, 4, 3);
            txtbResidential.Name = "txtbResidential";
            txtbResidential.Size = new Size(115, 23);
            txtbResidential.TabIndex = 32;
            txtbResidential.Text = "1.0";
            txtbResidential.TextChanged += txtbResidential_TextChanged;
            // 
            // lblPublicSpaces
            // 
            lblPublicSpaces.AutoSize = true;
            lblPublicSpaces.Location = new Point(14, 134);
            lblPublicSpaces.Margin = new Padding(4, 0, 4, 0);
            lblPublicSpaces.Name = "lblPublicSpaces";
            lblPublicSpaces.Size = new Size(258, 15);
            lblPublicSpaces.TabIndex = 35;
            lblPublicSpaces.Text = "Нежилые помещения, общественные (МОП)";
            // 
            // txtbPublicSpaces
            // 
            txtbPublicSpaces.Location = new Point(293, 130);
            txtbPublicSpaces.Margin = new Padding(4, 3, 4, 3);
            txtbPublicSpaces.Name = "txtbPublicSpaces";
            txtbPublicSpaces.Size = new Size(115, 23);
            txtbPublicSpaces.TabIndex = 34;
            txtbPublicSpaces.Text = "1.0";
            // 
            // lblNonResidential
            // 
            lblNonResidential.AutoSize = true;
            lblNonResidential.Location = new Point(14, 40);
            lblNonResidential.Margin = new Padding(4, 0, 4, 0);
            lblNonResidential.Name = "lblNonResidential";
            lblNonResidential.Size = new Size(185, 15);
            lblNonResidential.TabIndex = 37;
            lblNonResidential.Text = "Нежилые помещения квартиры";
            // 
            // txtbNonResidential
            // 
            txtbNonResidential.Location = new Point(293, 40);
            txtbNonResidential.Margin = new Padding(4, 3, 4, 3);
            txtbNonResidential.Name = "txtbNonResidential";
            txtbNonResidential.Size = new Size(115, 23);
            txtbNonResidential.TabIndex = 36;
            txtbNonResidential.Text = "1.0";
            // 
            // lblLoggias
            // 
            lblLoggias.AutoSize = true;
            lblLoggias.Location = new Point(14, 70);
            lblLoggias.Margin = new Padding(4, 0, 4, 0);
            lblLoggias.Name = "lblLoggias";
            lblLoggias.Size = new Size(51, 15);
            lblLoggias.TabIndex = 39;
            lblLoggias.Text = "Лоджии";
            // 
            // txtbLoggias
            // 
            txtbLoggias.Location = new Point(293, 70);
            txtbLoggias.Margin = new Padding(4, 3, 4, 3);
            txtbLoggias.Name = "txtbLoggias";
            txtbLoggias.Size = new Size(115, 23);
            txtbLoggias.TabIndex = 38;
            txtbLoggias.Text = "0.5";
            // 
            // lblBalconies
            // 
            lblBalconies.AutoSize = true;
            lblBalconies.Location = new Point(14, 100);
            lblBalconies.Margin = new Padding(4, 0, 4, 0);
            lblBalconies.Name = "lblBalconies";
            lblBalconies.Size = new Size(109, 15);
            lblBalconies.TabIndex = 41;
            lblBalconies.Text = "Балконы, Террасы";
            // 
            // txtbBalconies
            // 
            txtbBalconies.Location = new Point(293, 100);
            txtbBalconies.Margin = new Padding(4, 3, 4, 3);
            txtbBalconies.Name = "txtbBalconies";
            txtbBalconies.Size = new Size(115, 23);
            txtbBalconies.TabIndex = 40;
            txtbBalconies.Text = "0.3";
            // 
            // lblOffices
            // 
            lblOffices.AutoSize = true;
            lblOffices.Location = new Point(14, 164);
            lblOffices.Margin = new Padding(4, 0, 4, 0);
            lblOffices.Name = "lblOffices";
            lblOffices.Size = new Size(47, 15);
            lblOffices.TabIndex = 43;
            lblOffices.Text = "Офисы";
            // 
            // txtbOffices
            // 
            txtbOffices.Location = new Point(293, 160);
            txtbOffices.Margin = new Padding(4, 3, 4, 3);
            txtbOffices.Name = "txtbOffices";
            txtbOffices.Size = new Size(115, 23);
            txtbOffices.TabIndex = 42;
            txtbOffices.Text = "1.0";
            // 
            // lblWarmLoggias
            // 
            lblWarmLoggias.AutoSize = true;
            lblWarmLoggias.Location = new Point(14, 194);
            lblWarmLoggias.Margin = new Padding(4, 0, 4, 0);
            lblWarmLoggias.Name = "lblWarmLoggias";
            lblWarmLoggias.Size = new Size(94, 15);
            lblWarmLoggias.TabIndex = 45;
            lblWarmLoggias.Text = "Тёплые лоджии";
            // 
            // txtbWarmLoggias
            // 
            txtbWarmLoggias.Location = new Point(293, 190);
            txtbWarmLoggias.Margin = new Padding(4, 3, 4, 3);
            txtbWarmLoggias.Name = "txtbWarmLoggias";
            txtbWarmLoggias.Size = new Size(115, 23);
            txtbWarmLoggias.TabIndex = 44;
            txtbWarmLoggias.Text = "1.0";
            // 
            // CoefficientSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(422, 268);
            Controls.Add(lblWarmLoggias);
            Controls.Add(txtbWarmLoggias);
            Controls.Add(lblOffices);
            Controls.Add(txtbOffices);
            Controls.Add(lblBalconies);
            Controls.Add(txtbBalconies);
            Controls.Add(lblLoggias);
            Controls.Add(txtbLoggias);
            Controls.Add(lblNonResidential);
            Controls.Add(txtbNonResidential);
            Controls.Add(lblPublicSpaces);
            Controls.Add(txtbPublicSpaces);
            Controls.Add(lblResidential);
            Controls.Add(txtbResidential);
            Controls.Add(btnOk);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CoefficientSettingsForm";
            Text = "Настройка коэффициента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblResidential;
        private System.Windows.Forms.TextBox txtbResidential;
        private System.Windows.Forms.Label lblPublicSpaces;
        private System.Windows.Forms.TextBox txtbPublicSpaces;
        private System.Windows.Forms.Label lblNonResidential;
        private System.Windows.Forms.TextBox txtbNonResidential;
        private System.Windows.Forms.Label lblLoggias;
        private System.Windows.Forms.TextBox txtbLoggias;
        private System.Windows.Forms.Label lblBalconies;
        private System.Windows.Forms.TextBox txtbBalconies;
        private System.Windows.Forms.Label lblOffices;
        private System.Windows.Forms.TextBox txtbOffices;
        private System.Windows.Forms.Label lblWarmLoggias;
        private System.Windows.Forms.TextBox txtbWarmLoggias;
    }
}