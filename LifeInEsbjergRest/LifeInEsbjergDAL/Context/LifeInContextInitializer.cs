using LifeInEsbjergDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergDAL.Context
{
    public class LifeInContextInitializer : DropCreateDatabaseAlways<LifeInContext>
    {

        protected override void Seed(LifeInContext context)
        {
            IList<Company> companies = new List<Company>();

            Category category0 = context.Categories.Add(new Category() { Id = 0, Name = "ALL" });
            Category category1 = context.Categories.Add(new Category() { Id = 1, Name = "Bank" });
            Category category2 = context.Categories.Add(new Category() { Id = 2, Name = "Plumber" });
            Category category3 = context.Categories.Add(new Category() { Id = 3, Name = "Electrician" });
            Category category4 = context.Categories.Add(new Category() { Id = 4, Name = "Electronics" });
            Category category5 = context.Categories.Add(new Category() { Id = 5, Name = "Offshore" });
            Category category6 = context.Categories.Add(new Category() { Id = 6, Name = "Grocery store" });
            Category category7 = context.Categories.Add(new Category() { Id = 7, Name = "Coffee shop" });
            Category category8 = context.Categories.Add(new Category() { Id = 8, Name = "Hair salon" });

            Rating rating1 = context.Ratings.Add(new Rating() { Id = 1, CustomerService = 10, Quality = 8, Price = 9, OverAll = 8 });
            Rating rating2 = context.Ratings.Add(new Rating() { Id = 2, CustomerService = 9, Quality = 7, Price = 8, OverAll = 8 });
            Rating rating3 = context.Ratings.Add(new Rating() { Id = 3, CustomerService = 9, Quality = 10, Price = 5, OverAll = 8 });
            Rating rating4 = context.Ratings.Add(new Rating() { Id = 4, CustomerService = 6, Quality = 7, Price = 4, OverAll = 5 });
            Rating rating5 = context.Ratings.Add(new Rating() { Id = 5, CustomerService = 10, Quality = 8, Price = 9, OverAll = 8 });
            Rating rating6 = context.Ratings.Add(new Rating() { Id = 6, CustomerService = 9, Quality = 7, Price = 8, OverAll = 8 });
            Rating rating7 = context.Ratings.Add(new Rating() { Id = 7, CustomerService = 9, Quality = 10, Price = 5, OverAll = 8 });
            Rating rating8 = context.Ratings.Add(new Rating() { Id = 8, CustomerService = 6, Quality = 7, Price = 4, OverAll = 5 });
            Rating rating9 = context.Ratings.Add(new Rating() { Id = 9, CustomerService = 10, Quality = 8, Price = 9, OverAll = 8 });
            Rating rating10 = context.Ratings.Add(new Rating() { Id = 10, CustomerService = 9, Quality = 7, Price = 8, OverAll = 8 });
            Rating rating11 = context.Ratings.Add(new Rating() { Id = 11, CustomerService = 9, Quality = 10, Price = 5, OverAll = 8 });
            Rating rating12 = context.Ratings.Add(new Rating() { Id = 12, CustomerService = 6, Quality = 7, Price = 4, OverAll = 5 });



            Review rev1 = context.Reviews.Add(new Review() { Id = 1, Title = "Great Stuff", Text = "I like the overall experience" });
            Review rev2 = context.Reviews.Add(new Review() { Id = 2, Title = "Awfull", Text = "Very very bad experience" });
            Review rev3 = context.Reviews.Add(new Review() { Id = 3, Title = "Good", Text = "I like the overall experience" });
            Review rev4 = context.Reviews.Add(new Review() { Id = 4, Title = "Baaad", Text = "Very very bad experience" });
            Review rev5 = context.Reviews.Add(new Review() { Id = 5, Title = "Yeees", Text = "I like the overall experience" });
            Review rev6 = context.Reviews.Add(new Review() { Id = 6, Title = "craap", Text = "Very very bad experience" });



            Tag tag1 = context.Tags.Add(new Tag() { Id = 1, Name = "tomato" });
            Tag tag2 = context.Tags.Add(new Tag() { Id = 2, Name = "cheap" });
            Tag tag3 = context.Tags.Add(new Tag() { Id = 3, Name = "men hair cutting" });
            Tag tag4 = context.Tags.Add(new Tag() { Id = 4, Name = "good value" });
            Tag tag5 = context.Tags.Add(new Tag() { Id = 5, Name = "ship" });
            //Customer customer1 = context.Customers.Add(new Customer() { Id = 1, Name = "Kim Cormen", Email = "Google@google.tinfoil", Password = "1234abcd" });

            companies.Add(new Company()
            {
                CVR = 23598712,
                Name = "JensBank",
                ImageUrl = "data:image/png;base64,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",
                Address = "Stormgade66",
                WebSite = "www.jensbank.dk",
                Tel = "+45959595",
                OpenHours = "9-10",
                MinPrice = 500,
                MaxPrice = 1000,
                Description = "Small local bank",
                Category = category1,
                Ratings = new List<Rating>() { rating1 },
                Reviews = new List<Review>() { rev1 },
                Tags = new List<Tag>() { tag1, tag2, tag3 },
                NrRate = 1

            });
            companies.Add(new Company()
            {
                CVR = 83534712,
                Name = "iPhone fix",
                ImageUrl = "http://reginaiphonerepair.ca/wp-content/uploads/2015/04/applebroken2.jpg",
                Address = "Ingemanns Alle 69",
                WebSite = "www.iPhonefix.dk",
                Tel = "+45897720",
                OpenHours = "9-6",
                MinPrice = 500,
                MaxPrice = 2500,
                Description = "Innovative iphone fixing",
                Category = category4,
                Ratings = new List<Rating>() { rating2, rating3 },
                Reviews = new List<Review>() { rev2 },
                Tags = new List<Tag>() { tag4 },
                NrRate = 2

            });

            companies.Add(new Company()
            {
                CVR = 87998712,
                Name = "OK Offshore shippments",
                ImageUrl = "https://s-media-cache-ak0.pinimg.com/236x/47/32/6c/47326c1fe194bc01cfb85de60e166be4.jpg",
                Address = "Harper road 1",
                WebSite = "www.OkShipping.dk",
                Tel = "+45855721",
                OpenHours = "8-8",
                MinPrice = 5000,
                MaxPrice = 100000,
                Description = "Safe Shipping all the way!",
                Category = category5,
                Ratings = new List<Rating>() { rating4, rating5, rating6 },
                Reviews = new List<Review>() { rev3 },
                Tags = new List<Tag>() { tag1, tag4, tag5 },
                NrRate = 3

            });

            companies.Add(new Company()
            {
                CVR = 13597812,
                Name = "The Shopping cart",
                ImageUrl = "http://www.clipartbest.com/cliparts/nTE/qg8/nTEqg8bTA.jpeg",
                Address = "Skolegade 89",
                WebSite = "www.Shopcart.dk",
                Tel = "+45854116",
                OpenHours = "10-8",
                MinPrice = 10,
                MaxPrice = 1000,
                Description = "Shop with us and get a free cart!",
                Category = category6,
                Ratings = new List<Rating>() { rating7, rating8 , rating9 },
                Reviews = new List<Review>() { rev4 },
                Tags = new List<Tag>() { tag4, tag5, tag3 },
                NrRate = 3

            });

            companies.Add(new Company()
            {
                CVR = 65598712,
                Name = "Coffeee2go!",
                ImageUrl = "http://living.sas.cornell.edu/living/dine/wheretoeat/orderahead/images/coffee2go-logo.jpg",
                Address = "Skolegade 89",
                WebSite = "www.c2go.dk",
                Tel = "+40101010",
                OpenHours = "6-10",
                MinPrice = 30,
                MaxPrice = 150,
                Description = "On the run and need fuel? Come by and crab acup today!",
                Category = category7,
                Ratings = new List<Rating>() { rating10 },
                Reviews = new List<Review>() { rev5 },
                Tags = new List<Tag>() { tag5 },
                NrRate = 1

            });


            companies.Add(new Company()
            {
                CVR = 78598712,
                Name = "Wild hair",
                ImageUrl = "https://stocklogos-pd.s3.amazonaws.com/styles/logo-medium-alt/logos/image/cb5719494a08e764c8e051cac90065d9.png?itok=kjyW4wJl",
                Address = "Spangsbjerg Kirkevej 100 A",
                WebSite = "www.Wildhair.dk",
                Tel = "+41626289",
                OpenHours = "8-7",
                MinPrice = 150,
                MaxPrice = 500,
                Description = "Dedicaded hair salon for the wildness in your hair.",
                Category = category8,
                Ratings = new List<Rating>() { rating11, rating12 },
                Reviews = new List<Review>() { rev6 },
                Tags = new List<Tag>() { tag3,tag4 },
                NrRate = 2

            });

            foreach (Company com in companies)
                context.Companies.Add(com);



            base.Seed(context);
        }
    }
}