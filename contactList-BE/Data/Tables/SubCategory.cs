namespace contactList_BE.Data.Tables
{
	public class SubCategory
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int CategoryID { get; set; }
        public Category Category { get; set; }
	}
}
