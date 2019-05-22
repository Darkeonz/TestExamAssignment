using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExamAssignment.SchoolActivity;
using TestExamAssignment.Database;
using System.Data.SQLite;

namespace TestExamAssignment.Factories
{
	public class CourseFactory
	{


        DatabaseHandler DBHandler = new DatabaseHandler();
        public List<Course> ListOfCourses;

		public CourseFactory() {
			ListOfCourses = new List<Course>();
		}

		public bool AddCourseToSemester(Semester semester, Course course)
		{
			if (!semester.ListOfCourses.Contains(course))
			{
				semester.ListOfCourses.Add(course);
				return true;
			}
			return false;
		}

		public bool CreateNewCourse(string name, int courseLengthInHours, DateTime courseStart, Subject subject)
		{
			Course newCourse = new Course { Name = name, CourseLenghtInHours = courseLengthInHours, CourseStart = courseStart, CourseSubject = subject };
			
			if (!ListOfCourses.Contains(newCourse))
			{
				ListOfCourses.Add(newCourse);
				return true;
			}
			return false;
		}

        //Adds a new semester to the Database
        public void AddNewSemesterToDB(Semester semester)
        {
            string query = "INSERT INTO Semester {'SemesterStart') VALUES (@SemesterStart)}";
            SQLiteCommand myCommand = new SQLiteCommand(query, DBHandler.myConnection);
            DBHandler.OpenConnection();
            DBHandler.myConnection.Open();
            myCommand.Parameters.AddWithValue("@SemesterStart", semester.SemesterStart);
            myCommand.ExecuteNonQuery();
            DBHandler.CloseConnection();
        }
    }
	}

