using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int money = 1850;
    [SerializeField] private GameObject cashMonitor;
    [SerializeField] private ownProeprtyUi ownPropertyUiScript;
    private List<propertyState> ownedProperties = new List<propertyState>();
    InputAction clickInput;

    private void Awake()
    {
        clickInput = InputSystem.actions.FindAction("Click");
    }
    private void Update()
    {
        if (cashMonitor != null)
        {
            cashMonitor.GetComponent<TextMeshProUGUI>().text = "$" + money;
        }

        if (clickInput != null &&
            ownPropertyUiScript != null &&
            clickInput.IsPressed() &&
            ownPropertyUiScript.checkingProperty)
        {
            ownPropertyUiScript.HideOwnProperty();

            Debug.Log("Input To Close Own Property Viewing");
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void TaxMoney(int amount)
    {
        money -= amount;
    }

    public void SuperTaxMoney(int amount)
    {
        money -= amount;
    }

    public bool BuyPropertyAndSetOwner(propertyState property)
    {
        if (money >= property.purchasePrice)
        {
            money -= property.purchasePrice;

            property.owned = true;

            // This player owns it
            property.owner = this;

            // Make sure it isn't also marked as bot-owned
            property.ownerBot = null;

            // Store property in this player's list
            ownedProperties.Add(property);

            Debug.Log( gameObject.name + "bought" + property.propertyName);
            return true;
        }
        Debug.Log(gameObject.name + " cannot afford " + property.propertyName);
        return false;
    }
    public List<propertyState> GetOwnedProperties()
    {
        return ownedProperties;
    }

    public int GetMoney()
    {
        return money;
    }
    /*public bool SubtractPropertyPriceFromPlayerAmount(int propertyPrice)
    {
        Debug.Log("Checking If Money Is Enough");
        if ( money >= propertyPrice)
        {
            Debug.Log("Money Is Enough");
            money -= propertyPrice;
            return true;
        }
        Debug.Log("Money Is Not Enough");
        return false;
    }
    public bool BuyPropertyAndSetOwner(propertyState property)
    {
        if (money >= property.purchasePrice)
        {
            money -= property.purchasePrice;

            property.owned = true;
            property.owner = this;

            return true;
        }

        return false;
    }*/

}
