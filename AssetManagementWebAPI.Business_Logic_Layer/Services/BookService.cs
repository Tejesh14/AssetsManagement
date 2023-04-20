using AssetManagementWebAPI.Business_Logic_Layer.Interfaces;
using AssetManagementWebAPI.Data_Access_Layer;
using AssetManagementWebAPI.Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Business_Logic_Layer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBook(Book book)
        {
            return await _bookRepository.AddBook(book);
        }

        public async Task<Book> Assign(int id, string userName)
        {
            return await _bookRepository.Assign(id, userName);
        }

        public async Task<Book> Delete(int id)
        {
            return await _bookRepository.Delete(id);
        }

        public async Task<List<Book>> Display()
        {
            return await _bookRepository.Display();
        }

        public async Task<Book> Search(int id)
        {
            return await _bookRepository.Search(id);
        }

        public async Task<Book> UnAssign(int id)
        {
            return await _bookRepository.UnAssign(id);
        }

        public async Task<Book> Update(int id, Book book)
        {
            return await _bookRepository.Update(id, book);
        }
    }
}
