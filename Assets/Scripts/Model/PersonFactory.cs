
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersonFactory 
{ 
    public static People GetPeople()
    {
        var people = new People
        {
           
        };
        var person1 = new Person
        {
            key=1,
           
            lastname = "Matzari",
            firstname = "Alexandra",
            age=104,
            accountNumber="13132",
            amount = 120000,
            productID=10022

        };
        var person2 = new Person
        { key=2,
            
            lastname = "Cole",
            firstname = "David",
            age = 14,
            accountNumber = "56565",
            amount = 20000

        };
        var person3 = new Person
        { key=3,
            
            lastname = "Volre",
            firstname = "Simona",
            age = 20,
            accountNumber = "2732",
            amount = 29990

        };


        people.PeopleMembers.Add(person1);
        people.PeopleMembers.Add(person2);
        people.PeopleMembers.Add(person3);

        return people;
    }
}
