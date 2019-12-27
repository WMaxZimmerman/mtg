using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigDeckPlays.Tests.DAL.Repositories.FileRepository
{
    [TestClass]
    public class TestReadLines : TestFileRepository
    {
        [TestMethod]
        public void ReturnsAllLinesOfGivenFile_WhenFileIsValid()
        {
            var file_path = GetTempFilePath();
            var expected_lines = new List<string>
            {
                "line 1",
                "line 2",
                "line 3",
            };
            File.WriteAllLines(file_path, expected_lines);

            var actual_lines = _repo.ReadLines(file_path).ToList();
            File.Delete(file_path);
            
            CollectionAssert.AreEqual(expected_lines, actual_lines);
        }
        
        [TestMethod]
        public void ReturnsEmptyCollection_WhenFileIsInvalid()
        {
            var file_path = "fake_invalid_file_path.txt";
            var expected_lines = new List<string>();

            var actual_lines = _repo.ReadLines(file_path).ToList();

            CollectionAssert.AreEqual(expected_lines, actual_lines);
        }
    }
}
