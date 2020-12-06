using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IHitter, Ivulnerable
{
    [SerializeField] float movementSpeed = 0.5f;
    private SpriteRenderer renderer;
    Animator animator;

    float playDelay=1.7f;
    float lastPlay=0;



    GameObject player;
    Rigidbody2D rb;
    AudioSource source;
    Vector2 playerPos;
    [SerializeField] int life = 3;

    //movement variables
    float movementDelay=0.5f;
    float lastMovement;

    bool shouldPlay = false;


    
    void Start()
    {
        source = GetComponent<AudioSource>();
        
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        basicFollowPlayer();
        playSound();
    }

    private void basicFollowPlayer()
    {
        playerPos = (Vector2)player.transform.position;
        Vector2 direction = playerPos - (Vector2)transform.position;

        AnimatorStateInfo info =animator.GetCurrentAnimatorStateInfo(0);

        
        
        if (info.normalizedTime%1>0.3 && info.normalizedTime%1<0.8)
        {
            if (shouldPlay)
            {
                source.Play();
                shouldPlay = false;
            }

            rb.MovePosition((Vector2)transform.position + direction.normalized * movementSpeed * Time.deltaTime);

        }
        else { shouldPlay = true; }


        if (Time.realtimeSinceStartup-lastMovement>movementDelay)
        {
            for (int i=0; i<10; i++)
            lastMovement = Time.realtimeSinceStartup;
        }
        
        flipSprite(direction.x);

    }

    private void flipSprite(float x)
    {
        if (x > 0)
            renderer.flipX = false;
        else if (x < 0)
            renderer.flipX = true;
    }

    public void hit(Ivulnerable other)
    {
        other.hurt();
    }

    public void hurt()
    {
        life--;
        if (life < 1)
            Destroy(gameObject);
    }


    public void playSound()
    {
        if (Time.realtimeSinceStartup-lastMovement>playDelay)
        {
            source.Play();
            lastMovement = Time.realtimeSinceStartup;
        }
    }

}
