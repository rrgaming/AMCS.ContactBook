using ContactBookApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Models
{
    public class ContactModelTest
    {
        [Fact]
        public void ContactModel_When_ModelIsValid()
        {
            //arrange
            var model = new ContactModel()
            {
                FirstName = "Fname",
                LastName = "Lname",
                PhoneNumber = "09162902852",
                Email = "test@email.com",
                Address = "Address"
            };

            //act
            ValidationHelper helper = new ValidationHelper();
            var validationResult = helper.ValidateModel(model);

            Assert.Empty(validationResult);
        }

        [Fact]
        public void ContactModel_When_PhoneNumberIsMax()
        {
            //arrange
            var model = new ContactModel()
            {
                FirstName = "Fname",
                LastName = "Lname",
                PhoneNumber = "09162902852123123132",
                Email = "test@email.com",
                Address = "Address"
            };

            //act
            ValidationHelper helper = new ValidationHelper();
            var validationResult = helper.ValidateModel(model);

            Assert.Equal(1, validationResult.Count);
        }

        [Fact]
        public void ContactModel_When_PhoneNumberIsMin()
        {
            //arrange
            var model = new ContactModel()
            {
                FirstName = "Fname",
                LastName = "Lname",
                PhoneNumber = "12345",
                Email = "test@email.com",
                Address = "Address"
            };

            //act
            ValidationHelper helper = new ValidationHelper();
            var validationResult = helper.ValidateModel(model);

            Assert.Equal(1, validationResult.Count);
        }
    }
}
