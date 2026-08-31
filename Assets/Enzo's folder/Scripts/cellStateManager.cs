using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class cellStateManager : MonoBehaviour
{
    [SerializeField] private GameObject cellCollection;
    [SerializeField] GameObject[] individualCell;

    private bool listMade;
    /*private bool templateApllied;*/

    private void Start()
    {
        listMade = false;
        /*templateApllied = false;*/

        ProduceListOfPurchableProperty();
    }
    private void Update()
    {
        /*if (listMade == true && templateApllied == false)
        {
            AssignPropertyStateTemplateToIndividualsInList();
            Debug.Log("Assigning Template To Properties");
        }*/
    }
    private void ProduceListOfPurchableProperty()
    {
        List<GameObject> Properties = new List<GameObject>();

        for (int i = 0; i < cellCollection.transform.childCount; i++)
        {
            GameObject cell = cellCollection.transform.GetChild(i).gameObject;

            if (cell.CompareTag("Property"))
            {
                Properties.Add(cell);
            }
        }
        individualCell = Properties.ToArray();

        if (individualCell.Length != 0)
        {
            Debug.Log("List Made");
            listMade = true;
        }
    }

    //Here originally was an idea to automatically assign values to the templates through script instead of doing it manually
    //But it was too hard so I just went the manual route
    /*private void AssignPropertyStateTemplateToIndividualsInList()
    {
        foreach (GameObject cell in individualCell)
        {
            cell.AddComponent<propertyState>();


        }
        templateApllied = true;
        Debug.Log("Added Template To Properties");
    }*/
}
