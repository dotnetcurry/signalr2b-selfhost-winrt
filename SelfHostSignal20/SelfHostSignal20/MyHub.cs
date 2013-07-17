using Microsoft.AspNet.SignalR;

namespace SelfHostSignalR20
{
    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }
    }
}
