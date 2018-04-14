using Macaroni.Models.Abstractions;
using System.Windows.Forms;

namespace Macaroni.Models.Callbacks
{
    public class LogCallback : ICallback
    {
        private readonly ListBox _listBox;

        private readonly string _text;
        
        public LogCallback(ListBox listBox, string text)
        {
            _listBox = listBox;

            _text = text;
        }

        public void RunCallback()
        {
            _listBox.Items.Add(_text);
        }
    }
}
