using RegistroPersona.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPersona.DataBase
{
    public class Data
    {
        readonly SQLiteAsyncConnection _database;

        public Data(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Persona>().Wait();
        }

        public Task<List<Persona>> GetPersonasAsync()
        {
            return _database.Table<Persona>().ToListAsync();
        }

        public Task<Persona> GetPersonaAsync(string cedula)
        {
            return _database.Table<Persona>().Where(i => i.Cedula == cedula).FirstOrDefaultAsync();
        }

        public Task<int> SavePersonaAsync(Persona persona)
        {
            return _database.InsertAsync(persona);
        }

        public Task<int> UpdatePersonaAsync(Persona persona)
        {
            return _database.UpdateAsync(persona);
        }

        public Task<int> DeletePersonaAsync(Persona persona)
        {
            return _database.DeleteAsync(persona);
        }
    }
}
