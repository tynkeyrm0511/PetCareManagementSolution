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
        private bool isConnected;
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
                .WithUrl("https://localhost:7181/chatHub")
                .Build();

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                AppendMessageToListBox($"{user}: {message}");
            });

            try
            {
                await connection.StartAsync();
                isConnected = true;
                AppendMessageToListBox("System: Đã kết nối tới khách hàng!");
            }
            catch (Exception ex)
            {
                AppendMessageToListBox($"System: Kết nối tới khách hàng thất bại!!!: {ex.Message}");
            }
        }

        private void AppendMessageToListBox(string message)
        {
            if (listBoxMessages.InvokeRequired)
            {
                listBoxMessages.Invoke(new Action(() =>
                {
                    listBoxMessages.Items.Add(message);
                    listBoxMessages.TopIndex = listBoxMessages.Items.Count - 1;
                }));
            }
            else
            {
                listBoxMessages.Items.Add(message);
                listBoxMessages.TopIndex = listBoxMessages.Items.Count - 1;
            }
        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                var message = txtMessage.Text;
                await connection.InvokeAsync("SendMessage", "Admin:", message);
                //AppendMessageToListBox($"You: {message}");
                txtMessage.Clear();
            }
            else
            {
                AppendMessageToListBox("System: Unable to send message: not connected");
            }
        }
    }
}
