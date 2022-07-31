using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class SearchBarProductController : MonoBehaviour, IDataReceiver
{    public TMP_InputField searchinputtext;
    public EditProductViewModel editproductviewModel;
    public IDataAccessor dataProvider;
    public string inputtext;
    public Products  productslist;
    public void Start()
    {  dataProvider = new LocalDataAccessor();
        //this is where the connection is happening
        dataProvider.GetItem<Products>(this, "products");
    }
    public void KeyPressed()
    {
        //var searchBarController = this;
        //dataProvider.GetItem<Products>(this, "products");
        //
        inputtext = searchinputtext.text;
        var product = productslist.FindProductByProductName(inputtext);
        editproductviewModel.Product = product;
        editproductviewModel.productslist = productslist;
    }
    public void setLocalProvider()
    {
        Debug.Log("Called Local Accessor");
        var localProvider = new LocalDataAccessor();
        dataProvider = localProvider;
        editproductviewModel.dataProvider = localProvider;
        dataProvider.GetItem<Products>(this, "products");
    }
    public void setAzureProvider()
    {   
        Debug.Log("Called Azure Accessor Section");
        //var azureProvider = new AzureDataAccessor();
        //dataProvider = azureProvider;
        //editproductviewModel.dataProvider = azureProvider;
        //dataProvider.GetItem<Products>(this, "products");
    }
    public void ReceiveData<T>(object data)
    {   productslist = (Products)data;
        GiveProductList(productslist);
     }
    public Products GiveProductList(Products item)
    {        var productsToGice = item;
             return productsToGice;
    }


    public void setRobotsProvider()
    {
        Debug.Log("Called Robots Accessor");
        var provider = new ContainerAzureRobotsDataAccessor();
        dataProvider = provider;
        editproductviewModel.dataProvider = provider;
        dataProvider.GetItem<Products>(this, "products");
    }
    public void setBuildingsProvider()
    {
        Debug.Log("Called Buldings Accessor");
        var provider = new AzureDataAccessor();
        dataProvider = provider;
        editproductviewModel.dataProvider = provider;
        dataProvider.GetItem<Products>(this, "products");
    }

    public void setFinanceProvider()
    {
        Debug.Log("Called Finance Accessor");
        var provider = new ContainerAzureFinanceDataAccessor();
        dataProvider = provider;
        editproductviewModel.dataProvider = provider;
        dataProvider.GetItem<Products>(this, "products");
    }

}












    




    





   
