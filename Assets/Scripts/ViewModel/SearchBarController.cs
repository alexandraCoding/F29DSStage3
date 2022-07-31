
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchBarController : MonoBehaviour, IDataReceiver
{   public TMP_InputField searchinputtext;
    public EditAccountViewModel editaccountviewModel;
    public IDataAccessor dataProvider;
    public string inputtext;
   public People peoplelist;
    public void Start()
    {  dataProvider = new LocalDataAccessor();
        //this is where the connection is happening
        dataProvider.GetItem<People>(this,"people");
    }
    public void KeyPressed()
    {     var searchBarController = this;
            dataProvider.GetItem<People>(this, "people");
            editaccountviewModel.peoplelist = peoplelist;
            inputtext = searchinputtext.text;
            var person = peoplelist.FindPersonBySurname(inputtext);
            editaccountviewModel.Person = person;
    }
    public void setLocalProvider()
    {  Debug.Log("Called Local Accessor");
        var localProvider = new LocalDataAccessor();
        dataProvider = localProvider;
        editaccountviewModel.dataProvider = localProvider;
        dataProvider.GetItem<People>(this, "people");
    }
    public void setAzureProvider()
    {   Debug.Log("Called Azure Accessor");
        var azureProvider = new AzureDataAccessor();
       dataProvider = azureProvider;
       editaccountviewModel.dataProvider = azureProvider;
       dataProvider.GetItem<People>(this, "people");
    }
    public void ReceiveData<T>(object data)
    {  ///Important!!!!!
        peoplelist = (People)data;
        //GiveProductList(peoplelist);
    }   
   // public People GiveProductList(People item)
   // {   var peopleToGive = item;
    //    return peopleToGive;
  //  }
}

