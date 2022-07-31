using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PeopleTests 
{
    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/PeopleSite.unity");
    }



    [Test]
    public void FindPersonBySurnameTest()
    {
        //Arrange
         
        
        People people = new People();
        people.PeopleMembers = PersonFactory.GetPeople().PeopleMembers;

        //Act
       var personfound= people.FindPersonBySurname("Matzari");


        //Assert
        Assert.AreEqual("Matzari", personfound.lastname); 
    }
    [Test]
    public void FindPersonByKeyTest()
    {
        //Arrange


        People people = new People();
        people.PeopleMembers = PersonFactory.GetPeople().PeopleMembers;

        //Act
       var index= people.FindPersonByKey(1);
        var index2 = people.FindPersonByKey(2);
        var index3 = people.FindPersonByKey(3);
        var index4 = people.FindPersonByKey(4);


        //Assert

        Assert.AreEqual(0,index);

        Assert.AreEqual(1, index2);
        Assert.AreEqual(2, index3);
        Assert.AreNotEqual(3, index4);
    }

    [Test]
    public void UpdatePersonTest()
    {
        //Arrange


        People people = new People();
        people.PeopleMembers = PersonFactory.GetPeople().PeopleMembers;

        Person persontoreplace = new Person
        {
            lastname = "Loren",
            firstname = "Katerina",
            age = 34,
            accountNumber = "2355",
            amount = 345
        };

        //Act
        //var index = people.FindPersonByKey(1);

        people.UpdatePerson(1, persontoreplace);


        //Assert

        Assert.AreEqual(persontoreplace.lastname,people.PeopleMembers[0].lastname);

    }


    [Test]
    public void DeletePersonTest()
    {
        //Arrange


        People people = new People();
        people.PeopleMembers = PersonFactory.GetPeople().PeopleMembers;

        

        //Act
        //var index = people.FindPersonByKey(1);

        people.DeletePerson(3);


        //Assert

       Assert.AreEqual(2,people.PeopleMembers.Count);

    }

    [Test]
    public void InsertPersonTest()
    {
        //Arrange


        People people = new People();
        people.PeopleMembers = PersonFactory.GetPeople().PeopleMembers;

        Person persontoadd = new Person
        {
            lastname = "Loren",
            firstname = "Katerina",
            age = 34,
            accountNumber = "2355",
            amount = 345
        };

        //Act
        //var index = people.FindPersonByKey(1);

        people.InsertPerson(persontoadd);


        //Assert

        Assert.AreEqual(4, people.PeopleMembers.Count);

    }


    [Test]
    public void GetNextKeyTest()
    {
        //Arrange


        People people = new People();
        people.PeopleMembers = PersonFactory.GetPeople().PeopleMembers;


        int returnedkey=people.GetNextKey();

        //Assert

        Assert.AreEqual(3, people.PeopleMembers.Count);
        Assert.AreEqual(4, returnedkey);


    }


}

