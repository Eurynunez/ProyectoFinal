
namespace ProyectoFinal.Forms
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtContrasena = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.PbUser = new System.Windows.Forms.PictureBox();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.LblContrasena = new System.Windows.Forms.Label();
            this.PbContrasena = new System.Windows.Forms.PictureBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.PbLogin = new System.Windows.Forms.PictureBox();
            this.BtnIniciarSesion = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbUser)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbContrasena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PbLogin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnIniciarSesion, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.51387F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.63263F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.74251F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 901);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.TxtContrasena, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.TxtUsuario, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(163, 341);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.40741F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(740, 270);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtContrasena.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtContrasena.Location = new System.Drawing.Point(3, 204);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.PasswordChar = '•';
            this.TxtContrasena.Size = new System.Drawing.Size(734, 35);
            this.TxtContrasena.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.Controls.Add(this.PbUser, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.LblUsuario, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(734, 68);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // PbUser
            // 
            this.PbUser.BackColor = System.Drawing.Color.White;
            this.PbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbUser.Image = ((System.Drawing.Image)(resources.GetObject("PbUser.Image")));
            this.PbUser.Location = new System.Drawing.Point(3, 3);
            this.PbUser.Name = "PbUser";
            this.PbUser.Size = new System.Drawing.Size(67, 62);
            this.PbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbUser.TabIndex = 0;
            this.PbUser.TabStop = false;
            // 
            // LblUsuario
            // 
            this.LblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Leelawadee UI", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblUsuario.Location = new System.Drawing.Point(76, 19);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(655, 30);
            this.LblUsuario.TabIndex = 1;
            this.LblUsuario.Text = "USUARIO";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.Controls.Add(this.LblContrasena, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.PbContrasena, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 137);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(734, 61);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // LblContrasena
            // 
            this.LblContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblContrasena.AutoSize = true;
            this.LblContrasena.Font = new System.Drawing.Font("Leelawadee UI", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblContrasena.Location = new System.Drawing.Point(76, 15);
            this.LblContrasena.Name = "LblContrasena";
            this.LblContrasena.Size = new System.Drawing.Size(655, 30);
            this.LblContrasena.TabIndex = 2;
            this.LblContrasena.Text = "CONTRASEÑA";
            // 
            // PbContrasena
            // 
            this.PbContrasena.BackColor = System.Drawing.Color.White;
            this.PbContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbContrasena.Image = ((System.Drawing.Image)(resources.GetObject("PbContrasena.Image")));
            this.PbContrasena.Location = new System.Drawing.Point(3, 3);
            this.PbContrasena.Name = "PbContrasena";
            this.PbContrasena.Size = new System.Drawing.Size(67, 55);
            this.PbContrasena.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbContrasena.TabIndex = 0;
            this.PbContrasena.TabStop = false;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUsuario.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtUsuario.Location = new System.Drawing.Point(3, 77);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(734, 35);
            this.TxtUsuario.TabIndex = 2;
            // 
            // PbLogin
            // 
            this.PbLogin.Image = ((System.Drawing.Image)(resources.GetObject("PbLogin.Image")));
            this.PbLogin.Location = new System.Drawing.Point(163, 3);
            this.PbLogin.Name = "PbLogin";
            this.PbLogin.Size = new System.Drawing.Size(740, 332);
            this.PbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbLogin.TabIndex = 1;
            this.PbLogin.TabStop = false;
            // 
            // BtnIniciarSesion
            // 
            this.BtnIniciarSesion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnIniciarSesion.BackColor = System.Drawing.Color.White;
            this.BtnIniciarSesion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnIniciarSesion.BackgroundImage")));
            this.BtnIniciarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIniciarSesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniciarSesion.Font = new System.Drawing.Font("Leelawadee UI", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.BtnIniciarSesion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnIniciarSesion.Location = new System.Drawing.Point(371, 617);
            this.BtnIniciarSesion.Name = "BtnIniciarSesion";
            this.BtnIniciarSesion.Size = new System.Drawing.Size(324, 272);
            this.BtnIniciarSesion.TabIndex = 2;
            this.BtnIniciarSesion.Text = "INICIAR SESIÓN";
            this.BtnIniciarSesion.UseVisualStyleBackColor = false;
            this.BtnIniciarSesion.Click += new System.EventHandler(this.BtnIniciarSesion_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 901);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IsMdiContainer = true;
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbUser)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbContrasena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox PbUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox PbContrasena;
        private System.Windows.Forms.PictureBox PbLogin;
        private System.Windows.Forms.TextBox TxtContrasena;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Label LblContrasena;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Button BtnIniciarSesion;
    }
}

