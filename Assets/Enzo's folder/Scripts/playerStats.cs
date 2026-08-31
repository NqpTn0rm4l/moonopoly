using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private GameObject cashMonitor;
    
    private void Update()
    {
        cashMonitor.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + money.ToString();
    }
}
