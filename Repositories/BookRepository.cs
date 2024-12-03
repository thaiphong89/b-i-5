using BookCRUD.Repositories;
using BookCRUD.Models;
using System.Linq;

namespace BookCRUD.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>();

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public void AddBook(Book book)
        {
            book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.Image = book.Image;
                existingBook.Price = book.Price;
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}