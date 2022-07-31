using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Proyecto26;
using Models;
using UnityEditor;

public class AzureDataAccessor : IDataAccessor
{

   

    public void GetItem<T>(IDataReceiver dataReceiver, string url)
    {
        //http://localhost:11919/https://localhost:49157/products
        ///////////////excersizemvvmwebapi.azurewebsites.net/people
        ///https://productsgetterapiservice.orangeground-b08e00a0.westeurope.azurecontainerapps.io
        //////https://excersizemvvmwebapi.azurewebsites.net/
        ///for the people
        /////
        ///////for the productshttps://buildingsservice.orangeground-b08e00a0.westeurope.azurecontainerapps.io/
        RestClient.Request(new RequestHelper
            {  
                Method = "GET", 
                Uri = "https://peopleapicall.orangeground-b08e00a0.westeurope.azurecontainerapps.io/" + url
        }).Then(res =>
            {
                var item = JsonConvert.DeserializeObject<T>(res.Text);
                dataReceiver.ReceiveData<T>(item);

            }).Catch(err =>
            {
                var error = err as RequestException;
                Debug.LogError(error);
            });

       
        }

   

    public void SaveItem<T>(object item, string url)
    {
        var itemToSave = JsonConvert.SerializeObject(item);
       
       
        RestClient.Put<T>("https://peopleapicall.orangeground-b08e00a0.westeurope.azurecontainerapps.io/" + url, itemToSave).Then(customResponse =>
        {
            //JsonUtility.ToJson(customResponse, true);
            Debug.Log("object" + itemToSave);
        });



     
    }

   



}
