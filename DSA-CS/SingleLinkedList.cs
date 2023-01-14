
namespace DSA
{
    public class NodeSingle<T>
    {
        public T Value;
        public NodeSingle<T> Next;
    }

    public class SingleLinkedList<T>
    {
        public NodeSingle<T> Head;
        public NodeSingle<T> Tail;

        public void AddToBack(T value)
        {
            var newNode = new NodeSingle<T>()
            {
                Value = value
            };

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public void PrintForward()
        {
            for (var current = Head; current != null; current = current.Next)
            {
                Console.WriteLine(current.Value);
            }
        }
    }   
}

