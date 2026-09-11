using System.Collections.Generic;
using UnityEngine;

public class Botplayerstats : MonoBehaviour
{
    [SerializeField] private int money = 1850;
    private List<propertyState> ownedProperties = new List<propertyState>();


    public void AddMoney(int amount)
    {
        money += amount;

        Debug.Log(
            gameObject.name +
            " received $" +
            amount +
            ". Money: $" +
            money
        );
    }

    public void TaxMoney(int amount)
    {
        money -= amount;

        Debug.Log(
            gameObject.name +
            " lost $" +
            amount +
            ". Money: $" +
            money
        );
    }

    public bool BuyProperty(propertyState property)
    {
        if (money >= property.purchasePrice)
        {
            money -= property.purchasePrice;

            property.owned = true;

            // This bot owns it
            property.ownerBot = this;

            // Make sure it isn't also human-owned
            property.owner = null;

            // Add property to bot's collection
            ownedProperties.Add(property);

            Debug.Log(
                gameObject.name +
                " bought " +
                property.propertyName
            );

            return true;
        }

        Debug.Log(
            gameObject.name +
            " cannot afford " +
            property.propertyName
        );

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
}
