using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Tests.Mocks;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Interfaces;
using CleanThatCode.Community.Models.Entities;
using FizzWare.NBuilder;
using Moq;
using System.Linq;

namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class PostRepositoryTests
    {
         private IPostRepository _postRepoMock;
         private Mock<ICleanThatCodeDbContext> cleanThatCodeDbContextMoq;

        [TestInitialize]
        public void Initialize()
        {
            cleanThatCodeDbContextMoq = new Mock<ICleanThatCodeDbContext>();

            cleanThatCodeDbContextMoq.Setup(method => method.Posts).Returns(
                FizzWare.NBuilder.Builder<Post>
                .CreateListOfSize(3)
                .TheFirst(2).With(x => x.Title = "Grayskull").With(x => x.Author = "He-Man")
                .TheNext(1).With(x => x.Title = "“Hack the planet!").With(x => x.Author = "“Richard Stallman")
                .Build());

            _postRepoMock = new PostRepository(cleanThatCodeDbContextMoq.Object);
        }

        [TestMethod]
        public void  GetAllPosts_NoFilter_ShouldContainAListOfThree()
        {
            var results = _postRepoMock.GetAllPosts("", "");
            Assert.AreEqual(3, results.Count());
        }
    }
}