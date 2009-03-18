using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IBase
/// </summary>
public interface IBase
{
    //possible attributes/properties? still an unknown

    //behaviours
    IList<T> Get();
    bool Add();
    bool Delete();
    void Clear();


}
