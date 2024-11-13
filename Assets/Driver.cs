using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float slowSpeed = 4f;
    [SerializeField] float boostSpeed = 15f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Booster") {
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, 0.2f);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
}
