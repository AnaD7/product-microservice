using DevOpsMicroservices.Controllers;
using DevOpsMicroservices.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using Xunit;

namespace DevOpsMicroservicesTests
{
    public class ProductUnitTestController
    {
        private ProductRepository repository;
        public static DbContextOptions<ProductContext> dbContextOptions { get; }
        public static string connectionString = "Server=.\\LOCAL; Database=Catalog; Integrated Security=SSPI; ";

        public ProductUnitTestController()
        {
            var context = new ProductContext(dbContextOptions);
            DBTestDummyDataInitializer db = new DBTestDummyDataInitializer();
            db.Seed(context);

            repository = new ProductRepository(context);
        }

        [Fact]
        public async void Task_Delete_Post_Return_OkResult()
        {
            //Arrange  
            var controller = new ProductController(repository);
            var postId = 2;

            //Act  
            var data = controller.Delete(postId);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        static ProductUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProductContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
