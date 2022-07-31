using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductListViewModel : MonoBehaviour, IDataReceiver
{

    public IDataAccessor dataProvider;


    public Products productslist;
    public Product product;
    public Person person;
    public TMPro.TMP_Text mytextNameDisplay;
    public TMPro.TMP_Text mytextDescriptionDisplay;
    public TMPro.TMP_Text mytext1NameDisplay;
    public TMPro.TMP_Text mytext1DescriptionDisplay;
    public TMPro.TMP_Text mytext2NameDisplay;
    public TMPro.TMP_Text mytext2DescriptionDisplay;

    public delegate void ProductChosen(int productID);
    public static event ProductChosen OnProductChosen;

    //CheckChoices
    public Toggle checkToggle1;
    public Toggle checkToggle2;
    public Toggle checkToggle3;

    void Start()
    {
        dataProvider = new LocalDataAccessor();
        dataProvider.GetItem<Products>(this, "products");

       

        checkToggle1.isOn = false;
        checkToggle2.isOn = false;
        checkToggle3.isOn = false;

    }

    public Person Person
    {
        get
        {
            return person;
        }
        set
        {
            person = value;



            
        }
    }
    
    public void ReceiveData<T>(object data)
    {
        productslist = (Products)data;
        GiveProductList(productslist);
    }
    public Products GiveProductList(Products item)
    {
        var productsToGive = item;

        return productsToGive;
    }
  
    public void ProductSelector()
    {

        Debug.Log(productslist);
        
        var product = productslist.FindProductByOrder(0);
       
        mytextNameDisplay.text = product.productname;
        mytextDescriptionDisplay.text = product.description;
        var product1 = productslist.FindProductByOrder(1);
       
        mytext1NameDisplay.text = product1.productname;
        mytext1DescriptionDisplay.text = product1.description;
        var product2 = productslist.FindProductByOrder(2);
        
        mytext2NameDisplay.text = product2.productname;
        mytext2DescriptionDisplay.text = product2.description;


    }

   

    public void SaveChoicesToPerson()
    {
        if (checkToggle1.isOn)
        {
            var product = productslist.FindProductByOrder(0);
            if (OnProductChosen != null)
            {
                OnProductChosen(product.IDCODE);

            }

            //eventcalled - product person and editaccount should pass the item 

        }
        if (checkToggle2.isOn) 
        {
            var product = productslist.FindProductByOrder(1);
            if (OnProductChosen != null) 
            {
                OnProductChosen(product.IDCODE);
            
            }

            //eventcalled - product person and editaccount should pass the item 

        }
        if (checkToggle3.isOn)
        {
            var product = productslist.FindProductByOrder(2);
            if (OnProductChosen != null)
            {
                OnProductChosen(product.IDCODE);

            }

            //eventcalled - product person and editaccount should pass the item 

        }
        else if(!checkToggle1.isOn)
        {
            var product = productslist.FindProductByProductName("");
            
            
          
        }
       
        else
        {
            Debug.Log("No change selected");
        }
    
       
    }

}
