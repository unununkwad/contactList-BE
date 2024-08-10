using Microsoft.EntityFrameworkCore;
using contactList_BE.Data.Tables;

namespace contactList_BE.Data
{
	public class DbCon : DbContext
	{

		public DbCon(DbContextOptions<DbCon> options)
		: base(options)
		{
		}

		// classes from Tables folder
		public DbSet<User> User { get; set; }
		public DbSet<Contact> Contact { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<SubCategory> SubCategory { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// default data
			User admin = new User
			{
				ID = 1,
				UserName = "admin",
				Password = BCrypt.Net.BCrypt.HashPassword("password")
			};
			Category category1 = new Category
			{
				ID = 1,
				Name = "służbowy"
			};
			Category category2 = new Category
			{
				ID = 2,
				Name = "prywatny"
			};
			Category category3 = new Category
			{
				ID = 3,
				Name = "inny"
			};
			SubCategory subCategory1 = new SubCategory
			{
				ID = 1,
				Name = "szef",
				CategoryID = 1
			};
			SubCategory subCategory2 = new SubCategory
			{
				ID = 2,
				Name = "klient",
				CategoryID = 1
			};
			SubCategory subCategory3 = new SubCategory
			{
				ID = 3,
				Name = "kolega",
				CategoryID = 3
			};
			Contact contact1 = new Contact
			{
				ID = 1,
				Name = "Jakub",
				LastName = "Jastak",
				Email = "jakubjastak@gmail.com",
				Password = "BVzA;,3<W85D",
				CategoryID = 1,
				SubCategoryID = 1,
				PhoneNumber = "826171248",
				BirthDate = DateTime.Parse("1973-10-21"),
			};
			Contact contact2 = new Contact
			{
				ID = 2,
				Name = "Damian",
				LastName = "Mendak",
				Email = "damianmendak@gmail.com",
				Password = "0Be9##7[ueEa",
				CategoryID = 2,
				SubCategoryID = null,
				PhoneNumber = "350 736 024",
				BirthDate = DateTime.Parse("1985-11-11"),
			};
			Contact contact3 = new Contact
			{
				ID = 3,
				Name = "Aurelia",
				LastName = "Sochocka",
				Email = "aureliasochocka@gmail.com",
				Password = "F?cU~79:.l1u",
				CategoryID = 1,
				SubCategoryID = 2,
				PhoneNumber = "+48930384181",
				BirthDate = DateTime.Parse("1995-03-15"),
			};
			Contact contact4 = new Contact
			{
				ID = 4,
				Name = "Łukasz",
				LastName = "Filiks",
				Email = "lukaszfiliks@gmail.com",
				Password = "1[%H7i26j2bc",
				CategoryID = 2,
				SubCategoryID = null,
				PhoneNumber = "522-023-813",
				BirthDate = DateTime.Parse("2007-07-06"),
			};
			Contact contact5 = new Contact
			{
				ID = 5,
				Name = "Agnieszka",
				LastName = "Malarczyk",
				Email = "agnieszkamalarczyk@gmail.com",
				Password = "Hn_)6Pxe3=nK",
				CategoryID = 2,
				SubCategoryID = null,
				PhoneNumber = "340423962",
				BirthDate = DateTime.Parse("1946-10-08"),
			};
			Contact contact6 = new Contact
			{
				ID = 6,
				Name = "Sabina",
				LastName = "Prus",
				Email = "sabinaprus@gmail.com",
				Password = "k~/V<kg}0l/y",
				CategoryID = 3,
				SubCategoryID = 3,
				PhoneNumber = "329361319",
				BirthDate = DateTime.Parse("1959-07-02"),
			};
			Contact contact7 = new Contact
			{
				ID = 7,
				Name = "Mieczysław",
				LastName = "Wojtaszczyk",
				Email = "mieczyslawwojtaszczyk@gmail.com",
				Password = "/ixj{+xYFe7A",
				CategoryID = 1,
				SubCategoryID = 1,
				PhoneNumber = "276108577",
				BirthDate = DateTime.Parse("1981-07-06"),
			};
			Contact contact8 = new Contact
			{
				ID = 8,
				Name = "Lena",
				LastName = "Hałas",
				Email = "lenahalas@gmail.com",
				Password = ")%{1nEBiC+jq",
				CategoryID = 2,
				SubCategoryID = null,
				PhoneNumber = "895743201",
				BirthDate = DateTime.Parse("1987-09-03"),
			};
			Contact contact9 = new Contact
			{
				ID = 9,
				Name = "Benedykt",
				LastName = "Przybylski",
				Email = "benedyktprzybylski@gmail.com",
				Password = "KQN1_qn]Gm)/",
				CategoryID = 3,
				SubCategoryID = 3,
				PhoneNumber = "532330198",
				BirthDate = DateTime.Parse("1988-10-27"),
			};
			Contact contact10 = new Contact
			{
				ID = 10,
				Name = "Marcelina",
				LastName = "Cwynar",
				Email = "marcelinacwynar@gmail.com",
				Password = "44%BJIqBYPck",
				CategoryID = 1,
				SubCategoryID = 2,
				PhoneNumber = "461018986",
				BirthDate = DateTime.Parse("1962-07-25"),
			};


			modelBuilder.Entity<User>().HasData(new User[] { admin });
			modelBuilder.Entity<Category>().HasData(new Category[] { category1, category2, category3 });
			modelBuilder.Entity<SubCategory>().HasData(new SubCategory[] { subCategory1, subCategory2, subCategory3 });
			modelBuilder.Entity<Contact>().HasData(new Contact[] { contact1, contact2, contact3, contact4, contact5, contact6, contact7, contact8, contact9, contact10 });

			base.OnModelCreating(modelBuilder);
		}
	}
}
