using UnityEngine;
using System.Collections;

public class millionMUpdate : MonoBehaviour {

    public makeM makem;

    void Update()
    {
        makem.moneydisplay.text = makem.Money + "M ";
    }
}
