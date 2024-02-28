using Microsoft.VisualBasic;
using Moq;
using Online.Application.Ports.Output;
using Online.Domain;

namespace Online.Application.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var mock = new Mock<IPersistence>();

        mock.Setup(foo => foo.Fetch("sdajkl")).Returns(null as OnlineItem);
        OnlineService t = new OnlineService("abe", mock.Object);

        var res = t.GetOnlineItems("sdajkl");
        Assert.That(res, Has.Count.EqualTo(3));
    }
}