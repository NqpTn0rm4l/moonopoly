using UnityEngine;

public class ownProeprtyUi : MonoBehaviour
{
    [SerializeField] private GameObject ownPropertyTemplate;
    public bool checkingProperty = false;

    public void ShowOwnProperty()
    {
        if (!checkingProperty)
        {
            ownPropertyTemplate.SetActive(true);
            checkingProperty = true;
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
