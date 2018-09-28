
namespace Pixy.Topology.Payloads
{
    public interface IPayload
    {
        byte Current { get; }
        byte Limit { get; }
    }
}
