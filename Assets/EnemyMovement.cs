using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IHitter, Ivulnerable
{
    //Initializing class fields
    SpriteRenderer renderer;
    Animator animator;
    GameObject player;
    Rigidbody2D rb;
    AudioSource source;

    Vector2 playerPos;

    [SerializeField] int life = 3;

    
    [SerializeField] float movementSpeed = 0.5f;
    float playDelay=1.7f;
    float lastMovement;

    bool shouldPlaySound;

    void Start()
    {
        source   = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        player   = GameObject.FindGameObjectWithTag("Player");
        rb       = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

        shouldPlaySound = false;
    }

    void Update()
    {
        basicFollowPlayer();
    }
    private void basicFollowPlayer()
    {
        playerPos = (Vector2)player.transform.position;
        Vector2 direction = playerPos - (Vector2)transform.position;

        AnimatorStateInfo info =animator.GetCurrentAnimatorStateInfo(0);
        float currentAnimationTime= info.normalizedTime % 1;
        
        if (currentAnimationTime>0.4 && currentAnimationTime<0.8)
        {
            playSound();
            rb.MovePosition((Vector2)transform.position + direction.normalized * movementSpeed * Time.deltaTime);
        }
        else { shouldPlaySound = true; }     
        flipSprite(direction.x);

    }
    private void playSound()
    {
        if (shouldPlaySound)
        {
            source.Play();
            shouldPlaySound = false;
        }
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
        {
            EnemySpawner.decreaseEnemyCount();
            Destroy(gameObject);
        }

    }
}
