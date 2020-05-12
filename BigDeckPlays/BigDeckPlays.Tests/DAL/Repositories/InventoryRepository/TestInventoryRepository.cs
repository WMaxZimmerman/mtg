using Microsoft.VisualStudio.TestTools.UnitTesting;
using repos = BigDeckPlays.DAL.Repositories;
using BigDeckPlays.Shared.Models;
using Moq;
using System;

namespace BigDeckPlays.Tests.DAL.Repositories.InventoryRepository
{
    [TestClass]
    public class TestInventoryRepository
    {
        protected Mock<repos.IFileRepository> _mockFile;        
        protected repos.InventoryRepository _repo;
        protected Random _randy;

        [TestInitialize]
        public virtual void Init()
        {
            _mockFile = new Mock<repos.IFileRepository>();
            _repo = new repos.InventoryRepository(_mockFile.Object);
            _randy = new Random();
        }

        protected Card RandomCard()
        {
            return new Card
            {
                Name = Guid.NewGuid().ToString(),
            };
        }
    }
}
