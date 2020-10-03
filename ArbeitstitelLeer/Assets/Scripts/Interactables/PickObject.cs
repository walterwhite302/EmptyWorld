using UnityEngine;

public class PickObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Destroy(this.gameObject);
    }
}
