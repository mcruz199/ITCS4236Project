using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDir;
    public KeyCode dropKey;
    public GameObject player;
    public Animator animator;
    public Collider2D weaponHitbox;
    [SerializeField] private float attackDamage = 10f;
    private bool canAttack = true;
    public AudioClip swing;
    public AudioClip hit;
    public AudioSource swingSource;
    public AudioSource hitSource;
    public AudioClip enemyDeath;
    public AudioClip ambience;
    public AudioSource source;

    void Awake()
    {
        DontDestroyOnLoad(player);
        source.clip = ambience;
        source.Play();
    }


    void Update()
    {
        ProcessInputs();
        Attack();
        
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetBool("Attacking", true);
            swingSource.clip = swing;
            swingSource.Play();
        }
    }

    void checkForAnimationEnd(string str)
    {
        if (str.Equals("AnimationEnded"))
        {
            animator.SetBool("Attacking", false);
            canAttack = true;
        }
    }

    void FixedUpdate()
    {
        Move();
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && animator.GetBool("Attacking"))
        {
            if (canAttack == true)
            {
                hitSource.clip = hit;
                hitSource.Play();
                other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-attackDamage);
                canAttack = false;
                if (other.gameObject.GetComponent<EnemyHealth>().IsDead())
                {
                    this.gameObject.GetComponent<PlayerHealth>().UpdateScore(100);
                    hitSource.clip = enemyDeath;
                    hitSource.Play();
                }
            }
        }
    }
    

}
