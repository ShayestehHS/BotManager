
namespace Accounting_App_
{
    partial class frmMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbNight = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pcImage = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnNewTransi = new System.Windows.Forms.ToolStripButton();
            this.btnIncome = new System.Windows.Forms.ToolStripButton();
            this.btnOutcome = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblOutcome = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Info;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnNewTransi,
            this.btnIncome,
            this.btnOutcome});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(782, 70);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Transaction of this month";
            // 
            // cbNight
            // 
            this.cbNight.AutoSize = true;
            this.cbNight.BackColor = System.Drawing.SystemColors.Info;
            this.cbNight.Location = new System.Drawing.Point(618, 56);
            this.cbNight.Name = "cbNight";
            this.cbNight.Size = new System.Drawing.Size(113, 25);
            this.cbNight.TabIndex = 1;
            this.cbNight.Text = "Dark mode";
            this.cbNight.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 26);
            this.toolStripMenuItem1.Text = "Setting";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.settingToolStripMenuItem.Text = "Change login ID";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOutcome);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.lblIncome);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(411, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 200);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction of this month";
            // 
            // pcImage
            // 
            this.pcImage.Image = global::Accounting_App_.Properties.Resources.Untitled_1;
            this.pcImage.InitialImage = null;
            this.pcImage.Location = new System.Drawing.Point(0, 337);
            this.pcImage.Name = "pcImage";
            this.pcImage.Size = new System.Drawing.Size(277, 277);
            this.pcImage.TabIndex = 4;
            this.pcImage.TabStop = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::Accounting_App_.Properties.Resources._1371476468_preferences_contact_list;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(123, 67);
            this.toolStripButton1.Text = "Managements";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnNewTransi
            // 
            this.btnNewTransi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransi.Image = global::Accounting_App_.Properties.Resources._1371476499_todo_list;
            this.btnNewTransi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNewTransi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTransi.Name = "btnNewTransi";
            this.btnNewTransi.Size = new System.Drawing.Size(138, 67);
            this.btnNewTransi.Text = "New transaction";
            this.btnNewTransi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewTransi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewTransi.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnIncome
            // 
            this.btnIncome.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.Image = global::Accounting_App_.Properties.Resources.servicesCosts;
            this.btnIncome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIncome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(130, 67);
            this.btnIncome.Text = "Income reports";
            this.btnIncome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnOutcome
            // 
            this.btnOutcome.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutcome.Image = global::Accounting_App_.Properties.Resources._1370791030_credit_card;
            this.btnOutcome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOutcome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutcome.Name = "btnOutcome";
            this.btnOutcome.Size = new System.Drawing.Size(144, 67);
            this.btnOutcome.Text = "Outcome reports";
            this.btnOutcome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOutcome.Click += new System.EventHandler(this.btnOutcome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 84);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Outcome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Income:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 121);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Balance:";
            // 
            // lblIncome
            // 
            this.lblIncome.Location = new System.Drawing.Point(117, 46);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(237, 21);
            this.lblIncome.TabIndex = 3;
            this.lblIncome.Text = "0";
            // 
            // lblBalance
            // 
            this.lblBalance.Location = new System.Drawing.Point(117, 121);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(237, 21);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.Text = "0";
            // 
            // lblOutcome
            // 
            this.lblOutcome.Location = new System.Drawing.Point(117, 84);
            this.lblOutcome.Name = "lblOutcome";
            this.lblOutcome.Size = new System.Drawing.Size(237, 21);
            this.lblOutcome.TabIndex = 8;
            this.lblOutcome.Text = "0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.pcImage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbNight);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal Accountant";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnNewTransi;
        private System.Windows.Forms.ToolStripButton btnIncome;
        private System.Windows.Forms.ToolStripButton btnOutcome;
        private System.Windows.Forms.CheckBox cbNight;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pcImage;
        private System.Windows.Forms.Label lblOutcome;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}