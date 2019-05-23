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
            // Arrange phase is empty: Testing a bool return value

            // Act
            CourseFactory factory = new CourseFactory();
			Subject subject = new Subject { Name = subjectName, ConsecutiveSemesters = subjectConsecutive};
			Assert.InRange(subject.ConsecutiveSemesters, 0, 6);
			bool result = factory.CreateNewCourse(name, courseLengthInHours, courseStart, subject);

            //Assert
            Assert.True(result);
		}

        // Test if we're able to add a course to a semester
		[Theory]
		[InlineData("2019,01,01")]
		public void AddCourseToSemesterTest(DateTime semesterStart)
		{
            // Arrange phase is empty: Testing a bool return value

            // Act
            CourseFactory factory = new CourseFactory();
			Subject subject = new Subject { Name = "Matematik", ConsecutiveSemesters = 5 };
			DateTime courseStart = new DateTime(2019, 01, 01);			
			Course course = new Course { Name = "Matematik a niveau", CourseLenghtInHours = 60, CourseSubject = subject, CourseStart = courseStart};
			Semester semester = new Semester { SemesterStart = semesterStart };
			semester.ListOfCourses = new List<Course>();

			//Assert
			bool result = factory.AddCourseToSemester(semester, course);
			Assert.True(result);

		}
        // Integrationstests--------------------------------------------------------------------
        
        //Tests if we can actually connect to the database.
        [Fact]
        public void CanConnectToDatabaseTest()
        {
            // Arrange phase is empty: Testing a bool return value
            // According to: https://docs.microsoft.com/en-us/dotnet/api/system.data.connectionstate?view=netframework-4.8
            // The value of an open connection state, is 1
            int connectionState = 1;

            // Act
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.OpenConnection();
            int dbValue = (int)dbHandler.myConnection.State;
           

            //Assert
            Assert.Equal(connectionState, dbValue);
            Assert.NotEqual(0, dbValue);
            Assert.NotInRange(dbValue, 2, int.MaxValue);
        
        }

        //Test if a connection is closed after closing it
        [Fact]
        public void CanCloseConnectionToDbTest()
        {
            // Arrange phase is empty: Testing a bool return value
            // According to: https://docs.microsoft.com/en-us/dotnet/api/system.data.connectionstate?view=netframework-4.8
            // The value of an open connection state, is 0
            int connectionState = 0;

            // Act
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.CloseConnection();
            int dbValue = (int)dbHandler.myConnection.State;

            //Assert
            Assert.Equal(connectionState, dbValue);
            Assert.NotInRange(dbValue,1, int.MaxValue);
        }

        // Test if we can add a new semester to the database
        [Fact]
        public void CreateNewSemesterTest()
        {
            //Arrange: if adding to the new semester fails, it will throw an exception and the test will fail.

            // Act
            Semester semester = new Semester();
            semester.SemesterStart = Convert.ToDateTime("2019,01,01");
            CourseFactory factory = new CourseFactory();
            factory.AddNewSemesterToDB(semester);

            //Assert is empty as it is a void method that results in an exception if the method fails.

        }

        //Currently not working properly. Locks Database

        //[Fact]
        //public void FetchSemestersTest() {

        // Arrange is empty due to  testing the datatype returned.

        //    List<Semester> semesterList = new List<Semester>();
        //    CourseFactory factory = new CourseFactory();
        //    semesterList = factory.SelectAllSemestersFromDatabase();

        //  Assert
        //    Assert.NotNull(semesterList);
        //    Assert.IsType(Type.GetType("System.Int32"), semesterList[0].SemesterId);
        //}
    }
}
