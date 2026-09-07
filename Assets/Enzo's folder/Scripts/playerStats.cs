using UnityEngine;
using UnityEngine.InputSystem;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private GameObject cashMonitor;
    [SerializeField] private ownProeprtyUi ownPropertyUiScript;
    InputAction clickInput;

    private void Awake()
    {
        clickInput = InputSystem.actions.FindAction("Click");
    }
    private void Update()
    {
        cashMonitor.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + money.ToString();
        if ( clickInput.IsPressed() && ownPropertyUiScript.checkingProperty == true)
        {
            ownPropertyUiScript.HideOwnProperty();
            Debug.Log("Input To Close Own Property Viewing");
        }
    }
    public bool SubtractPropertyPriceFromPlayerAmount(int propertyPrice)
    {
        Debug.Log("Checking If Money Is Enough");
        if ( money >= propertyPrice)
        {
            Debug.Log("Money Is Enough");
            money -= propertyPrice;
            return true;
        }
        Debug.Log("Money Is Not Enough");
        return false;
    }
}
