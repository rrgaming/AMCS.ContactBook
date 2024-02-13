using ContactBookApp;

namespace UnitTest.ContactBookServiceTest
{
    public class DisplayContactsByPhoneNumberTest
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
        public void DisplayContactByPhoneNumber_When_Success()
        {
            //arrange
            Init();

            //act
            ContactModel? result = _service.DisplayContactByPhoneNumber("09162902850");

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void DisplayContactByPhoneNumber_When_NotFound()
        {
            //arrange
            Init();

            //act
            ContactModel? result = _service.DisplayContactByPhoneNumber("09111111111");

            //assert
            Assert.Null(result);
        }

        [Fact]
        public void DisplayContactByPhoneNumber_When_InvalidPhoneNumber()
        {
            //arrange
            Init();

            //act
            ContactModel? result = _service.DisplayContactByPhoneNumber("091invalid");

            //assert
            Assert.Null(result);
        }
    }
}