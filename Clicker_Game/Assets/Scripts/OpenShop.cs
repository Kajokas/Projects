using UnityEngine;
using System.Collections;

public class OpenShop : MonoBehaviour {
    public GameObject game, shop;

    public void Shop(bool clicked) {
        if (clicked == true)
        {
            shop.gameObject.SetActive(clicked);
            game.gameObject.SetActive(false);
        }else {
            shop.gameObject.SetActive(clicked);
            game.gameObject.SetActive(true);
        }
    }
}
