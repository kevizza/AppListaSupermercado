using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using AppListaSupermercado.Model;
using System.Threading.Tasks;

namespace AppListaSupermercado.Helper
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDataBaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Save(Produto t)
        {
            return _connection.InsertAsync(t);
        }

        public Task<List<Produto>> GetAllRows()
        {
            return _connection.Table<Produto>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _connection.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Update, fará a atualização no banco de dados. //
        public Task<List<Produto>> Update(Produto t)
        {
            string sql = "UPDATE produto SET " +
                         "Nome=?, Valor_Estimado=?, Valor_Pago=? " +
                         "WHERE Id=?";

            return _connection.QueryAsync<Produto>(sql,
                t.Nome, t.Valor_Estimado, t.Valor_Pago, t.Id);
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM produto WHERE Nome LIKE '%" + q + "%'";

            return _connection.QueryAsync<Produto>(sql);
        }
    }
}