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
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
namespace PetCareAdminApp
{
    public partial class frmChat: Form
    {
        private HubConnection connection;
        private bool isConnected;
        private WebView2 webView;
        public frmChat()
        {
            InitializeComponent();
            InitializeWebView();
        }
        private void InitializeWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            Controls.Add(webView);
            webView.Source = new Uri("https://dashboard.tawk.to/");
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                webView.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
            }
            else
            {
                MessageBox.Show("Không thể tải trang web. Vui lòng kiểm tra kết nối mạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CoreWebView2_DOMContentLoaded(object sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            webView.CoreWebView2.ExecuteScriptAsync("document.body.innerHTML += '<div style=\"position: fixed; bottom: 10px; right: 10px; background: rgba(255,0,0,0.7); color: white; padding: 5px;\">Đã tải trang web thành công!</div>';");
        }
        private void frmChat_Load(object sender, EventArgs e)
        {

        }
        
    }
}
