namespace Chat
{
    partial class Chat
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
            this.lb_chat = new System.Windows.Forms.ListBox();
            this.lb_title = new System.Windows.Forms.Label();
            this.tb_mensagem = new System.Windows.Forms.TextBox();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_logged_as = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_chat
            // 
            this.lb_chat.FormattingEnabled = true;
            this.lb_chat.Location = new System.Drawing.Point(9, 50);
            this.lb_chat.Margin = new System.Windows.Forms.Padding(2);
            this.lb_chat.Name = "lb_chat";
            this.lb_chat.Size = new System.Drawing.Size(390, 381);
            this.lb_chat.TabIndex = 1;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Monotype Corsiva", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.Location = new System.Drawing.Point(9, 5);
            this.lb_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(139, 43);
            this.lb_title.TabIndex = 2;
            this.lb_title.Text = "The Chat";
            // 
            // tb_mensagem
            // 
            this.tb_mensagem.Location = new System.Drawing.Point(9, 442);
            this.tb_mensagem.Margin = new System.Windows.Forms.Padding(2);
            this.tb_mensagem.Multiline = true;
            this.tb_mensagem.Name = "tb_mensagem";
            this.tb_mensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_mensagem.Size = new System.Drawing.Size(390, 53);
            this.tb_mensagem.TabIndex = 3;
            this.tb_mensagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_KeyDown);
            // 
            // lb_username
            // 
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(262, 27);
            this.lb_username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(125, 21);
            this.lb_username.TabIndex = 4;
            this.lb_username.Text = "guest";
            this.lb_username.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_logged_as
            // 
            this.lb_logged_as.AutoSize = true;
            this.lb_logged_as.Location = new System.Drawing.Point(286, 7);
            this.lb_logged_as.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_logged_as.Name = "lb_logged_as";
            this.lb_logged_as.Size = new System.Drawing.Size(100, 13);
            this.lb_logged_as.TabIndex = 5;
            this.lb_logged_as.Text = "You\'re logged in as:";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 509);
            this.Controls.Add(this.lb_logged_as);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.tb_mensagem);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.lb_chat);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(423, 548);
            this.MinimumSize = new System.Drawing.Size(423, 548);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lb_chat;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.TextBox tb_mensagem;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_logged_as;
    }
}

