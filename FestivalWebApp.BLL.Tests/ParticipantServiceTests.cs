using System.Threading.Tasks;
using FestivalWebApp.BLL.Contracts;
using FestivalWebApp.BLL.Exceptions;
using FestivalWebApp.BLL.Tests.Mocks;
using FestivalWebApp.Core.Models;
using FestivalWebApp.DAL.Contracts;
using NUnit.Framework;

namespace FestivalWebApp.BLL.Tests
{
    [TestFixture]
    public class ParticipantServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _repository = new ParticipantMockRepository();
            _service = new ParticipantService(_repository);
        }

        private IParticipantService _service;
        private IParticipantRepository _repository;

        [Test]
        public async Task Should_Remove_Item_If_It_Exists()
        {
            //Arrange
            const int id = 100;
            var participant = new Participant
            {
                Name = "Test",
                SecondName = "Test",
                Id = id
            };
            await _repository.AddParticipant(participant);
            //Act
            await _service.RemoveParticipant(id);
            //Assert
            Assert.IsFalse(await _repository.IsExist(id));
        }

        [Test]
        public void Should_Throw_Exception_When_No_Element_To_Update()
        {
            //Arrange
            const int id = 100;
            var participant = new Participant
            {
                Name = "Test",
                SecondName = "Test",
                Id = id
            };
            //Act + assert
            Assert.ThrowsAsync<ElementNotFoundException>(async () => await _service.UpdateParticipant(participant));
        }

        [Test]
        public void Should_Throw_Exception_When_Nothing_To_Remove()
        {
            //Arrange
            const int id = 100;
            //Act + assert
            Assert.ThrowsAsync<ElementNotFoundException>(async () => await _service.RemoveParticipant(id));
        }

        [Test]
        public async Task When_Add_Participant_To_Repository_Should_Return_It_Back()
        {
            //Arrange
            const int id = 100;
            var participant = new Participant
            {
                Name = "Test",
                SecondName = "Test",
                Id = id
            };

            //Act
            var result = await _service.AddParticipant(participant);

            //Assert
            Assert.AreEqual(participant.Id, result.Id);
        }

        [Test]
        public async Task When_Update_Participant_In_Repository_Should_Return_It_Back()
        {
            //Arrange
            const int id = 100;
            var participant = new Participant
            {
                Name = "Test",
                SecondName = "Test",
                Id = id
            };
            var updatedParticipant = new Participant
            {
                Name = "Result",
                SecondName = "Result",
                Id = id
            };
            await _repository.AddParticipant(participant);

            //Act
            await _service.UpdateParticipant(updatedParticipant);
            var shouldBeUpdated = await _repository.GetParticipantById(id);

            //Assert
            Assert.AreEqual(shouldBeUpdated.Name, updatedParticipant.Name);
        }
    }
}