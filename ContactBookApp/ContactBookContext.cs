
using ContactBookApp.Models;

namespace ContactBookApp
{
    public class ContactBookContext
    {
        private List<ContactModel> Contacts { get; set; } = new List<ContactModel>();

        public ResponseModel<List<ContactModel>> GetAllContacts()
        {
            var result = new ResponseModel<List<ContactModel>>();
            try
            {
                result.Success = true;
                result.Data = Contacts;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseModel<ContactModel?> GetContactByPhone(string phoneNumber)
        {
            var result = new ResponseModel<ContactModel?>();
            try
            {
                var data = Contacts.FirstOrDefault(f => f.PhoneNumber == phoneNumber);
                if (data != null)
                {
                    result.Success = true;
                    result.Data = data;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Contact not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseModel<ContactModel?> AddContact(ContactModel contact)
        {
            var result = new ResponseModel<ContactModel?>();
            try
            {

                bool isExistingContact = Contacts.Any(f => f.PhoneNumber == contact.PhoneNumber);

                if (isExistingContact)
                {
                    result.Success = false;
                    result.Message = "Contact with this number already exist.";
                }
                else
                {
                    Contacts.Add(contact);
                    result.Success = true;
                    result.Message = "Contact was added successfully.";
                    result.Data = contact;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseModel<ContactModel?> UpdateContact(UpdateContactModel contact)
        {

            var result = new ResponseModel<ContactModel?>();
            try
            {
                var contactToUpdateIndex = Contacts.FindIndex(f => f.PhoneNumber == contact.PhoneNumber);
                if (contactToUpdateIndex != -1)
                {
                    Contacts[contactToUpdateIndex].Email = contact.Email;
                    Contacts[contactToUpdateIndex].Address = contact.Address;
                    result.Success = true;
                    result.Message = "Contact was updated successfully.";
                }
                else
                {
                    result.Success = false;
                    result.Message = "Contact not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResponseModel<ContactModel?> DeleteContactByPhone(string phoneNumber)
        {
            var result = new ResponseModel<ContactModel?>();
            try
            {
                var contactToDeleteIndex = Contacts.FindIndex(f => f.PhoneNumber == phoneNumber);
                if (contactToDeleteIndex != -1)
                {
                    Contacts.RemoveAt(contactToDeleteIndex);
                    result.Success = true;
                    result.Message = "Contact was deleted successfully.";
                }
                else
                {
                    result.Success = false;
                    result.Message = "Contact not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
            
        }
    }
}
