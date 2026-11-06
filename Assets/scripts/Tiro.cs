using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 12f;

    void Update()
    {
        // Move a bala continuamente para a direita
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        // Se acertar o inimigo comum
        if (outro.CompareTag("Inimigo"))
        {
            Destroy(outro.gameObject); // Destrói o inimigo
            Destroy(gameObject);      // Destrói a bala
        }
        // Se acertar o Boss
        else if (outro.CompareTag("Boss"))
        {
            Destroy(gameObject);      // Destrói a bala (o Boss conta o dano dele próprio)
        }
    }
}