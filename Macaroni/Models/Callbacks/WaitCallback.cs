using Macaroni.Models.Abstractions;
using System;
using System.Windows.Forms;

namespace Macaroni.Models.Callbacks
{
    public class WaitCallback : ICallback
    {
        private readonly int _milliseconds;
                
        public WaitCallback(int milliseconds)
        {
            _milliseconds = milliseconds;
        }

        public void RunCallback()
        {
            var until = DateTime.Now.AddMilliseconds(_milliseconds);

            Form1.UpdateTimer.Stop();

            while (DateTime.Now < until)
            {
                Application.DoEvents();
            }

            Form1.UpdateTimer.Start();
        }
    }
}
