using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class cellHopping : MonoBehaviour
{
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject[] cells;
    [SerializeField] private GameObject[] player;
    [SerializeField] private int playersTurn;
    [SerializeField] private int[] playerDisplacement;

    //New
    [SerializeField] private int goMoney = 200;

    private void Start()
    {
        cells = new GameObject[board.transform.childCount];

        for ( int i = 0; i < board.transform.childCount; i++)
        {
            cells[i] = board.transform.GetChild(i).gameObject;
        }

        playerDisplacement = new int[player.Length];
    }
    public void MovePlayer(int diceresult)
    {
        int oldPosition = playerDisplacement[playersTurn];

        int newPosition = oldPosition + diceresult;
        if (newPosition >= 40)
        {
            player[playersTurn].GetComponent<playerStats>().AddMoney(goMoney);

            Debug.Log("Player " + playersTurn + " passed GO!");
            Debug.Log("Received $" + goMoney);
        }

        playerDisplacement[playersTurn] += diceresult;
        playerDisplacement[playersTurn] %= cells.Length;
        player[playersTurn].transform.position = cells[playerDisplacement[playersTurn]].transform.position;
        EndTurn();
    }
    public void EndTurn()
    {
        playersTurn++;
        if (playersTurn >= player.Length)
        {
            playersTurn = 0;
        }
    }
}
