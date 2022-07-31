using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DataAccessorProductsTests : MonoBehaviour
{
    /////////////////////////////////////////////////////////////////
    ///
    // Testing Products
    ////////////////////////////////////////////
    /////////////////////////////////////////
    private SearchBarProductController searchBarProductController;
    [SetUp]
    public void SetUp()
    {

        EditorSceneManager.OpenScene("Assets/Scenes/ProductSite.unity");

        searchBarProductController = GameObject.Find("SearchBarProductController").GetComponent<SearchBarProductController>();
    }
    [Test]
    public void TestProductsLoader()
    {
        //Arrange
        var dataAccess = new LocalDataAccessor();
        var products = ProductFactory.GetProducts();


        //Act
        dataAccess.SaveItem<Products>(products, "products");
        dataAccess.GetItem<Products>(searchBarProductController, "products");

        Products productsToLoad = searchBarProductController.productslist;
        // USE AREEQUAL FOR VALUE COMPARISONS
        // Assert
        Assert.AreEqual(products.ProductMembers.Count, productsToLoad.ProductMembers.Count);
    }

    [Test]
    public void TestProductsFirstPerson()
    {
        //Arrange
        var dataAccess = new LocalDataAccessor();
        var products = ProductFactory.GetProducts();


      

        //Act
        dataAccess.SaveItem<Products>(products, "products");
        dataAccess.GetItem<Products>(searchBarProductController, "products");

        Products productsToLoad = searchBarProductController.productslist;





        Assert.AreEqual(products.ProductMembers[0].productname, productsToLoad.ProductMembers[0].productname);

    }

    [Test]
    public void TestProductLoaderAzure()
    {
        //Arrange
        var dataAccess = new AzureDataAccessor();
        var products = ProductFactory.GetProducts();


        //Act
        dataAccess.SaveItem<Products>(products, "products");
        dataAccess.GetItem<Products>(searchBarProductController, "products");

        Products productsToLoad = searchBarProductController.productslist;


        // USE AREEQUAL FOR VALUE COMPARISONS
        // Assert
        Assert.AreEqual(products.ProductMembers.Count, productsToLoad.ProductMembers.Count);




    }

    [Test]
    public void TestProductsFirstProductAzure()
    {
        //Arrange
        var dataAccess = new AzureDataAccessor();
        var products = ProductFactory.GetProducts();


        // var viewModelToTest = GameObject.Find("SearchBarViewModel").GetComponent<SearchBarViewModel>();

        //Act
        dataAccess.SaveItem<Products>(products, "products");
        dataAccess.GetItem<Products>(searchBarProductController, "products");

        Products productsToLoad = searchBarProductController.productslist;





        Assert.AreEqual(products.ProductMembers[0].productname, productsToLoad.ProductMembers[0].productname);

    }
}
