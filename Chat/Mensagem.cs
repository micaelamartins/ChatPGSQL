using System;

namespace Chat
{
    public partial class Mensagem

    {
        public String Id;
        public DateTime Data;
        public String Msg;
        public String Username;
       

        public Mensagem()
        {
           
        }

        public Mensagem(String id, DateTime data, String username, String mensagem)
        {
            Id= id;
            Data = data;
            Msg = mensagem;
            Username = username;
        }

        public override string ToString()
        {
            return "( " +Data+" ) "+ Username + ": " + Msg;
        }
    }
}
