using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindAnyObjectByType<GetMoney>().AddMoney();
    }
}
