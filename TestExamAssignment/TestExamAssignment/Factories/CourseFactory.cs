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

		public List<Course> ListOfCourses;

		public CourseFactory() {
			ListOfCourses = new List<Course>();
		}

		public bool AddCourseToSemester(Semester semester, Course course)
		{
			if (!semester.listOfCourses.Contains(course))
			{
				semester.listOfCourses.Add(course);
				return true;
			}
			return false;
		}

		public bool CreateNewCourse(string name, int courseLengthInHours, DateTime courseStart, Subject subject)
		{
			Course newCourse = new Course();
			newCourse.Name = name;
			newCourse.CourseLenghtInHours = courseLengthInHours;
			newCourse.CourseStart = courseStart;
			newCourse.CourseSubject = subject;

			if (!ListOfCourses.Contains(newCourse))
			{
				ListOfCourses.Add(newCourse);
				return true;
			}
			return false;
		}
	}
	}

