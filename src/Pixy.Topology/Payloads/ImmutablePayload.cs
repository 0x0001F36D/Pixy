
namespace Pixy.Topology.Payloads
{
    internal sealed class ImmutablePayload : IPayload
    {
        internal static ImmutablePayload Instance
        {
            get
            {
                lock (s_locker)
                {
                    if (s_instance == null)
                    {
                        lock (s_locker)
                        {
                            s_instance = new ImmutablePayload();
                        }
                    }
                    return s_instance;
                }
            }
        }

        private readonly static object s_locker = new object();
        private static volatile ImmutablePayload s_instance;

        private ImmutablePayload()
        {

        }
        public byte Current => 1;

        public byte Limit => 1;
    }
}
