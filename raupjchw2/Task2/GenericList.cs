using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;

        public GenericList()
        {
            Count = 0;
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            Count = 0;
            if (initialSize <= 0)
            {
                throw new ArgumentException("IntegerList initial size must be higher than 0.");
            }
            _internalStorage = new X[initialSize];
        }

        public int Count { get; private set; }

        public void Add(X item)
        {
            if (Count >= _internalStorage.Length)
            {
                Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
            }
            _internalStorage[Count++] = item;
        }

        public void Clear()
        {
            Count = 0;
            _internalStorage = new X[4];
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index < Count)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            while (this.Contains(item))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (_internalStorage[i].Equals(item))
                    {
                        for (int j = i; j < Count - 1; j++)
                        {
                            _internalStorage[j] = _internalStorage[j + 1];
                        }
                        Count--;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                Count--;
                return true;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
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
