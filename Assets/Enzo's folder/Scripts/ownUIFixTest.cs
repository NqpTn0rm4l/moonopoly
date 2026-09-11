using UnityEngine;

public class ownUIFixTest : MonoBehaviour
{
    [SerializeField] private ownProeprtyUi OwnPropertyUi;
    [SerializeField] private GameObject parrallelOwnPropertyTemplate;

    void Start()
    {
        OwnPropertyUi = FindAnyObjectByType<ownProeprtyUi>();
    }
    public void HideOwnProperty()
    {
        OwnPropertyUi.HideOwnProperty();
    }
}
