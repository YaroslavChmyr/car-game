using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destructionDelay = 0.5f;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up.");
            hasPackage = true;
            Destroy(other.gameObject, destructionDelay);
        }
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Package delivered.");
            hasPackage = false;
        }
    }
}
