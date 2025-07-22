using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Movimento
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpCooldown = 0.2f;
    public float wallSlideSpeed = 2f;
    public LayerMask wallLayer;

    // Componentes
    private Rigidbody2D rb;
    private Animator anim;

    // Estados
    private bool isGrounded;
    private bool onWall;
    private bool isWallSliding;
    private float horizontalInput;
    private float currentWallJumpCooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Pega o Animator automaticamente
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Flip do sprite
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Atualiza a anima��o - considera se est� no ch�o E se est� se movendo
        bool isMoving = Mathf.Abs(horizontalInput) > 0.01f && !isWallSliding && isGrounded;
        anim.SetBool("isWalking", isMoving);

        // L�gica de movimento e wall slide/jump
        if (currentWallJumpCooldown > wallJumpCooldown)
        {
            // Movimento horizontal (exceto durante wall slide)
            if (!isWallSliding)
            {
                rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
            }

            // Wall slide
            if (onWall && !isGrounded)
            {
                isWallSliding = true;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlideSpeed, float.MaxValue));
            }
            else
            {
                isWallSliding = false;
            }

            // Pulo
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    Jump();
                }
                else if (onWall)
                {
                    WallJump();
                }
            }
        }
        else
        {
            currentWallJumpCooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void WallJump()
    {
        // Empurra o jogador para longe da parede e d� um impulso vertical
        rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * moveSpeed, jumpForce);
        currentWallJumpCooldown = 0; // Reseta o cooldown
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Verifica se o jogador est� tocando uma parede
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            onWall = true;
        }

        // Morte ao tocar no inimigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit by enemy!");
            Die();
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        // Verifica se o jogador n�o est� mais tocando uma parede
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            onWall = false;
            isWallSliding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Morte ao tocar no pingo
        if (collision.CompareTag("Drop"))
        {
            Debug.Log("Player hit by drop!");
            Destroy(collision.gameObject); // Destroi o pingo
            Die();
        }

        // Morte ao tocar no ácido
        if (collision.CompareTag("Acidot"))
        {
            Debug.Log("Player hit by acid!");
            Die();
        }

        // Coleta o queijo
        if (collision.CompareTag("Cheese"))
        {
            Debug.Log("Cheese collected!");
            CheeseManager.Instance.CollectCheese();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("WinObject"))
        {
            Debug.Log("Player Won!");
            SceneManager.LoadSceneAsync(4);
        }
    }

    public void Die()
    {
        Debug.Log("Player Died!");
        SceneManager.LoadSceneAsync(5);
    }
}