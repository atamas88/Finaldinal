using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeInEsbjergDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeInEsbjergDAL.DomainModel;
using LifeInEsbjergDAL.Context;

namespace LifeInEsbjergDAL.Repository.Tests
{
    [TestClass()]
    public class CompanyRepositoryTests
    {
        CompanyRepository repo = new CompanyRepository();

        List<Company> companies = new List<Company>();

        Category category0 = new Category() { Id = 0, Name = "ALL" };
        Category category1 = new Category() { Id = 1, Name = "Bank" };
        Category category2 = new Category() { Id = 2, Name = "Plumber" };
        Category category3 = new Category() { Id = 3, Name = "Electrician" };
        Category category4 = new Category() { Id = 4, Name = "Electronics" };
        Category category5 = new Category() { Id = 5, Name = "Offshore" };
        Category category6 = new Category() { Id = 6, Name = "Grocery store" };
        Category category7 = new Category() { Id = 7, Name = "Coffee shop" };
        Category category8 = new Category() { Id = 8, Name = "Hair salon" };

        Rating rating1 = new Rating() { Id = 1, CustomerService = 10, Quality = 8, Price = 9, OverAll = 8 };
        Rating rating2 = new Rating() { Id = 2, CustomerService = 9, Quality = 7, Price = 8, OverAll = 8 };
        Rating rating3 = new Rating() { Id = 3, CustomerService = 9, Quality = 10, Price = 5, OverAll = 8 };
        Rating rating4 = new Rating() { Id = 4, CustomerService = 6, Quality = 7, Price = 4, OverAll = 5 };
        Rating rating5 = new Rating() { Id = 5, CustomerService = 10, Quality = 8, Price = 9, OverAll = 8 };
        Rating rating6 = new Rating() { Id = 6, CustomerService = 9, Quality = 7, Price = 8, OverAll = 8 };
        Rating rating7 = new Rating() { Id = 7, CustomerService = 9, Quality = 10, Price = 5, OverAll = 8 };
        Rating rating8 = new Rating() { Id = 8, CustomerService = 6, Quality = 7, Price = 4, OverAll = 5 };
        Rating rating9 = new Rating() { Id = 9, CustomerService = 10, Quality = 8, Price = 9, OverAll = 8 };
        Rating rating10 = new Rating() { Id = 10, CustomerService = 9, Quality = 7, Price = 8, OverAll = 8 };
        Rating rating11 = new Rating() { Id = 11, CustomerService = 9, Quality = 10, Price = 5, OverAll = 8 };
        Rating rating12 = new Rating() { Id = 12, CustomerService = 6, Quality = 7, Price = 4, OverAll = 5 };


        Review rev1 = new Review() { Id = 1, Title = "Great Stuff", Text = "I like the overall experience" };
        Review rev2 = new Review() { Id = 2, Title = "Awfull", Text = "Very very bad experience" };
        Review rev3 = new Review() { Id = 3, Title = "Good", Text = "I like the overall experience" };
        Review rev4 = new Review() { Id = 4, Title = "Baaad", Text = "Very very bad experience" };
        Review rev5 = new Review() { Id = 5, Title = "Yeees", Text = "I like the overall experience" };
        Review rev6 = new Review() { Id = 6, Title = "craap", Text = "Very very bad experience" };



        Tag tag1 = new Tag() { Id = 1, Name = "tomato" };
        Tag tag2 = new Tag() { Id = 2, Name = "cheap" };
        Tag tag3 = new Tag() { Id = 3, Name = "men hair cutting" };
        Tag tag4 = new Tag() { Id = 4, Name = "good value" };
        Tag tag5 = new Tag() { Id = 5, Name = "ship" };

        Badge badge1 = new Badge { Id = 1, Name = "Excellence in Customer Service", ImgPath = "http://dab1nmslvvntp.cloudfront.net/wp-content/uploads/2014/11/1415490092badge.png" };
        Badge badge2 = new Badge { Id = 2, Name = "Excellence in Quality", ImgPath = "http://thumbs.dreamstime.com/z/winner-badge-81762.jpg" };
        Badge badge3 = new Badge { Id = 3, Name = "Excellence in Price", ImgPath = "https://pixabay.com/static/uploads/photo/2013/07/12/16/01/badge-150755_640.png" };
        Badge badge4 = new Badge { Id = 4, Name = "Overall Excellence", ImgPath = "http://www.vectorgraphit.com/wp-content/uploads/2013/09/vintage_badge.jpg" };



        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public List<Company> Companies()
        {
            using (var ctx = new LifeInContext())
            {
                return ctx.Companies.Include("Category").Include("Ratings").Include("Reviews").Include("Tags").Include("Badges").ToList();

            }
        }

        [TestMethod()]
        public void ReadAllTest()
        {

            List<Company> expected = Companies();
            List<Company> actual = repo.ReadAll();
            Assert.IsTrue(listcomparer(expected, actual));           
      //      Assert.IsTrue(Enumerable.SequenceEqual(expected.OrderBy(c => c.Id), actual.OrderBy(c => c.Id)));

        }
        [TestMethod()]
        public void AddandDeleteTest()
        {
            List<Company> expected = Companies();
            Company company = new Company()
            {
                CVR = 68598712,
                Name = "Wild hairy",
                Id = 7,
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
                Tags = new List<Tag>() { tag3, tag4 },
                NrRate = 2,
                Badges = new List<Badge> { }
            };

            expected.Add(company);
            repo.Add(company);
            List<Company> actual = repo.ReadAll();
            Company actuall = actual.Last();
            Assert.IsTrue(comparer(company, actuall));

            repo.Delete(company.Id);
            expected.Remove(company);

            Assert.IsTrue(listcomparer(repo.ReadAll(), expected));

        }
        [TestMethod]
        public void FindTest()
        {
            Company expected = new Company();
            companies = Companies();
            foreach (var item in companies)
            {
                if (item.Id == 1)
                {
                     expected = item;
                }

            }
            Company actual = repo.Find(1);

            Assert.IsTrue(comparer(expected, actual));


        }
        [TestMethod]
        public void EditTest()
        {
            Company company = repo.Find(1);
            company.Name = "Updated";
            repo.Edit(company);
            Company actual = repo.Find(1);
            Assert.IsTrue(comparer(company, actual));
        }

        public bool comparer(Company a, Company b)
        {
            if(a.Name == b.Name && a.Id == b.Id)
            {
                return true;
            }
            return false;
        }

        public bool listcomparer(List<Company> a, List<Company>b)
        {
            bool equals = true;
            if(a.Count() != b.Count())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.Count(); ++i)
                {
                    if (!comparer(a[i], b[i]))
                    {
                        equals = false;
                    }
                }
            }
            return equals;
        }

    }
}