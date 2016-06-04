using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firstMvcDatabase.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace firstMvcDatabase.Repository
{
    public class EmpRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbConn"].ToString();
            con = new SqlConnection();
        }
        public bool AddEmployee(EmpModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails",con);
            com.Parameters.AddWithValue("@Name",obj.Name);
            com.Parameters.AddWithValue("@City",obj.city);
            com.Parameters.AddWithValue("@Address", obj.address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList =new List<EmpModel>();
            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            EmpList = (from DataRow dr in dt.Rows

                       select new EmpModel()
                       {
                           Empid = Convert.ToInt32(dr["Id"]),
                           Name = Convert.ToString(dr["Name"]),
                           city = Convert.ToString(dr["City"]),
                           address = Convert.ToString(dr["Address"])
                       }).ToList();


            return EmpList;


        }
        //To Update Employee details
        public bool UpdateEmployee(EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);
           
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.city);
            com.Parameters.AddWithValue("@Address", obj.address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                
                return true;

            }
            else
            {

                return false;
            }


        }
        
        public bool DeleteEmployee(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }
    }
}