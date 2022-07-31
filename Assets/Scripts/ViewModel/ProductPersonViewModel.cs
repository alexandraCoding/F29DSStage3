using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPersonViewModel : MonoBehaviour, IDataReceiver
{
    public IDataAccessor dataProvider;


    public Products productslist;
    public Product product;
    private Person person;
    public TMPro.TMP_Text textproduct;
    public ProductListViewModel productListViewModel;
    void Start()
    {
        dataProvider = new LocalDataAccessor();
        productListViewModel = GameObject.Find("ProductListViewModel").GetComponent<ProductListViewModel>();
        //this is where the connection is happening
       dataProvider.GetItem<Products>(this,"products");
    }


    public Person Person
    {
        get
        {
            return GetCoreProperties();
        }
        set
        {
            person = value;

            SetCoreProperties();
        }
    }

    public Product Product
    {
        get
        {
            return null;// product.productname= textproduct.text ; 
        }
        set
        {
            product = value;
            textproduct.text = product.productname;
        }
    }

    private void SetCoreProperties()
    {
        
        if (person != null)
        {
            var myproduct = productslist.GetProductByIDCODE(person.productID);
            //var myproduct = productslist.GetProductByIDCODE(10022);
            if (myproduct != null)
            {
                Product = myproduct;
                productListViewModel.Person = person;
            }
           
          
            //Product productListViewModel.product;
            //  Product = person.product.productname;
        }
    }

    private Person GetCoreProperties()
    {

        var person = new Person
        {


            };

            return person;
        
    }

    public void ReceiveData<T>(object data)
    {
        productslist = (Products)data;
        GiveProductList(productslist);
    }
    public Products GiveProductList(Products item)
    {
        var productsToGice = item;
        return productsToGice;
    }
}
