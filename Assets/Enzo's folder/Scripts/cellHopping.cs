using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField] private int taxCell = 150;

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
        if (newPosition >= cells.Length)
        {
            GiveMoneyToCurrentPlayer(goMoney);
        }

        playerDisplacement[playersTurn] += diceresult;
        playerDisplacement[playersTurn] %= cells.Length;

        movingPlayer = playersTurn;

        playerStart = player[playersTurn].transform.position;
        playerEnd = cells[playerDisplacement[playersTurn]].transform.position;

        elapsedTime = 0f;
        desiredDurtion = 0.5f;
        isMoving = true;

        player[playersTurn].transform.position = cells[playerDisplacement[playersTurn]].transform.position;

        propertyState currentproperty = cells[playerDisplacement[playersTurn]].GetComponent<propertyState>();
        if (currentproperty != null)
        {
            Debug.Log("Checking If Property");

            if (!currentproperty.owned)
            {
                Botplayerscript bot = player[playersTurn].GetComponent<Botplayerscript>();

                if (bot != null)
                {
                    bot.BuyProperty(currentproperty);
                }
                else
                {
                    purchaseProperty.ShowProperty(currentproperty);
                }
            }
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;

            float percentageComplete =
                elapsedTime / desiredDurtion;

            player[movingPlayer].transform.position =
                Vector3.Lerp(
                    playerStart,
                    playerEnd,
                    curve.Evaluate(percentageComplete)
                );

            if (percentageComplete >= 1f)
            {
                player[movingPlayer].transform.position =
                    playerEnd;

                isMoving = false;

                MovementFinished();
            }
        }
    }
    private void MovementFinished()
    {
        propertyState currentProperty =
            cells[playerDisplacement[playersTurn]]
            .GetComponent<propertyState>();

        if (currentProperty != null && currentProperty.owned)
        {
            PayRent(currentProperty);
        }

        Botplayerscript bot =
            player[playersTurn]
            .GetComponent<Botplayerscript>();

        if (bot != null)
        {
            AdvanceTurn();
        }
    }

    public void EndTurn()
    {
        Botplayerscript bot =
            player[playersTurn]
            .GetComponent<Botplayerscript>();

        if (bot != null)
        {
            Debug.Log("It is the bot's turn.");
            return;
        }

        if (isMoving)
        {
            Debug.Log("Player is still moving.");
            return;
        }

        AdvanceTurn();
    }

    public void AdvanceTurn()
    {
        Debug.Log("Turns Changed");

        playersTurn++;

        if (playersTurn >= player.Length)
        {
            playersTurn = 0;
        }

        BotPlayerPlays();
    }

    public void BotPlayerPlays()
    {
        Botplayerscript bot =
            player[playersTurn]
            .GetComponent<Botplayerscript>();

        if (bot != null)
        {
            bot.BotTakesItsTurn();
        }
    }

    private void GiveMoneyToCurrentPlayer(int amount)
    {
        Botplayerstats botStats =
            player[playersTurn]
            .GetComponent<Botplayerstats>();

        if (botStats != null)
        {
            botStats.AddMoney(amount);
            return;
        }

        playerStats playerStats =
            player[playersTurn]
            .GetComponent<playerStats>();

        if (playerStats != null)
        {
            playerStats.AddMoney(amount);
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }
    private void PayRent(propertyState property)
    {
        if (!property.owned)
        {
            return;
        }

        // Who landed on the property?
        playerStats currentHuman =
            player[playersTurn].GetComponent<playerStats>();

        Botplayerstats currentBot =
            player[playersTurn].GetComponent<Botplayerstats>();


        // ==========================================
        // PROPERTY OWNED BY HUMAN
        // ==========================================

        if (property.owner != null)
        {
            // Human landed on their own property
            if (currentHuman != null &&
                property.owner == currentHuman)
            {
                Debug.Log("Landed on own property.");
                return;
            }

            // Human landed on another human's property
            if (currentHuman != null)
            {
                currentHuman.TaxMoney(property.rentPrice);
                property.owner.AddMoney(property.rentPrice);

                Debug.Log(
                    currentHuman.gameObject.name +
                    " paid $" +
                    property.rentPrice +
                    " rent to " +
                    property.owner.gameObject.name
                );

                return;
            }

            // Bot landed on a human's property
            if (currentBot != null)
            {
                currentBot.TaxMoney(property.rentPrice);
                property.owner.AddMoney(property.rentPrice);

                Debug.Log(
                    currentBot.gameObject.name +
                    " paid $" +
                    property.rentPrice +
                    " rent to " +
                    property.owner.gameObject.name
                );

                return;
            }
        }


        // ==========================================
        // PROPERTY OWNED BY BOT
        // ==========================================

        if (property.ownerBot != null)
        {
            // Bot landed on its own property
            if (currentBot != null &&
                property.ownerBot == currentBot)
            {
                Debug.Log("Landed on own property.");
                return;
            }

            // Human landed on bot's property
            if (currentHuman != null)
            {
                currentHuman.TaxMoney(property.rentPrice);
                property.ownerBot.AddMoney(property.rentPrice);

                Debug.Log(
                    currentHuman.gameObject.name +
                    " paid $" +
                    property.rentPrice +
                    " rent to " +
                    property.ownerBot.gameObject.name
                );

                return;
            }

            // Bot landed on another bot's property
            if (currentBot != null)
            {
                currentBot.TaxMoney(property.rentPrice);
                property.ownerBot.AddMoney(property.rentPrice);

                Debug.Log(
                    currentBot.gameObject.name +
                    " paid $" +
                    property.rentPrice +
                    " rent to " +
                    property.ownerBot.gameObject.name
                );
            }
        }
    }
}