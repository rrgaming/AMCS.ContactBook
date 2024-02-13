using ContactBookApp;

namespace UnitTest.ContactBookServiceTest
{
    public class DeleteContactTest
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
        public void DeleteContact_When_Success()
        {
            //arrange
            Init();

            //act
            bool resultFlag = _service.DeleteContact("09162902850");
            int resultCount = _service.DisplayAllContacts();

            //assert
            Assert.True(resultFlag);
            Assert.Equal(0, resultCount);
        }

        [Fact]
        public void InsertContact_When_InvalidPhoneNumber()
        {
            //arrange
            Init();

            //act
            bool resultFlag = _service.DeleteContact("091invalid");

            //assert
            Assert.False(resultFlag);
        }

        [Fact]
        public void InsertContact_When_NotFound()
        {
            //arrange
            Init();

            //act
            bool resultFlag = _service.DeleteContact("09111111111");

            //assert
            Assert.False(resultFlag);
        }
    }
}