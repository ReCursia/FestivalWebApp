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
    public class FestivalServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _repository = new FestivalMockRepository();
            _service = new FestivalService(_repository);
        }

        private IFestivalService _service;
        private IFestivalRepository _repository;

        [Test]
        public async Task Should_Remove_Item_If_It_Exists()
        {
            //Arrange
            const int id = 100;
            var festival = new Festival
            {
                Name = "Test",
                Description = "TestDescription",
                Id = id
            };
            await _repository.AddFestival(festival);
            //Act
            await _service.RemoveFestival(id);
            //Assert
            Assert.IsFalse(await _repository.IsExist(id));
        }

        [Test]
        public void Should_Throw_Exception_When_No_Element_To_Update()
        {
            //Arrange
            const int id = 100;
            var festival = new Festival
            {
                Name = "Test",
                Description = "TestDescription",
                Id = id
            };
            //Act + assert
            Assert.ThrowsAsync<ElementNotFoundException>(async () => await _service.UpdateFestival(festival));
        }

        [Test]
        public void Should_Throw_Exception_When_Nothing_To_Remove()
        {
            //Arrange
            const int id = 100;
            //Act + assert
            Assert.ThrowsAsync<ElementNotFoundException>(async () => await _service.RemoveFestival(id));
        }

        [Test]
        public async Task When_Add_Festival_To_Repository_Should_Return_It_Back()
        {
            //Arrange
            const int id = 100;
            var festival = new Festival
            {
                Name = "Test",
                Description = "TestDescription",
                Id = id
            };

            //Act
            var result = await _service.AddFestival(festival);

            //Assert
            Assert.AreEqual(festival.Id, result.Id);
        }

        [Test]
        public async Task When_Update_Festival_In_Repository_Should_Return_It_Back()
        {
            //Arrange
            const int id = 100;
            var festival = new Festival
            {
                Name = "Test",
                Description = "TestDescription",
                Id = id
            };
            var updatedFestival = new Festival
            {
                Name = "Result",
                Description = "ResultDescription",
                Id = id
            };
            await _repository.AddFestival(festival);

            //Act
            await _service.UpdateFestival(updatedFestival);
            var shouldBeUpdated = await _repository.GetFestivalById(id);

            //Assert
            Assert.AreEqual(shouldBeUpdated.Name, updatedFestival.Name);
        }
    }
}