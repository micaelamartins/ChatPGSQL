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
        string conn = "Server=192.168.1.202;port=5432;Database=chat;UserID=postgres;Password=mica";
        public Login()
        {
            InitializeComponent();
            textbox_password.UseSystemPasswordChar = true;

        }

      
        private void Login_Load(object sender, EventArgs e)
        {

           


        }



        private void button_registo_Click(object sender, EventArgs e)
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

            DataTable dt = new DataTable();
            NpgsqlConnection con = new NpgsqlConnection(conn);
            con.Open();
            String all_users = "SELECT *  FROM users";
            NpgsqlCommand cmd = new NpgsqlCommand(all_users, con);
            dt.Load(cmd.ExecuteReader());
            List<DataRow> drList = dt.AsEnumerable().ToList();

            try
            {
                bool cont = true;



                foreach (DataRow str in drList)
                {
                    if (str.ItemArray[0].ToString().Equals(textbox_username.Text))
                    {
                        cont = false;
                        MessageBox.Show("Ja existe o Username");
                    }

                }

                if (cont == true)
                {
                    string sql1 = "INSERT INTO users(username, password) VALUES ('" + username.ToString() + "','" + result.ToString() + "')";
                    NpgsqlCommand cmdo = new NpgsqlCommand(sql1, con);

                    //dbcmd.CommandText = sql1;

                    cmdo.ExecuteNonQuery();
                    lb_alert.Text = "Registo Efetuado com Sucesso!";
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }

         
           
        }


        private void button_entrar_Click(object sender, EventArgs e)
        {
            string username = textbox_username.Text;
            string password = textbox_password.Text;


            byte[] hash;
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] hashdata = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = hashdata;
            }

            DataTable dt = new DataTable();
           
            string result = System.Text.Encoding.UTF8.GetString(hash);
            NpgsqlConnection con = new NpgsqlConnection(conn);

           
            con.Open();
            String all_users = "SELECT *  FROM users";
            bool cont = false;

            NpgsqlCommand cmd = new NpgsqlCommand(all_users, con);
            dt.Load(cmd.ExecuteReader());
            List<DataRow> drList = dt.AsEnumerable().ToList();
            foreach(DataRow str in drList)
            {
                if (str.ItemArray[0].ToString().Equals(textbox_username.Text) && str.ItemArray[1].Equals(result))
                {
                    cont = true;
                    Chat ga = new Chat(textbox_username.Text);
                    this.Hide();
                    ga.ShowDialog();
                    this.Close();
                    break;
                }
                
            }
            if (cont== false)
            {
                MessageBox.Show("Dados incorretos ou não está Registado!");
            }

            con.Close();
        }
    }
}







