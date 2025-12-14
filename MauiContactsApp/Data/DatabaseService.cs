using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiContactsApp.Models;
using ContactModel = MauiContactsApp.Models.Contact;


namespace MauiContactsApp.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Models.Contact>().Wait();
        }

        public Task<List<Models.Contact>> GetContactsAsync() => _db.Table<Models.Contact>().ToListAsync();
        public Task<Models.Contact> GetContactAsync(int id) => _db.Table<Models.Contact>().Where(c => c.Id == id).FirstOrDefaultAsync();
        public Task<int> AddContactAsync(Models.Contact contact) => _db.InsertAsync(contact);
        public Task<int> UpdateContactAsync(Models.Contact contact) => _db.UpdateAsync(contact);
        public Task<int> DeleteContactAsync(Models.Contact contact) => _db.DeleteAsync(contact);
    }
}
