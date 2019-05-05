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
		//Subjects
	
		//Courses
		//Course course1 = new Course()
		//{
		//	CourseLenghtInHours = 60,
		//	CourseStart = new DateTime(DateTime.Now.Year, 01, 01),
		//	CourseSubject = subject1,
		//	Name = "Matematik A niveau"
		//};

		//Semesters


		[Theory]
		[InlineData("Matematik", 60, "2019,01,01", 5, "Matematik A niveau" )]
		public void CreateNewCourseTest(string subjectName, int courseLengthInHours, DateTime  courseStart,  int subjectConsecutive , string name)
		{
			Subject subject = new Subject();
			subject.Name = subjectName;
			subject.ConsecutiveSemesters = subjectConsecutive;

			CourseFactory factory = new CourseFactory();
			bool result = factory.CreateNewCourse(subjectName, courseLengthInHours, courseStart, subject);
			Assert.InRange(subject.ConsecutiveSemesters, 0, 6);
			Assert.True(result);
		}

		[Theory]
		public void AddCourseToSemesterTest()
		{
			Semester semester = new Semester();
			semester.Autumn = true;
		
			CourseFactory factory = new CourseFactory();
			Assert.True(factory.AddCourseToSemester(semester, course1));

		}
	}
}
