using ContactBookApp;

namespace UnitTest.ContactBookServiceTest
{
    public class UpdateContactTest
    {

        private ContactBookService _service = new ContactBookService();

        private void Init()
        {
            var model = new ContactModel()
            {
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "09162902850",
                Email = "old@gmail.com",
                Address = "Old Address"
            };

            _service.InsertContact(model);
        }

        [Fact]
        public void UpdateContact_When_Success()
        {
            //arrange
            Init();

            //act
            var newContact = new UpdateContactModel
            {
                PhoneNumber = "09162902850",
                Email = "new@gmail.com",
                Address = "New Address",
            };
           
            bool resultFlag = _service.UpdateContact(newContact);
            ContactModel? updatedResult = _service.DisplayContactByPhoneNumber(newContact.PhoneNumber);

            //assert
            Assert.True(resultFlag);
            Assert.NotNull(updatedResult);
            Assert.Equal(updatedResult.Email, newContact.Email);
            Assert.Equal(updatedResult.Address, newContact.Address);
        }

        [Fact]
        public void UpdateContact_When_InvalidPhoneNumber()
        {
            //arrange
            Init();

            //act
            var newContact = new UpdateContactModel
            {
                PhoneNumber = "091invalid",
                Email = "new@gmail.com",
                Address = "New Address",
            };

            bool resultFlag = _service.UpdateContact(newContact);

            //assert
            Assert.False(resultFlag);
        }

        [Fact]
        public void UpdateContact_When_InvalidEmail()
        {
            //arrange
            Init();

            //act
            var newContact = new UpdateContactModel
            {
                PhoneNumber = "09162902850",
                Email = "new_invalid",
                Address = "New Address",
            };

            bool resultFlag = _service.UpdateContact(newContact);

            //assert
            Assert.False(resultFlag);
        }

        [Fact]
        public void InsertContact_When_NotFound()
        {
            //arrange
            Init();

            //act
            var newContact = new UpdateContactModel
            {
                PhoneNumber = "09111111111",
                Email = "new@gmail.com",
                Address = "New Address",
            };

            bool resultFlag = _service.UpdateContact(newContact);

            //assert
            Assert.False(resultFlag);
        }
    }
}