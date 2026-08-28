using UnityEngine;

public class rollDice : MonoBehaviour
{
    [SerializeField] private int[] diceResult;
    [SerializeField] private GameObject[] diceVisual;
    [SerializeField] private cellHopping cellHoppingScript;

    public void RollDice()
    {
        diceResult = Random.Range(2, 13);
        Debug.Log(diceResult);
        cellHoppingScript.MovePlayer(diceResult);
    }
}
