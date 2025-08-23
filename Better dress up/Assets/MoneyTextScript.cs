using TMPro;
using UnityEngine;

public class MoneyTextScript : MonoBehaviour
{
    public TextMeshProUGUI moneytext;

    private void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        moneytext.text = "Money: " + ContextScript.instance.currentbalance;
    }
}
