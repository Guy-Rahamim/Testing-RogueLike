using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeTime;
    Animator animator;
    [SerializeField] ProjectileManager projManager;
    Vector2 direction;
    Rigidbody2D rb;


    [SerializeField] float speed;
    float startTime;

    void Start()
    {
        animator = GetComponent<Animator>();
     //   projManager = FindObjectOfType<ProjectileManager>();
        startTime = Time.realtimeSinceStartup;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        propel();
        killTimer();
    }
    private void killTimer()
    {
        if (Time.realtimeSinceStartup - startTime > projManager.getLifeTime())
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
        }
    }
    private void propel()
    {
        Vector2 signedDirection = new Vector2(Mathf.Sign(direction.x), Mathf.Sign(direction.y));
        Vector2 pos = (Vector2)transform.position;
        rb.MovePosition(pos + direction.normalized * projManager.getSpeed() * Time.deltaTime);
    }
    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Ivulnerable other = collision.gameObject.GetComponent<Ivulnerable>();
        if (other!=null)
        { 
            other.hurt();
        }
        projManager.instantiateProjectilePickup(transform.position);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ivulnerable other = collision.gameObject.GetComponent<Ivulnerable>();
        if (other != null)
        {
            other.hurt();
        }
        projManager.instantiateProjectilePickup(transform.position);
        Destroy(gameObject);
    }

}
