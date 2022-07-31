using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person 
{
    public int key { get; set; }

    public string firstname { get; set; }
    public string lastname { get; set; }
    public int age { get; set; }
    public string accountNumber  { get; set; }
    public float amount { get; set; }
    public int productID { get; set; }

    public override string ToString()
    {
        return string.Format("Account Information:\n\t Key: {0},\n\t  Firstname: {1}, \n\t Lastname: {2}, Age: {3}, \n\t" +
            " Account Number: {4},\n\t Passnumber: {5},\n\t ProductID: {6}", key, firstname, lastname, age, accountNumber, amount, productID);
    }
}
