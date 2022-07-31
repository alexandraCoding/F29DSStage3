using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[TestFixture]
public class DataAccessorPeopleTests
{


    private SearchBarController searchBarController;
   

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/PeopleSite.unity");

        searchBarController = GameObject.Find("SearchBarController").GetComponent<SearchBarController>();


    }


//[Test]
//public void TestPeopleLoader()
//{
//    //Arrange
//    var dataaccess = new DataAccessPoint();
//    var server = PersonFactory.GetServer();
//    var listpeople = server.people;
//    // var viewModelToTest = GameObject.Find("SearchBarViewModel").GetComponent<SearchBarViewModel>();
//    dataaccess.SavePeople(listpeople);
//     //Act
//    List<Person> peopleToLoad= dataaccess.Loadpeople();


//    //USE AREEQUAL FOR VALUE COMPARISONS
//    //Assert
//   Assert.AreEqual(listpeople.Count, peopleToLoad.Count);




//}

    [Test]
    public void TestPeopleLoader()
    {
        //Arrange
        var dataAccess = new LocalDataAccessor();
        var people = PersonFactory.GetPeople();


        //Act
        dataAccess.SaveItem<People>(people,"people");
        dataAccess.GetItem<People>(searchBarController, "people");

        People peopleToLoad = searchBarController.peoplelist;
        // USE AREEQUAL FOR VALUE COMPARISONS
        // Assert
        Assert.AreEqual(people.PeopleMembers.Count, peopleToLoad.PeopleMembers.Count);




    }

    [Test]
    public void TestPeopleFirstPerson()
    {
        //Arrange
        var dataAccess = new LocalDataAccessor();
        var people = PersonFactory.GetPeople();


        // var viewModelToTest = GameObject.Find("SearchBarViewModel").GetComponent<SearchBarViewModel>();

        //Act
        dataAccess.SaveItem<People>(people, "people");
        dataAccess.GetItem<People>(searchBarController, "people");

        People peopleToLoad = searchBarController.peoplelist;





        Assert.AreEqual(people.PeopleMembers[0].lastname, peopleToLoad.PeopleMembers[0].lastname);

    }

    [Test]
    public void TestPeopleLoaderAzure()
    {
        //Arrange
        var dataAccess = new AzureDataAccessor();
        var people = PersonFactory.GetPeople();


        //Act
        dataAccess.SaveItem<People>(people, "people");
        dataAccess.GetItem<People>(searchBarController, "people");

        People peopleToLoad = searchBarController.peoplelist;


        // USE AREEQUAL FOR VALUE COMPARISONS
        // Assert
        Assert.AreEqual(people.PeopleMembers.Count, peopleToLoad.PeopleMembers.Count);




    }

    [Test]
    public void TestPeopleFirstPersonAzure()
    {
        //Arrange
        var dataAccess = new AzureDataAccessor();
        var people = PersonFactory.GetPeople();


        // var viewModelToTest = GameObject.Find("SearchBarViewModel").GetComponent<SearchBarViewModel>();

        //Act
        dataAccess.SaveItem<People>(people, "people");
        dataAccess.GetItem<People>(searchBarController, "people");

        People peopleToLoad = searchBarController.peoplelist;





        Assert.AreEqual(people.PeopleMembers[0].lastname, peopleToLoad.PeopleMembers[0].lastname);

    }

   
   

   
}
