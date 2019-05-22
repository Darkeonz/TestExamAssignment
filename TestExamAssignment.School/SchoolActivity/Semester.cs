using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestExamAssignment.SchoolActivity
{
	public class Semester
	{
        public int SemesterId { get; set; }
        public DateTime SemesterStart { get; set; }
		public List<Course> ListOfCourses { get; set; }

	
	}
}
