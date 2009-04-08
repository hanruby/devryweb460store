using System;
using System.Collections.ObjectModel;
using DataAccessModule; //IMPORTANT: Remember to add this line.

public partial class TestDal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //////////////////////////////////////////////////////////////////////////////
        //See DataAccessBase.cs #region Abstract Members for the list of DAL Features
        //////////////////////////////////////////////////////////////////////////////
        

        ///////////////////////////////////////////////////////////////////////////////////////
        //Welcome to the DAL Tutorial where we will be looking at how to use the DAL to:
        //
        //1. Save an Object using Save()
        //
        //2. Save a Collection of Objects using Save()
        //
        //3. Get a Collection of Objects using Get()
        //
        //4. Get a Collection of ALL Objects using Get()
        //
        //5. Get a Collection of Objects with the SQL LIKE Operator using GetLike()
        //
        //6. Delete Objects using Delete()
        ///////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Introduction:
        //
        //We will be using the Business Object Category and its DataAccess component CategoryDA in these examples,
        //but all Business Objects and DataAccess Components work similarly.
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        ///////////////////////////////////
        //1. Saving an Object using Get()
        //////////////////////////////////
        
        //Create Category objects using full constructor
        var category1  = new Category(1, "Category", "cat1.jpg");
        var category2 = new Category(2, "category2", "cat2.jpg");

        //Create Category object using default constructor
        var category3 = new Category();
        category3.Id = 3;
        category3.Name = "Category3";
        category3.ImageLocation = "cat2.jpg";
        
        //Instantiate our Category specific DataAccess Class
        CategoryDA categoryDA = new CategoryDA();
        
        //Save the Objects to the Database
        categoryDA.Save(category1);
        categoryDA.Save(category2);
        categoryDA.Save(category3);


        ////////////////////////////////////////////////
        //2. Saving a Collection<T> of Objects using Save()
        ////////////////////////////////////////////////
        
        //We can use a Collection<T> to Save as well
        
        //Create the Collection
        var categories = new Collection<Category>();
        
        //Add the Objects to the Collection
        categories.Add(category1);
        categories.Add(category2);
        categories.Add(category3);
        
        //Save the Collection to the database
        int rowsSaved = categoryDA.Save(categories);

        //The amount of rows affected is returned.  Let's display how many were saved.
        //This line will appear at the TOP of the page
        //btw don't write to the page like this in normal code....we get malformed HTML
        Response.Write("<div><b>" + rowsSaved.ToString() + "</b> rows were saved to the database by <b>Save(Collection)</b>." + "</div>");
        Response.Write("<br/>");
        

        ////////////////////////////////
        //3. Getting Objects using Get()
        //////////////////////////////

        //Create an Object that specifies what we want to Get
        Category getCategory = new Category();

        //Let's Get categories use have an imageLocation of "cat2.jpg" we should get 2 results
        getCategory.ImageLocation = "cat2.jpg";

        //We will be returned a collection so lets Declare that and fill it using Get()
        Collection<Category> getCategoies = categoryDA.Get(getCategory);

        //Let's display what we got back in a Repeater
        Repeater1.DataSource = getCategoies;
        Repeater1.DataBind();


        ////////////////////////////////////////////////////
        //4. Getting EVERY Object from the Table
        ////////////////////////////////////////////////////

        //We can get ALL rows back by using NULL instead of an Object
        Collection<Category> allCategories = categoryDA.Get(null);
        
        ///////////////////////////////////////////////////////////////////////////////////
        //5. Getting a Collection of Objects with the SQL LIKE Operator using GetLike()
        ///////////////////////////////////////////////////////////////////////////////////
        //For information on LIKE queries see http://msdn.microsoft.com/en-us/library/aa933232(SQL.80).aspx

        //Let's find Categories that contain a Name LIKE %ategory%
        Category likeCategory = new Category();
        likeCategory.Name = "%Category%"; //not case sensitive
        Collection<Category> likeCategories = categoryDA.GetLike(likeCategory);

        
        //Now let's put the results in a GridView
        GridView1.DataSource = likeCategories;
        GridView1.DataBind();

        /////////////////////////////////////
        //6. Deleting an Object using Delete()
        //////////////////////////////////////
        
        //Create an Object that specifies what we want to DELETE
        Category deleteCategory = new Category();

        //The primary key is used to perform the delete.
        //Let's delete the Category using the Id of 1.
        deleteCategory.Id = 1;

        //the rows deleted will be returned
        //and in all cases should either be 1 (row was deleted) or 0 (row never existed)
        int rowsDeleted = categoryDA.Delete(category1);
        
        //Let's see if it was deleted. (It should be 1)
        //This line will appear at the TOP of the page
        //btw don't write to the page like this in normal code....we get malformed HTML
        Response.Write("<div><b>" + rowsDeleted.ToString() + "</b> row was deleted by <b>Delete(Category)</b>.</div>");


        //////////////////////////////////////////////////////////////////////////////////
        //7. Deleting a Collection<T> of Objects using Delete()
        //////////////////////////////////////////////////////////////////////////////////
        
        //Now that we have reached the end of the tutorial, let's delete all the rows we have created in the Database
        Collection<Category> tutorialCategories = new Collection<Category>();
        tutorialCategories.Add(category1);
        tutorialCategories.Add(category2);
        tutorialCategories.Add(category3);

        int countRowsDeleted = categoryDA.Delete(tutorialCategories);

        //Let's see if what was deleted. Since we already deleted category1 above, the count should be 2
        //This line will appear at the TOP of the page
        //btw don't write to the page like this in normal code....we get malformed HTML
        Response.Write("<div><b>" + countRowsDeleted.ToString() + "</b> rows were deleted by <b>Delete(Collection)</b>. </div>");
        Response.Write("<br/>");
        Response.Write("<br/>");

        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //END
        //
        //That's it for now.
        //Stay tuned for more functionallity...possibly.....
        //
        //Such As:
        //-Composition in the Business Objects for foreign key relationships
        //-GetNotLike()
        //-GetCount()
        //
        //If you need a feature added, feel free to request it and I will try to implement it for you.
        //Alternatively, you can add the feature yourself.
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
    }
}
