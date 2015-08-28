using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Observer
{
    public class RDSTransmitter
    {

        private List<IRdsSubscriber> _subscribers;

        public RDSTransmitter()
        {
            _subscribers = new List<IRdsSubscriber>();
        }

        private string _lastNews;
        public string LastNews
        {
            get { return _lastNews; }
            set
            {
                _lastNews = value;
                Notify();
            }
        }

        public void Subscribe(IRdsSubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public void UnSubscribe(IRdsSubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }

        private void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(LastNews);
            }
        } 
    }
}
