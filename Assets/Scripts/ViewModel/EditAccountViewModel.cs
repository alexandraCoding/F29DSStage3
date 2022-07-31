
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditAccountViewModel : MonoBehaviour
{    //data bounding of view with model
    //view model is a controller with ui properties bound to data model
    private Person person;
    private int key,chosenProductId;
    public TMP_InputField accountlastnametext;
    public TMP_InputField accountfirstnametext;
    public TMP_InputField accountagetext;
    public TMP_InputField accountaccountnumber;
    public TMP_InputField amounttext;
    public TMP_Text accountrpoduct;
    public ProductPersonViewModel productPersonViewModel;
    public People peoplelist;
    public IDataAccessor dataProvider;
    public void Start()
    {  dataProvider = new LocalDataAccessor();
    }
    public void OnEnable()
    {
        ProductListViewModel.OnProductChosen += ProductListViewModel_OnProductChosen;
    }

    private void ProductListViewModel_OnProductChosen(int productID)
    {
        chosenProductId = productID;
        //forces update
        Person = Person;//both properties to call setproperties and get
    }

    public void OnDisable()
    {
        ProductListViewModel.OnProductChosen -= ProductListViewModel_OnProductChosen;
    }
    public Person Person
    {   get
        {
            return GetCoreProperties();
        }
        set
        {
           person = value;
           


           SetCoreProperties();
        }
    }
    public People People
    {
        get
        {
            return peoplelist;
        }
        set
        {
            peoplelist = value;

        }
    }
    //this is a viewmodelproperty
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
    public string LastName
    {
        get
        {//this is a UI property returned
            return accountlastnametext.text;
        }
        set
        {//this is setting the UI property
            accountlastnametext.text = value;
        }
    }
    public string FirstName
    {
        get
        {
            return accountfirstnametext.text;
        }
        set
        {
            accountfirstnametext.text = value;
        }
    }
    public int Age
    {
        get
        {
            return int.Parse(accountagetext.text);
        }
        set
        {
            accountagetext.text = value.ToString();
        }
    }

    public string AccountNumber
    {
        get
        {
            return accountaccountnumber.text;
        }
        set
        {
            accountaccountnumber.text = value;
        }
    }

    public float Ammount
    {
        get
        {
            return float.Parse(amounttext.text);
        }
        set
        {
            amounttext.text = value.ToString();
        }
    }

   
    public void SetCoreProperties()
    {  // var person = person.FindPersonBySurname(searchBarViewModel.searchinputtext.ToString());
        if (person != null)
        {   Key=person.key; LastName = person.lastname; FirstName = person.firstname;
            Age = person.age; AccountNumber = person.accountNumber;
            Ammount = person.amount;
            chosenProductId = person.productID;
           productPersonViewModel.Person = person;
        }
    }
    public Person GetCoreProperties()
    {
        var person = new Person
        { key = Key, firstname = FirstName, lastname = LastName,
            age = Age, amount = Ammount, accountNumber = AccountNumber,
            productID = chosenProductId
            
             };
        return person;
    }
    public void SavePerson()
    {  //dependency injection 
        //the empty person has the last key and give it to the update person method to find and locate the new information. 
        var personToSave = Person;
        peoplelist.UpdatePerson(personToSave.key, personToSave);
      dataProvider.SaveItem<People>(peoplelist, "people");
    }

    public void DeletePerson()
    {   //dependency injection 
        var personToDelete = Person;
        peoplelist.DeletePerson(personToDelete.key);
       dataProvider.SaveItem<People>(peoplelist, "people");
    }
    public void InsertPerson()
    {   //  var personToInsert = editaccountviewModel.Person;
        var personToInsert = new Person();
        peoplelist.InsertPerson(personToInsert);
        //it has the key of the getkey method from insert
        Person = personToInsert;
    }

   
}
