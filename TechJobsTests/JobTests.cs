using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job test_job;
        Job emptyFieldJob;
        Job semiFilledJob;

        [TestInitialize]
        public void CreateJobObject()
        {
            test_job = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            semiFilledJob = new Job("Product tester", new Employer(), new Location("Desert"), new PositionType(), new CoreCompetency("Persistence"));
            emptyFieldJob = new Job();
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            Job job1 = new Job();
            Job job2 = new Job();
            Assert.AreEqual(job2.Id, job1.Id + 1);
            Assert.IsFalse(job1.Equals(job2));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual(test_job.Name, "Product tester");
            Assert.IsTrue(test_job.EmployerName.ToString().Equals("ACME"));
            Assert.IsTrue(test_job.EmployerLocation.Value.Equals("Desert"));
            Assert.IsTrue(test_job.JobType.Value.Equals("Quality control"));
            Assert.IsTrue(test_job.JobCoreCompetency.Value.Equals("Persistence"));
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job second_job = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsFalse(test_job.Equals(second_job));
        }

        //testing string contains a blank line before and after the job information
        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {            
            int len = semiFilledJob.ToString().Length;

            Assert.AreEqual(semiFilledJob.ToString()[0], '\n');
            Assert.AreEqual(semiFilledJob.ToString()[len - 1], '\n');
        }

        //test to confirm Job ToString contains correct labels and data
        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            Assert.AreEqual(test_job.ToString(), "\nID: " + test_job.Id + "\nName: Product tester" + "\nEmployer: ACME" +
                "\nLocation: Desert" + "\nPosition Type: Quality control" + "\nCore Competency: Persistence\n");
        }

        //test to confirm Job ToString if field is empty method should add "Data not available"
        [TestMethod]
        public void TestToStringContainsDisplayDataNotAvailable()
        {
            Assert.AreEqual(semiFilledJob.ToString(), "\nID: " + semiFilledJob.Id + "\nName: Product tester" + "\nEmployer: Data not available" +
                "\nLocation: Desert" + "\nPosition Type: Data not available" + "\nCore Competency: Persistence\n");
        }

        //test to display message when Job object have only id value(no parameter constructor)
        [TestMethod]
        public void TestObjectContainsOnlyIdField()
        {
            Assert.AreEqual(emptyFieldJob.ToString(), "OOPS!This job does not seem to exist");
        }
    }
}
