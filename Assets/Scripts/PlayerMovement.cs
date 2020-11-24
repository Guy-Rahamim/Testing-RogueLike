using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Camera camera;
    [SerializeField] bool followMouse=false;
    [SerializeField] float speedModifier = 3f;
   
    Vector2 movement;

    float horizontal;
    float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

    }
      
}
