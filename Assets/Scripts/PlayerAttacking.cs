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
        // Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        //// aimRay = new Ray2D(transform.position, mousePos);
        // Debug.DrawRay(transform.position, mousePos, Color.red);

        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.DrawRay((Vector3)transform.position, (Vector3)dir);

        if (Input.GetMouseButtonDown(0))
            fireProjectile(dir, angle);
    }

    private void fireProjectile(Vector2 direction, float angle)
    {
        makeProjectile(transform.position, direction, angle);
    }

    private void makeProjectile(Vector2 origin, Vector2 direction, float angle)
    {
        Vector3 orig = (Vector3)origin;

      Projectile proj=  Instantiate(projectile, orig, Quaternion.identity);
        proj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), proj.GetComponent<CircleCollider2D>());
        proj.setDirection(direction);
    }
}
