using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int money = 30000;
    [SerializeField] private GameObject cashMonitor;

    private void Update()
    {
        cashMonitor.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + money.ToString();
    }
}
