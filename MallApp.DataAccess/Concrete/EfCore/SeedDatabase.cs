using MallApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MallApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new MallContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);

                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategory);

                }
                context.SaveChanges();
            }


        }

        private static Category[] Categories =
        {
            new Category(){Name="Telefon"},
            new Category(){Name="TV"},
            new Category(){Name="Bilgisayar"},
            new Category(){Name="Tablet"}

        };

        private static Product[] Products =
        {
                new Product(){ Name="Samsung S6" , ImageUrl="1.jpg" ,Price=1000,Description="<p>Cok guzel bir telefon </p>" },
                new Product(){ Name="Samsung S7" , ImageUrl="2.jpg" ,Price=1000,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung S8" , ImageUrl="3.jpg" ,Price=1000,Description="<p>Cok guzel bir telefon </p>" },
                new Product(){ Name="Samsung S9" , ImageUrl="4.jpg" ,Price=1000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung S10" , ImageUrl="5.jpg" ,Price=1000,Description="<p>Cok guzel bir telefon </p>" },

                new Product(){ Name="Apple IPhone 6" , ImageUrl="6.jpg" ,Price=2000,Description="<p>Cok guzel bir telefon </p>" },
                new Product(){ Name="Apple IPhone 6S" , ImageUrl="7.jpg" ,Price=3000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Apple IPhone 7" , ImageUrl="8.jpg" ,Price=4000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Apple IPhone 8" , ImageUrl="9.jpg" ,Price=5000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Apple IPhone 9" , ImageUrl="10.jpg" ,Price=6000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Apple IPhone 10" , ImageUrl="11.jpg" ,Price=7000 ,Description="<p>Cok guzel bir telefon </p>"},

                new Product(){ Name="LG Akıllı TV 32' " , ImageUrl="12.jpg" ,Price=3000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="LG Akıllı TV 36' " , ImageUrl="13.jpg" ,Price=4000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung Akıllı TV 40' " , ImageUrl="14.jpg" ,Price=5000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung Akıllı TV 42'" , ImageUrl="15.jpg" ,Price=6000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung Akıllı TV 48'" , ImageUrl="16.jpg" ,Price=7000 ,Description="<p>Cok guzel bir telefon </p>"},

                new Product(){ Name="LG Akıllı Tablet 2' " , ImageUrl="17.jpg" ,Price=3000,Description="<p>Cok guzel bir telefon </p>" },
                new Product(){ Name="LG Akıllı Tablet 3 " , ImageUrl="18.jpg" ,Price=4000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung Tablet GALAXY " , ImageUrl="19.jpg" ,Price=5000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung Tablet 1" , ImageUrl="20.jpg" ,Price=6000 ,Description="<p>Cok guzel bir telefon </p>"},
                new Product(){ Name="Samsung Tablet  2" , ImageUrl="21.jpg" ,Price=7000,Description="<p>Cok guzel bir telefon </p>" }

        };

        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory(){Product = Products[0] , Category= Categories[0]},
            new ProductCategory(){Product = Products[1] , Category= Categories[0]},
            new ProductCategory(){Product = Products[2] , Category= Categories[0]},
            new ProductCategory(){Product = Products[3] , Category= Categories[0]},
            new ProductCategory(){Product = Products[4] , Category= Categories[0]},
            new ProductCategory(){Product = Products[5] , Category= Categories[0]},
            new ProductCategory(){Product = Products[6] , Category= Categories[0]},
            new ProductCategory(){Product = Products[7] , Category= Categories[0]},
            new ProductCategory(){Product = Products[8] , Category= Categories[0]},
            new ProductCategory(){Product = Products[9] , Category= Categories[0]},
            new ProductCategory(){Product = Products[10] , Category= Categories[0]},

            new ProductCategory(){Product = Products[11] , Category= Categories[1]},
            new ProductCategory(){Product = Products[12] , Category = Categories[1]},
            new ProductCategory(){Product = Products[13] , Category = Categories[1]},
            new ProductCategory(){Product = Products[14] , Category = Categories[1]},
            new ProductCategory(){Product = Products[15] , Category = Categories[1]},

            new ProductCategory(){Product = Products[16] , Category= Categories[3]},
            new ProductCategory(){Product = Products[17] , Category = Categories[3]},
            new ProductCategory(){Product = Products[18] , Category = Categories[3]},
            new ProductCategory(){Product = Products[19] , Category = Categories[3]},
            new ProductCategory(){Product = Products[20] , Category = Categories[3]},


    };
 }
}