
namespace smk_restaurant
{
    partial class FHead
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
            this.btnBack = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtNamePembeli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnPilih = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Fira Code", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 40);
            this.label1.TabIndex = 10;
            this.label1.Text = "Form Pilih Pembeli";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Fira Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 403);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 35);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(62, 97);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(696, 150);
            this.dgv.TabIndex = 12;
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(554, 52);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(118, 20);
            this.txtQty.TabIndex = 16;
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Fira Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.Location = new System.Drawing.Point(678, 49);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(107, 26);
            this.btnCari.TabIndex = 17;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            // 
            // txtNamePembeli
            // 
            this.txtNamePembeli.Location = new System.Drawing.Point(423, 277);
            this.txtNamePembeli.Name = "txtNamePembeli";
            this.txtNamePembeli.Size = new System.Drawing.Size(118, 20);
            this.txtNamePembeli.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Fira Code", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name Pembeli :";
            // 
            // btnBatal
            // 
            this.btnBatal.Font = new System.Drawing.Font("Fira Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Location = new System.Drawing.Point(282, 326);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(107, 35);
            this.btnBatal.TabIndex = 20;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // btnPilih
            // 
            this.btnPilih.Font = new System.Drawing.Font("Fira Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilih.Location = new System.Drawing.Point(413, 326);
            this.btnPilih.Name = "btnPilih";
            this.btnPilih.Size = new System.Drawing.Size(107, 35);
            this.btnPilih.TabIndex = 21;
            this.btnPilih.Text = "Pilih";
            this.btnPilih.UseVisualStyleBackColor = true;
            this.btnPilih.Click += new System.EventHandler(this.btnPilih_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(423, 277);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(118, 20);
            this.txtId.TabIndex = 22;
            // 
            // FHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnPilih);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.txtNamePembeli);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Name = "FHead";
            this.Text = "FHead";
            this.Load += new System.EventHandler(this.FHead_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtNamePembeli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnPilih;
        private System.Windows.Forms.TextBox txtId;
    }
}