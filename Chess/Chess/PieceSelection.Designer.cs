namespace Chess
{
    partial class PieceSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PieceSelection));
            this.RightArrow = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftArrow = new System.Windows.Forms.Button();
            this.Preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // RightArrow
            // 
            this.RightArrow.BackColor = System.Drawing.Color.LightSalmon;
            this.RightArrow.Location = new System.Drawing.Point(232, 149);
            this.RightArrow.Margin = new System.Windows.Forms.Padding(2);
            this.RightArrow.Name = "RightArrow";
            this.RightArrow.Size = new System.Drawing.Size(46, 31);
            this.RightArrow.TabIndex = 1;
            this.RightArrow.Text = ">>";
            this.RightArrow.UseVisualStyleBackColor = false;
            // 
            // ApplyButton
            // 
            this.ApplyButton.BackColor = System.Drawing.Color.LightSalmon;
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.Location = new System.Drawing.Point(118, 253);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(2);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(72, 29);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Xác nhận!";
            this.ApplyButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(104, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Phong cấp Tốt!";
            // 
            // LeftArrow
            // 
            this.LeftArrow.BackColor = System.Drawing.Color.LightSalmon;
            this.LeftArrow.Location = new System.Drawing.Point(29, 149);
            this.LeftArrow.Margin = new System.Windows.Forms.Padding(2);
            this.LeftArrow.Name = "LeftArrow";
            this.LeftArrow.Size = new System.Drawing.Size(46, 31);
            this.LeftArrow.TabIndex = 5;
            this.LeftArrow.Text = "<<";
            this.LeftArrow.UseVisualStyleBackColor = false;
            // 
            // Preview
            // 
            this.Preview.Location = new System.Drawing.Point(107, 97);
            this.Preview.Margin = new System.Windows.Forms.Padding(2);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(97, 104);
            this.Preview.TabIndex = 2;
            this.Preview.TabStop = false;
            // 
            // PieceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(331, 350);
            this.Controls.Add(this.LeftArrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.RightArrow);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(347, 389);
            this.MinimumSize = new System.Drawing.Size(347, 389);
            this.Name = "PieceSelection";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RightArrow;
        private System.Windows.Forms.PictureBox Preview;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LeftArrow;
    }
}