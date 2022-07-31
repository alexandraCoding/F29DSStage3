using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SearchBarViewModelTests 
{
    private SearchBarController searchBarController;

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/PeopleSite.unity");
        searchBarController = GameObject.Find("SearchBarController").GetComponent<SearchBarController>();
    }

    //[Test]
    //public void SavePersonTest()
    //{
    //    //Arrange
    //    var viewmodelToTest = GameObject.Find("SearchBarViewModel").GetComponent<SearchBarViewModel>();
    //    var person = new Person
    //    {
    //        accountNumber = "345",
    //        age = 26,
    //        amount = 26,
    //        firstname = "Peter",
    //        lastname = "Test"
    //    };

    //    //Act
    //    //inject editaccount + dataaccessor
    //    viewmodelToTest.SavePerson();


    //    //Assert



    //}

    


    
    [Test]
    public void CanChangeSettingsProviderLocal()
    {
        //Arrange
        var localProvider = new LocalDataAccessor();

        //Act
        searchBarController.setLocalProvider();



        //Assert
        Assert.AreEqual(localProvider.GetType(), searchBarController.dataProvider.GetType());


    }

    [Test]
    public void CanChangeSettingsProviderReal()
    {
        //Arrange
        var azureProvider = new AzureDataAccessor();

        //Act
        searchBarController.setAzureProvider();



        //Assert
        Assert.AreEqual(azureProvider.GetType(), searchBarController.dataProvider.GetType());


    }


}
