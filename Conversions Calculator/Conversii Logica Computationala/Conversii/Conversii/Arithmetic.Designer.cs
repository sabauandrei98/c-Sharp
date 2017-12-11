namespace Conversii
{
    partial class Arithmetic
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
            this.compute = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.operationCombo = new System.Windows.Forms.ComboBox();
            this.numar = new System.Windows.Forms.TextBox();
            this.cifra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baseCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.baseLabel = new System.Windows.Forms.Label();
            this.signLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.answer = new System.Windows.Forms.TextBox();
            this.tip = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // compute
            // 
            this.compute.ForeColor = System.Drawing.Color.Navy;
            this.compute.Location = new System.Drawing.Point(113, 313);
            this.compute.Name = "compute";
            this.compute.Size = new System.Drawing.Size(117, 27);
            this.compute.TabIndex = 0;
            this.compute.Text = "Compute";
            this.compute.UseVisualStyleBackColor = true;
            this.compute.Click += new System.EventHandler(this.compute_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(199, 28);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(87, 42);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // operationCombo
            // 
            this.operationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationCombo.FormattingEnabled = true;
            this.operationCombo.Items.AddRange(new object[] {
            "addition",
            "subtraction ",
            "multiplication ",
            "division"});
            this.operationCombo.Location = new System.Drawing.Point(7, 35);
            this.operationCombo.Name = "operationCombo";
            this.operationCombo.Size = new System.Drawing.Size(117, 21);
            this.operationCombo.TabIndex = 2;
            this.operationCombo.SelectedIndexChanged += new System.EventHandler(this.operationCombo_SelectedIndexChanged);
            // 
            // numar
            // 
            this.numar.Location = new System.Drawing.Point(38, 28);
            this.numar.MaxLength = 16;
            this.numar.Name = "numar";
            this.numar.Size = new System.Drawing.Size(138, 20);
            this.numar.TabIndex = 3;
            this.numar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cifra
            // 
            this.cifra.Location = new System.Drawing.Point(155, 54);
            this.cifra.MaxLength = 1;
            this.cifra.Name = "cifra";
            this.cifra.Size = new System.Drawing.Size(21, 20);
            this.cifra.TabIndex = 4;
            this.cifra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Arithmetic operations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Operation:";
            // 
            // baseCombo
            // 
            this.baseCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baseCombo.FormattingEnabled = true;
            this.baseCombo.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "16"});
            this.baseCombo.Location = new System.Drawing.Point(184, 35);
            this.baseCombo.Name = "baseCombo";
            this.baseCombo.Size = new System.Drawing.Size(117, 21);
            this.baseCombo.TabIndex = 7;
            this.baseCombo.SelectedIndexChanged += new System.EventHandler(this.baseCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Base:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.operationCombo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.baseCombo);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(15, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.baseLabel);
            this.groupBox2.Controls.Add(this.signLabel);
            this.groupBox2.Controls.Add(this.clearButton);
            this.groupBox2.Controls.Add(this.numar);
            this.groupBox2.Controls.Add(this.cifra);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(15, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 92);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(108, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Digit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "N:";
            // 
            // baseLabel
            // 
            this.baseLabel.AutoSize = true;
            this.baseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel.Location = new System.Drawing.Point(179, 71);
            this.baseLabel.Name = "baseLabel";
            this.baseLabel.Size = new System.Drawing.Size(0, 13);
            this.baseLabel.TabIndex = 8;
            // 
            // signLabel
            // 
            this.signLabel.AutoSize = true;
            this.signLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signLabel.Location = new System.Drawing.Point(179, 28);
            this.signLabel.Name = "signLabel";
            this.signLabel.Size = new System.Drawing.Size(0, 20);
            this.signLabel.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(19, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Result:";
            // 
            // answer
            // 
            this.answer.Enabled = false;
            this.answer.Location = new System.Drawing.Point(65, 287);
            this.answer.Name = "answer";
            this.answer.ReadOnly = true;
            this.answer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.answer.Size = new System.Drawing.Size(210, 20);
            this.answer.TabIndex = 6;
            this.answer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tip.Location = new System.Drawing.Point(69, 139);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(0, 13);
            this.tip.TabIndex = 11;
            this.tip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(172, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Made by Sabau Andrei-Mircea";
            // 
            // Arithmetic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(334, 375);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compute);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Arithmetic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arithmetic";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compute;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ComboBox operationCombo;
        private System.Windows.Forms.TextBox numar;
        private System.Windows.Forms.TextBox cifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baseCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label signLabel;
        private System.Windows.Forms.TextBox answer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label baseLabel;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}