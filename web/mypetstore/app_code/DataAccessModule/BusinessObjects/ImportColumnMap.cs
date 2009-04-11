using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ImportColumnMap
/// </summary>
public class ImportColumnMap
{
    private int? importId;
    private int? columnNumber;
    private string sourceColumn;
    private string destinationColumn;
    private string dataType;
    private string length;

    public ImportColumnMap(int importId, int columnNumber, string sourceColumn, string destinationColumn, string dataType, string length)
    {
        this.importId = importId;
        this.columnNumber = columnNumber;
        this.sourceColumn = sourceColumn;
        this.destinationColumn = destinationColumn;
        this.dataType = dataType;
        this.length = length;
    }

    public int? ImportId
    {
        get { return importId; }
        set { importId = value; }
    }

    public int? ColumnNumber
    {
        get { return columnNumber; }
        set { columnNumber = value; }
    }

    public string SourceColumn
    {
        get { return sourceColumn; }
        set { sourceColumn = value; }
    }

    public string DestinationColumn
    {
        get { return destinationColumn; }
        set { destinationColumn = value; }
    }

    public string DataType
    {
        get { return dataType; }
        set { dataType = value; }
    }

    public string Length
    {
        get { return length; }
        set { length = value; }
    }
}
