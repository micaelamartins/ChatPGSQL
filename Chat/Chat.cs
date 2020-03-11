using System;
using System.Data;
using System.Windows.Forms;
using RethinkDb.Driver;
using RethinkDb.Driver.Net.Clustering;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using Npgsql;

namespace Chat
{
    public partial class Chat : Form
    {
        string conn = "Server=192.168.1.202;port=5432;Database=chat;UserID=postgres;Password=mica";

        public Chat(string text)
        {
            InitializeComponent();
            lb_username.Text = text;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

     /*       try

            {
               

                for (int i = 0; i < 10; i++) {
                    //Stablish connection to RethinkDB Server that is running on Raspberry
                    var conn = r.ConnectionPool().Seed(new[] { "192.168.0.184:28015", "192.168.1.202:28015", "192.168.1.189:28015" });
                    conn.PoolingStrategy(new EpsilonGreedyHostPool(new TimeSpan(0, 1, 0), EpsilonCalculator.Linear())).Discover(true);
                    pool = conn.Connect();
                   
                    Thread.Sleep(1000);
                 }
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible to Connect!");
            }

            tb_mensagem.Text ="";
            


            //Get all messages from RethinkDB
            List<Mensagem> all_messages = r.Db("chat").Table("chattable").OrderBy("Data").Run<List<Mensagem>>(pool);
                



                //Load all previous messages to the listbox of messages
                foreach (var message in all_messages)
                {
                    //Create message
                    Mensagem msg = new Mensagem(message.Id, message.Data, message.Username, message.Msg);
                    //Adding Message to Listbox
                    lb_chat.Items.Add(msg);
                }
                focus_last_message();

                //Calling and running the task
                Task.Run(() => HandleUpdates(pool, lb_chat));*/
            }
        


        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            //Checks if Enter key is pressed on the Textbox
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //if shift is pressed, enter will paragraph
                if (e.Shift)
                {
                    tb_mensagem.AppendText(Environment.NewLine);
                }
                //if there is no username available enter will warn that it needs a username
               
                //if message textbox is empty it wont do anything
                else if (string.IsNullOrWhiteSpace(tb_mensagem.Text)) ;
                //if everything is ok successfully send and save message
                else
                {
                    //getting the information to a variable
                    string username = lb_username.Text;
                    
                    string message_text = tb_mensagem.Text;
                    //Creating a message
                    //
                    Mensagem mensagem = new Mensagem { Data = DateTime.Now,  Msg = message_text };
                    ///////////////////////////////////////////////focus_last_message();
                   NpgsqlConnection dbcon = new NpgsqlConnection(conn);

                    dbcon.Open();

                    try
                    {

                        //Writing the message on the Database    
                        string sql1 = "INSERT INTO users(Username, Mensagem) VALUES ('" + username.ToString() + "','" + message_text.ToString() + "')";
                        NpgsqlCommand cmdo = new NpgsqlCommand(sql1, dbcon);

                        //dbcmd.CommandText = sql1;

                        cmdo.ExecuteNonQuery();
                        lb_chat.Items.Add(mensagem);
                        dbcon.Close();




                    }
                    catch(Exception ex)
                    {
                        tb_mensagem.Text = "Trying to Reconnect...";

                        Form1_Load(sender, e);
                    }
                    

                    //Clean up
                    tb_mensagem.Text = "";
                    


                }
            }
        }
        /*
//Waits for changes in the database and updates the listbox with new messages
public static async Task HandleUpdates(ConnectionPool pool, ListBox lb_chat)
{
   //Create a feed that waits for a new message to reach the database
   var feed = await r.Db("chat").Table("chattable").Changes().RunChangesAsync<Mensagem>(pool);
   //Take the feed and create a message
   foreach (var message in feed)
   {
       if (message.NewValue != null)
       {
           Mensagem msg = new Mensagem(message.NewValue.Id, message.NewValue.Data, message.NewValue.Username , message.NewValue.Msg);
           try
           {
               //Invoke listbox from the Form to the thread to be able to use it
               lb_chat.Invoke(new Action(() => lb_chat.Items.Add(msg)));
               if (lb_chat.Items.Count != 0)
               {
                   lb_chat.Invoke(new Action(() => lb_chat.SetSelected(lb_chat.Items.Count - 1, true)));
                   lb_chat.Invoke(new Action(() => lb_chat.SetSelected(lb_chat.Items.Count - 1, false)));
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Erro");
           }
       }
       else
       {
           lb_chat.Invoke(new Action(() => lb_chat.Items.Remove(lb_chat.SelectedItem)));
       }
       //Create message
   }
}
//Selecting a message from the listbox to delete
private void lb_chat_DoubleClick(object sender, EventArgs e)
{
   //Checks if selected item has a message
   if (lb_chat.SelectedItem != null)
   {
       //Check if message was sent by user
       Mensagem msg = lb_chat.SelectedItem as Mensagem;
       //Allows to delete if message belongs to user
     //  if (msg.Username == lb_username.Text)
       //{
           DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this message?" + "\n" + "\n" + ": " + msg.Msg, "DELETE MESSAGE", MessageBoxButtons.YesNo);

           if (dialogResult == DialogResult.Yes)
           {
               //Deletes message from database and listbox
               r.Db("chat").Table("chattable").Get(msg.Id).Delete().Run(pool);

           }
       //}
   }
}

//Focus on the last message (this is for the listbox to automaticly scroll down to the last message)
public void focus_last_message()
{
   if (lb_chat.Items.Count != 0)
   {
       lb_chat.SetSelected(lb_chat.Items.Count - 1, true);
       lb_chat.SetSelected(lb_chat.Items.Count - 1, false);
   }*/
    }
    }



