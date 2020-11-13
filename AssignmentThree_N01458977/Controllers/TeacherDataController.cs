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
        private Teacher School = new Teacher();

        //Get the class by teacher id for SHOW page
        [HttpGet]
        public string ShowTeacher(int? id)
        {
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

            //Create an empty string of for the teacher name
            String TeacherName = " ";

            List<String> TeacherNames = new List<string> { };

            while (ResultSet.Read())
            {
                TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author namess
            return TeacherName;
        }

        //Get the class by teacher id for SHOW page
        [HttpGet]
        public string ShowTeacherClass(int? id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where teacherid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty string of for the teacher class name
            String TeacherClass = " ";

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                TeacherClass = ResultSet["classname"] + " ";
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return TeacherClass;
        }

        //Get the class by teacher id for LIST page
        [HttpGet]
        public IEnumerable<string> ListTeachers()
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
            List<String> TeacherNames = new List<string> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];
                //Add the Author Name to the List
                TeacherNames.Add(TeacherName);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return TeacherNames;
        }
    }
}
