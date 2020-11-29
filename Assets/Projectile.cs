using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeTime;

    Vector2 direction;
    Rigidbody2D rb;

    [SerializeField] float speed;
    float startTime;

    void Start()
    {
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
        if (Time.realtimeSinceStartup - startTime > lifeTime)
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
        }
    }
    private void propel()
    {
        Vector2 signedDirection = new Vector2(Mathf.Sign(direction.x), Mathf.Sign(direction.y));
        Vector2 pos = (Vector2)transform.position;
        rb.MovePosition(pos + direction.normalized * speed * Time.deltaTime);
    }
    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
    }



}
