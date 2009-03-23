using System.Collections.Generic;



public class ParmList
{
    private readonly List<ParmObject> m_list;

    public ParmList()
    {
        m_list = new List<ParmObject>();
    }

    public List<ParmObject> Items
    {
        get
        {
            return (m_list);
        }
    }

    public void Add(ParmObject P_obj)
    {
        m_list.Add(P_obj);
    }

    public void Add(string P_name, object P_obj)
    {
        m_list.Add(new ParmObject(P_name, P_obj));
    }
}

public class ParmObject
{
    public string ParmName { get; private set; }
    public object ParmObj { get; private set; }

    public ParmObject(string P_parmName, object P_obj)
    {
        ParmName = P_parmName;
        ParmObj = P_obj;
    }
}
