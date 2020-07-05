using System;
using System.Collections;
using System.Collections.Generic;

namespace _3_2_1_Dynamic_Array
{
    class MyDynamicArray<T> : IList<T>, IEnumerator<T>, ICloneable
    {
        protected T[] _array;

        public MyDynamicArray()
        {
            Capasity = 8;
        }
        public MyDynamicArray(int capasity)
        {
            Capasity = capasity;
        }
        public MyDynamicArray(IEnumerable<T> array) : this()
        {
            foreach (var item in array)
            {
                Add(item);
            }
        }

        /// <exception cref="ArgumentOutOfRangeException"> Сannot go beyond the scope of the array! </exception>
        public T this[int index]
        {
            get
            {
                if (index > Count * -1 && index < Count)
                {
                    if (index >= 0)
                    {
                        return _array[index];
                    }
                    else
                    {
                        return _array[Count - 1 + index];
                    }
                }

                throw new ArgumentOutOfRangeException("Сannot go beyond the scope of the array!");
            }

            set
            {
                if (index > Count * -1 && index < Count)
                {
                    if (index >= 0)
                    {
                        _array[index] = value;
                    }
                    else
                    {
                        _array[Count - 1 + index] = value;
                    }

                    return;
                }

                throw new ArgumentOutOfRangeException("Сannot go beyond the scope of the array!");
            }
        }

        public int Count
        {
            get;
            protected set;
        }
        /// <exception cref="ArgumentOutOfRangeException"> The Capasity cannot be less the Count! </exception>
        public int Capasity
        {
            get => _array.Length;

            set
            {
                if (_array == null)
                {
                    _array = new T[value];
                }
                else if (Count <= value)
                {
                    T[] temp = _array;

                    _array = new T[value];

                    temp.CopyTo(_array, 0);
                }
                else
                {
                    new ArgumentOutOfRangeException("The Capasity cannot be less the Count!");
                }
            }
        }
        public bool IsReadOnly => false;

        protected int _index = -1;
        public T Current => _array[_index];
        object IEnumerator.Current => Current;

        public void Add(T item)
        {
            if (Count == Capasity)
            {
                Capasity *= 2;
            }

            _array[Count] = item;

            Count++;
        }
        public void Clear()
        {
            _array = new T[0];
        }
        public bool Contains(T item)
        {
            foreach (var value in this)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
        /// <exception cref="ArgumentOutOfRangeException"> arrayIndex go beyond the scope of the array! </exception>
        /// <exception cref="Exception"> Insufficient array size! </exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("arrayIndex go beyond the scope of the array!");
            }
            if (array.Length - arrayIndex < Count)
            {
                throw new Exception("Insufficient array size!");
            }

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = _array[i];
            }
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }
        /// <exception cref="ArgumentOutOfRangeException"> Index go beyond the scope of the array! </exception>
        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index go beyond the scope of the array!");
            }

            _array[index] = item;
        }
        public bool Remove(T item)
        {
            int temp = IndexOf(item);

            if (temp == -1)
            {
                return false;
            }

            RemoveAt(temp);

            return true;
        }
        /// <exception cref="ArgumentOutOfRangeException"> Index go beyond the scope of the array! </exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index go beyond the scope of the array!");
            }

            for (int i = index; i < Count; i++)
            {
                if (!(i + 1 == Count))
                {
                    _array[i] = _array[i + 1];
                }
            }

            Count--;
        }
        public object Clone()
        {
            MyDynamicArray<T> temp = new MyDynamicArray<T>(ToArray());

            for (int i = temp.Count - 1; i > Count - 1; i--)
            {
                temp.RemoveAt(i);
            }

            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public virtual bool MoveNext()
        {
            if (Count - 1 > _index)
            {
                _index++;

                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void Reset()
        {
            _index = -1;
        }

        public override bool Equals(object obj)
        {
            MyDynamicArray<T> temp = obj as MyDynamicArray<T>;

            if (temp != null)
            {
                if (Capasity == temp.Capasity && Count == temp.Count)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (!_array[i].Equals(temp[i]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            return false;
        }
        public override int GetHashCode()
        {
            return _array.GetHashCode();
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int collectionLenght = 0;

            foreach (var item in collection)
            {
                collectionLenght++;
            }

            if (Count + collectionLenght > Capasity)
            {
                int newCapasity = Capasity;

                while (Count + collectionLenght > newCapasity)
                {
                    newCapasity *= 2;
                }

                Capasity = newCapasity;
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public T[] ToArray()
        {
            T[] temp = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                temp[i] = _array[i];
            }

            return temp;
        }
    }
}