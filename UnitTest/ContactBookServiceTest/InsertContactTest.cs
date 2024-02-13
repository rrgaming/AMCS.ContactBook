using ContactBookApp;

namespace UnitTest.ContactBookServiceTest
{
    public class InsertContactTest
    {

        private ContactBookService _service = new ContactBookService();

        
        [Fact]
        public void InsertContact_When_Success()
        {
            //act
            var newContact = new ContactModel
            {
                FirstName = "Ernesto",
                LastName = "Cirilo",
                PhoneNumber = "09162902851",
                Email = "ecirilo@gmail.com",
                Address = "Test",
            };
           
            bool resultFlag = _service.InsertContact(newContact);
            int resultCount = _service.DisplayAllContacts();

            //assert
            Assert.True(resultFlag);
            Assert.Equal(1, resultCount);
        }

        [Fact]
        public void InsertContact_When_InvalidPhoneNumber()
        {
            //act
            var newContact = new ContactModel
            {
                FirstName = "Ernesto",
                LastName = "Cirilo",
                PhoneNumber = "091invalid",
                Email = "ecirilo@gmail.com",
                Address = "Test",
            };

            bool resultFlag = _service.InsertContact(newContact);
            int resultCount = _service.DisplayAllContacts();

            //assert
            Assert.False(resultFlag);
            Assert.Equal(0, resultCount);
        }

        [Fact]
        public void InsertContact_When_InvalidEmail()
        {
            //act
            var newContact = new ContactModel
            {
                FirstName = "Ernesto",
                LastName = "Cirilo",
                PhoneNumber = "09162902851",
                Email = "ecirilo_invalid",
                Address = "Test",
            };

            bool resultFlag = _service.InsertContact(newContact);
            int resultCount = _service.DisplayAllContacts();

            //assert
            Assert.False(resultFlag);
            Assert.Equal(0, resultCount);
        }

        [Fact]
        public void InsertContact_When_ContactExist()
        {
            //act
            var newContact = new ContactModel
            {
                FirstName = "Ernesto",
                LastName = "Cirilo",
                PhoneNumber = "09162902851",
                Email = "ecirilo@gmail.com",
                Address = "Test",
            };

            //act
            var anothernContact = new ContactModel
            {
                FirstName = "Ernesto 2",
                LastName = "Cirilo 2",
                PhoneNumber = "09162902851",
                Email = "ecirilo2@gmail.com",
                Address = "Test2",
            };

            bool result1 = _service.InsertContact(newContact);
            bool result2 = _service.InsertContact(anothernContact);
            int resultCount = _service.DisplayAllContacts();

            //assert
            Assert.True(result1);
            Assert.False(result2);
            Assert.Equal(1, resultCount);
        }
    }
}