using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Console.WriteLine(list.First());
            Console.WriteLine(list.First(x=>x == 2));

        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        public LinkedList()
        {

        }

        public void Add(T value) 
        {
            var newNode =  new LinkedListNode<T>();
            newNode.Value = value;
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else 
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public T First() {
            if (head == null) {
                throw new Exception("Empty list");
            }
            return head.Value;
        }

        public bool Any() {
            return head != null;
        }
        
        public T First(Func<T, bool> predicate) {
            
            var current = head;

            while (!predicate(current.Value))
            {
                if (current.Next == null)
                {
                    throw new Exception("Not Found");
                }

                current = current.Next;
            }

            return current.Value;
        }

        public T FirstOrDefault(Func<T, bool> predicate) {
            var current = head;
            while (!predicate(current.Value)) {
                if (current.Next == null) {
                    return default(T);
                }

                current = current.Next;
            }

            return current.Value;
        }
    }

    public class LinkedListNode<T> 
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get;set; }
    }
}
