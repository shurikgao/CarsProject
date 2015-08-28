using Domain.Domain;
using Factories.Factory;
using InterfaceActions.Actions;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GermanyCarFactoryFixture
    {
        [SetUp]
        public void Setup()
        {
            _mockNotifyUsersAction = new Mock<INotifyUsersAction>();
            _germanyCarFactory = new GermanyCarFactory(_mockNotifyUsersAction.Object);
        }

        //string name, int engineVol, int tankVol, string bodyType

        private readonly string _name = "BMW";
        private readonly string _bodyType = "sedan";
        private readonly int _engineVol = 2000;
        private readonly int _tankVol = 80;
        private GermanyCarFactory _germanyCarFactory;
        private Mock<INotifyUsersAction> _mockNotifyUsersAction;

        public void ActByCreatingGermanyCar()
        {
         //   _germanyCarFactory.CreateNewGermanyCar(_name, _engineVol, _tankVol, _bodyType);
        }

        [Test]
        public void ItShouldCallNotify()
        {
            _mockNotifyUsersAction.Setup(x => x.Notify(It.IsAny<GermanyCar>()));

            ActByCreatingGermanyCar();

            _mockNotifyUsersAction.Verify(x => x.Notify(It.IsAny<GermanyCar>()), Times.Once);
        }
    }
}