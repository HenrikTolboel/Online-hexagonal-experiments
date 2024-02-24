using System.Security.Cryptography.X509Certificates;
using Online.Domain;

namespace Online.Application.Ports.Output;

public interface IPersistence
{
    public Boolean Store(String id, OnlineItem onlineItem);
    public OnlineItem? Fetch(String id);
}
