using UnityEngine;
using TMPro;

public class purchasePropertyButton : MonoBehaviour
{
    [SerializeField] private playerStats playerStats;
    [SerializeField] private GameObject propertyUI;
    [SerializeField] private TMP_Text propertyNameUI;
    [SerializeField] private TMP_Text propertyPriceUI;

    private propertyState currentProperty;
    /*public void TurnOnUI()
    {
        propertyNameUI.SetActive(true);
    }
    public void PrintPropertyName()
    {
        propertyNameUI.(getpropertyname);
    }*/

    public void ShowProperty(propertyState property)
    {
        Debug.Log("Turning Purchase UI On");
        currentProperty = property;
        propertyNameUI.text = property.propertyName;
        propertyPriceUI.text = "$" + property.purchasePrice;
        propertyUI.SetActive(true);
    }
    public void AnswerYes()
    {
        Debug.Log("Purchase Process");
        if (playerStats.SubtractPropertyPriceFromPlayerAmount(currentProperty.purchasePrice))
        {
            Debug.Log("Purchase Done");
            currentProperty.owned = true;
            propertyUI.SetActive(false);
        }
    }
    public void AnswerNo()
    {
        Debug.Log("Purchase Rejected");
        propertyUI.SetActive(false);
    }
}
