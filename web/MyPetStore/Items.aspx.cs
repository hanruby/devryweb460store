using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessModule;
/*
 * Author: Daniel
 * 
 */
public partial class CategoryImages_Items : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        listViewSearch.Visible = false;

        if (Request.QueryString["Search"] != null && Request.QueryString["CategoryName"] == null)
        {




            listViewItems.Visible = false;
            listViewSearch.Visible = true;

            //Item likeItem = new Item();

            //ItemDA itemDA = new ItemDA();

            //likeItem.Description = "%" + Request.QueryString["Search"] + "%";
            //// likeItem.Upc = "%" + Request.QueryString["Search"] + "%";
            //// likeItem.IsActive = true;
            //// likeItem.Size = "%" + Request.QueryString["Search"] + "%";
            ////  likeItem.Name = "%" + Request.QueryString["Search"] + "%";
            ////  likeItem.Price = decimal.Parse(Request.QueryString["Search"]);


            //Collection<Item> getlikeItem = itemDA.GetLike(likeItem);


            //// puts results in listviewsearch
            //listViewSearch.DataSource = getlikeItem;
            //listViewSearch.DataBind();

        }
    }

    // checks weather an item is on sale
    protected void CheckSale(object source, ListViewItemEventArgs e)
    {

        ListViewDataItem item = (ListViewDataItem)e.Item;

        // Get the index of the listviewitem in the underlying data source object.
        int myDataItemIndex = item.DataItemIndex;


        Label sale = (Label)e.Item.FindControl("lblOnSale");
        Label saleAnswer = (Label)e.Item.FindControl("lblOnSaleAnswer");

        Label price = (Label)e.Item.FindControl("lblPriceAnswer");


        //for (int i = 0; i < myDataItemIndex; i++ )
        //{
        if (saleAnswer.Text == "")
        {
            sale.Visible = false;
            saleAnswer.Visible = false;
        }
        else
        {
            // sale.Text = "On Sale: ";
            price.ForeColor = Color.Red;
            price.Visible = true;
            price.Font.Bold = true;
            price.Font.Strikeout = true;

            saleAnswer.ForeColor = Color.DarkBlue;
            saleAnswer.Font.Bold = true;

        }
        //} 






    }


}
