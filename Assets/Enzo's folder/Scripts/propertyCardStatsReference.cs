using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class propertyCardStatsReference : MonoBehaviour
{
    [SerializeField] private Image propertyCardColor;
    [SerializeField] private TMP_Text rentSingleColor;
    [SerializeField] private TMP_Text rentFullColor;
    [SerializeField] private TMP_Text house;
    [SerializeField] private TMP_Text house2;
    [SerializeField] private TMP_Text house3;
    [SerializeField] private TMP_Text house4;
    [SerializeField] private TMP_Text hotel;
    [SerializeField] private TMP_Text sellPrice;
    public propertyState propertyState;

    private void Start()
    {
        rentSingleColor.text = ("Price: ");
        rentFullColor.text = ("Price: ");
        house.text = ("Price: ");
        house2.text = ("Price: ");
        house3.text = ("Price: ");
        house4.text = ("Price: ");
        hotel.text = ("Price: ");
        sellPrice.text = ("Price: ");
    }
    public void SetValues(propertyState property)
    {
        propertyCardColor.color = property.propertyColor;
        rentSingleColor.text = "Price: " + property.rentPrice;
        rentFullColor.text = "Price: " + property.rentPrice * 2;
        house.text = "Price: " + property.rentPrice * 2.5f;
        house2.text = "Price: " + property.rentPrice * 3;
        house3.text = "Price: " + property.rentPrice * 4;
        house4.text = "Price: " + property.rentPrice * 5;
        hotel.text = "Price: " + property.rentPrice * 6;
        sellPrice.text = "Price: " + property.rentPrice / 2;
        Debug.Log("Values Set");
    }
}
