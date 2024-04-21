using UnityEngine;
using System.Collections;

public class Openshop001 : MonoBehaviour {

    public GameObject shop;

    public void Shop(bool clicked)
    {
        if (clicked == true)
        {
            shop.gameObject.SetActive(clicked);
        }
        else
        {
            shop.gameObject.SetActive(clicked);
        }
    }
}