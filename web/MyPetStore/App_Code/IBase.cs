using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// The interface for our dbAPI objects to implement
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
