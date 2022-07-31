

using System.Collections.Generic;

public interface IDataAccessor 
{
    void SaveItem<T>(object item,string url);
    void GetItem<T>(IDataReceiver dataReceiver, string url);
    //IdataAccessor includes the IdataReceiver (utilized not including it)
}
