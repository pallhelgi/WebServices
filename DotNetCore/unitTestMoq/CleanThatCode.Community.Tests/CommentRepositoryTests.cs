using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Tests.Mocks;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Interfaces;
using System.Linq;

namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class CommentRepositoryTests
    {
        private ICommentRepository _commentRepo;

        [TestInitialize]
        public void Initialize()
        {
            ICleanThatCodeDbContext cleanThatCodeDbContextMock = new CleanThatCodeDbContextMock();
            _commentRepo = new CommentRepository(cleanThatCodeDbContextMock);
        }

        [TestMethod]
        public void GetAllCommentsByPostId_GivenWrongPostId_ShouldReturnNoComments()
        {
            var results = _commentRepo.GetAllCommentsByPostId(-1);
            Assert.AreEqual(0, results.Count());
                    
        }

        [TestMethod]
        public void GetAllCommentsByPostId_GivenValidPostId_ShouldReturnTwoComments()
        {
            var results = _commentRepo.GetAllCommentsByPostId(1);
            Assert.AreEqual(2, results.Count());
        }
    }
}