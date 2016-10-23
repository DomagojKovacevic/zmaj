using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfIntegers
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private int curIndex;
        private T curT;
        private GenericList<T> _collection;

        public GenericListEnumerator(GenericList<T> collection)
        {
            _collection = collection;
            curIndex = -1;
            curT = default(T);

        }

        public T Current
        {
            get
            {
                return curT;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            throw new Exception("Not implemented");
        }

        public bool MoveNext()
        {
            if(++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                curT = _collection.GetElement(curIndex);
            }
            return true;
        }

        public void Reset()
        {
            curIndex = -1;
        }
    }

}
