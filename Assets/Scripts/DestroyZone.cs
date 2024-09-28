using Interface;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void HandleDestroy(Collider other)
    {
        var destroyObjet = other.gameObject.GetComponent<IDestroyObject>();
        destroyObjet?.Destroy();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        HandleDestroy(other);
    }
}