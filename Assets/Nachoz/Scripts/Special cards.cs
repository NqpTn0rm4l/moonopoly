using UnityEngine;

public enum CellType
{
    Chance,
    CommunityChest,
    Tax,
    SuperTax,
    WaterWork,
    Station,
    ElectricianWork,
}
public class Specialcards : MonoBehaviour
{
    public CellType type;
    public int taxAmount;
}
