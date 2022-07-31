using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


public class EditAccountViewModelTests : MonoBehaviour
{
    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/PeopleSite.unity");
    }

    

    [Test]
    public void CanSetPersonProperty()
    {
        //Arrange
        var viewmodelToTest = GameObject.Find("EditAccountViewModel").GetComponent<EditAccountViewModel>();
        var person = new Person
        {
            accountNumber = "345",
            age = 26,
            amount = 26,
            firstname = "Peter",
            lastname = "Test"
        };

        //Act

        viewmodelToTest.Person = person;

        //Assert

        Assert.AreEqual(person.accountNumber, viewmodelToTest.Person.accountNumber);
        Assert.AreEqual(person.age, viewmodelToTest.Person.age);
        Assert.AreEqual(person.amount, viewmodelToTest.Person.amount);
        Assert.AreEqual(person.firstname, viewmodelToTest.Person.firstname);
        Assert.AreEqual(person.lastname, viewmodelToTest.Person.lastname);

    }

    [Test]
    public void CanSetTextUI()
    {
        //Arrange
        var viewmodelToTest = GameObject.Find("EditAccountViewModel").GetComponent<EditAccountViewModel>();
        var person = new Person
        {
            accountNumber = "345",
            age = 26,
            amount = 26,
            firstname = "Peter",
            lastname = "Test"
        };

        //Act

        viewmodelToTest.Person = person;

        //Assert

        Assert.AreEqual(person.accountNumber, viewmodelToTest.accountaccountnumber.text);
        Assert.AreEqual(person.age.ToString(), viewmodelToTest.accountagetext.text);
        Assert.AreEqual(person.amount.ToString(), viewmodelToTest.amounttext.text);
        Assert.AreEqual(person.firstname, viewmodelToTest.accountfirstnametext.text);
        Assert.AreEqual(person.lastname, viewmodelToTest.accountlastnametext.text);

    }

    public void CanGetPersonProperty()
    {
        //Arrange
        var viewmodelToTest = GameObject.Find("EditAccountViewModel").GetComponent<EditAccountViewModel>();
        var person = new Person
        {
            accountNumber = "345",
            age = 26,
            amount = 26,
            firstname = "Peter",
            lastname = "Test"
        };

        //Act


        viewmodelToTest.Person = person;

        viewmodelToTest.accountlastnametext.text = "Roland";
        var updatedPerson = viewmodelToTest.Person;
        //Assert

        
        Assert.AreEqual(updatedPerson.lastname, "Roland");

    }

}
