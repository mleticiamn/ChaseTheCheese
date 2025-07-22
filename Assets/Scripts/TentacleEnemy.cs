using UnityEngine;

public class TentacleEnemy : MonoBehaviour
{
    public float attackRange = 5f; // Distância para detectar o jogador
    public float attackDistance = 2f; // Distância que o inimigo se move para frente
    public float attackSpeed = 10f; 
    public float retreatSpeed = 5f;
    public float cooldown = 2f;

    private Transform player; 
    private Vector2 startPosition; // Posição inicial do inimigo
    private Vector2 attackPosition; // Posição de ataque
    private bool isAttacking = false;
    private bool isReturning = false;
    private float cooldownTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontra o jogador
        startPosition = transform.position; 
    }

    void Update()
    {
        // Verifica a distância até o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Se o jogador estiver dentro do alcance e o inimigo não estiver atacando ou voltando
        if (distanceToPlayer <= attackRange && !isAttacking && !isReturning && cooldownTimer <= 0f)
        {
            StartAttack();
        }

        
        if (isAttacking)
        {
            Attack();
        }

        
        if (isReturning)
        {
            ReturnToStart();
        }

        // Atualiza o cooldown
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void StartAttack()
    {
        // Define a posição de ataque (uma distância fixa à frente)
        attackPosition = startPosition + (Vector2)transform.right * attackDistance;
        isAttacking = true;
    }

    void Attack()
    {
        // Move o inimigo para a posição de ataque
        transform.position = Vector2.MoveTowards(transform.position, attackPosition, attackSpeed * Time.deltaTime);

        // Verifica se atingiu a posição de ataque
        if (Vector2.Distance(transform.position, attackPosition) < 0.1f)
        {
            isAttacking = false;
            isReturning = true;
        }
    }

    void ReturnToStart()
    {
        // Move o inimigo de volta para a posição inicial
        transform.position = Vector2.MoveTowards(transform.position, startPosition, retreatSpeed * Time.deltaTime);

        // Verifica se voltou para a posição inicial
        if (Vector2.Distance(transform.position, startPosition) < 0.1f)
        {
            isReturning = false;
            cooldownTimer = cooldown; // Inicia o cooldown
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hit by tentacle!");
            collision.GetComponent<PlayerController>().Die();
        }
    }
}