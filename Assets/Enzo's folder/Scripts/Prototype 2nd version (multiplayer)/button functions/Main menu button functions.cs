using UnityEngine;

public class Mainmenubuttonfunctions : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;

    public void OpenGameSettings()
    {
        menus[0].SetActive(true);
    }
}
