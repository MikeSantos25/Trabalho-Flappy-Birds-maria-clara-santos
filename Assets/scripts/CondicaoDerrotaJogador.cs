using UnityEngine;
using TMPro;

public class CondicaoDerrotaJogador : MonoBehaviour
{
    [Header("Sistema de Vidas e UI")]
    public int vidas = 3;
    public TextMeshProUGUI textoDerrotaUI; // Arraste o TextoDerrota para aqui no Inspector
    private bool jogoEncerrado = false;

    void Start()
    {
        if (textoDerrotaUI != null)
        {
            textoDerrotaUI.gameObject.SetActive(false); // Garante que começa oculto
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (jogoEncerrado) return;

        // Se encostar no Inimigo, no Projétil do Boss ou numa zona de morte
        if (outro.CompareTag("Inimigo") || outro.CompareTag("Boss") || outro.CompareTag("TiroBoss") || outro.CompareTag("Morte"))
        {
            vidas--;
            Debug.Log("Dano recebido! Vidas restantes: " + vidas);

            if (!outro.CompareTag("Morte") && !outro.CompareTag("Boss"))
            {
                Destroy(outro.gameObject); // Destrói o perigo (inimigo ou tiro)
            }

            if (vidas <= 0)
            {
                PerderJogo();
            }
        }
    }

    void PerderJogo()
    {
        jogoEncerrado = true;
        Debug.Log("GAME OVER!");

        // Mostra o texto de derrota na tela
        if (textoDerrotaUI != null)
        {
            textoDerrotaUI.gameObject.SetActive(true);
        }

        // Congela o tempo do jogo para parar tudo
        Time.timeScale = 0f;
    }
}