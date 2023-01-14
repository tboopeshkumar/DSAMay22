namespace DSA
{
     public class Program
    {
        public static void Main(string[] args)
        {
            // var sLL = new SingleLinkedList<int>();
            // sLL.AddToBack(5);
            // sLL.AddToBack(7);
            // sLL.AddToBack(1);
            // sLL.PrintForward();

            var dLL = new DoubleLinkedList<int>();
            dLL.AddToBack(3);
            dLL.AddToBack(5);
            dLL.AddToBack(7);
            dLL.AddToFront(1);
            dLL.InsertAfter(3, 4);
            dLL.InsertBefore(7, 6);                
            Console.WriteLine("Forward");
            dLL.PrintForward();
            Console.WriteLine("Backward");
            dLL.PrintBackward();
            dLL.RemoveNode(4);
            dLL.RemoveNode(1);
            dLL.RemoveNode(7);
            Console.WriteLine("Forward");
            dLL.PrintForward();
            Console.WriteLine("Backward");
            dLL.PrintBackward();
        }
    }
}