using gps.codingtest.core.ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace gps.codingtest.core.Services
{
    public class StatusService : IStatusService
    {
        private readonly Dictionary<Guid, string> _messageStatusDictionary;

        public StatusService()
        {
            _messageStatusDictionary = new Dictionary<Guid, string>();
        }

        public void SetStatus(Guid id, string status)
        {        
            _messageStatusDictionary.Add(id, status);
        }

        public string GetStatus(Guid id)
        {
            if (_messageStatusDictionary.ContainsKey(id))
            {
                return _messageStatusDictionary[id];
            }

            return string.Empty;
        }
    }
}