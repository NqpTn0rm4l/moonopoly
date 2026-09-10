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

    public propertyState propertyStateImported;

    public void OwnedPropertyShowsUpAtRoster(propertyState property)
    {
        propertyStateImported = property;
        if (propertyCount >= UIPositions.Length)
        {
            Debug.Log("No More Space For Property Cards");
            return;
        }
        GameObject newCard = Instantiate(propertyCard, UIPositions[propertyCount].transform);
        newCard.transform.localPosition = Vector3.zero;
        Image cardImage = newCard.transform.GetChild(0).GetComponent<Image>();
        cardImage.color = property.propertyColor;
        propertyCount++;
    }
    public void ViewOwnedProperty()
    {

        if (!checkingProperty)
        {
            ownPropertyTemplate.SetActive(true);
            checkingProperty = true;
            propertyCardStatsReference.SetValues(propertyStateImported);
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
