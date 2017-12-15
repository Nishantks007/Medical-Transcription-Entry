using MedicalTranscriptionEntry.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalTranscriptionEntry.Data_Access
{
    public class DbOperations
    {
        public string GetConnectionString()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PatientDbConnection"].ConnectionString;
            return connStr;
        }

        public bool SubmitData(Patient Pt)
        {
            string connetionString = GetConnectionString();
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tbl_Patient (Name, Gender, Age, Department, SubDepartment) VALUES" + "(" + "'" + Pt.Name + "'" + "," + "'" + Pt.Gender + "'" + "," + Pt.Age + "," + "'" + Pt.Department + "'" + "," + "'" + Pt.SubDepartment + "'" + ")", cnn);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Patient SearchPatient(string patientName, string patientId)
        {
            List<Patient> PatientList = new List<Patient>();
            string connetionString = GetConnectionString();
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                using (cnn)
                {

                    string commandString = string.Empty;

                    if (!String.IsNullOrEmpty(patientId))
                    {
                        commandString = "Select * from tbl_Patient where ID = " + patientId;
                    }
                    else if (!String.IsNullOrEmpty(patientName))
                    {
                        commandString = "Select * from tbl_Patient where Name = " + "'" + patientName + "'";
                    }

                    SqlCommand cmd = new SqlCommand(commandString, cnn);

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())

                    {

                        Patient P = new Patient();
                        P.ID = Convert.ToInt32(rd.GetInt32(0));
                        P.Name = Convert.ToString(rd.GetString(1));
                        P.Gender = Convert.ToString(rd.GetString(2));
                        P.Age = Convert.ToInt32(rd.GetInt32(3));
                        P.Department = Convert.ToString(rd.GetString(4));
                        P.SubDepartment = Convert.ToString(rd.GetString(5));
                        PatientList.Add(P);

                    }
                }
                return PatientList.First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Patient> GetAndBindData(int pageNumber, int recordCount, bool nameSort, bool depSort, bool ageSort, bool subDepSort, bool genderSort)
        {
            List<Patient> PatientList = new List<Patient>();
            string connectionString = GetConnectionString();
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectPatientsWithPaging";
            cmd.Connection = con;

            SqlParameter par1 = new SqlParameter();
            par1.ParameterName = "PageNumber";
            par1.DbType = System.Data.DbType.Int32;
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = pageNumber;
            cmd.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter();
            par2.ParameterName = "RowsPerPage";
            par2.DbType = System.Data.DbType.Int32;
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = recordCount;
            cmd.Parameters.Add(par2);

            SqlParameter par3 = new SqlParameter();
            par3.ParameterName = "NameSort";
            par3.DbType = System.Data.DbType.Boolean;
            par3.Direction = System.Data.ParameterDirection.Input;
            par3.Value = nameSort;
            cmd.Parameters.Add(par3);

            SqlParameter par4 = new SqlParameter();
            par4.ParameterName = "AgeSort";
            par4.DbType = System.Data.DbType.Boolean;
            par4.Direction = System.Data.ParameterDirection.Input;
            par4.Value = ageSort;
            cmd.Parameters.Add(par4);

            SqlParameter par5 = new SqlParameter();
            par5.ParameterName = "DepSort";
            par5.DbType = System.Data.DbType.Boolean;
            par5.Direction = System.Data.ParameterDirection.Input;
            par5.Value = depSort;
            cmd.Parameters.Add(par5);

            SqlParameter par6 = new SqlParameter();
            par6.ParameterName = "GenderSort";
            par6.DbType = System.Data.DbType.Boolean;
            par6.Direction = System.Data.ParameterDirection.Input;
            par6.Value = genderSort;
            cmd.Parameters.Add(par6);

            SqlParameter par7 = new SqlParameter();
            par7.ParameterName = "SubDepSort";
            par7.DbType = System.Data.DbType.Boolean;
            par7.Direction = System.Data.ParameterDirection.Input;
            par7.Value = subDepSort;
            cmd.Parameters.Add(par7);


            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            DataSet ds = new DataSet();

            con.Open();
            adp.Fill(ds);

            var drData = ds.Tables[0].CreateDataReader();

            while (drData.Read())

            {

                Patient P = new Patient();
                P.Name = Convert.ToString(drData.GetString(1));
                P.Gender = Convert.ToString(drData.GetString(2));
                P.Age = Convert.ToInt32(drData.GetInt32(3));
                P.Department = Convert.ToString(drData.GetString(4));
                P.SubDepartment = Convert.ToString(drData.GetString(5));
                PatientList.Add(P);

            }
            /*Session["TotalRows"] = par3.Value.ToString();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();*/
            return PatientList;
        }


        public List<Patient> GetAllData()
        {
            List<Patient> PatientList = new List<Patient>();
            string connetionString = GetConnectionString();
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                using (cnn)
                {

                    SqlCommand cmd = new SqlCommand("Select * from tbl_Patient", cnn);

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())

                    {

                        Patient P = new Patient();
                        P.Name = Convert.ToString(rd.GetString(1));
                        P.Gender = Convert.ToString(rd.GetString(2));
                        P.Age = Convert.ToInt32(rd.GetInt32(3));
                        P.Department = Convert.ToString(rd.GetString(4));
                        P.SubDepartment = Convert.ToString(rd.GetString(5));
                        PatientList.Add(P);

                    }
                }
                return PatientList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateData(Patient Pt)
        {
            string connetionString = GetConnectionString();
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE dbo.tbl_Patient SET Name = " + "'" + Pt.Name + "'"+ ", Gender = " + "'" + Pt.Gender + "'" + ", Age = "  + Pt.Age  + ", Department = " + "'" + Pt.Department + "'" + ", SubDepartment = " + "'" + Pt.SubDepartment + "'" + " WHERE ID = " + Pt.ID, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteData(int Id)
        {
            string connetionString = GetConnectionString();
            SqlConnection cnn;

            cnn = new SqlConnection(connetionString);
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE from dbo.tbl_Patient WHERE ID = " + Id, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}