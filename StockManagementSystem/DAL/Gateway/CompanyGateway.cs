using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.DAL.Gateway
{
    public class CompanyGateway:CommonGateway
    {
        public int CompanySave(Company company)
        {
            string query = "INSERT INTO Company VALUES('" + company.Name + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public List<Company> GetAllCompany()
        {
            string query = "SELECT * FROM Company";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Company> companylist = new List<Company>();
            while (Reader.Read())
            {
                Company company = new Company();
                company.Sl = Convert.ToInt32(Reader["Sl"]);
                company.Name = Reader["Name"].ToString();

                companylist.Add(company);

            }

            Connection.Close();
            return companylist;
        }

        public bool IsCompanyExists(string company)
        {
            string query = "SELECT * FROM Company WHERE Name='" + company + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;
        }

        public int Update(Company company)
        {
            string query = "UPDATE Company SET Name='" + company.Name + "' WHERE Sl=" + company.Sl;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public Company GetCompanyBySl(int Id)
        {
            string query = "SELECT * FROM Company WHERE Sl=" + Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Company company = new Company();
            company.Sl = Convert.ToInt32(Reader["Sl"]);
            company.Name = Reader["Name"].ToString();

            Connection.Close();
            return company;
        }
    }
}