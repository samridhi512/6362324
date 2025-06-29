using System;
using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> mockMapper;

        [OneTimeSetUp]
        public void Init()
        {
            mockMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_ShouldCreatePlayer_WhenNameIsUnique()
        {
            
            string testName = "Samridhi";
            mockMapper.Setup(p => p.IsPlayerNameExistsInDb(testName)).Returns(false);
            mockMapper.Setup(p => p.AddNewPlayerIntoDb(testName));

            
            Player player = Player.RegisterNewPlayer(testName, mockMapper.Object);


            Assert.That(player.Name, Is.EqualTo(testName));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameIsEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer("", mockMapper.Object));
            Assert.That(ex.Message, Is.EqualTo("Player name can’t be empty."));
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameAlreadyExists()
        {
            
            string existingName = "ExistingPlayer";
            mockMapper.Setup(p => p.IsPlayerNameExistsInDb(existingName)).Returns(true);

            
            var ex = Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer(existingName, mockMapper.Object));
            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
        }
    }
}
