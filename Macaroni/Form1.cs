using Macaroni.Models;
using Macaroni.Models.Callbacks;
using Macaroni.Models.EventTriggers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Macaroni
{
    public partial class Form1 : Form
    {
        public static Timer UpdateTimer;

        private IList<EventListener> _eventListeners;

        public Form1()
        {
            InitializeComponent();

            UpdateTimer = timer1;

            _eventListeners = new List<EventListener>();

            UpdateTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var eventTrigger = new PixelEventTrigger(new Point(500, 500), Color.Red, 1);

            var eventListener = new EventListener(eventTrigger);

            eventListener.Callbacks.Add(new LogCallback(listBox2, "hello"));

            eventListener.Callbacks.Add(new WaitCallback(5000));

            eventListener.Callbacks.Add(new LogCallback(listBox2, "ok go"));

            _eventListeners.Add(eventListener);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var ev in _eventListeners)
            {
                ev.Update();
            }
        }
    }
}
