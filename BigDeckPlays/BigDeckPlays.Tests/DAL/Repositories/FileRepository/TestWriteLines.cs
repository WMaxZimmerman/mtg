using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigDeckPlays.Tests.DAL.Repositories.FileRepository
{
    [TestClass]
    public class TestWriteLines : TestFileRepository
    {
        [TestMethod]
        public void WritesAllGivenLines()
        {
            var file_path = GetTempFilePath();
            var expected_lines = new List<string>
            {
                "line 1",
                "line 2",
                "line 3",
            };

            _repo.WriteLines(expected_lines, file_path);
            var actual_lines = File.ReadAllLines(file_path);
                
            CollectionAssert.AreEqual(expected_lines, actual_lines);
            File.Delete(file_path);
        }
    }
}
