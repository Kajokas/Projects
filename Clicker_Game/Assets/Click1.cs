using UnityEngine;
using System.Collections;

public class Click1 : MonoBehaviour
{

    public UnityEngine.UI.Text Mpc;
    public UnityEngine.UI.Text moneydisplay;
    public float money;
    public int moneyPerClick = 1;
    public float Million;
    public GameObject MlMaker;

    void Update()
    {
        moneydisplay.text = "Money: " + money;
        Mpc.text = "YourMoneyPerHour: " + moneyPerClick;
    }

    public void Clicked()
    {
        money += moneyPerClick;
    }

    public void Ml()
    {
        if (money >= Million)
        {
            MlMaker.gameObject.SetActive(true);
        }
    }
}