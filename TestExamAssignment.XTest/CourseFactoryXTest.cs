using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamAssignment.Database;
using TestExamAssignment.Factories;
using TestExamAssignment.SchoolActivity;
using Xunit;

namespace TestExamAssignment.XTest
{
    public class CourseFactoryXTest
    {
        // Test if we're able to create a new course
		[Theory]
		[InlineData("Matematik", 60, "2019,01,01", 5, "Matematik A niveau" )]
		public void CreateNewCourseTest(string subjectName, int courseLengthInHours, DateTime  courseStart,  int subjectConsecutive , string name)
		{
			CourseFactory factory = new CourseFactory();

			Subject subject = new Subject { Name = subjectName, ConsecutiveSemesters = subjectConsecutive};
			Assert.InRange(subject.ConsecutiveSemesters, 0, 6);

			bool result = factory.CreateNewCourse(name, courseLengthInHours, courseStart, subject);
			Assert.True(result);
		}

        // Test if we're able to add a course to a semester
		[Theory]
		[InlineData("2019,01,01")]
		public void AddCourseToSemesterTest(DateTime semesterStart)
		{
			CourseFactory factory = new CourseFactory();

			Subject subject = new Subject { Name = "Matematik", ConsecutiveSemesters = 5 };
			DateTime courseStart = new DateTime(2019, 01, 01);			
			Course course = new Course { Name = "Matematik a niveau", CourseLenghtInHours = 60, CourseSubject = subject, CourseStart = courseStart};
			Semester semester = new Semester { SemesterStart = semesterStart };
			semester.ListOfCourses = new List<Course>();

			
			bool result = factory.AddCourseToSemester(semester, course);
			Assert.True(result);

		}
        // Integrationstests.
        [Fact]
        public void CreateNewSemesterTest() {
            Semester semester = new Semester();         
            semester.SemesterStart = Convert.ToDateTime("2019,01,01");
            CourseFactory factory = new CourseFactory();         
            factory.AddNewSemesterToDB(semester);
            
        }

        //Tests if we can actually connect to the database.
        [Fact]
        public void CanConnectToDatabaseTest()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.OpenConnection();
            int dbValue = (int)dbHandler.myConnection.State;
            // According to: https://docs.microsoft.com/en-us/dotnet/api/system.data.connectionstate?view=netframework-4.8
            // The value of an open connection state, is 1

            Assert.Equal(1,dbValue);
            Assert.NotEqual(0, dbValue);
            Assert.NotInRange(dbValue, 2, int.MaxValue);
        
        }

        //Test if a connection is closed after closing it
        [Fact]
        public void CanCloseConnectionToDbTest()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.CloseConnection();
            int dbValue = (int)dbHandler.myConnection.State;
            // According to: https://docs.microsoft.com/en-us/dotnet/api/system.data.connectionstate?view=netframework-4.8
            // The value of an closed connection state, is 0
            Assert.Equal(0, dbValue);
            Assert.NotInRange(dbValue,1, int.MaxValue);
        }
    }
}
