using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestExamAssignment
{

    public class Student
    {
        
        public int Id{ get; set; }
        public string Name { get; set; }
		public DateTime Birthday { get; set; }
	}
}
