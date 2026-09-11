using UnityEngine;

public class Proeprty : MonoBehaviour
{
    private propertyState property;

    public void Setup(propertyState newProperty)
    {
        property = newProperty;
    }

    public void ViewProperty()
    {
        if (property == null)
        {
            Debug.LogWarning("Property card has no property assigned.");
            return;
        }

        ownProeprtyUi ui =
            FindAnyObjectByType<ownProeprtyUi>();

        if (ui != null)
        {
            ui.ViewOwnedProperty(property);
        }
    }
}