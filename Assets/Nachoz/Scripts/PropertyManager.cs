using UnityEngine;

public class PropertyManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindAnyObjectByType<BrownProperties>().BrownProperty();

    }
}
