using System;

namespace Performance
{
    public struct S : IComparable
    {
        public int _i;

        public int CompareTo(object obj)
        {
            var s = (S)obj;
            return _i.CompareTo(s._i);
        }
    }
}