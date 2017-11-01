using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> _genericList;

        private int position = -1;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this._genericList = genericList;
        }

        public X Current
        {
            get
            {
                try
                {
                    return _genericList.GetElement(position);
                }
                catch (IndexOutOfRangeException)
                {

                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current { get; }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position++;
            return (position < _genericList.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
