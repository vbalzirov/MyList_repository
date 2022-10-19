namespace MyListApp
{
    public class LinkedListExample
    {
        private static LinkedList<int> list = new LinkedList<int>();

        public static void Run()
        {
            /*
            int[] array = new int[10];
            array[0] = 1;

            list.AddFirst("Dog");
            list.AddFirst("The");
            list.AddLast("is");
            list.AddLast("sitting");
            list.AddLast("on");
            list.AddLast("the");
            list.AddLast("floor");

            var current = list.First;

            var c = list.First;
            LinkedListNode<string> result = null;

            for (int i = 0; i < 5; i++)
            {
                result = c.Next;
            }


            string s = string.Empty;
            s = current.Value;

            Console.Write(current.Value);

            while (current.Previous != null)
            {
                current = current.Previous;
                Console.Write(current.Value);
            }
            Console.WriteLine(s);
            //Console.WriteLine(String.Join(' ', list));
            // The Dog;
            */


            LinkedListNodeExample<int> intType = new LinkedListNodeExample<int>();
            LinkedListNodeExample<string> strType = new LinkedListNodeExample<string>();

            intType.Value = 111 * 200;

            strType.Value = "Hello"!;
            strType.Value = String.Concat(strType.Value, " It's me");

            Console.WriteLine($"asd {strType.Value} asdsa");
            Console.WriteLine(strType.Value);
        }
    }

    public class LinkedListNodeExample<T>
    {
        public T Value;

        public LinkedListNodeExample<T> Previous;

        public LinkedListNodeExample<T> Next;
    }
}
