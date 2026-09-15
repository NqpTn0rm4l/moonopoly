using UnityEngine;

public class propertyState : MonoBehaviour
{
    public string propertyName;
    public int purchasePrice;
    public int rentPrice;
    public bool owned = false;
    public playerStats owner;
    public Botplayerstats ownerBot;
    public GameObject typeOfAssetOnProperty;
    public Color propertyColor;
}
