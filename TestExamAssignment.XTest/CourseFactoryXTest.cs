using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamAssignment.Factories;
using TestExamAssignment.SchoolActivity;
using Xunit;

namespace TestExamAssignment.XTest
{
    public class CourseFactoryXTest
    {

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

        [Fact]
        public void CreateNewSemesterTest() {

            DateTime semesterStart = new DateTime();
            semesterStart = Convert.ToDateTime("2019,01,01");
            CourseFactory factory = new CourseFactory();
            Semester semester = new Semester { SemesterStart = semesterStart };
            factory.AddNewSemesterToDB(semester);
            
        }
	}
}
