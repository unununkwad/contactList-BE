using contactList_BE.Data;
using contactList_BE.Data.Tables;
using contactList_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contactList_BE.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly DbCon db;
		public ContactsController(DbCon db)
		{
			this.db = db;
		}


		[HttpGet]
		public async Task<JsonResult> GetContacts() =>
			new JsonResult(await db.Contact.Include(a => a.Category).Include(a => a.SubCategory).Select(a => new ContactModel(a)).ToListAsync());

		[HttpGet]
		[Authorize]
		public async Task<JsonResult> GetCategories() =>
			new JsonResult(await db.Category.ToListAsync());

		[HttpGet]
		[Authorize]
		public async Task<JsonResult> GetSubCategories() =>
			new JsonResult(await db.SubCategory.Where(a => a.CategoryID == 1).ToListAsync());

		[HttpGet]
		[Authorize]
		public async Task<JsonResult> GetEmails() =>
			new JsonResult(await db.Contact.Select(a => a.Email).Distinct().ToListAsync());

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddContact(ContactModel contact)
		{
			// add subcategory if it not exist
			if (contact.CategoryID == 3)
			{
				SubCategory? subCategory = await db.SubCategory.Where(a => a.Name == contact.SubCategoryString).FirstOrDefaultAsync();
				if (subCategory == null)
				{
					SubCategory subCategoryToAdd = new()
					{
						Name = contact.SubCategoryString,
						CategoryID = 3,
					};
					db.Add(subCategoryToAdd);
					await db.SaveChangesAsync();

					contact.SubCategoryID = await db.SubCategory.Where(a => a.Name == contact.SubCategoryString).Select(a => a.ID).FirstOrDefaultAsync();
				}
				else
				{
					contact.SubCategoryID = subCategory.ID;
				}
			}

			// create contact
			Contact contactToAdd = new()
			{
				Name = contact.Name,
				LastName = contact.LastName,
				Email = contact.Email,
				Password = contact.Password,
				CategoryID = contact.CategoryID,
				SubCategoryID = contact.SubCategoryID,
				PhoneNumber = contact.PhoneNumber,
				BirthDate = DateTime.Parse(contact.BirthDate)
			};
			db.Add(contactToAdd);
			await db.SaveChangesAsync();

			return Ok();
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> EditContact(ContactModel contact)
		{
			// add subcategory if it not exist
			if (contact.CategoryID == 3)
			{
				SubCategory? subCategory = await db.SubCategory.Where(a => a.Name == contact.SubCategoryString).FirstOrDefaultAsync();
				if (subCategory == null)
				{
					SubCategory subCategoryToAdd = new()
					{
						Name = contact.SubCategoryString,
						CategoryID = 3,
					};
					db.Add(subCategoryToAdd);
					await db.SaveChangesAsync();

					contact.SubCategoryID = await db.SubCategory.Where(a => a.Name == contact.SubCategoryString).Select(a => a.ID).FirstOrDefaultAsync();
				}
				else
				{
					contact.SubCategoryID = subCategory.ID;
				}
			}

			// if contact exist, save changes
			Contact? contactToEdit = await db.Contact.Where(a => a.ID == contact.ID).FirstOrDefaultAsync();
			if (contactToEdit == null) return Problem();
			else
			{
				contactToEdit.Name = contact.Name;
				contactToEdit.LastName = contact.LastName;
				contactToEdit.Email = contact.Email;
				contactToEdit.Password = contact.Password;
				contactToEdit.CategoryID = contact.CategoryID;
				contactToEdit.SubCategoryID = contact.SubCategoryID;
				contactToEdit.PhoneNumber = contact.PhoneNumber;
				contactToEdit.BirthDate = DateTime.Parse(contact.BirthDate);

				db.Update(contactToEdit);
				await db.SaveChangesAsync();
			}
			return Ok();
		}

		[Authorize]
		[HttpDelete("{contactID}")]
		public async Task<IActionResult> DeleteContact(int contactID)
		{
			Contact? contactToDelete = await db.Contact.Where(a => a.ID == contactID).FirstOrDefaultAsync();
			if (contactToDelete == null) return Problem();

			db.Remove(contactToDelete);
			await db.SaveChangesAsync();

			return Ok();
		}
	}
}
