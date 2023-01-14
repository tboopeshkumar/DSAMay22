
namespace DSA
{
    public class NodeDouble<T>
    {
        public T Value;
        public NodeDouble<T> Next;
        public NodeDouble<T> Prev;
    }

    public class DoubleLinkedList<T>
    {
        private NodeDouble<T> Head;
        private NodeDouble<T> Tail;

        public void AddToBack(T value)
        {
            var newNode = new NodeDouble<T>()
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
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public void AddToFront(T value)
        {
            var newNode = new NodeDouble<T>()
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
                Head.Prev = newNode;
                newNode.Next = Head;
                Head = newNode;
            }
        }

        public bool InsertAfter(T searchValue, T insertValue)
        {
            for (var searchNode = Head; searchNode != null; searchNode = searchNode.Next)
            {
                if (searchNode.Value.Equals(searchValue))
                {
                    var newNode = new NodeDouble<T>()
                    {
                        Value = insertValue
                    };

                    if (searchNode == Tail)
                        Tail = newNode;
                    else
                        searchNode.Next.Prev = newNode;
                    newNode.Next = searchNode.Next;
                    searchNode.Next = newNode;
                    newNode.Prev = searchNode;
                    return true;
                }
            }
            return false;
        }

        public bool InsertBefore(T searchValue, T insertValue)
        {
            for (var searchNode = Head; searchNode != null; searchNode = searchNode.Next)
            {
                if (searchNode.Value.Equals(searchValue))
                {
                    var newNode = new NodeDouble<T>()
                    {
                        Value = insertValue
                    };

                    newNode.Next = searchNode;
                    newNode.Prev = searchNode.Prev;
                    if (searchNode == Head)
                    {
                        Head = newNode;
                    }
                    else
                        newNode.Prev.Next = newNode;
                    searchNode.Prev = newNode;
                    return true;
                }
            }
            return true;
        }

        public bool RemoveNode(T value) 
        {
            for (var deleteNode = Head; deleteNode != null; deleteNode = deleteNode.Next) 
            {
                if(deleteNode.Value.Equals(value))
                {
                    if (Head == Tail)
                    {
                        this.Head = null;
                        this.Tail = null;
                    }
                    if(deleteNode == Head) 
                    {
                        Head = deleteNode.Next;
                        Head.Prev = null;
                    }
                    else if(deleteNode == Tail) 
                    {
                        Tail = deleteNode.Prev;
                        Tail.Next = null;
                    }
                    else 
                    {
                        deleteNode.Prev.Next = deleteNode.Next;
                        deleteNode.Next.Prev = deleteNode.Prev;
                        deleteNode.Prev = deleteNode.Next = null;
                    }

                    return true;
                }
            }
            return false;
        }
        public void PrintForward()
        {
            for (var current = Head; current != null; current = current.Next)
            {
                Console.WriteLine(current.Value);
            }
        }

        public void PrintBackward()
        {
            for (var current = Tail; current != null; current = current.Prev)
            {
                Console.WriteLine(current.Value);
            }
        }
    }
}

