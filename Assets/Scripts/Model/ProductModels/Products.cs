using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Products 
{
    public List<Product> ProductMembers = new List<Product>();





    public Product FindProductByProductName(string name)
    {
        foreach (var product in ProductMembers)
        {



            if (product.productname.ToLower() == name.ToLower())
                return product;



        }
        return null;
    }

    public Product FindProductByOrder(int i)
    {
        if (i < ProductMembers.Count)
        {
            var product = ProductMembers[i];
            return product;
        }
        else
        {
            return null;
        }

        return null;





    }

    public Product GetProductByIDCODE(int IDCODE)
    {
        

        foreach (var product in ProductMembers)
        {



            if (product.IDCODE == IDCODE)
                return product;
            


        }
        return null;
    }

    public int FindProductByKey(int key)
    {
        int c = 0;

        foreach (var product in ProductMembers)
        {



            if (product.key == key)
                return c;
            c++;


        }
        return -1;
    }
    //add new methods of adding and deleting person 
    //
    public void UpdateProduct(int key, Product replacementproduct)
    {
        var index = FindProductByKey(key);

        ProductMembers[index] = replacementproduct;


    }


    public void DeleteProduct(int key)
    {
        var index = FindProductByKey(key);

        ProductMembers.RemoveAt(index);


    }




    public void InsertProduct(Product product)
    {
        product.key = GetNextKey();
        ProductMembers.Add(product);

    }

    public int GetNextKey()
    {
        int maxvalue = 0;
        foreach (var key in ProductMembers)
        {
            if (key.key > maxvalue)
            {
                maxvalue = key.key;
            }

        }
        return maxvalue + 1;
    }

}
