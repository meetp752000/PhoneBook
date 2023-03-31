using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase2
{
    class DeletedContacts
    {
        private Stack<Contact> deletedContacts ;

        public DeletedContacts()
        {
            deletedContacts = new Stack<Contact>();
        }

        //This fucntion is called to stack the deleted contacts.
        public void addDeletedContacts(String name, String number)
        {
            deletedContacts.Push(new Contact(name, number));
        }

        //This function prints all the deleted contacts stored in the stack currently. the user then has the options to pop all the contacts if they want to delete the history.
        public void displayDeletedContacts()
        {
        
            foreach (Contact contact in deletedContacts)
            {
                Console.WriteLine("Name: {0}, Number: {1} ", contact.name, contact.number);
            }

         

            bool rightAnswer = false;
            
            if(deletedContacts.Count == 0)
            {
                rightAnswer = true;
                Console.WriteLine("There's no contacts in your contact list! ");

            }

            while (rightAnswer == false) {
                Console.WriteLine("Would you like to delete the deleted contacts history(y/n): ");
                String answer = Console.ReadLine();
                if (answer.ToLower().Equals("y"))
                {
               
                    while (deletedContacts.Count > 0)
                    {
                        deletedContacts.Pop();
                    }

                    rightAnswer = true;
                } else if (answer.ToLower().Equals("n"))
                {

                    rightAnswer = true;
                }
                else
                {
                    rightAnswer = false;
                    Console.WriteLine("You have entered an invalid value, please try again");
                }
            }



        }


    }
}
