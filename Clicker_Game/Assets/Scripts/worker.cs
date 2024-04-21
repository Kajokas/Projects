using UnityEngine;
using System.Collections;

public class worker : MonoBehaviour
{

    public Click1 click;
    public UnityEngine.UI.Text itemInfo;
    public float cost;
    public int count;
    public int tickValue;
    public string itemName;
    private float baseCost;

    void Start()
    {
        baseCost = cost;
    }

    void Update()
    {
        itemInfo.text = itemName + "\nCost: " + cost + "\nMoney: +" + tickValue + "/h";
    }

    public void PurchasedItem()
    {
        if (click.money >= cost)
        {
            click.money -= cost;
            count += 1;
            cost = Mathf.Round (baseCost * Mathf.Pow(1.15f, count));
        }
    }
}