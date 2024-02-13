using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ContactBookApp.Helpers;
using ContactBookApp.Models;

namespace ContactBookApp
{
    public class ContactBookService
    {
        ContactBookContext _contactBookContext;
        public ContactBookService() 
        {
            _contactBookContext = new ContactBookContext();
        }

        
        public int DisplayAllContacts()
        {
            try
            {
                var allContactsResult = _contactBookContext.GetAllContacts();
                if (allContactsResult.Success && allContactsResult.Data != null && allContactsResult.Data.Count > 0)
                {
                    foreach (ContactModel contact in allContactsResult.Data)
                    {
                        ConsoleHelper.WriteLine(
                            $"Contact: {contact.FirstName} {contact.LastName} | {contact.PhoneNumber} | " +
                            $"{contact.Email} | {contact.Address}"
                        );
                    }
                }
                else
                {
                    ConsoleHelper.WriteLine("No Contact is inserted yet.", false);
                }
                
                return allContactsResult.Data?.Count ?? 0;
            }
            catch 
            {
                ConsoleHelper.WriteLine("There is something wrong with the app.", false);
                return 0;
            }
        }
        public ContactModel? DisplayContactByPhoneNumber(string? phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber) || !phoneNumber.IsValidPhoneNumberFormat())
                {
                    ConsoleHelper.WriteLine("Phone number is invalid.\n");
                    return null;
                }
                else
                {
                    var contactResult = _contactBookContext.GetContactByPhone(phoneNumber);

                    if (contactResult.Success && contactResult.Data != null)
                    {
                        ConsoleHelper.WriteLine(
                            $"Contact: {contactResult.Data.FirstName} {contactResult.Data.LastName} | " +
                            $"{contactResult.Data.PhoneNumber} | {contactResult.Data.Email} | {contactResult.Data.Address}"
                        );
                    }
                    else
                    {
                        ConsoleHelper.WriteLine(contactResult.Message, false);
                    }
                    
                    return contactResult.Data;
                }
            }
            catch
            {
                ConsoleHelper.WriteLine("There is something wrong with the app.", false);
                return null;
            }
        }

        public bool InsertContact(ContactModel newContact)
        {
            try
            {
                //Empty values validation
                if (string.IsNullOrEmpty(newContact.FirstName) ||
                    string.IsNullOrEmpty(newContact.LastName) ||
                    string.IsNullOrEmpty(newContact.PhoneNumber) ||
                    string.IsNullOrEmpty(newContact.Email) ||
                    string.IsNullOrEmpty(newContact.Address))
                {
                    ConsoleHelper.WriteLine("Some field is empty.", false);
                    return false;
                }

                //Phone number format validation.
                else if (!newContact.PhoneNumber.IsValidPhoneNumberFormat())
                {
                    ConsoleHelper.WriteLine("Your phone number is invalid.", false);
                    return false;
                }

                //Email format validation
                else if (!newContact.Email.IsValidEmail())
                {
                    ConsoleHelper.WriteLine("Your email is invalid.", false);
                    return false;
                }
                else
                {
                    var addContactResult = _contactBookContext.AddContact(newContact);

                    ConsoleHelper.WriteLine(addContactResult.Message, addContactResult.Success);

                    return addContactResult.Success;
                }

            }
            catch
            {
                ConsoleHelper.WriteLine("There is something wrong with the app.", false);
                return false;
            }
        }

        public bool UpdateContact(UpdateContactModel updateContact)
        {
            try
            {
                if (string.IsNullOrEmpty(updateContact.PhoneNumber) || !updateContact.PhoneNumber.IsValidPhoneNumberFormat())
                {
                    ConsoleHelper.WriteLine("Phone number is invalid.", false);
                    return false;
                }
                else if (string.IsNullOrEmpty(updateContact.Email) || string.IsNullOrEmpty(updateContact.Address))
                {
                    ConsoleHelper.WriteLine("Some field is empty.", false);
                    return false;
                }
                else if (!updateContact.Email.IsValidEmail())
                {
                    ConsoleHelper.WriteLine("Email is invalid.", false);
                    return false;
                }
                else
                {
                    var deleteResult = _contactBookContext.UpdateContact(updateContact);

                    ConsoleHelper.WriteLine(deleteResult.Message, deleteResult.Success);

                    return deleteResult.Success;
                }
            }
            catch
            {
                ConsoleHelper.WriteLine("There is something wrong with the app.", false);
                return false;
            }
        }

        public bool DeleteContact(string? phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber) || !phoneNumber.IsValidPhoneNumberFormat())
                {
                    ConsoleHelper.WriteLine("Phone number is invalid.", false);
                    return false;
                }
                
                else
                {
                    var deleteResult = _contactBookContext.DeleteContactByPhone(phoneNumber);

                    ConsoleHelper.WriteLine(deleteResult.Message, deleteResult.Success);

                    return deleteResult.Success;
                }

            }
            catch
            {
                ConsoleHelper.WriteLine("There is something wrong with the app.", false);
                return false;
            }
        }

        public bool CheckExistenceByPhone(string? phoneNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber) || !phoneNumber.IsValidPhoneNumberFormat())
                {
                    return false;
                }
                else
                {
                    var contactResult = _contactBookContext.GetContactByPhone(phoneNumber);

                    return contactResult.Success;
                }

            }
            catch
            {
                ConsoleHelper.WriteLine("There is something wrong with the app.", false);
                return false;
            }
        }
    }
}
