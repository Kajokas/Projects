using UnityEngine;
using System.Collections;

public class WorkerMoney : MonoBehaviour {

    public Click1 click;
    public UnityEngine.UI.Text workerJob;
    public worker[] items;

    void Start() {
        StartCoroutine(Autotick());
    }

    void Update() {
        workerJob.text = "MoneyPerHour: " + GetMoneyPerHour();
    }

    public int GetMoneyPerHour() {
        int tick = 0;
        foreach(worker item in items) {
            tick += item.count * item.tickValue;
        }
        return tick;
    }

    public void AutoMoneyPerHour() {
        click.money += GetMoneyPerHour();
    }
    IEnumerator Autotick() {
        while (true) {
            AutoMoneyPerHour();
            yield return new WaitForSeconds(1);
        }
    }

}
