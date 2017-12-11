namespace Conversii
{
    partial class Conversions
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
            this.convert = new System.Windows.Forms.Button();
            this.operationType = new System.Windows.Forms.ComboBox();
            this.fromBase = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.tip = new System.Windows.Forms.Label();
            this.toBaseLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fromBaseLabel = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toBase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // convert
            // 
            this.convert.Location = new System.Drawing.Point(136, 294);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(75, 23);
            this.convert.TabIndex = 0;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // operationType
            // 
            this.operationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationType.FormattingEnabled = true;
            this.operationType.Items.AddRange(new object[] {
            "Substitution method",
            "Successive divisions",
            "Rapid conversions"});
            this.operationType.Location = new System.Drawing.Point(6, 44);
            this.operationType.Name = "operationType";
            this.operationType.Size = new System.Drawing.Size(121, 21);
            this.operationType.TabIndex = 1;
            this.operationType.SelectedIndexChanged += new System.EventHandler(this.operationType_SelectedIndexChanged);
            // 
            // fromBase
            // 
            this.fromBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromBase.Enabled = false;
            this.fromBase.FormattingEnabled = true;
            this.fromBase.Location = new System.Drawing.Point(206, 44);
            this.fromBase.Name = "fromBase";
            this.fromBase.Size = new System.Drawing.Size(56, 21);
            this.fromBase.TabIndex = 2;
            this.fromBase.SelectedIndexChanged += new System.EventHandler(this.fromBase_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resultTextBox);
            this.groupBox1.Controls.Add(this.tip);
            this.groupBox1.Controls.Add(this.toBaseLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.toBase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.convert);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.operationType);
            this.groupBox1.Controls.Add(this.fromBase);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 323);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Substitution method | Successive divisions | Rapid conversions ";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Location = new System.Drawing.Point(9, 204);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.resultTextBox.Size = new System.Drawing.Size(333, 88);
            this.resultTextBox.TabIndex = 11;
            this.resultTextBox.Text = "";
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.ForeColor = System.Drawing.Color.Maroon;
            this.tip.Location = new System.Drawing.Point(68, 83);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(0, 13);
            this.tip.TabIndex = 10;
            this.tip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toBaseLabel
            // 
            this.toBaseLabel.AutoSize = true;
            this.toBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toBaseLabel.Location = new System.Drawing.Point(309, 295);
            this.toBaseLabel.Name = "toBaseLabel";
            this.toBaseLabel.Size = new System.Drawing.Size(33, 15);
            this.toBaseLabel.TabIndex = 7;
            this.toBaseLabel.Text = "(16)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(6, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Result:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fromBaseLabel);
            this.groupBox2.Controls.Add(this.inputTextBox);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(9, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 64);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // fromBaseLabel
            // 
            this.fromBaseLabel.AutoSize = true;
            this.fromBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromBaseLabel.Location = new System.Drawing.Point(300, 42);
            this.fromBaseLabel.Name = "fromBaseLabel";
            this.fromBaseLabel.Size = new System.Drawing.Size(0, 15);
            this.fromBaseLabel.TabIndex = 6;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(6, 19);
            this.inputTextBox.MaxLength = 45;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(313, 20);
            this.inputTextBox.TabIndex = 5;
            this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "To base:";
            // 
            // toBase
            // 
            this.toBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toBase.Enabled = false;
            this.toBase.FormattingEnabled = true;
            this.toBase.Location = new System.Drawing.Point(272, 44);
            this.toBase.Name = "toBase";
            this.toBase.Size = new System.Drawing.Size(56, 21);
            this.toBase.TabIndex = 6;
            this.toBase.SelectedIndexChanged += new System.EventHandler(this.toBase_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From base:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Conversion type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Conversions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(216, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Made by Sabau Andrei-Mircea";
            // 
            // Conversions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(378, 400);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Conversions";
            this.Text = "Conversions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convert;
        private System.Windows.Forms.ComboBox operationType;
        private System.Windows.Forms.ComboBox fromBase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox toBase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label fromBaseLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label toBaseLabel;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.Label label6;
    }
}