using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/// <summary>
/// Summary description for OrderItem
/// Author: Daniel Aguayo
/// </summary>
public class OrderItem : IBase
{
    // attributes and Paramaters
    private int orderID;
    private string itemID;
    private int vendorID;
    private double price;
    private int quantity;



    public const string OrderIDColumn = "OrderID";
    public const string ItemIDColumn = "ItemID";
    public const string VendorIDColumn = "VendorID";
    public const string PriceColumn = "Price";
    public const string QuantityColumn = "Quantity";


    public const string ParmOrderID = "@orderID";
    public const string ParmItemID = "@itemID";
    public const string ParmVendorID = "@vendorID";
    public const string ParmPrice = "@price";
    public const string ParmQuantity = "@quantity";


    // contructors
    public OrderItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public OrderItem(int orderID, string itemID, int vendorID, double price, int quantity)
    {
        this.orderID = orderID;
        this.itemID = itemID;
        this.vendorID = vendorID;
        this.price = price;
        this.quantity = quantity;
    }


    // behaviors
    #region IBase Members

    public IList<object> Get()
    {
      

        ParmList parm = new ParmList();
       


        // connect to database
        DBConnect dbConnect = new DBConnect(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyPetStore.mdf;Integrated Security=True;User Instance=True", parm);



        // build insert command
        string comm = String.Format("SELECT * FROM OrderItem");

        parm.Add(ParmOrderID, OrderID);
        parm.Add(ParmItemID, ItemID);
        parm.Add(ParmVendorID, VendorID);
        parm.Add(ParmPrice, Price);
        parm.Add(ParmQuantity, Quantity);
        // execute reader command

        List<object> orderList = new List<object>();

        SqlDataReader reader;

  
        reader = dbConnect.GetDR(comm);
       
        while (reader.Read())
        {
            OrderItem orderItem = new OrderItem((int)reader["orderID"], (string)reader["itemID"],
                (int)reader["vendorID"], (double)reader["price"], (int)reader["quantity"]);

            orderList.Add(orderItem);

           
        }

        reader.Close();
   

       

            return orderList;
        



    }

    public bool Add()
    {
        ParmList parm = new ParmList();
    


        // connect to database
        DBConnect dbConnect = new DBConnect(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyPetStore.mdf;Integrated Security=True;User Instance=True", parm);

       

        // build insert command
        string comm = String.Format("INSERT INTO OrderItem ({0}, {1}, {2}, {3}, {4}) VALUES ( {5}, {6}, {7}, {8}, {9})",
            OrderIDColumn, ItemIDColumn, VendorIDColumn, PriceColumn, QuantityColumn,
            5, 2, 5, 1, 2
            );
     
        parm.Add(ParmOrderID, OrderID);
        parm.Add(ParmItemID, ItemID);
        parm.Add(ParmVendorID, VendorID);
        parm.Add(ParmPrice, Price);
        parm.Add(ParmQuantity, Quantity);
   


        // execute command
        dbConnect.ExecSQL(comm);

        
        dbConnect.Close();


        // clear commands
        Clear();

        return true;

    }

    public bool Delete()
    {

        ParmList parm = new ParmList();

  


        // connect to database
        DBConnect dbConnect = new DBConnect(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyPetStore.mdf;Integrated Security=True;User Instance=True", parm);

     

        // build insert command
        string comm = String.Format("DELETE FROM OrderItem WHERE {0} = {1}",
            ParmOrderID, 0
           );

        parm.Add(ParmOrderID, OrderID);
        parm.Add(ParmItemID, ItemID);
        parm.Add(ParmVendorID, VendorID);
        parm.Add(ParmPrice, Price);
        parm.Add(ParmQuantity, Quantity);


   
        // execute command
        dbConnect.ExecSQL(comm);

        dbConnect.Close();


        return true;
    }

    public void Clear()
    {
        orderID = -1;
        itemID = null;
        vendorID = -1;
        price = -1;
        quantity = -1;
    }

    #endregion

    // properties
    public int OrderID
    {
        get
        {
            return orderID;
        }
        set
        {
            orderID = value;
        }
    }

    public string ItemID
    {
        get
        {
            return itemID;
        }
        set
        {
            itemID = value;
        }
    }

    public int VendorID
    {
        get
        {
            return vendorID;
        }
        set
        {
            vendorID = value;
        }
    }

    public double Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            quantity = value;
        }
    }
}
