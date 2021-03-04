using BuzzerBernd.Models;
using System;
using System.Collections.Generic;

namespace BuzzerBernd.Services
{
    public class BuzzerService
    {
        public List<User> Users { get; set; } = new List<User>();

        private List<Buzz> _results = new List<Buzz>();
        public List<Buzz> Results 
        { 
            get => _results; 
            set
            {
                _results = value;
                ResultsChanged.Invoke(this, _results);
            }
        }

        public event EventHandler<List<Buzz>> ResultsChanged;

        public void AddResult(Buzz result)
        {
            _results.Add(result);
            ResultsChanged.Invoke(this, _results);
        }
    }
}
