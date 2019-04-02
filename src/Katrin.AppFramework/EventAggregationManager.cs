using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework
{
    public static class EventAggregationManager
    {
        private static readonly IEventAggregator eventAggregator = new EventAggregator();

        public static void SendMessage<TMessage>(TMessage message, Action<Action> marshal = null)
        {
            eventAggregator.SendMessage(message, marshal);
        }

        public static void SendMessage<TMessage>(Action<Action> marshal = null) where TMessage : new()
        {
            eventAggregator.SendMessage(new TMessage(), marshal);
        }

        public static IEventSubscriptionManager AddListener(object listener, bool? holdStrongReference = null)
        {
            return eventAggregator.AddListener(listener, holdStrongReference);
        }

        public static IEventSubscriptionManager AddListener<T>(IListener<T> listener, bool? holdStrongReference = null)
        {
            return eventAggregator.AddListener(listener, holdStrongReference);
        }

        public static IEventSubscriptionManager RemoveListener(object listener)
        {
            return eventAggregator.RemoveListener(listener);
        }
    }
}
