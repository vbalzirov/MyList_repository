namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList();

            myList.Add(101);
            myList.Add(101);

            var a = new int[] { 1, 2, 3, 4 };
            myList.AddListInEnd(a);

            Console.WriteLine(myList.ToString());
        }
    }

    public class MyList 
    {
        private int[] _list;

        public int Length
        {
            get
            {
                if (_list == null)
                {
                    return 0;
                }
                
                return _list.Length;
            }

            private set { }
        }

        public MyList()
        {
        }

        public void Add(int element)
        {
            if (_list == null)
            {
                _list = new int[1];
                _list[0] = element;
            }
            else
            {
                Array.Resize(ref _list, _list.Length + 1);
                _list[_list.Length - 1] = element;
            }
        }

        public void AddListInEnd(int[] array)
        {
            if (_list == null)
            {
                
                _list = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    _list[i] = array[i];
                }
                
                _list = array;
            }
            else
            {
                var len = _list.Length;
                Array.Resize(ref _list, _list.Length + array.Length);
                
                for (int i = 0; i < array.Length; i++)
                {
                    _list[len + i] = array[i];
                }
            }
        }

        public string ToString()
        {
            string result = "";
            if (_list != null)
            {
                for (var i = 0; i < _list.Length; i++)
                {
                    if (i == 0)
                    {
                        result = _list[i].ToString();
                    }
                    else
                    {
                        result = result + ", " + _list[i];
                    }
                }
            }

            return result;
        }
    }
}