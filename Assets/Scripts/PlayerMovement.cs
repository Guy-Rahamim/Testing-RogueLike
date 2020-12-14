using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Camera camera;
    [SerializeField] bool followMouse=false;
    [SerializeField] float speedModifier = 3f;
    SpriteRenderer renderer;

    [SerializeField] Vector3 screen1;
    [SerializeField] Vector3 screen2;

    [SerializeField] tempSpawner spawner;

    bool onScreen1, onScreen2;
   
    Vector2 movement;

    float horizontal;
    float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        screen1 = camera.transform.position;
        onScreen1 = true;
        renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        animator.SetFloat("horizontal", mousePos.x);
        animator.SetFloat("vertical", mousePos.y);
        animator.SetFloat("speed", mousePos.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        moving();
    }
    void moving()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector2(horizontal, vertical);

        rb.MovePosition(rb.position + movement * speedModifier*Time.fixedDeltaTime);
        if (horizontal>0)
        {
            renderer.flipX = false;
        }
        else if (horizontal<0)
        {
            renderer.flipX = true;
        }
        else { }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (onScreen1)
            {
                onScreen1 = false;
                onScreen2 = true;
                camera.transform.position = screen2;
                transform.position = new Vector3(0.3f, 12, 0);
                spawner.instantiateRoom2();
            }

            else
            {
                onScreen2 = false;
                onScreen1 = true;
                camera.transform.position = screen1;
                transform.position = new Vector3(0.55f, 6.25f, 0);
                spawner.instantiateRoom1();
            }
        }
    }

}
