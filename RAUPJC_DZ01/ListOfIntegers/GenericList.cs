using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfIntegers
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        int ArrayIndex = 0;

        public GenericList()
        {

            this._internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 1) Console.Write("Insert a bigger number");
            if (initialSize > 1) this._internalStorage = new X[initialSize];
        }

        //ResizeArray
        public Array ResizeArray(X[] oldArray, int newArrayLenght)
        {
            int i;
            int oldArraySize = oldArray.Length;
            X[] newArray = new X[newArrayLenght];
            for (i = 0; i < oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }
            return newArray;
        }

        //implementacija Add metode
        public void Add(X item)
        {
            if (ArrayIndex == _internalStorage.Length)
            {
                _internalStorage = (X[])ResizeArray(_internalStorage, _internalStorage.Length * 2);
            }
            _internalStorage[ArrayIndex] = item;
            ArrayIndex++;
        }

        //implementacija Remove metode
        public bool Remove(X item)
        {
            int i = 0;
            int RemoveIndex = -1;
            while ((!EqualityComparer<X>.Default.Equals(_internalStorage[i], item)) && (i < _internalStorage.Length - 1))
            {
                i++;
            }
            if (EqualityComparer<X>.Default.Equals(_internalStorage[i], item)) RemoveIndex = i;
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
        public X GetElement(int index)
        {
            if (index < 0 || index >= _internalStorage.Length)
                throw new IndexOutOfRangeException();
            else
                return _internalStorage[index];
        }

        //implementacija IndexOf metode
        public int IndexOf(X item)
        {
            int i = 0;
            do
            {
                if (EqualityComparer<X>.Default.Equals(_internalStorage[i], item))
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
                _internalStorage[i] = default(X);
            ArrayIndex = 0;
        }

        //implementacija Contains metode
        public bool Contains(X item)
        {
            int i = 0;
            do
            {
                if (EqualityComparer<X>.Default.Equals(_internalStorage[i], item))
                    return true;
                i++;
            } while (i < _internalStorage.Length);
            return false;
        }

        // IEnumerable <X> implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




    }
}
