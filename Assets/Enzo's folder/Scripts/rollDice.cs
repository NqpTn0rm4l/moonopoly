using UnityEngine;

public class rollDice : MonoBehaviour
{
    [SerializeField] private int[] diceResult;
    [SerializeField] private GameObject[] diceVisual;
    [SerializeField] private cellHopping cellHoppingScript;

    private void Start()
    {
        diceResult = new int[2];
    }
    public void RollDice()
    {
        diceResult[0] = Random.Range(1, 6);
        diceResult[1] = Random.Range(1, 6);
        for (int i = 0; i < 6; i++)
        {
            diceVisual[0].transform.GetChild(i).gameObject.SetActive(i == diceResult[0]);
            diceVisual[1].transform.GetChild(i).gameObject.SetActive(i == diceResult[1]);
        }
        int totalRollSum = diceResult[0] + diceResult[1];
        cellHoppingScript.MovePlayer(totalRollSum);

    }
}
