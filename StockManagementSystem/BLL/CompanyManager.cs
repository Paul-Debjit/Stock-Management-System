using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.BLL
{
    public class CompanyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();

        public string CompanySave(Company comapany)
        {
            if (companyGateway.IsCompanyExists(comapany.Name))
            {
                return "Company Name Already Exists ";
            }
            else
            {
                int rowAffect = companyGateway.CompanySave(comapany);
                if (rowAffect > 0)
                {
                    return "Saved Sucessfull";
                }
                else
                {
                    return "Save Faild";
                }
            }

        }

        public List<Company> GetAllCompany()
        {

            return companyGateway.GetAllCompany();
        }

        public Company GetCompanyyBySl(int id)
        {
            return companyGateway.GetCompanyBySl(id);

        }
        public string Update(Company company)
        {
            int rowAffect = companyGateway.Update(company);
            if (rowAffect > 0)
            {
                return "Update Sucessfull";
            }
            else
            {
                return "Faild";
            }
        }
    }
}