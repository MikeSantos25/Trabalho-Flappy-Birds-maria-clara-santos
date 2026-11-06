using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlaJogadorMouseEsquerdo : MonoBehaviour
{
    bool comecou;
    bool jogoAcabou;
    Rigidbody2D corpoJogador;
    Vector2 forcaImpulso = new Vector2(0, 500f);

    [Header("Sistema de Tiro e UI")]
    public GameObject tiroPrefab;
    public Transform pontoDisparo;
    public int municao = 10;
    public TextMeshProUGUI textoMunicaoUI;

    [Header("Vitória e Derrota")]
    public GameObject painelVitoria;    // arraste o TextoVitoria (ou um painel) aqui
    public GameObject painelDerrota;    // arraste o painel/texto de derrota aqui
    public float limiteInferiorY = -6f;
    public float limiteSuperiorY = 6f;

    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        AtualizarTextoMunicao();

        if (painelVitoria != null) painelVitoria.SetActive(false);
        if (painelDerrota != null) painelDerrota.SetActive(false);
    }

    void Update()
    {
        if (jogoAcabou)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (!comecou)
            {
                comecou = true;
                corpoJogador.bodyType = RigidbodyType2D.Dynamic; // MUDOU
            }

            corpoJogador.linearVelocity = Vector2.zero;
            corpoJogador.AddForce(forcaImpulso);
        }

        if (Input.GetKeyDown(KeyCode.Space) && municao > 0)
        {
            municao--;
            Instantiate(tiroPrefab, pontoDisparo.position, Quaternion.identity);
            AtualizarTextoMunicao();
        }

        if (comecou && (transform.position.y < limiteInferiorY || transform.position.y > limiteSuperiorY))
        {
            Derrota();
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (jogoAcabou) return;

        // MUDOU: inimigo ou boss causam derrota
        if (colisao.gameObject.CompareTag("Inimigo") || colisao.gameObject.CompareTag("Boss"))
            Derrota();
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (jogoAcabou) return;

        // MUDOU: inimigo ou boss causam derrota
        if (outro.CompareTag("Inimigo") || outro.CompareTag("Boss"))
            Derrota();
    }

    // Chamado pelo BossController quando a vida do Boss chega a 0
    public void Vitoria()
    {
        if (jogoAcabou) return;

        jogoAcabou = true;
        Debug.Log("VITÓRIA!");
        if (painelVitoria != null) painelVitoria.SetActive(true);
        Time.timeScale = 0f;
    }

    void Derrota()
    {
        if (jogoAcabou) return;

        jogoAcabou = true;
        Debug.Log("DERROTA!");
        if (painelDerrota != null) painelDerrota.SetActive(true);
        Time.timeScale = 0f;
    }

    void AtualizarTextoMunicao()
    {
        if (textoMunicaoUI != null)
            textoMunicaoUI.text = "Munição: " + municao;
    }
}