using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
namespace PetCareAdminApp
{
    public partial class frmChat: Form
    {
        private ChromiumWebBrowser browser;
        public frmChat()
        {
            InitializeComponent();
        }

        private void InitializeChromium()
        {
            if (!Cef.IsInitialized.HasValue || !Cef.IsInitialized.Value)
            {
                Cef.Initialize(new CefSettings());
            }
            browser = new ChromiumWebBrowser("https://dashboard.tawk.to/")
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(browser);
        }


        private void frmChat_Load(object sender, EventArgs e)
        {
            InitializeChromium();
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser?.Dispose();
        }
    }
}
