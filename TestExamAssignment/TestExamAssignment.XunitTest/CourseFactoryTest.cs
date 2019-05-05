using System;
using TestExamAssignment.Factories;
using TestExamAssignment.SchoolActivity;
using Xunit;

namespace TestExamAssignment.XunitTest
{
    public class CourseFactoryTest
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
					Assert.InRange(subject.ConsecutiveSemesters,0, 6);
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
