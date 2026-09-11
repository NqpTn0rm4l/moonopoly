using UnityEngine.UI;
using UnityEngine;

public class ownProeprtyUi : MonoBehaviour
{
    [SerializeField] private GameObject ownPropertyTemplate;
    [SerializeField] private GameObject propertyCard;
    [SerializeField] private GameObject[] UIPositions;
    [SerializeField] private propertyCardStatsReference propertyCardStatsReference;
    [SerializeField] private int propertyCount = 0;
    public bool checkingProperty = false;


    public void OwnedPropertyShowsUpAtRoster(propertyState property)
    {
        if (propertyCount >= UIPositions.Length)
        {
            Debug.Log("No More Space For Property Cards");
            return;
        }

        GameObject newCard = Instantiate(
            propertyCard,
            UIPositions[propertyCount].transform
        );

        newCard.transform.localPosition = Vector3.zero;

        Image cardImage =
            newCard.transform.GetChild(0).GetComponent<Image>();

        if (cardImage != null)
        {
            cardImage.color = property.propertyColor;
        }

        Proeprty propertyButton =
            newCard.GetComponent<Proeprty>();

        if (propertyButton != null)
        {
            propertyButton.Setup(property);
        }
        else
        {
            Debug.LogWarning(
                "Property card prefab does not have the Proeprty component."
            );
        }

        propertyCount++;
    }
    public void ViewOwnedProperty(propertyState property)
    {

        if (!checkingProperty)
        {
            ownPropertyTemplate.SetActive(true);
            checkingProperty = true;
            propertyCardStatsReference.SetValues(property);
            Debug.Log("Owned Property Is Being Viewed");
        }
    }
    public void HideOwnProperty()
    {
        if ( checkingProperty)
        {
            ownPropertyTemplate.SetActive(false);
            checkingProperty = false;
            Debug.Log("Stop Viewing Owned Property");
        }
    }
}
