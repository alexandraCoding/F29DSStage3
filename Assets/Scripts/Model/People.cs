
using System.Collections;
using System.Collections.Generic;

public class People 
{
    public List<Person> PeopleMembers = new List<Person>();

    public Person FindPersonBySurname(string name)
    {
        foreach (var person in PeopleMembers)
        {

            if (person.lastname.ToLower() == name.ToLower())
                return person;

        }
        return null;
    }
    public int FindPersonByKey(int key)
    {
        int c = 0;

        foreach (var person in PeopleMembers)
        {



            if (person.key== key)
                return c;
            c++;


        }
        return -1;
    }
 
    public void UpdatePerson(int key, Person replacementperson)
    {
         var index = FindPersonByKey(key);

        PeopleMembers[index] = replacementperson;


    }

    public void DeletePerson(int key)
    {
        var index = FindPersonByKey(key);

       PeopleMembers.RemoveAt(index);


    }

    public void InsertPerson(Person person)
    {
        person.key = GetNextKey();
        PeopleMembers.Add(person);
        
    }
    public int GetNextKey()
    {
        int maxvalue = 0;
        foreach(var  key in PeopleMembers)
        {
            if (key.key > maxvalue)
            {
                maxvalue = key.key;
            }
          
        }
        return maxvalue+1;
    }

}
