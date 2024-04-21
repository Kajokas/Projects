using UnityEngine;
using System.Collections;

public class makeM : MonoBehaviour
{

    public Click1 click;
    public UnityEngine.UI.Text moneydisplay;
    public float Money;
    public int moneyPerClick = 1;
    public float cost;
    public float Million;
    public GameObject MlMaker;

    public void ClickedOnIt()
    {
        if (click.money >= cost)
        {
            click.money -= cost;
            Money += moneyPerClick;
        }
    }
    public void Ml(bool clicked)
    {
        if (clicked == true)
        {
            MlMaker.gameObject.SetActive(false);
        }
    }
}
