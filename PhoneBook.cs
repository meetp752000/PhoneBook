using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase2
{
    class PhoneBook
    {
        private ArrayList contacts;
        private BinaryTree btContacts;
        private DeletedContacts deletedContacts;

        //constructor of phonebook
        public PhoneBook()
        {
            contacts = new ArrayList();
            btContacts = new BinaryTree();
            deletedContacts = new DeletedContacts();
        }

       //when this function is called, It Search for a contact where name == name from the arraylist and prints the name and the number
        public void searchByContacts(String name)
        {
            for (int i = 0; i < this.contacts.Count; i++)
            {
                Contact contact = (Contact)this.contacts[i];
                if (contact.name.Equals(name))
                {
                    Console.WriteLine("Name: {0}, Number: {1} ", contact.name, contact.number);
                }
            }
        }

        //This function loops though the arraylist to delete the desired contact and also stores the contact in a stack.
        public void deleteContacts(String name)
        {

            //Store deleted contacts into the deletedContacts
            for (int i = 0; i < this.contacts.Count; i++)
            {
                Contact contact = (Contact)this.contacts[i];
                if (contact.name.Equals(name))
                {
                    deletedContacts.addDeletedContacts(contact.name, contact.number);
                    Console.WriteLine("User deleted");
                }
            }

            //Deleting from the arrayList as well as the binary tree

            //check if the contact exist using the fast binary tree search
            Node checkUserExist = this.btContacts.Find(name);

            if (checkUserExist == null)
            {
                Console.WriteLine("There is no such a user named " + name);   
            }
            else
            {
                for (int i = 0; i < this.contacts.Count; i++)
                {
                    Contact contact = (Contact)this.contacts[i];
                    if (contact.name.Equals(name))
                    {
                        this.contacts.RemoveAt(i);
                    }
                }
                this.btContacts.Remove(name);
            }

        }

        //this function prints all the contacts with the number and name.
        public void displayContacts()
        {
            foreach(Contact contact in contacts)
            {
                Console.WriteLine("Name: {0}, Number: {1} \n", contact.name, contact.number);
            }

            if(contacts.Count == 0)
            {
                Console.WriteLine("There's no contacts in your contact list! ");
            }

        }

        //this is basically "get" displayDeletedContacts
        public void displayDeletedContacts()
        {
            deletedContacts.displayDeletedContacts();
        }

        //This fucntion lets you add a contact to the arraylist. Prints a error if the contact name already exists.
        public void addContacts(Contact contact)
        {
            Node checkUserExist = this.btContacts.Find(contact.name);

            if (checkUserExist == null)
            {
                this.contacts.Add(contact);
                this.btContacts.Add(contact.name);
            }
            else
            {
                Console.WriteLine("Username already exists, please try again with the different name!");
            }

        }

        //This search Function uses the Binarytree Search function to check if contact exists. Then prints the data or throw an error "User does not exisits"
        public void searchNameByBinary(String name)
        {
            Node node = this.btContacts.Find("cc");
            if (node != null) {
                Console.WriteLine("User " + node.Data + " found!");
            }
            else
            {
                Console.WriteLine("User does not exisits");
            }
        }

        public BinaryTree getBtContacts()
        {
            return btContacts;
        }




    }
}
