using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestExamAssignment.SchoolActivity
{
	public class Course
	{
		public string Name { get; set; }

		public Subject CourseSubject { get; set; }

		public int CourseLenghtInHours { get; set; }

		public DateTime CourseStart { get; set; }

	}
}
