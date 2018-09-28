
namespace Pixy.Topology.Nodes
{
    using Pixy.Topology.Payloads;
    using System;
    using System.Collections.Generic;



    /// <summary>
    /// The Simplex Topological-Node (Combined by multiple EPs)
    /// </summary>
    public class SX : ITN
    {

        public const byte DEFAULT_LIMIT = 5;

        private VariablePayload _payload;
        public SX() : this(DEFAULT_LIMIT)
        {

        }

        private SX(byte limit)
        {
            this._payload = new VariablePayload(limit);

            this._serials = new Stack<byte>(limit);
            for (byte i = limit; i >= 1; i--)
            {
                this._serials.Push(i);
            }
            this._table = new Dictionary<byte, EP>(limit);
        }


        public IPayload Payload => this._payload;
        private readonly Stack<byte> _serials;
        private readonly Dictionary<byte, EP> _table;
        public int Limit { get; private set; }

        public bool Increase(EP endpoint)
        {
            Contract.Null(endpoint, nameof(endpoint));

            if (this._serials.IsEmpty())
                return false;
            if (this._table.ContainsValue(endpoint))
                return false;

            var sn = this._serials.Pop();
            _table[sn] = endpoint;
            this._payload++;

            return true;
        }

        public bool Decrease(EP endpoint)
        {
            Contract.Null(endpoint, nameof(endpoint));

            foreach (var key in this._table.Keys)
            {
                var current = this._table[key];
                if(current.Equals(endpoint))
                {
                    this._serials.Push(key);
                    this._table[key] = null;
                    this._payload--;
                    return true;
                }
            }
            return false;
            
        }
        public IEnumerable<ITN> GetCurrentLayer()
        {
            foreach (var item in this._table.Values)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// The Endpoint Topological-Node (Minimum condition for forming a node)
    /// </summary>
    public class EP : ITN
    { 
        public IPayload Payload => ImmutablePayload.Instance; 

        public IEnumerable<ITN> GetCurrentLayer()
        {
            yield return this; 
        }
        
    } 

    /// <summary>
    /// The Topological-Node interface
    /// </summary>
    public interface ITN
    {
        IPayload Payload { get; }

        IEnumerable<ITN> GetCurrentLayer();
    }

}
