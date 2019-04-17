using System;
using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;

namespace CleanThatCode.Community.Tests.Mocks
{
    public class CleanThatCodeDbContextMock : ICleanThatCodeDbContext
    {
        public IEnumerable<Comment> Comments => FakeData.Comments;

        public IEnumerable<Post> Posts => FakeData.Posts;
    }
}