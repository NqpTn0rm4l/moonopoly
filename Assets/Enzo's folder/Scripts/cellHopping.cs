using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class cellHopping : MonoBehaviour
{
    [SerializeField] private GameObject purchaseUI;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject[] cells;
    [SerializeField] private GameObject[] player;
    [SerializeField] private int playersTurn;
    [SerializeField] private int[] playerDisplacement;
    [SerializeField] private purchasePropertyButton purchaseProperty;

    [SerializeField]
    private AnimationCurve curve;

    private Vector3 playerEnd;
    private Vector3 playerStart = new Vector3 (0, 0,0);
    private float desiredDurtion = 3f;
    private float elapsedTime;

    private int movingPlayer;

    //New
    [SerializeField] private int goMoney = 200;

    [SerializeField]
    private float hopDuration = 0.25f;

    private bool isMoving = false;

    private void Start()
    {
        cells = new GameObject[board.transform.childCount];

        for ( int i = 0; i < board.transform.childCount; i++)
        {
            cells[i] = board.transform.GetChild(i).gameObject;
        }

        playerDisplacement = new int[player.Length];

        for (int i = 0; i < player.Length; i++)
        {
            player[i].transform.position = cells[0].transform.position;
        }
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

        movingPlayer = playersTurn;

        playerStart = player[playersTurn].transform.position;
        playerEnd = cells[playerDisplacement[playersTurn]].transform.position;

        elapsedTime = 0f;
        desiredDurtion = 0.5f;

        //player[playersTurn].transform.position = cells[playerDisplacement[playersTurn]].transform.position;

        propertyState currentproperty = cells[playerDisplacement[playersTurn]].GetComponent<propertyState>();
        if ( currentproperty != null)
        {
            Debug.Log("Checking If Property");
            if ( currentproperty.owned == false)
            {
                Debug.Log("Cecking If Property Is Owned");
                purchaseProperty.ShowProperty(currentproperty);
            }
        }
    }

    private void Update()
    {
        if (elapsedTime < desiredDurtion)
        {
            elapsedTime += Time.deltaTime;

            float percentageComplete = elapsedTime / desiredDurtion;

            player[movingPlayer].transform.position = Vector3.Lerp(playerStart, playerEnd, curve.Evaluate(percentageComplete));
        }
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
