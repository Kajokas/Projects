using UnityEngine;
using System.Collections;

public class RareCards : MonoBehaviour {

    //public Click1 click;
    public makeM Click;
    public UnityEngine.UI.Text itemInfo;
    public float cost;
    public int count = 0;
    public GameObject game, shop;

    void Update()
    {
        itemInfo.text = "\nCost: " + cost + "M";
    }

    public void PurchasedUpgrade(bool clicked)
    {
        if (Click.Money >= cost)
        {
            Click.Money -= cost;
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
