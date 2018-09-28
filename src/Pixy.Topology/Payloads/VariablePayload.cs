

namespace Pixy.Topology.Payloads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class VariablePayload : IPayload
    {
        public VariablePayload(byte limit)
        {
            this.Limit = limit;
        }

        private byte _current;
        public byte Current
        {
            get => this._current;
            set
            {
                if(this.IsOutOfRange(value))
                {
                    throw new ArgumentOutOfRangeException(); 
                }
                this._current = value;
            }
        }

        public bool IsOutOfRange(byte value)
        {
            return value > this.Limit;
        }

        public byte Limit { get; private set; }

        public static VariablePayload operator ++(VariablePayload obj)
        {
            obj.Current++;
            return obj;
        }
        public static VariablePayload operator --(VariablePayload obj)
        {
            obj.Current--;
            return obj;
        }

    }
    
}
