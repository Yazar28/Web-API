using System.Collections.Generic;

namespace LinkedListAPI.Models
{
    public class LinkedList
    {
        private Node? head = null;

        public Guid Add(string value)
        {
            var newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            return newNode.Id;
        }

        public List<object> GetAll()
        {
            var result = new List<object>();
            var current = head;

            while (current != null)
            {
                result.Add(new { current.Id, current.Value });
                current = current.Next;
            }

            return result;
        }

        public bool Remove(Guid id)
        {
            if (head == null)
                return false;

            if (head.Id == id)
            {
                head = head.Next;
                return true;
            }

            var current = head;
            while (current.Next != null)
            {
                if (current.Next.Id == id)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }
}
