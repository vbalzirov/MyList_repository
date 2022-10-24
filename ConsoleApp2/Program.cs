namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList();            

            var a = new int[] { 1, 2, 3, 4, 5, 6 };

            //// Testing methods of MyList class
            myList.AddList(a);

            myList.RemoveRange(new int[] { 2, 3, 1, 5 });
            //myList.AddList(new int[] { 11, 22, 33, 44, 55 }, false);

            //myList.InsertByIndex(10, 99);

            //// See what has changed in the instance of MyClass
            Console.WriteLine(myList.ToString());
            //LinkedListExample.Run();
        }
    }

    /// <summary>
    /// This MyList class.
    /// </summary>
    public class MyList 
    {
        /// <summary>
        /// 
        /// </summary>
        private int[] _list;

        /// <summary>
        /// 
        /// </summary>
        private LinkedList<int> _linkedList { get; set; }

        public void AddListInTheBegginig(int[] input)
        { 
        
        
        }

        public void AddListInTheEnd(int[] input)
        {


        }

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
                IncreaseCapacityBy(_list.Length + 1);
                _list[_list.Length - 1] = element;
            }
        }

        public void AddList(int[] array)
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
                IncreaseCapacityBy(_list.Length + array.Length);
                
                for (int i = 0; i < array.Length; i++)
                {
                    _list[len + i] = array[i];
                }
            }
        }
        
        public void AddList(int[] array, bool insertInTheEnd)
        {
            // add array in the end
            if (insertInTheEnd)
            {
                AddList(array);
            }
            // add array in the beggining
            else
            {
                /*
                var delta = 1;
                var shiftSize = _list.Length;
                if (shiftSize < array.Length)
                {
                    shiftSize = array.Length;
                    delta = 0;
                }

                IncreaseCapacityBy(array.Length);

                for (int i = _list.Length - 1; i > array.Length - 1; i--)
                { 
                    _list[i] = _list[i - shiftSize + delta];
                }

                for (int i = 0; i < array.Length; i++) 
                {
                    _list[i] = array[i];
                }
                */

                var tmpArray = new int[_list.Length + array.Length];
                Array.Copy(array, tmpArray, array.Length);
                Array.Copy(_list, 0, tmpArray, array.Length, _list.Length);
                _list = tmpArray;
            }
        }

        public void InsertByIndex(int index, int value)
        {
            if (_list == null)
            {
                _list = new int[index + 1];
                _list[index] = value;

                return;
            }

            var delta = GetDelta(_list.Length, index);

            IncreaseCapacityBy(_list.Length + delta);

            for (int i = _list.Length - 1; i > index; i--)
            {
                _list[i] = _list[i - 1];
            }

            _list[index] = value;
        }

        /// <summary>
        /// XML Comment. Removes elements by given indexes.
        /// </summary>
        /// <param name="arr">Array with indexes to be removed.</param>
        public void RemoveRange(int[] arr)
        {
            var newList = new int[_list.Length - arr.Length];
            int j = 0;
            for (var i=0; i < _list.Length; i++)
            {
                var flag = false;
                foreach (var elem in arr)
                {
                    if (elem == i)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    newList[j] = _list[i];
                    j++;
                }
            }
            _list = newList;
        }

        public void RemoveByIndex(int index)
        {
            if (_list == null)
            {
                return;
            }

            for (int i = index; i < _list.Length - 1; i++)
            {
                _list[i] = _list[i + 1];
            }
            IncreaseCapacityBy(-1);
        }

        public override string ToString()
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

        public void RemoveRange(int index, int count)
        {
            // 1 2 3 4 5 6
            // index == 1; count == 3
            // 1 5 6

            if (_list == null)
            {
                return;
            }

            for (int i = index; i <= index + count; i++)
            {
                if (i + count == _list.Length)
                {
                    break;
                }

                _list[i] = _list[i + count];
            }
            // 1 5 6

            IncreaseCapacityBy(-1*3);
        }

        private static int GetDelta(int currentSize, int index)
        {
            int delta = 1;
            if (currentSize < index)
            {
                delta = index - currentSize + 1;
            }

            Console.WriteLine();

            return delta;
        }

        /// <summary>
        /// Increases internal array by given number.
        /// </summary>
        /// <param name="increaseBy">The size internal array must be increased by.</param>
        private void IncreaseCapacityBy(int increaseBy)
        {
            // Resize array if we need to extend it's capasity.
            Array.Resize(ref _list, _list.Length + increaseBy);
        }
    }
}