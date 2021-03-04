using BuzzerBernd.Models;
using System;
using System.Collections.Generic;

namespace BuzzerBernd.Services
{
    public class BuzzerService
    {
        public List<User> Users { get; set; } = new List<User>();

        public List<Buzz> Results { get; set; } = new List<Buzz>();
    }
}
