using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.UI
{
    public partial class CatagorySetupUI : System.Web.UI.Page
    {
        CategoryManager categoryManager=new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            catagoryGridView.DataSource = categoryManager.GetAllCategories();
            catagoryGridView.DataBind();

            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Category category=new Category();
            category.Name = nameTextBox.Text;
            category.Sl = Int32.Parse(HiddenField1.Value);

            if (category.Sl > 0)
            {
                // if hidden value 0 to greater this else work Update category
                outputMsgLabel.Text = categoryManager.Update(category);
            }
            else
            {
                // if hidden value 0 this else work save category
                outputMsgLabel.Text = categoryManager.CategorySave(category);
            }
            //clear data 
            nameTextBox.Text = "";
            HiddenField1.Value = "";

            //page reload after save or update 
            Response.Redirect(Request.Url.AbsoluteUri);
         
            //if (saveButton.Text.ToLower()=="Update".ToLower())
            //{
            //    category.Sl = Convert.ToInt32(HiddenField1.Value);
            //    outputMsgLabel.Text = categoryManager.Update(category);
            //    nameTextBox.Text = category.Name;
            //}

            //else
            //{
            //    outputMsgLabel.Text = categoryManager.CategorySave(category);
            //}
        }

      

        protected void catagoryGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
                int id = Convert.ToInt32(Request.QueryString["Sl"]);

                Category category = categoryManager.GetCategoryByID(id);

                //regiTextBox.Text = student.RegNo;
                nameTextBox.Text = category.Name;
               
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(catagoryGridView, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField1.Value = catagoryGridView.SelectedRow.Cells[0].Text;
            nameTextBox.Text  = catagoryGridView.SelectedRow.Cells[1].Text;
        }
    }
}