
namespace PhoneBook {
	
	class Contact {
		
		private static int CONTACTS_ID = 0;
		
		private int id;
		private string name;
		private string surname;
		private string number;
		
		public Contact(string name, string number) : this(name, number, string.Empty) {}
		
		public Contact(string name, string number, string surname){
			this.name = name;
			this.surname = surname;
			this.number = number;
			this.id = ++CONTACTS_ID;
		}
		
		public int Id { get { return id; } }
		public string Name { get { return name; } set { name = value; } }
		
		public string Surname { get { return surname; } set { surname = value; } }
		
		public string Number { get { return number; } set { number = value; } }
		
		
		
		public override bool Equals (object obj)
		{
			
			if (obj == null || this.GetType() != obj.GetType())
			{
				return false;
			}
			
			return this.id == ((Contact)obj).id;
		}
		
		public override string ToString(){
			return string.Format("{0}: {1}, {2} - {3}", id, name, surname, number);
		}
	}
	
	
}