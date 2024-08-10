
using contactList_BE.Data.Tables;

namespace contactList_BE.Models
{
	public class ContactModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int CategoryID { get; set; }
		public Category? Category { get; set; }
		public int? SubCategoryID { get; set; }
		public SubCategory? SubCategory { get; set; }
        public string SubCategoryString { get; set; }
		public string PhoneNumber { get; set; }
		public string BirthDate { get; set; }

		// create model from table class
		public ContactModel(Contact contact)
		{
			ID = contact.ID;
			Name = contact.Name;
			LastName = contact.LastName;
			Email = contact.Email;
			Password = contact.Password;
			CategoryID = contact.CategoryID;
			Category = contact.Category;
			SubCategoryID = contact.SubCategoryID;
			SubCategory = contact.SubCategory;
			PhoneNumber = contact.PhoneNumber;
			BirthDate = contact.BirthDate.ToString("dd.MM.yyyy");
		}

		public ContactModel()
		{
		}
	}
}
