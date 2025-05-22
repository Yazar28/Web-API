using System;

namespace LinkedListAPI.Models
{
    public class Node
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Node? Next { get; set; }

        public Node(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
            Next = null;
        }
    }
}
