using System;

namespace BuzzerBernd.Models
{
    public class User
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public User(string name, Guid id)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            if (Guid.Empty == id)
                throw new ArgumentException($"'{nameof(id)}' cannot be empty", nameof(id));

            Name = name;
            Id = id;
        }
    }
}
