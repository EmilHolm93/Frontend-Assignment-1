using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Models;
using SQLite;

namespace CarWorkshop.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Models.Workorder>().Wait();
            _database.CreateTableAsync<Models.Invoice>().Wait();
        }


        public Task<int> AddWorkorderAsync(Workorder workorder) => _database.InsertAsync(workorder);

        public Task<List<Workorder>> GetWorkordersByDateAsync(DateTime date) =>
            _database.Table<Workorder>().Where(j => j.HandinDate == date).ToListAsync();

        public Task<List<Workorder>> GetWorkordersAsync() =>
            _database.Table<Workorder>().ToListAsync();

        public Task<Workorder> GetJobByIdAsync(int jobId) => 
            _database.Table<Workorder>().FirstOrDefaultAsync(j => j.Id == jobId);

        public Task<int> AddInvoiceAsync(Invoice invoice) => _database.InsertAsync(invoice);

    }
}
