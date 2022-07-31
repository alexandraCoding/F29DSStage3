using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProductFactory 
{
    public static Products GetProducts()
    {
        var products = new Products
        {

        };

        var product1 = new Product
        {
            key = 1,

            IDCODE = 10021,
            productname = "GRID_Building",
            description = "Floor_2",
            category = "StorageAccount"

        };

       

    var product2 = new Product
        {
        key = 2,

        IDCODE = 10022,
        productname = "Robatorium_Building",
        description = "Floor_3",
        category = "BusinessAccount"

    };

        var product3 = new Product
        {
            key = 3,

            IDCODE = 10023,
            productname = "EBS_Building",
            description = "Floor_4",
            category = "ConferenceAccount"

        };










        products.ProductMembers.Add(product1);
        products.ProductMembers.Add(product2);
        products.ProductMembers.Add(product3);



        return products;
    }
}




