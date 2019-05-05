using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamAssignment.SchoolActivity;

namespace TestExamAssignment.Factories
{
	public class CourseFactory
	{

		List<Course> listOfCourses = new List<Course>();

		public bool AddCourseToSemester(Semester semester, Course course)
		{
			if (!semester.ListOfCourses.Contains(course))
			{
				listOfCourses.Add(course);
				return true;
			}
			return false;
		}

		public bool CreateNewCourse(Subject subject)
		{
			throw new NotImplementedException();
		}
	}
}
