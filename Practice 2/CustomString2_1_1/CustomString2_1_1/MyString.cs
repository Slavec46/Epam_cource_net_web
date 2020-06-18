using System;
using System.Text;

namespace CustomString2_1_1
{
    public sealed class MyString : IComparable<MyString>
    {
        private char[] str;
        public int Length
        {
            get
            {
                return str.Length;
            }
        }

        public MyString(string str)
        {
            this.str = str.ToCharArray();
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();

            foreach (var item in str)
            {
                temp.Append(item);
            }

            return temp.ToString();
        }
        public override bool Equals(object obj)
        {
            MyString myString = obj as MyString;

            if (myString != null)
            {
                return ToString() == myString.ToString();
            }

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static int Compare(MyString firstString, MyString secondString)
        {
            if (firstString.Length > secondString.Length)
            {
                return 1;
            }
            else if (firstString.Length < secondString.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public int CompareTo(MyString other)
        {
            if (Length > other.str.Length)
            {
                return 1;
            }
            else if (Length < other.str.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public bool IsChar(char simbol)
        {
            foreach (var item in str)
            {
                if (item == simbol)
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(char simbol)
        {
            StringBuilder builder = new StringBuilder(ToString());

            str = builder.Replace(simbol + "", "").ToString().ToCharArray();
        }

        public static MyString operator +(MyString firstString, MyString secondString)
        {
            return new MyString(firstString.ToString() + secondString.ToString());
        }

        public char this[int index]
        {
            get
            {
                if (str.Length > index && index > -1)
                {
                    return str[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Index '{index}' incorrect!");
                }
            }
            set
            {
                if (str.Length > index && index > -1)
                {
                    str[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Index '{index}' incorrect!");
                }
            }
        }
    }
}