using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    Ray2D aimRay;
    [SerializeField] Camera camera;
    [SerializeField] Projectile projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        float direction = Vector2.Distance(mousePos, (Vector2)transform.position);
        aimRay = new Ray2D(transform.position, mousePos);
        Debug.DrawRay(transform.position, mousePos, Color.red);

        if (Input.GetMouseButtonDown(0))
            fireProjectile(mousePos);
    }

    private void fireProjectile(Vector2 direction)
    {
        makeProjectile(transform.position, direction);
    }

    private void makeProjectile(Vector2 origin, Vector2 direction)
    {
        //Projectile projectile;
        Vector3 orig = (Vector3)origin;
        Vector3 dir = (Vector3)direction;
        orig.x += Mathf.Sign(dir.x) * 1;
        orig.y += Mathf.Sign(dir.y) * 1;
      Projectile proj=  Instantiate(projectile, orig, Quaternion.identity);
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), proj.GetComponent<CircleCollider2D>());
        proj.setDirection(direction);
    }
}
