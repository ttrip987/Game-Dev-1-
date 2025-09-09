using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 16f;
    private Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 5);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector3 direction)
    {

        velocity = direction * speed;
    }
}
