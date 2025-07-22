using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float leftBound = -5f;
    public float rightBound = 5f;

    private bool movingRight = true;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimento
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = false; // Virado para direita
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = true; // Virado para esquerda
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
            }
        }

        // Ativa a animação de andar
        anim.SetFloat("Speed", moveSpeed);
    }
}