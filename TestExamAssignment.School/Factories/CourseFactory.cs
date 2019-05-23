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
            string query = "INSERT INTO Semester ('SemesterStart') VALUES (@semesterStart)";
            SQLiteCommand myCommand = new SQLiteCommand(query, DBHandler.myConnection);
            DBHandler.OpenConnection();           
            myCommand.Parameters.AddWithValue("@semesterStart", semester.SemesterStart.ToString());
            myCommand.ExecuteNonQuery();
            DBHandler.CloseConnection();
        }

        // Returns all the semesters
        public List<Semester> SelectAllSemestersFromDatabase()
        {
            string query = "SELECT * FROM Semester";
            SQLiteCommand myCommand = new SQLiteCommand(query, DBHandler.myConnection);
            DBHandler.OpenConnection();        
            SQLiteDataReader result = myCommand.ExecuteReader();
            DBHandler.CloseConnection();
            List<Semester> semester = new List<Semester>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Semester tempSemester = new Semester();
                    Course tempCourse = new Course();
                    tempSemester.ListOfCourses.Add(tempCourse);
                    tempSemester.SemesterId = result.GetInt32(0);
                    tempSemester.SemesterStart = Convert.ToDateTime(result.GetString(1));
                    semester.Add(tempSemester);
                }
            }       
            return semester;
        }
    }
	}

