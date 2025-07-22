using UnityEngine;

public class ToxicPipe : MonoBehaviour
{
    public GameObject dropPrefab; // Prefab do pingo
    public float dropInterval = 2f; // Intervalo entre os pingos
    public float dropSpeed = 3f; // Velocidade de queda do pingo
    private float timer;

    void Update()
    {
        // Contador para soltar pingos em intervalos regulares
        timer += Time.deltaTime;
        if (timer >= dropInterval)
        {
            SpawnDrop();
            timer = 0f;
        }
    }

    void SpawnDrop()
    {
        // Instancia o pingo na posi��o do cano
        GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);

        // Adiciona movimento ao pingo
        Rigidbody2D dropRb = drop.GetComponent<Rigidbody2D>();
        dropRb.linearVelocity = Vector2.down * dropSpeed;
    }
}