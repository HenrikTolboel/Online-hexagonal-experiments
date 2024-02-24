using Online.Domain;

namespace Online.Application;

public interface IOnlineUseCase
{


    public List<OnlineItem> GetOnlineItems(String ListCommand);
}
