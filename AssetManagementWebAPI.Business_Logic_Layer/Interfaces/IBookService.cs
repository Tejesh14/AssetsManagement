using AssetManagementWebAPI.Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Business_Logic_Layer.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> Display();
        Task<Book> AddBook(Book book);
        Task<Book> Update(int id, Book book);
        Task<Book> Delete(int id);
        Task<Book> Search(int id);
        Task<Book> Assign(int id, string userName);
        Task<Book> UnAssign(int id);
    }
}
