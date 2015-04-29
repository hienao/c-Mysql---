namespace RoomRentSystem
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usertextBox = new System.Windows.Forms.TextBox();
            this.textBoxpwd = new System.Windows.Forms.TextBox();
            this.labelclose = new System.Windows.Forms.Label();
            this.loginbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usertextBox
            // 
            this.usertextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.usertextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usertextBox.Font = new System.Drawing.Font("宋体", 25F);
            this.usertextBox.Location = new System.Drawing.Point(86, 188);
            this.usertextBox.Name = "usertextBox";
            this.usertextBox.Size = new System.Drawing.Size(188, 39);
            this.usertextBox.TabIndex = 0;
            // 
            // textBoxpwd
            // 
            this.textBoxpwd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxpwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxpwd.Font = new System.Drawing.Font("宋体", 25F);
            this.textBoxpwd.Location = new System.Drawing.Point(86, 238);
            this.textBoxpwd.Name = "textBoxpwd";
            this.textBoxpwd.PasswordChar = '*';
            this.textBoxpwd.Size = new System.Drawing.Size(188, 39);
            this.textBoxpwd.TabIndex = 1;
            // 
            // labelclose
            // 
            this.labelclose.AutoSize = true;
            this.labelclose.BackColor = System.Drawing.Color.Transparent;
            this.labelclose.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelclose.ForeColor = System.Drawing.Color.Red;
            this.labelclose.Location = new System.Drawing.Point(278, -8);
            this.labelclose.Name = "labelclose";
            this.labelclose.Size = new System.Drawing.Size(47, 46);
            this.labelclose.TabIndex = 2;
            this.labelclose.Text = "×";
            this.labelclose.Click += new System.EventHandler(this.labelclose_Click);
            // 
            // loginbutton
            // 
            this.loginbutton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.loginbutton.FlatAppearance.BorderSize = 0;
            this.loginbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.loginbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbutton.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginbutton.Location = new System.Drawing.Point(45, 307);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(230, 44);
            this.loginbutton.TabIndex = 4;
            this.loginbutton.Text = "登录";
            this.loginbutton.UseVisualStyleBackColor = false;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.loginbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(320, 468);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.labelclose);
            this.Controls.Add(this.textBoxpwd);
            this.Controls.Add(this.usertextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usertextBox;
        private System.Windows.Forms.TextBox textBoxpwd;
        private System.Windows.Forms.Label labelclose;
        private System.Windows.Forms.Button loginbutton;
    }
}

