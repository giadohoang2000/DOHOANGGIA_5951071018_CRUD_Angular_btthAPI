using _5951071018_DOHOANGGIA_CRUD_Angular.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _5951071018_DOHOANGGIA_CRUD_Angular.Controllers
{
    public class StudentController : ApiController
    {
        private SqlConnection con;
        private SqlDataAdapter adap;
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-H6BPC8N\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");
            DataTable dt = new DataTable();
            var query = "select * from student";
            adap = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            } ;

            adap.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentRecord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecord));
                }
            }
            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-H6BPC8N\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");
            DataTable dt = new DataTable();
            var query = "select * from student where id = " + id;
            adap = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };

            adap.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentRecord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecord));
                }
            }
            return students;
        }

        // POST api/<controller>
        public string Post([FromBody] CreateStudent value)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-H6BPC8N\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");
            var query = "insert into student (f_name, m_name, l_name, address, birthDate, score) values (@f_name, @m_name, @l_name, @address, @birthDate, @score) ";
            SqlCommand insertCommand = new SqlCommand(query, con);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);
            con.Open();

            int result = insertCommand.ExecuteNonQuery();
            if (result > 0 )
            {
                return "Insert Thanh Cong";
            }
            else
            {
                return "Insert That bai";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] CreateStudent value)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-H6BPC8N\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");
            var query = "update student set f_name = @f_name, m_name = @m_name, l_name = @l_name, address = @address, birthDate = @birthDate, score = @score where id = " +id;
            SqlCommand insertCommand = new SqlCommand(query, con);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);
            con.Open();

            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Update Thanh Cong";
            }
            else
            {
                return "Update That bai";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-H6BPC8N\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");
            var query = "delete from student where id = " + id;
            SqlCommand insertCommand = new SqlCommand(query, con);
            con.Open();

            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Delete Thanh Cong";
            }
            else
            {
                return "Delete That bai";
            }
        }
    }
}