using UnityEngine;
using System.Collections;

public class Cards : MonoBehaviour {

    public Click1 click;
    public UnityEngine.UI.Text itemInfo;
    public float cost;
    public int count = 0;
    public GameObject game, shop;

    void Update()
    {
        itemInfo.text = "\nCost: " + cost;
    }

    public void PurchasedUpgrade(bool clicked)
    {
        if (click.money >= cost)
        {
            click.money -= cost;
            if (clicked == true)
            {
                shop.gameObject.SetActive(clicked);
                game.gameObject.SetActive(false);
            }
            else
            {
                shop.gameObject.SetActive(clicked);
                game.gameObject.SetActive(true);
            }
        }
    }

}
