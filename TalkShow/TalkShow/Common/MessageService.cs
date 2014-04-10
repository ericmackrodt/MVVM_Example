using System.Windows;

namespace TalkShow.Common
{
    public class MessageService : IMessageService
    {
        public void Show(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
