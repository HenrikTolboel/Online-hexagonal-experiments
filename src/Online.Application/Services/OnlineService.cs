using Online.Application.Ports.Output;
using Online.Domain;

namespace Online.Application;

public class OnlineService : IOnlineUseCase
{
    private readonly String _str;
    private readonly DateTime _created;
    private readonly IPersistence _persistence;
    public OnlineService(String str, IPersistence persistence) {
        _str = str;
        _persistence = persistence;
        _created = DateTime.Now;
    }
    public List<OnlineItem> GetOnlineItems(string ListCommand)
    {
        var t = _persistence.Fetch(ListCommand);
        var list = new List<OnlineItem>();
        list.Add(new OnlineItem(_str));
        list.Add(new OnlineItem(ListCommand));
        list.Add(new OnlineItem(_created.ToString("O")));
        return list;
    }
}
