// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Pixy.Topology
{
    using System.Collections.Generic;

    public static class Utils
    {
        public static bool IsEmpty<T>(this Stack<T> stack)
        {
            return stack is Stack<T> s && s.Count == 0;
        }
    }
}