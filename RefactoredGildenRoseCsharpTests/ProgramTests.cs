using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace RefactoredGildenRoseCsharp
{
    //Test created in separate project as it is will not be deploed to user in the release version

    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ExecuteProgramMethodsTest()
        {
            #region Arange

            string pathToDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string benchmarkFileName = "GoldenMaster.txt";
            string pathToBenchMarkFile = Path.Combine(pathToDirectory, benchmarkFileName);
            string expectedString = File.ReadAllText(pathToBenchMarkFile);

            #endregion

            #region Act

            Program.ExecuteProgramMethods();
            string reportFileName = "Report.txt";
            string pathToReportFile = Path.Combine(pathToDirectory, reportFileName);
            string actualString = File.ReadAllText(pathToReportFile);

            #endregion

            #region Assert

            Assert.AreEqual(expectedString, actualString);

            #endregion
        }
    }
}