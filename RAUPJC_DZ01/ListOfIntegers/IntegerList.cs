using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ListOfIntegers
{

    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        int ArrayIndex = 0;

        public IntegerList()
        {

            this._internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 1) Console.Write("Insert a bigger number");
            if (initialSize > 1) this._internalStorage = new int[initialSize];
        }

        //implementacija ResizeArray metode
        public Array ResizeArray(int[] oldArray, int newArrayLenght)
        {
            int i;
            int oldArraySize = oldArray.Length;
            int[] newArray = new int[newArrayLenght];
            for (i = 0; i < oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }
            return newArray;
        }

        //implementacija Add metode
        public void Add(int item)
        {
            if (ArrayIndex == _internalStorage.Length)
            {
                _internalStorage = (int[])ResizeArray(_internalStorage, _internalStorage.Length * 2);
            }
            _internalStorage[ArrayIndex] = item;
            ArrayIndex++;
        }

        //implementacija Remove metode
        public bool Remove(int item)
        {
            int i = 0;
            int RemoveIndex = -1;
            while((_internalStorage[i] != item) && (i < _internalStorage.Length-1))
            {
                i++;
            }
            if (_internalStorage[i] == item) RemoveIndex = i;
            if (RemoveIndex != -1)
            {
                for (i = RemoveIndex; i < _internalStorage.Length - 2; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                ArrayIndex = ArrayIndex - 1;
                return true;
            }
            else
                return false;
        }

        //implementacija RemoveAt metode
        public bool RemoveAt(int index)
        {
            int i;
            if (index > _internalStorage.Length - 1 || index < 0)
            {
                return false;
            }
            else
            {
                for (i = index; i < _internalStorage.Length - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                ArrayIndex = ArrayIndex - 1;
                return true;
            }
        }

        //Implementacija GetElement metode
        public int GetElement(int index)
        {
            if (index < 0 || index >= _internalStorage.Length)
                throw new IndexOutOfRangeException();
            else
                return _internalStorage[index];
        }

        //implementacija IndexOf metode
        public int IndexOf(int item)
        {
            int i = 0;
            do
            {
                if (_internalStorage[i] == item)
                    return i;
                i++;
            } while (i < _internalStorage.Length);
            return -1;
        }

        //implementacija Count metode
        public int Count
        {
            get
            {
                return ArrayIndex;
            }
        }

        //implementacija Clear metode
        public void Clear()
        {
            for (int i = 0; i < _internalStorage.Length - 1; i++)
                _internalStorage[i] = 0;
            ArrayIndex = 0;
        }

        //implementacija Contains metode
        public bool Contains(int item)
        {
            int i = 0;
            do
            {
                if (_internalStorage[i] == item)
                    return true;
                i++;
            } while (i < _internalStorage.Length);
            return false;
        }


        //testna aplikacija
        public void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1); // [1]
            listOfIntegers.Add(2); // [1 ,2]
            listOfIntegers.Add(3); // [1 ,2 ,3]
            listOfIntegers.Add(4); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5); // [2, 3, 4]
            Console.WriteLine ( listOfIntegers.Count ) ; // 3
            Console.WriteLine ( listOfIntegers.Remove (100) ) ; // false
            Console.WriteLine ( listOfIntegers.RemoveAt (5) ) ; // false
            listOfIntegers.Clear () ; // []
            Console.WriteLine ( listOfIntegers.Count ) ; // 0
        }
    }
}