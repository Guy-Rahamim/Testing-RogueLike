using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Camera camera;
    [SerializeField] bool followMouse=false;
    [SerializeField] float speedModifier = 3f;
    FMODUnity.StudioEventEmitter footsteps;
    float walkDelay = 0.55f;
    float lastWalk = 0;

    [FMODUnity.EventRef]
    bool isWalking;

    Vector2 movement;

    float horizontal;
    float vertical;
    public static Vector2 soundMovement;

    void Start()
    {
        footsteps= GetComponent<FMODUnity.StudioEventEmitter>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        playFootsSteps();

        soundMovement = new Vector2(horizontal, vertical);
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
        
    void playFootsSteps()
    {
        if ((Time.realtimeSinceStartup - lastWalk > walkDelay ) && movement.magnitude>0)
        {
            footsteps.Play();
            lastWalk = Time.realtimeSinceStartup;
        }
    }
}
