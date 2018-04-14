using Macaroni.Models.Abstractions;
using System.Collections.Generic;

namespace Macaroni.Models
{
    public class EventListener
    {
        private readonly IEventTrigger _eventTrigger;

        public IList<ICallback> Callbacks { get; set; }

        public EventListener(IEventTrigger eventTrigger)
        {
            _eventTrigger = eventTrigger;

            Callbacks = new List<ICallback>();
        }

        public void Update()
        {
            if (_eventTrigger.IsTriggering())
            {
                foreach (var callback in Callbacks)
                {
                    callback.RunCallback();
                }
            }
        }
    }
}
