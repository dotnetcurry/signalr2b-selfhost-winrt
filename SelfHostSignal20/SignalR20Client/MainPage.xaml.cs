using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SignalR20Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CoreDispatcher dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
        HubConnection hubConnection;
        IHubProxy myHubProxy;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnection(ServerPath.Text);
                myHubProxy = hubConnection.CreateHubProxy("MyHub");
                myHubProxy.On<string>("addMessage", OnAddMessage);
                await hubConnection.Start();
            }
        }

        volatile string message = "";
        private async void OnAddMessage(string msg)
        {
            message = msg;
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, handler);
        }

        private void handler()
        {
            IncomingMessages.Text = IncomingMessages.Text + Environment.NewLine + message;
        }

        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            myHubProxy.Invoke("Send", OutgoingMessage.Text);
            OutgoingMessage.Text = string.Empty;
        }
    }
}
