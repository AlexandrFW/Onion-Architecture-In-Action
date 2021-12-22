using System;

namespace Performance
{
    public class C : IComparable
    {
        public int _i = 0;

        public int CompareTo(object obj)
        {
            C c = (C)obj;
            return _i.CompareTo(c._i);
        }
    }
}