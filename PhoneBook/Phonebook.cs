using System;
using System.Linq;
using System.Collections.Generic;

namespace PhoneBook
{
	
	class Phonebook {
		
		private List<Contact> contacts;
		
		public Phonebook(){
			this.contacts = new List<Contact>();
		}
		
		public List<Contact> AllContacts { get { return contacts; } }
		
		public void AddContact(string name, string number){
			contacts.Add(new Contact(name, number));
			contacts = contacts.OrderBy(x => x.Name.ToLower()).ToList();
		}
		
		public void AddContact(string name, string number, string surname){
			contacts.Add(new Contact(name, number, surname));
			contacts = contacts.OrderBy(x => x.Name.ToLower()).ToList();
		}
		
		public void Remove(int id){
			Contact c = contacts.Find(x => x.Id == id);
			contacts.Remove(c);
		}
		
		
		
	}
	
}