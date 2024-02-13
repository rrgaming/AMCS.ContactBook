using ContactBookApp;

namespace UnitTest.ContactBookServiceTest
{
    public class DisplayAllContactsTest
    {

        private ContactBookService _service = new ContactBookService();

        private void Init()
        {
            var model = new ContactModel()
            {
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "09162902850",
                Email = "test@gmail.com",
                Address = "Test"
            };

            _service.InsertContact(model);
        }

        [Fact]
        public void DisplayAllContacts_When_Success()
        {
            //arrange
            Init();

            //act
            int result = _service.DisplayAllContacts();

            //assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void DisplayAllContacts_When_EmptyList()
        {
            //arrange
            //Init();

            //act
            int result = _service.DisplayAllContacts();

            //assert
            Assert.Equal(0, result);
        }
    }
}