using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for FixDataFeed
/// </summary>
public class FixDataFeed
{
    private string filename;


    public FixDataFeed()
    {
    }

    public FixDataFeed(string filename)
    {
        this.filename = filename;
    }
    
    public void RemoveHtmlTags()
    {
        //find HTML tags
        Regex matchHtmlTags = new Regex(@"&lt;.*?&gt;");

        string[] file = Read();

        //remove tags for every line in the file
        for (int i = 0; i < file.Count(); i++)
        {
            file[i] = matchHtmlTags.Replace(file[i], "");
        }

        //overwrite file
        Write(file);
    }

    public string[] Read()
    {
        return File.ReadAllLines(filename);
    }

    public void Write(string[] text)
    {
        //File.WriteAllLines(filename, text);
        File.WriteAllLines(filename, text);
    }

    public string Filename
    {
        get { return filename; }
        set { filename = value; }
    }
}
