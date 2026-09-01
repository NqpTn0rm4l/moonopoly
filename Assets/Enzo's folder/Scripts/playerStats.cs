using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private GameObject cashMonitor;
    
    private void Update()
    {
        cashMonitor.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + money.ToString();
    }

    private void AddMoney(int amount)
    {
        money += amount;
    }

    public bool SubtractPropertyPriceFromPlayerAmount(int propertyPrice)
    {
        Debug.Log("Checking If Money Is Enough");
        if ( money > propertyPrice)
        {
            Debug.Log("Money Is Enough");
            money -= propertyPrice;
            return true;
        }
        Debug.Log("Money Is Not Enough");
        return false;
    }
}
