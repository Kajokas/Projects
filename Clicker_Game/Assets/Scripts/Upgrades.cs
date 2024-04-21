using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {

    public Click1 click;
    public UnityEngine.UI.Text itemInfo;
    public float cost;
    public int count = 0;
    public int clickPower;
    public string itemName;
    private float _newCost;

    void Update() {
        itemInfo.text = itemName + "\nCost: " + cost + "\nPower: +" + clickPower;
    }

    public void PurchasedUpgrade() {
        if (click.money >= cost) {
            click.money -= cost;
            count += 1;
            click.moneyPerClick += clickPower;
            cost = Mathf.Round(cost * 1.15f);
            _newCost = Mathf.Pow(cost, _newCost = cost);
         }
    }

}
