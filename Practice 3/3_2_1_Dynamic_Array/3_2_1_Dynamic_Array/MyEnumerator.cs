using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3_2_1_Dynamic_Array
{
    class MyEnumerator : IEnumerator<object>
    {
        object[] internalArray;
        int position = -1;
        public MyEnumerator(object[] objects)
        {
            this.internalArray = objects;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= internalArray.Length)
                    throw new InvalidOperationException();
                return internalArray[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        object IEnumerator<object>.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (position < internalArray.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
}
