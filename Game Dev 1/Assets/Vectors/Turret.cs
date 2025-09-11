using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public float rate_of_fire = 0.2f;
    public float shoot_timer = 0;
    private Vector3 bullet_dir = Vector3.zero;
    public float spread = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot_timer > 0) 
            shoot_timer -= Time.deltaTime;
            //bullet_dir = (target.transform.position - transform.position).normalized;

        else
        {
            shoot_timer = rate_of_fire;
            GameObject new_bullet = Instantiate(bullet);

            new_bullet.transform.position = transform.position;

            
            new_bullet.GetComponent<Bullet>().SetVelocity(bullet_dir);
        }

       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + bullet_dir * 2);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 2);

        Gizmos.color = Color.cyan;
        Vector3 axis = Vector3.Cross(bullet_dir, Vector3.up);
        Gizmos.DrawLine(transform.position, transform.position + axis * 2);

        Gizmos.color = Color.yellow;
        Vector3 spread_dir = Quaternion.AngleAxis(spread, axis) * bullet_dir;
        Gizmos.DrawLine(transform.position, transform.position + spread_dir * 2);

        Gizmos.color = Color.magenta;
        Vector3 final_dir;
        for (int i = 1; i <= 15; i++)
        {
            final_dir = Quaternion.AngleAxis(22.5f * i, bullet_dir) * spread_dir;
            Gizmos.DrawLine(transform.position, transform.position + final_dir * 2);
        }
    }
}
