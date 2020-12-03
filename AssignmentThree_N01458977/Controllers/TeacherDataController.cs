using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AssignmentThree_N01458977.Models;
using MySql.Data.MySqlClient;

namespace AssignmentThree_N01458977.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        //Get the teacher name and class by teacher id for SHOW page
        [HttpGet]
        public Teacher ShowTeacher(int? id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();

                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Open the connection between the web server and database
            Conn.Open();

            //Create another instance of a connection
            MySqlCommand classcmd = Conn.CreateCommand();

            classcmd.CommandText = "Select * from classes where teacherid = " + id;

            MySqlDataReader ClassResultSet = classcmd.ExecuteReader();

            while (ClassResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string TeacherClass = ClassResultSet["classname"].ToString();

                NewTeacher.TeacherClass = TeacherClass;
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author namess
            return NewTeacher;
        }


        //Get the class by teacher id for LIST page
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Author Names
            List<Teacher> Teachers = new List<Teacher> {};

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;

                //Add the Author Names to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Teachers;
        }
    }
}
