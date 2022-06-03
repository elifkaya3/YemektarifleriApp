using YemekTarifleriApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifleriApp.Data.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new RecipeAppContext();
            if (context.Database.GetPendingMigrations().Count() == 0) 
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }
                if (context.Recipes.Count() == 0)
                {
                    context.Recipes.AddRange(Recipes);
                }
                if (context.Members.Count() == 0)
                {
                    context.Members.AddRange(Members);
                }
                if (context.RecipeCategories.Count() == 0)
                {
                    context.RecipeCategories.AddRange(RecipeCategories);
                }
                if (context.RecipeMembers.Count() == 0)
                {
                    context.RecipeMembers.AddRange(RecipeMembers);
                }
                context.SaveChanges();

            }
        }
        private static Category[] Categories = 
        {
            new Category() { CategoryName ="Etli Yemekler", Url="etli-yemek"},
            new Category() { CategoryName="Kurabiye Tarifleri",Url="kurabiye-tarifleri"},
            new Category() { CategoryName="Hamur İşi Tarifleri",Url="hamur-isi-tarifleri"},
            new Category() { CategoryName="Makarna Tarifleri",Url="makarna-tarifleri"},
            new Category() { CategoryName="tatlı Tarifleri",Url="tatlı-tarifleri"},
            new Category() { CategoryName="Sebze Yemekleri",Url="sebze-yemekleri"},
            new Category() { CategoryName="Diyet Yemekleri",Url="diyet-yemekleri"},
            new Category() { CategoryName="İçecek Tarifleri",Url="icecek-tarifleri"}
        };

        private static Recipe[] Recipes =
        {
            new Recipe() {RecipeName="İçli Köfte", RecipeMaterial="2 su bardağı köftelik bulgur,1 çay bardağı irmik,3 su bardağı sıcak su,1 çay bardağı un,1 adet yumurta,1 tatlı kaşığı biber salçası,Pul biber,Karabiber,Tuz", RecipeDescription="İçli köftenin hamurunu elimizle ince şekilde açtıktan sonra iç harcını doldurup kızgın yağda kızartıyoruz.",  Url="icli-kofte"},
            new Recipe() {RecipeName="Elmalı Kurabiye", RecipeMaterial="3 su bardağı un,250 gram oda ısısında tereyağı veya margarin,1 yemek kaşığı yoğurt,1 çay kaşığı kabartma tozu,1 limon kabuğu rendesi (isteğe bağlı),1 kahve fincanı pudra şekeri", RecipeDescription="Kurabiyenin Hamurunu yağ, un ve içine diğer malzemeleri karıştırarak yoğuralım.Üçgen şekilinde kesip elmalı harcı içine dolduralım.", Url="elmalı-kurabiye"},
            new Recipe() {RecipeName="Kahvaltılık Krep", RecipeMaterial="2 adet yumurta,2 su bardağından biraz az un,2 su bardağı süt,1 çay kaşığı tuz,pişirmek için tereyağı veya sıvı yağ", RecipeDescription="Un,süt yumurta çırpılarak ısıtılmış tavaya dökülür.", Url="kahvaltılık-krep"},
            new Recipe() {RecipeName="Kabak Spagetti", RecipeMaterial="4 adet orta boy kabak,4 yemek kaşığı zeytinyağı,Tuz", RecipeDescription="Kabaklar ince ince soyulur ve özel soslarıyla kaynar suda pişirilir.", Url="kabak-spagetti"},
            new Recipe() {RecipeName="Fırın Sütlaç", RecipeMaterial="1 litre Süt, 4 kaşık nişasta, 1 paket krema,1 su bardağı şeker,1 su bardağı pirinç", RecipeDescription="Tüm malzemeleri büyük bir tencereye atıp kaynayana kadar karıştıralım.", Url="fırın-sütla."},
            new Recipe() {RecipeName="Karnabahar Kızartması", RecipeMaterial="1 adet orta boy karnabahar,2 yumurta,tuz,un", RecipeDescription="Karnabaharları iyice Yıkadıktan sonra una ve yumurtaya bulayıp kızgın yağda kızartalım.", Url="karnabahar-kızartaması"},
            new Recipe() {RecipeName="Ton Balıklı Salata", RecipeMaterial="Ton balığı, marul, zeytin, mısır,çeri domates,zeytinyağı,tuz", RecipeDescription="Malzmeleri iri iri doğaryıp büyük bir kapta karıştırıp yağlayalım.", Url="ton-balıklı-salata"},
            new Recipe() {RecipeName="Limonata", RecipeMaterial="Limon,şeker,su", RecipeDescription="Limonları iyice sıkıp suyunu çıkartalım.Ardından şeker ve suyla karıştıralım", Url="limonata"}
        };

        private static Member[] Members =
        {
            new Member() {MemberName="Aslı Kale", MemberMail="aslı@gmail.com", MemberUserName="asli78"},
            new Member() {MemberName="Doğu Batı", MemberMail="dogu@gmail.com", MemberUserName="dogubatı"},
            new Member() {MemberName="Sale Mertkan", MemberMail="sale@gmail.com", MemberUserName="sale89sale"},
            new Member() {MemberName="Aybüke Serttaş", MemberMail="aybüke@gmail.com", MemberUserName="aybüs.serttas"},
            new Member() {MemberName="Melis Yüce", MemberMail="melis@gmail.com", MemberUserName="yuce_melis"},
            new Member() {MemberName="Batu Hasan Can", MemberMail="batu@gmail.com", MemberUserName="canBatu"}
        };

        private static RecipeCategory[] RecipeCategories =
        {
            new RecipeCategory() {Recipe=Recipes[0], Category=Categories[0]},
            new RecipeCategory() {Recipe=Recipes[1], Category=Categories[1]},
            new RecipeCategory() {Recipe=Recipes[2], Category=Categories[2]},
            new RecipeCategory() {Recipe=Recipes[3], Category=Categories[3]},
            new RecipeCategory() {Recipe=Recipes[4], Category=Categories[4]},
            new RecipeCategory() {Recipe=Recipes[5], Category=Categories[5]},
            new RecipeCategory() {Recipe=Recipes[6], Category=Categories[6]},
            new RecipeCategory() {Recipe=Recipes[7], Category=Categories[7]}
        };

        private static RecipeMember[] RecipeMembers =
        {
            new RecipeMember() {Recipe=Recipes[0], Member=Members[0]},
            new RecipeMember() {Recipe=Recipes[1], Member=Members[0]},
            new RecipeMember() {Recipe=Recipes[2], Member=Members[0]},
            new RecipeMember() {Recipe=Recipes[3], Member=Members[1]},
            new RecipeMember() {Recipe=Recipes[4], Member=Members[1]},
            new RecipeMember() {Recipe=Recipes[5], Member=Members[1]},
            new RecipeMember() {Recipe=Recipes[6], Member=Members[2]},
            new RecipeMember() {Recipe=Recipes[7], Member=Members[2]},
            new RecipeMember() {Recipe=Recipes[0], Member=Members[2]},
            new RecipeMember() {Recipe=Recipes[1], Member=Members[3]},
            new RecipeMember() {Recipe=Recipes[2], Member=Members[3]},
            new RecipeMember() {Recipe=Recipes[3], Member=Members[3]},
            new RecipeMember() {Recipe=Recipes[4], Member=Members[4]},
            new RecipeMember() {Recipe=Recipes[5], Member=Members[4]},
            new RecipeMember() {Recipe=Recipes[6], Member=Members[5]},
            new RecipeMember() {Recipe=Recipes[7], Member=Members[5]},
            new RecipeMember() {Recipe=Recipes[0], Member=Members[4]},
            new RecipeMember() {Recipe=Recipes[1], Member=Members[2]}
        };
    }
}
