using Npgsql;
using RethinkDb.Driver;
using RethinkDb.Driver.Net.Clustering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            textbox_password.UseSystemPasswordChar = true;

        }

  /*      //Login
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textbox_username.Text;
            string password = textbox_password.Text;

            byte[] hash;
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] hashdata = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = hashdata;
            }

            string result = System.Text.Encoding.UTF8.GetString(hash);

            try {
                List<Users> all_users = r.Db("chat").Table("users").OrderBy("Username").Run<List<Users>>(pool);
                bool cont = false;

                foreach (var us in all_users)
                {
                    string use = us.Username;
                    string pwd = us.Password;
                    if (use.ToString().Equals(textbox_username.Text) && pwd.ToString().Equals(result))
                    {
                        cont = true;
                        Chat ga = new Chat(textbox_username.Text);
                        this.Hide();
                        ga.ShowDialog();
                        this.Close();
                        break;
                    }

                }
                if (cont == false)
                {
                    MessageBox.Show("Dados incorretos ou não está Registado!");
                }
            }
            catch(Exception ex)
            {
                Login_Load(sender, e);
            }
            
        }*/

        private void Login_Load(object sender, EventArgs e)
        {

            





        }



        private void button_registo_Click(object sender, EventArgs e)
        {

            string conn = "Server=192.168.1.202;port=5432;Database=chat;UserID=postgres;Password=mica";

            NpgsqlConnection dbcon = new NpgsqlConnection(conn);
            
           dbcon.Open();

           // NpgsqlCommand dbcmd = dbcon.CreateCommand();

            string username = textbox_username.Text;
            string password = textbox_password.Text;

            byte[] hash;
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] hashdata = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = hashdata;
            }
            string result = System.Text.Encoding.UTF8.GetString(hash);

           
            

                string sql1 = "INSERT INTO users(id,username, password) VALUES (1,'" + username.ToString() + "','" + password.ToString() + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(sql1, dbcon);

                  //dbcmd.CommandText = sql1;
          
           cmd.ExecuteNonQuery();
            

           

           
        }
    }
}







