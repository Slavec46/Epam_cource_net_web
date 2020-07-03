using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3_2_1_Dynamic_Array
{
    class MyDynamicArray<T> : IEnumerable
    {
        private readonly MyEnumerator myEnumerator;

        private T[] internalArray;

        public MyDynamicArray<T>()
        {
        }

        public IEnumerator GetEnumerator()
        {
            return myEnumerator;
        }
    }
}
