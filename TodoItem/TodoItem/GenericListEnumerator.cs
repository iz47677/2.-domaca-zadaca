using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> listOfGenerics;
        private int position;
        private T curGeneric;

        object IEnumerator.Current { get { return Current; } }

        public T Current { get { return curGeneric; } }

        public GenericListEnumerator(GenericList<T> list)
        {
            listOfGenerics = list;
            position = -1;
        }

        public bool MoveNext()
        {
            position++;
            if (position >= listOfGenerics.Count)
            {
                return false;
            }
            else
            {
                curGeneric = listOfGenerics.GetElement(position);
            }
            return true;
        }

        public void Reset()
        {
            position = -1;
        }

        void IDisposable.Dispose() { }
    }
}
