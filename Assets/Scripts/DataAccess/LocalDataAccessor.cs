
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class LocalDataAccessor : IDataAccessor
{
    public void GetItem<T>(IDataReceiver dataReceiver, string url )
    {
        var filename = url + ".json";
        if (File.Exists(filename))
        {
            Debug.Log("File exists");
            string itemJson = File.ReadAllText(filename);
            
            var item = JsonConvert.DeserializeObject<T>(itemJson);
            
            dataReceiver.ReceiveData<T>(item);

        }
        else
        {
            Debug.Log("File does not exist, we create people with Factory and saving it"+ filename);
            //To Check later 
            if (url == "people")
            {
               var item = PersonFactory.GetPeople();
                SaveItem<T>(item, url);
            }
            if(url == "products")
            {
                var item = ProductFactory.GetProducts();
                SaveItem<T>(item, url);
            }
            
           
        }
       
    }

    public void SaveItem<T>(object item, string url)
    {


        string strResultJson = JsonConvert.SerializeObject(item);
        var filename = url + ".json";

        File.WriteAllText(filename, strResultJson);

    }
}
