using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int maxSize;
        private int size;

        public GenericList()
        {
            maxSize = 4;
            _internalStorage = new X[maxSize];
            size = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize > 0)
            {
                maxSize = initialSize;
                _internalStorage = new X[maxSize];
                size = 0;
            }
            else
                Console.WriteLine("Velicina mora biti pozitivna!");
        }

        public void Add(X item)
        {
            if (item == null)
                throw new ArgumentNullException();
            if (size == maxSize)
            {
                maxSize *= 2;
                X[] temp = new X[maxSize];
                for (int i = 0; i < size; i++)
                    temp[i] = _internalStorage[i];
                _internalStorage = temp;
            }
            _internalStorage[size] = item;
            size++;
        }

        public bool Remove(X item)
        {
            int index = size;
            for (int i = 0; i < size; i++)
                if (_internalStorage[i].Equals(item))
                {
                    index = i;
                    break;
                }
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                return false;
            if (index != size - 1)
                for (int i = index; i < size - 1; i++)
                    _internalStorage[i] = _internalStorage[i + 1];
            size--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index < size)
                return _internalStorage[index];
            else
                throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            int index = -1;
            for (int i = 0; i < size; i++)
                if (_internalStorage[i].Equals(item))
                {
                    index = i;
                    break;
                }
            return index;
        }

        public int Count { get { return size; } }

        int IGenericList<X>.Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            size = 0;
        }

        public bool Contains(X item)
        {
            bool contains = false;
            for (int i = 0; i < size; i++)
                if (_internalStorage[i].Equals(item))
                {
                    contains = true;
                    break;
                }
            return contains;
        }

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