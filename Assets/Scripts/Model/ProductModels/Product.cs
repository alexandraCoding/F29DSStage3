using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product 
{

    public int key { get; set; }

    public int IDCODE { get; set; }

    public string productname { get; set; }

    public string description { get; set; }

    public string category { get; set; }

 



    public override string ToString()
    {
        return string.Format("Product Information:\n\t Key: {0},\n\t IDCode: {1},\n\t  Product Name: {2}, \n\t Description: {3}, Category: {4}, \n\t", key, IDCODE, productname, description, category);
    }
}
