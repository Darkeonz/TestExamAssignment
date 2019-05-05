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

		[Fact]
		public void CreateNewCourseTest()
		{
			Subject subject = new Subject()
			{
				Name = "Matematik",
				ConsecutiveSemesters = 5
			};

			CourseFactory factory = new CourseFactory();
			bool result = factory.CreateNewCourse(subject);
			Assert.InRange(subject.ConsecutiveSemesters, 0, 6);
			Assert.True(result);
		}

		[Fact]
		public void AddCourseToSemesterTest()
		{
			Semester semester = new Semester();
			Course course = new Course();
			CourseFactory factory = new CourseFactory();

			//factory.AddCourseToSemester(semester, course);


		}
	}
}
