using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredGildenRoseCsharp
{
    //Test created in separate project as it is will not be deploed to user in the release version

    [TestFixture]
    public class ProgramApprovalTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void ExecuteProgramMethodsTest()
        {
            #region Act

            string pathToDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Program.ExecuteProgramMethods();
            string reportFileName = "Report.txt";
            string pathToReportFile = Path.Combine(pathToDirectory, reportFileName);
            string actualString = File.ReadAllText(pathToReportFile);

            #endregion

            Approvals.Verify(actualString);


            //#region Arange

            
            //string benchmarkFileName = "GoldenMaster.txt";
            //string pathToBenchMarkFile = Path.Combine(pathToDirectory, benchmarkFileName);
            //string expectedString = File.ReadAllText(pathToBenchMarkFile);

            //#endregion

        }
    }
}
