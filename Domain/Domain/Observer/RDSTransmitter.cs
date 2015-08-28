using System.Collections.Generic;

namespace Domain.Domain.Observer
{
    public class RDSTransmitter
    {
        private readonly List<IRdsSubscriber> _subscribers;
        private string _lastNews;

        public RDSTransmitter()
        {
            _subscribers = new List<IRdsSubscriber>();
        }

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