using Microsoft.EntityFrameworkCore;

namespace contactList_BE.Data.Tables
{
	[Index(nameof(Email), IsUnique = true)]
	public class Contact
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int CategoryID { get; set; }
        public Category Category { get; set; }
		public int? SubCategoryID { get; set; }
        public SubCategory? SubCategory { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
