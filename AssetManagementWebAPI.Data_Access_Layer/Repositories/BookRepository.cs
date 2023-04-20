using AssetManagementWebAPI.Data_Access_Layer.Context;
using AssetManagementWebAPI.Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Data_Access_Layer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AssetDBContext _assetContext;
        public BookRepository(AssetDBContext assetContext)
        {
            _assetContext = assetContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            var addBook = await _assetContext.AddAsync(book);
            await _assetContext.SaveChangesAsync();
            return addBook.Entity;
        }

        public async Task<Book> Assign(int id, string userName)
        {
            var findBook = await _assetContext.Books.FindAsync(id);
            if(findBook.AssignTo == null)
            {
                findBook.AssignTo = userName;
                await _assetContext.SaveChangesAsync();
                return findBook;
            }
            return findBook;
        }

        public async Task<Book> Delete(int id)
        {
            var findBook = await _assetContext.Books.FindAsync(id);
            _assetContext.Remove(findBook);
            await _assetContext.SaveChangesAsync();
            return findBook;
        }

        public async Task<List<Book>> Display()
        {
            var books = await _assetContext.Books.ToListAsync();
            return books;
        }

        public async Task<Book> Search(int id)
        {
            var findBook = await _assetContext.Books.FindAsync(id);
            return findBook;
        }

        public async Task<Book> UnAssign(int id)
        {
            var findBook = await _assetContext.Books.FindAsync(id);
            findBook.AssignTo = null;
            await _assetContext.SaveChangesAsync();
            return findBook;
        }

        public async Task<Book> Update(int id, Book book)
        {
            var findBook = await _assetContext.Books.FindAsync(id);
            findBook.BookName = book.BookName;
            findBook.BookAuthor = book.BookAuthor;
            findBook.DateOfPublish = book.DateOfPublish;
            findBook.AssignTo = book.AssignTo;

            await _assetContext.SaveChangesAsync();
            return findBook;
        }
    }
}
