using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer renderer;

   [SerializeField] float speedModifier = 3f;
    float horizontal;
    float vertical;


    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

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
