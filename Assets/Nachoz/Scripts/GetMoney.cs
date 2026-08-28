using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetMoney : MonoBehaviour
{
    private int money = 0;
    public TMP_Text moneyText;

    public void AddMoney()
    {
        money += 200;
        moneyText.text = "Money: " + money.ToString();
        Debug.Log("You passed GO! +$200");
    }
}
