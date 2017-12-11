namespace Conversii
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.arithmetic = new System.Windows.Forms.Button();
            this.conversions = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main menu";
            // 
            // arithmetic
            // 
            this.arithmetic.Location = new System.Drawing.Point(43, 55);
            this.arithmetic.Name = "arithmetic";
            this.arithmetic.Size = new System.Drawing.Size(155, 41);
            this.arithmetic.TabIndex = 1;
            this.arithmetic.Text = "Arithmetic operations";
            this.arithmetic.UseVisualStyleBackColor = true;
            this.arithmetic.Click += new System.EventHandler(this.arithmetic_Click);
            // 
            // conversions
            // 
            this.conversions.Location = new System.Drawing.Point(43, 120);
            this.conversions.Name = "conversions";
            this.conversions.Size = new System.Drawing.Size(155, 41);
            this.conversions.TabIndex = 2;
            this.conversions.Text = "Conversions";
            this.conversions.UseVisualStyleBackColor = true;
            this.conversions.Click += new System.EventHandler(this.conversions_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(48, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Made by Sabau Andrei-Mircea";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(239, 229);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.conversions);
            this.Controls.Add(this.arithmetic);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button arithmetic;
        private System.Windows.Forms.Button conversions;
        private System.Windows.Forms.Label label6;
    }
}

