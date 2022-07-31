using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Proyecto26;
using Models;
using UnityEditor;

public class ContainerAzureRobotsDataAccessor : IDataAccessor
{

    public void GetItem<T>(IDataReceiver dataReceiver, string url)
    {
        
        RestClient.Request(new RequestHelper
        {
            Method = "GET",
            Uri = "https://containerrobotsgetter.orangeground-b08e00a0.westeurope.azurecontainerapps.io/" + url
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


        RestClient.Put<T>("https://containerrobotsgetter.orangeground-b08e00a0.westeurope.azurecontainerapps.io/" + url, itemToSave).Then(customResponse =>
        {
            //JsonUtility.ToJson(customResponse, true);
            Debug.Log("object" + itemToSave);
        });




    }



}
