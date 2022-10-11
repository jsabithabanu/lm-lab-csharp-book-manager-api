using BookManagerApi.Models;

namespace BookManagerApi.Services
{
	public class BookManagementService : IBookManagementService
	{
        private readonly BookContext _context;

        public BookManagementService(BookContext context)
        {
            _context = context;
        }


        public List<Book> GetAllBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
          
        }

        public Book Update(long id, Book book)
        {
            var existingBookFound = FindBookById(id);

            existingBookFound.Title = book.Title;
            existingBookFound.Description = book.Description;
            existingBookFound.Author = book.Author;
            existingBookFound.Genre = book.Genre;

            _context.SaveChanges();
            return book;
        }

        //Tried to return a message with book name as a string
        public string DeleteBook(long id)
        {
            var existingBookFound = FindBookById(id);
            var bookTitle = existingBookFound.Title;
            _context.Books.Remove(existingBookFound);
            _context.SaveChanges();
            return bookTitle;
        }

        //Delete method without any return message to the user
        public bool Delete(long id)
        {
            var existingBookFound = FindBookById(id);
            _context.Books.Remove(existingBookFound);
            _context.SaveChanges();
            return true;
        }

        public Book FindBookById(long id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        public bool BookExists(long id)
        {
            return _context.Books.Any(b => b.Id == id);
        }
    }
}

