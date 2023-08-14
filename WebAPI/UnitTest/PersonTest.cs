using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using WebAPI.Interfaces;
using WebAPI.Model;

namespace UnitTest
{
    public class PersonTest
    {
        //Services/Repositories
        private readonly IPersonService _iPersonService;

        //Controllers
        private readonly PersonController _iPersonController;

        public PersonTest()
        {
            //Dependencies
            _iPersonService = A.Fake<IPersonService>(); //with FakeItEasy tool

            //SUT
            _iPersonController = new PersonController(_iPersonService);
        }

        [Fact]
        public void PersonController_GetPeople_ReturnListNotNull()
        {
            //Arrange
            var list = A.Fake<Task<List<Person>>>();
            A.CallTo(() => _iPersonService.GetAll()).Returns(list);

            //act
            var result = _iPersonController.GetPeople();

            //assert
            result.Should().BeOfType<Task<ActionResult<List<Person>>>>();
        }

        [Fact]
        public void PersonController_GetByIdAsync_returnPerson()
        {
            //Arrange
            var id = 1;
            var person = A.Fake<Person>();
            A.CallTo(() => _iPersonService.GetByIdAsync(id)).Returns(person);

            //act
            var result = _iPersonController.Detail(id);

            //assert
            result.Should().BeOfType<Task<ActionResult<Person>>>();
        }

        //[Theory]
        //[InlineData(1,1,2)]
        //[InlineData(2,2,4)]
        //public void GetPeople_ReturnListNotNull_2(int a, int b, int c)
        //{
        //    Task<List<Person>> list = _personService.GetPeople();

        //    list.Should().NotBeNull();
        //}

        [Fact]
        public void CreatePerson()
        {
            //Arrange
            var person = A.Fake<Person>(x => x.WithArgumentsForConstructor(() => new Person()));

            person.FirstName = "Jackie";
            person.LastName = "Chan";
            person.CreatedDate = DateTime.Now;
            person.Contacts = new List<Contact>()
                {
                    new Contact
                    {
                        IdPerson = 6,
                        Type = 2,
                        Text = "123456789",
                        CreatedDate = DateTime.Now
                    },
                    new Contact
                    {
                        IdPerson = 6,
                        Type = 3,
                        Text = "jackiechan@gmail.com",
                        CreatedDate = DateTime.Now
                    }
                };

            A.CallTo(() => _iPersonService.CreatePerson(person));

            A.CallTo(() => _iPersonService.GetByIdAsync(person.Id)).Returns(person);
            var result = _iPersonController.Detail(person.Id);

            //assert
            result.Should().BeOfType<Task<ActionResult<Person>>>();
        }

    }
}
