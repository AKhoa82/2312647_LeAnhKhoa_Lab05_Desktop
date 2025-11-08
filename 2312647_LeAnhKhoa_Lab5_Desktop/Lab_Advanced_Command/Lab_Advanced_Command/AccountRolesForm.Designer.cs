namespace Lab_Advanced_Command
{
    partial class AccountRolesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnUpdateRoles;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAccountName = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnUpdateRoles = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(20, 20);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(130, 17);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "Tài khoản: (chưa có)";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(20, 60);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.RowTemplate.Height = 24;
            this.dgvRoles.Size = new System.Drawing.Size(410, 200);
            this.dgvRoles.TabIndex = 1;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(20, 280);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(110, 30);
            this.btnAddRole.TabIndex = 2;
            this.btnAddRole.Text = "Thêm vai trò";
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnUpdateRoles
            // 
            this.btnUpdateRoles.Location = new System.Drawing.Point(150, 280);
            this.btnUpdateRoles.Name = "btnUpdateRoles";
            this.btnUpdateRoles.Size = new System.Drawing.Size(110, 30);
            this.btnUpdateRoles.TabIndex = 3;
            this.btnUpdateRoles.Text = "Cập nhật";
            this.btnUpdateRoles.Click += new System.EventHandler(this.btnUpdateRoles_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AccountRolesForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 330);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.btnUpdateRoles);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.Name = "AccountRolesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách vai trò được gán";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}