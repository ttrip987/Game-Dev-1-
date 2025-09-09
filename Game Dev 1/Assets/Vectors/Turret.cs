using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public float rate_of_fire = 0.2f;
    public float shoot_timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot_timer > 0)
            shoot_timer -= Time.deltaTime;
        else
        {
            shoot_timer = rate_of_fire;
            GameObject new_bullet = Instantiate(bullet);

            new_bullet.transform.position = transform.position;

            Vector3 bullet_dir = (target.transform.position - transform.position).normalized;
            new_bullet.GetComponent<Bullet>().SetVelocity(bullet_dir);
        }
    }
}
