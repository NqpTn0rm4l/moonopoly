using UnityEngine;

public class cellHopping : MonoBehaviour
{
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject[] cells;
    [SerializeField] private GameObject[] player;
    [SerializeField] private int playersTurn;
    [SerializeField] private int[] playerDisplacement;

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
        playerDisplacement[playersTurn] += diceresult;
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
