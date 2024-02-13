using System;

namespace ContactBookApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var _contactBookService = new ContactBookService();
            bool programIsRunning = true;

            ConsoleHelper.WriteLine("Contact Book");

            while (programIsRunning)
            {

                ConsoleHelper.WriteLine("\nSelect operation");
                ConsoleHelper.WriteLine("[1] Insert Contact");
                ConsoleHelper.WriteLine("[2] Delete Contact");
                ConsoleHelper.WriteLine("[3] Edit Contact");
                ConsoleHelper.WriteLine("[4] List all Contacts");
                ConsoleHelper.WriteLine("[5] View Contact");
                ConsoleHelper.WriteLine("[x] Exit Application");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        ConsoleHelper.WriteLine("Insert Contact");
                        ConsoleHelper.WriteLine("Enter First Name:");
                        var fNameInput = Console.ReadLine();
                        ConsoleHelper.WriteLine("Enter Last Name:");
                        var lNameInput = Console.ReadLine();
                        ConsoleHelper.WriteLine("Enter Phone number:");
                        var phoneNumberInput = Console.ReadLine();
                        ConsoleHelper.WriteLine("Enter Email:");
                        var email = Console.ReadLine();
                        ConsoleHelper.WriteLine("Enter Address:");
                        var address = Console.ReadLine();

                        var newContact = new ContactModel()
                        {
                            FirstName = fNameInput,
                            LastName = lNameInput,
                            PhoneNumber = phoneNumberInput,
                            Email = email,
                            Address = address
                        };

                        _contactBookService.InsertContact(newContact);
                        break;

                    case "2":
                        ConsoleHelper.WriteLine("Delete Contact");
                        ConsoleHelper.WriteLine("Enter Phone number to delete:");
                        phoneNumberInput = Console.ReadLine();

                        _contactBookService.DeleteContact(phoneNumberInput);
                        break;
                    case "3":
                        ConsoleHelper.WriteLine("Edit Contact (You can edit Email and Address)");
                        ConsoleHelper.WriteLine("Enter Phone number to edit:");
                        phoneNumberInput = Console.ReadLine();
                        
                        //check if contact exist before allowing user to enter email and address.
                        bool contactExist = _contactBookService.CheckExistenceByPhone(phoneNumberInput);

                        if (contactExist)
                        {
                            ConsoleHelper.WriteLine("Enter Email:");
                            email = Console.ReadLine();
                            ConsoleHelper.WriteLine("Enter Address:");
                            address = Console.ReadLine();

                            UpdateContactModel updateModel = new UpdateContactModel()
                            {
                                PhoneNumber = phoneNumberInput,
                                Email = email,
                                Address = address
                            };

                            _contactBookService.UpdateContact(updateModel);
                        }
                        else
                        {
                            ConsoleHelper.WriteLine("Contact does not exist.", false);
                        }
                        
                        break;
                    case "4":
                        ConsoleHelper.WriteLine("View All Contact");
                        _contactBookService.DisplayAllContacts();
                        break;
                    case "5":
                        ConsoleHelper.WriteLine("View Contact");
                        ConsoleHelper.WriteLine("Enter Phone number to view:");
                        phoneNumberInput = Console.ReadLine();

                        _contactBookService.DisplayContactByPhoneNumber(phoneNumberInput);
                        break;
                    case "x":
                        programIsRunning = false;
                        break;
                    default:
                        ConsoleHelper.WriteLine("Select valid operation.\n");
                        break;
                }
            }
            
        }
    }
}
