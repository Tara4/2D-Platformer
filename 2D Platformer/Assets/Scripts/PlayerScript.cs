using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public  float jumpPower;
    public bool isJumpingRight;
    public bool isGrounded;
    public GameObject attackBox;
    public float attackRange;
    public LayerMask enemyLayer;
    bool attacked = false;
    private int playerLives = 3;
    private int bossLives = 3;
    public Renderer df1;
    public Renderer df2;
    public Renderer df3;
    public Renderer df4;
    public BoxCollider2D f1;
    public BoxCollider2D f2;
    public BoxCollider2D f3;
    public BoxCollider2D f4;
    public bool dragonHit = false;
    public bool phase2 = false;
    public bool phase3 = false;
    public bool bossDefeated = false;
    private Rigidbody2D rb;
    private Animator anim;
    public Animator dragonAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //Idle
        if(moveInput == 0)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", false);
        }

        //Moving Right
        else if(moveInput > 0)
        {
            if(isGrounded == false)
            {
                anim.SetBool("isJumpingRight", true);
                anim.SetBool("isJumpingLeft", false);
                anim.SetBool("isRunningRight", false);
                anim.SetBool("isRunningLeft", false);
            }

            else
            {
                anim.SetBool("isRunningRight", true);
                anim.SetBool("isRunningLeft", false);
            }        
        }

        //Moving Left
        else if(moveInput < 0)
        {
             if(isGrounded == false)
            {
                anim.SetBool("isJumpingLeft", true);
                anim.SetBool("isJumpingRight", false);
                anim.SetBool("isRunningRight", false);
                anim.SetBool("isRunningLeft", false);
            }

            else
            {
                anim.SetBool("isRunningLeft", true);
                anim.SetBool("isRunningRight", false);
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            if(moveInput >= 0)
            {
                anim.SetBool("isJumpingRight", true);
                anim.SetBool("isGrounded", false);
            }

            else
            {
                anim.SetBool("isJumpingLeft", true);
                anim.SetBool("isGrounded", false);
            }
            isJumpingRight = true;
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !attacked && isGrounded)
        {
            StartCoroutine(attack());
        }

        if(playerLives == 2)
        {
            Destroy(GameObject.Find("PlayerHeart1"));
        }

        else if(playerLives == 1)
        {
            Destroy(GameObject.Find("PlayerHeart2"));
        }

        else if(playerLives == 0)
        {
            Destroy(GameObject.Find("PlayerHeart3"));
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator attack()
    {
        anim.SetTrigger("AttackRight");
        attacked = true;
        attackBox.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        attacked = false;
        attackBox.SetActive(false);
        

        Collider2D[] Enemies = Physics2D.OverlapCircleAll(attackBox.transform.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in Enemies)
        {
            if(enemy.CompareTag("Boss") && (dragonHit == false))
            {
                if(bossLives == 3)
                {
                    Destroy(GameObject.Find("BossHeart1"));
                    dragonHit = true;
                    bossLives -= 1;   
                    dragonAnimator.SetBool("isHit", true);

                    yield return new WaitForSecondsRealtime(1);
                    df1.enabled = true;
                    f1.enabled = true;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df2.enabled = true;
                    f2.enabled = true;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df3.enabled = true;
                    f3.enabled = true;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df4.enabled = true;
                    f4.enabled = true;

                    yield return new WaitForSecondsRealtime(2F);
                    df1.enabled = false;
                    f1.enabled = false;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df2.enabled = false;
                    f2.enabled = false;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df3.enabled = false;
                    f3.enabled = false;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df4.enabled = false;
                    f4.enabled = false;

                    phase2 = true;
                    dragonAnimator.SetBool("isHit", false);
                    dragonHit = false;
                }

                else if(bossLives == 2)
                {
                    Destroy(GameObject.Find("BossHeart2"));
                    dragonHit = true;
                    bossLives -= 1;   
                    dragonAnimator.SetBool("isHit", true);

                    yield return new WaitForSecondsRealtime(1);
                    df1.enabled = true;
                    f1.enabled = true;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df2.enabled = true;
                    f2.enabled = true;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df3.enabled = true;
                    f3.enabled = true;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df4.enabled = true;
                    f4.enabled = true;

                    yield return new WaitForSecondsRealtime(2F);
                    df1.enabled = false;
                    f1.enabled = false;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df2.enabled = false;
                    f2.enabled = false;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df3.enabled = false;
                    f3.enabled = false;
                    yield return new WaitForSecondsRealtime(0.1F);
                    df4.enabled = false;
                    f4.enabled = false;

                    phase2 = false;
                    phase3 = true;
                    dragonAnimator.SetBool("isHit", false);
                    dragonHit = false;
                }

                else if(bossLives == 1)
                {
                    Destroy(GameObject.Find("BossHeart3"));
                    dragonHit = true;
                    bossLives -= 1;
                    dragonAnimator.SetBool("isHit", true);
                    Destroy(GameObject.Find("DragonCollider").GetComponent<BoxCollider2D>());
                    SceneManager.LoadScene("Win");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor" || col.gameObject.tag == "Boss")
        {
            anim.SetBool("isJumpingRight", false);
            anim.SetBool("isJumpingLeft", false);
            anim.SetBool("isGrounded", true);
            isJumpingRight = false;
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }
        
        if(col.gameObject.tag == "Enemy")
        {
            transform.position = GameObject.FindWithTag("Spawn").transform.position;
            playerLives -= 1;
        }

        else if(col.gameObject.tag == "Level1Complete")
        {
            SceneManager.LoadScene("Level2");
            playerLives = 3;
        }

        else if(col.gameObject.tag == "Level2Complete")
        {
            SceneManager.LoadScene("Level3");
            playerLives = 3;
        }
    }

    private void FixedUpdate() 
    {
        if (transform.position.y < -8.0f)
        {
            transform.position = GameObject.FindWithTag("Spawn").transform.position;
            playerLives -= 1;
        }
    }
}
