using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditProductViewModel : MonoBehaviour
{
    private Product product;
    private int key;

    public TMP_InputField productIDtext;
    public TMP_InputField productnametext;
    public TMP_InputField productdescriptiontext;
    public TMP_InputField productcategorytext;
    


    public Products productslist;
    public IDataAccessor dataProvider;


    public void Start()
    {
        dataProvider = new LocalDataAccessor();


    }

    public Product Product
    {
        get
        {
            return GetCoreProperties();
        }
        set
        {
            product = value;

            SetCoreProperties();
        }
    }

    public Products Products
    {
        get
        {
            return productslist;
        }
        set
        {
            productslist = value;


        }
    }

    public int Key
    {
        get
        {//this is a UI property returned
            return key;
        }
        set
        {//this is setting the UI property
            key = value;
        }
    }

    public int IDCode
    {
        get
        {
            return int.Parse(productIDtext.text);
        }
        set
        {
            productIDtext.text = value.ToString();
        }
    }

    public string Productname
    {
        get
        {
            return productnametext.text;
        }
        set
        {
            productnametext.text = value;
        }
    }

    public string Description
    {
        get
        {
            return productdescriptiontext.text;
        }
        set
        {
            productdescriptiontext.text = value;
        }
    }

    public string Category
    {
        get
        {
            return productcategorytext.text;
        }
        set
        {
            productcategorytext.text = value;
        }
    }


    public void SetCoreProperties()
    {

        // var person = person.FindPersonBySurname(searchBarViewModel.searchinputtext.ToString());
        if (product != null)
        {
            Key = product.key;

            IDCode = product.IDCODE;
            Productname = product.productname;
            Description = product.description;
            Category = product.category;
           
        }

    }

    public Product GetCoreProperties()
    {
        var product = new Product
        {
            key = Key,
            IDCODE = IDCode,
            productname = Productname,
            description = Description,
            category = Category,
           


        };

        return product;
    }
    public void SaveProduct()
    {
        //dependency injection 


        //the empty person has the last key and give it to the update person method to find and locate the new information. 
        var productToSave = Product;

        productslist.UpdateProduct(productToSave.key, productToSave);


        dataProvider.SaveItem<Products>(productslist, "products");



    }

    public void DeleteProduct()
    {
        //dependency injection 


        var productToDelete = Product;

        productslist.DeleteProduct(productToDelete.key);


        dataProvider.SaveItem<Products>(productslist, "products");



        //provider model plugin grind framework- gateaway

    }

    public void InsertProduct()
    {

        //  var personToInsert = editaccountviewModel.Person;
        var productToInsert = new Product();
        productslist.InsertProduct(productToInsert);

        //it has the key of the getkey method from insert
        Product = productToInsert;


    }
}




