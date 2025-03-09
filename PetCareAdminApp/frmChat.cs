using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
namespace PetCareAdminApp
{
    public partial class frmChat: Form
    {
        private HubConnection connection;
        public frmChat()
        {
            InitializeComponent();
            InitializeSignalR();
        }

        private void frmChat_Load(object sender, EventArgs e)
        {

        }
        private async void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://your-signalr-server-url/chatHub")
                .Build();

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var newMessage = $"{user}: {message}";
                lstMessages.Items.Add(newMessage);
            });

            try
            {
                await connection.StartAsync();
                lstMessages.Items.Add("Connection started");
            }
            catch (Exception ex)
            {
                lstMessages.Items.Add($"Connection error: {ex.Message}");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (connection.State == HubConnectionState.Connected)
            {
                await connection.InvokeAsync("SendMessage", "Admin", txtMessage.Text);
                txtMessage.Clear();
            }
            else
            {
                lstMessages.Items.Add("Unable to send message: not connected");
            }
        }
    }
}
