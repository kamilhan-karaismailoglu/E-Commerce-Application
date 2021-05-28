using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using HatemogluApp.Models;
using System.Threading.Tasks;

namespace HatemogluApp.Databases
{
    public class SepetDataBase
    {
        readonly SQLiteAsyncConnection _database;

        public SepetDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SepetUrun>().Wait();
        }

        public Task<List<SepetUrun>> GetUrunsAsync()
        {
            return _database.Table<SepetUrun>().ToListAsync();
        }

        public Task<int> SaveUrunAsync(SepetUrun urun)
        {
            if (urun.ID!=0)
            {
                return _database.UpdateAsync(urun);
            }
            else
            {
                return _database.InsertAsync(urun);
            }
        }
        public Task<SepetUrun> GetSepetUrunAsync(int index)
        {
            return _database.Table<SepetUrun>().Where(i => i.ID == index).FirstOrDefaultAsync();
        }
        public Task<int> DellUrunAsync(SepetUrun urun)
        {
            return _database.DeleteAsync(urun);
        }
        public Task<int> DellAllUrunAsync( )
        {
            return _database.DeleteAllAsync<SepetUrun>();
        }
        public Task<SepetUrun> GetNameAndBedenSepetUrunAsync(string name,string beden)
        {
            return _database.Table<SepetUrun>().Where(i => i.Baslik == name).Where(i => i.Beden == beden).FirstOrDefaultAsync();
        }
        public async Task<double> ToplamıHesapla()
        {
            double toplam = 0;
            var urunler = await _database.Table<SepetUrun>().ToListAsync();

            foreach (var item in urunler)
            {
                toplam += item.Toplam;
            }
            return toplam;
        }
    }
}