using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Botplayerscript : MonoBehaviour
{
    [SerializeField] private Botplayerstats Botplayerstats;
    [SerializeField] private cellHopping CellHopping;
    [SerializeField] private rollDice RollDice;

    public void BotTakesItsTurn()
    {
        RollDice.RollDiceForBot();
        CellHopping.EndTurn();
    }
}
