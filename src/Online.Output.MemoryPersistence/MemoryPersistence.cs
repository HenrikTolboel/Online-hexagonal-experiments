using Online.Application.Ports.Output;
using Online.Domain;

namespace Online.Output.MemoryPersistence;

public class MemoryPersistence : IPersistence
{
    public OnlineItem? Fetch(string id)
    {
        return null; //throw new NotImplementedException();
    }

    public bool Store(string id, OnlineItem onlineItem)
    {
        throw new NotImplementedException();
    }
}
