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
		public DbSet<User> User { get; set; }
	}
}
