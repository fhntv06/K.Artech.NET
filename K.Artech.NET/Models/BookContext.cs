using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace K.Artech.NET.Models
{
    public class BookContext : DbContext
    {
        // создание базы данных
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        // при каждом запуске созданется таблица
        public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
        {
            // методы Seed, Add
            protected override void Seed(BookContext db)
            {
                db.Books.Add(new Book { Name = "Война и Мир", Author = "Л. Толстой", Price = 220 });
                db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
                db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });
    
                base.Seed(db);
            }
        }
    }
}
