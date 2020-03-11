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
        public string conn;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            getConnectionString();
            textbox_password.UseSystemPasswordChar = true;
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
            bool connectionWorks = getConnectionString();
            if (connectionWorks == true)
            {
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
            bool connectionWorks = getConnectionString();
            if (connectionWorks == true)
            {
                string result = System.Text.Encoding.UTF8.GetString(hash);
                NpgsqlConnection con = new NpgsqlConnection(conn);


                con.Open();
                String all_users = "SELECT *  FROM users";
                bool cont = false;

                NpgsqlCommand cmd = new NpgsqlCommand(all_users, con);
                dt.Load(cmd.ExecuteReader());
                List<DataRow> drList = dt.AsEnumerable().ToList();
                foreach (DataRow str in drList)
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
                if (cont == false)
                {
                    MessageBox.Show("Dados incorretos ou não está Registado!");
                }
                con.Close();
            }
        }
        private bool getConnectionString()
        {
            bool works = false;
            //Tests the current connection
            try
            {
                NpgsqlConnection testCurrentConnString = new NpgsqlConnection(conn);
                testCurrentConnString.Open();
                testCurrentConnString.Close();
                return works = true;
            }
            catch (Exception ex)
            {
            }

            //List of possible connection strings
            string[] ServersArray = new string[] { "Server=192.168.1.202;port=5432;Database=chat;UserID=postgres;Password=mica",
                                                    "Server=192.168.1.189;port=5432;Database=chat;UserID=postgres;Password=123",
                                                    "Server=192.168.1.184;port=5432;Database=chat;UserID=postgres;Password=123"};

            //Goes through each connection string
            foreach (string conn_string in ServersArray)
            {
                //Tests a connection with the current connection string
                NpgsqlConnection dbcon = new NpgsqlConnection(conn_string);
                try
                {
                    dbcon.Open();
                    //If the connection succeeds, updates the connection string and leaves
                    conn = conn_string;
                    dbcon.Close();
                    return works = true;
                }
                catch (Exception ex)
                {
                }
            }
            //If none of the connections are available, sends a message warning that there is no connection and returns
            MessageBox.Show("Unable to connect");
            return works;
        }
    }
}







