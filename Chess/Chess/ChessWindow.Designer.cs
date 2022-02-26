namespace Chess
{
    partial class Chess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            this.RestartButton = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.PictureBox();
            this.GameState = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WhiteTimer = new System.Windows.Forms.Label();
            this.TimeButton = new System.Windows.Forms.Button();
            this.BlackTimer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Undo)).BeginInit();
            this.Timer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RestartButton
            // 
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RestartButton.Location = new System.Drawing.Point(31, 211);
            this.RestartButton.Margin = new System.Windows.Forms.Padding(2);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(87, 22);
            this.RestartButton.TabIndex = 0;
            this.RestartButton.Text = "Chơi lại";
            this.RestartButton.UseVisualStyleBackColor = true;
            // 
            // Undo
            // 
            this.Undo.Image = global::Chess.Properties.Resources.undoArrrow;
            this.Undo.Location = new System.Drawing.Point(50, 147);
            this.Undo.Margin = new System.Windows.Forms.Padding(2);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(33, 26);
            this.Undo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Undo.TabIndex = 3;
            this.Undo.TabStop = false;
            // 
            // GameState
            // 
            this.GameState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GameState.AutoSize = true;
            this.GameState.BackColor = System.Drawing.Color.Transparent;
            this.GameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameState.ForeColor = System.Drawing.Color.ForestGreen;
            this.GameState.Location = new System.Drawing.Point(11, 179);
            this.GameState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GameState.Name = "GameState";
            this.GameState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GameState.Size = new System.Drawing.Size(31, 18);
            this.GameState.TabIndex = 2;
            this.GameState.Text = ".....!";
            this.GameState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timer
            // 
            this.Timer.BackColor = System.Drawing.Color.Transparent;
            this.Timer.Controls.Add(this.GameState);
            this.Timer.Controls.Add(this.Undo);
            this.Timer.Controls.Add(this.label5);
            this.Timer.Controls.Add(this.label4);
            this.Timer.Controls.Add(this.RestartButton);
            this.Timer.Controls.Add(this.WhiteTimer);
            this.Timer.Controls.Add(this.TimeButton);
            this.Timer.Controls.Add(this.BlackTimer);
            this.Timer.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.Location = new System.Drawing.Point(832, 155);
            this.Timer.Margin = new System.Windows.Forms.Padding(2);
            this.Timer.Name = "Timer";
            this.Timer.Padding = new System.Windows.Forms.Padding(2);
            this.Timer.Size = new System.Drawing.Size(138, 260);
            this.Timer.TabIndex = 3;
            this.Timer.TabStop = false;
            this.Timer.Text = "Menu";
            this.Timer.Enter += new System.EventHandler(this.Timer_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Player 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Player 2:";
            // 
            // WhiteTimer
            // 
            this.WhiteTimer.AutoSize = true;
            this.WhiteTimer.BackColor = System.Drawing.Color.White;
            this.WhiteTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteTimer.Location = new System.Drawing.Point(74, 66);
            this.WhiteTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WhiteTimer.Name = "WhiteTimer";
            this.WhiteTimer.Size = new System.Drawing.Size(44, 18);
            this.WhiteTimer.TabIndex = 2;
            this.WhiteTimer.Text = "00:00";
            // 
            // TimeButton
            // 
            this.TimeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TimeButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeButton.Location = new System.Drawing.Point(31, 104);
            this.TimeButton.Margin = new System.Windows.Forms.Padding(2);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(87, 30);
            this.TimeButton.TabIndex = 1;
            this.TimeButton.Text = "Chơi";
            this.TimeButton.UseVisualStyleBackColor = true;
            // 
            // BlackTimer
            // 
            this.BlackTimer.AutoSize = true;
            this.BlackTimer.BackColor = System.Drawing.Color.White;
            this.BlackTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackTimer.Location = new System.Drawing.Point(74, 31);
            this.BlackTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BlackTimer.Name = "BlackTimer";
            this.BlackTimer.Size = new System.Drawing.Size(44, 18);
            this.BlackTimer.TabIndex = 0;
            this.BlackTimer.Text = "00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(768, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 838);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-54, 799);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(827, 37);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(832, 481);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 251);
            this.listBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(832, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lịch sử nước đi:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(810, -2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(186, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Image = global::Chess.Properties.Resources.Black_King;
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::Chess.Properties.Resources.help;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 841);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1029, 880);
            this.MinimumSize = new System.Drawing.Size(1008, 880);
            this.Name = "Chess";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Chess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Undo)).EndInit();
            this.Timer.ResumeLayout(false);
            this.Timer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RestartButton;
        public System.Windows.Forms.Label GameState;
        private System.Windows.Forms.GroupBox Timer;
        private System.Windows.Forms.Label BlackTimer;
        private System.Windows.Forms.Button TimeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label WhiteTimer;
        private System.Windows.Forms.PictureBox Undo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

