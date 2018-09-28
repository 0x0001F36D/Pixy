// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Pixy.Topology
{
    using System;

    public static class Contract
    {
        public static void ArgumentOutOfRange(bool condition, string argName)
        {
            if (condition)
                throw new ArgumentOutOfRangeException(argName);
        }

        public static void Null<T>(T arg, string argName) where T : class
        {
            if (arg is null)
                throw new ArgumentNullException(argName);
        }
    }
}