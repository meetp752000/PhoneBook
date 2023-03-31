using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase2
{
    class Program
    {
        static void Main(string[] args)
        {

            PhoneBook phoneBook = new PhoneBook();


            int Select;
            bool running = true;

            while (running)
            {  

                Console.WriteLine("Pleases enter the numbers between 1 to 6\n");
                Console.WriteLine("\tPress 1 to add contact\n" +
                                  "\tPress 2 to delete contact\n" +
                                  "\tPress 3 to search contact\n" +
                                  "\tPress 4 to print the deleted contacts\n" +
                                  "\tPress 5 Display all contacts\n" +
                                  "\tPress 6 to quit the program\n\n"
                              );

                //The user can select The Following options using the "Select" Integer.
                Select = Convert.ToInt32(Console.ReadLine());

                //We store Number and name of each contact added to the porgram into and array list, Stack and binary tree.
                String name;
                String number;

                switch (Select)
                {
                    //case 1: lets the user enter a name and number of the contact they want to create
                    case 1:
                        Console.WriteLine("Enter the name: ");
                        name = Console.ReadLine();

                        Console.WriteLine("Enter the number: ");
                        number = Console.ReadLine();

                        phoneBook.addContacts(new Contact(name.ToLower(), number));
                        Console.WriteLine("\n");

                        break;

                    //case 2: Over here the user can delete the contacts. The user must enter the name of the user which they want to delete.
                    case 2:
                        Console.WriteLine("Enter the name: ");
                        name = Console.ReadLine();
                        phoneBook.deleteContacts(name.ToLower());
                        Console.WriteLine("\n");

                        break;

                    //case 3: The User can search the contact using there name to obtain their number.
                    case 3:
                        Console.WriteLine("Enter the name: ");
                        name = Console.ReadLine();
                        phoneBook.searchByContacts(name.ToLower());
                        Console.WriteLine("\n");

                        break;

                    //The user can see their deleted contacts history using this option 
                    case 4:
                        phoneBook.displayDeletedContacts();
                        Console.WriteLine("\n");

                        break;

                    //This prints all the Contacts, in 2 orders. added contacts and alphabetical order
                    case 5:

                        phoneBook.displayContacts();
                        phoneBook.getBtContacts().DisplayTree();

                        Console.WriteLine("\n");
                        break;

                    //This option lets you quit the porgram.
                    case 6:
                        running = false;
                        break;
                    
                    //if the user enters the wrong option it will error
                    default:
                        Console.WriteLine("You need to enter the right Input\n\n");
                        break;

                }

            }
        }

    }
}
