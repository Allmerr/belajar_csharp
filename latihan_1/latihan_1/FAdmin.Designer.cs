
namespace latihan_1
{
    partial class FAdmin
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "navigation ADMIN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome , ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnMember
            // 
            this.btnMember.Location = new System.Drawing.Point(342, 197);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(91, 32);
            this.btnMember.TabIndex = 3;
            this.btnMember.Text = "MEMBER";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(342, 244);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(91, 32);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.Text = "MENU";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(342, 300);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "REPORT";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(342, 351);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(91, 32);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(342, 148);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(91, 32);
            this.btnOrder.TabIndex = 8;
            this.btnOrder.Text = "ORDER";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // FAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnMember);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FAdmin";
            this.Text = "FAdmin";
            this.Load += new System.EventHandler(this.FAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOrder;
    }
}