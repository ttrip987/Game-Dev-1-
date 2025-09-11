using Mono.Cecil;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rb;

    public float speed = 5;

    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    
    void FixedUpdate()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");
        direction = direction.normalized;

        velocity = direction * speed; 
        velocity *= Time.fixedDeltaTime;
        Debug.Log(direction);


        rb.MovePosition(rb.position + velocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
        Gizmos.DrawLine(transform.position, transform.position + direction * 2);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 2);

        Gizmos.color = Color.cyan;
        Vector3 axis = Vector3.Cross(bullet_dir, Vector3.up);
        Gizmos.DrawLine(transform.position)
    }



}
