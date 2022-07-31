//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DropDownSelectionViewModel : MonoBehaviour
//{

//    public Image myImage;
//    public TMPro.TMP_Dropdown myDrop;
//    public Product product;
    
//    public TMPro.TMP_Text mytextNameDisplay;
//    public TMPro.TMP_Text mytextDescriptionDisplay;

//    public void ColorSelector()
//    {
//        if (myDrop.value == 0) myImage.color = Color.red;
//        else if (myDrop.value == 1) myImage.color = Color.green;
//        else if (myDrop.value == 2) myImage.color = Color.blue;


//    }

//    public void ProductSelector()
//    {
//        if (myDrop.value == 0)
//        {
//            product.productname = SearchBarProductController.instance.productslist.FindProductByProductName("StorageAccount").ToString();
//            mytextNameDisplay.text = product.productname;
//            mytextDescriptionDisplay.text = product.description;
//        }
//        else if (myDrop.value == 1)
//        {
//            product.productname = SearchBarProductController.instance.productslist.FindProductByProductName("RunningAccount").ToString();
//            mytextNameDisplay.text = product.productname;
//            mytextDescriptionDisplay.text = product.description;
//        }
//        else if (myDrop.value == 2) {
//            product.productname = SearchBarProductController.instance.productslist.FindProductByProductName("InVesting").ToString();
//            mytextNameDisplay.text = product.productname;
//            mytextDescriptionDisplay.text = product.description;
//        }


//    }
//}
