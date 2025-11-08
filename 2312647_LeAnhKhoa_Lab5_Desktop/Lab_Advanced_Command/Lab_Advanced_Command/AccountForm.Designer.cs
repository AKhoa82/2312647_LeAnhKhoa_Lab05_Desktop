namespace Lab_Advanced_Command
{
    partial class AccountForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.ContextMenuStrip cmsAccountOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmViewRoles;
        private System.Windows.Forms.ToolStripMenuItem tsmViewActivity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.cmsAccountOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmViewRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewActivity = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.cmsAccountOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(20, 15);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(120, 30);
            this.btnAddAccount.TabIndex = 0;
            this.btnAddAccount.Text = "Thêm tài khoản";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Location = new System.Drawing.Point(150, 15);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateAccount.TabIndex = 1;
            this.btnUpdateAccount.Text = "Cập nhật";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(260, 15);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(120, 30);
            this.btnResetPassword.TabIndex = 2;
            this.btnResetPassword.Text = "Reset mật khẩu";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(390, 15);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(110, 30);
            this.btnAddRole.TabIndex = 3;
            this.btnAddRole.Text = "Thêm vai trò";
            this.btnAddRole.UseVisualStyleBackColor = true;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.ContextMenuStrip = this.cmsAccountOptions;
            this.dgvAccounts.Location = new System.Drawing.Point(20, 60);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.RowTemplate.Height = 24;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(760, 360);
            this.dgvAccounts.TabIndex = 4;
            // 
            // cmsAccountOptions
            // 
            this.cmsAccountOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAccountOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmViewRoles,
            this.tsmViewActivity});
            this.cmsAccountOptions.Name = "cmsAccountOptions";
            this.cmsAccountOptions.Size = new System.Drawing.Size(199, 70);
            // 
            // tsmViewRoles
            // 
            this.tsmViewRoles.Name = "tsmViewRoles";
            this.tsmViewRoles.Size = new System.Drawing.Size(198, 22);
            this.tsmViewRoles.Text = "Xem danh sách vai trò";
            this.tsmViewRoles.Click += new System.EventHandler(this.tsmViewRoles_Click);
            // 
            // tsmViewActivity
            // 
            this.tsmViewActivity.Name = "tsmViewActivity";
            this.tsmViewActivity.Size = new System.Drawing.Size(198, 22);
            this.tsmViewActivity.Text = "Xem nhật ký hoạt động";
            this.tsmViewActivity.Click += new System.EventHandler(this.tsmViewActivity_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 440);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnUpdateAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.cmsAccountOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}