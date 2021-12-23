using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            // Form1 de boşluğa tıklanarak buraya gelinebilir.
            // Ürünleri listeleyecek kodu yazalım:

            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList(); // Entity Framework te tabloya erişme, listeleme kodu. 
                // SQL bağlantımızı References taki App.config dosyasına yazıldı.
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product); // Veritabanına product ekle.
                context.SaveChanges(); // Değişikliği kaydet.

                /*
                var entity = context.Entry(product)
                entity.State = System.Data.Entity.EntityState.Added;   ***BU ŞEKİLDE DE EKLEME İŞLEMİ YAPILABİLİRDİ.
                */
            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product); // 
                entity.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges(); // Değişikliği kaydet.
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product); // 
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges(); // Değişikliği kaydet.
            }
        }


    }
}
