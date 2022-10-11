using System;
using BookManagerApi.Models;

namespace BookManagerApi.Services
{
	public interface IBookManagementService
	{
        List<Book> GetAllBooks();
        Book Create(Book book);
        Book Update(long id, Book book);
        Book FindBookById(long id);
        bool BookExists(long id);

        //Delete method to test from Test file
        bool Delete(long id);

        //Delete method to use in swaggar to display a return message
        string DeleteBook(long id);
    }
}
