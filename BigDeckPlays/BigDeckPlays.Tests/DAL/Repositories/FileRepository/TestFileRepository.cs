using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using repos = BigDeckPlays.DAL.Repositories;

namespace BigDeckPlays.Tests.DAL.Repositories.FileRepository
{
    [TestClass]
    public class TestFileRepository
    {
        protected repos.FileRepository _repo;

        [TestInitialize]
        public virtual void Init()
        {
            _repo = new repos.FileRepository();
        }

        protected string GetTempFilePath()
        {
            return Path.GetTempPath() + $"filerepository_{Guid.NewGuid()}.txt";
        }
    }
}
