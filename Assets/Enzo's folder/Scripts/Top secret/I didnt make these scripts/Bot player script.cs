using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Botplayerscript : MonoBehaviour
{
    [SerializeField] private Botplayerstats botPlayerStats;
    [SerializeField] private cellHopping CellHopping;
    [SerializeField] private rollDice RollDice;

    public void BotTakesItsTurn()
    {
        RollDice.RollDiceForBot();
    }

    public void BuyProperty(propertyState property)
    {
        botPlayerStats.BuyProperty(property);
    }
}
