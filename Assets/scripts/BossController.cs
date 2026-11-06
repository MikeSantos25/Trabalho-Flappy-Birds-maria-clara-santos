using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossController : MonoBehaviour
{
    [Header("Sistema de Vida e UI")]
    public int vidaBoss = 10;
    public TextMeshProUGUI textoVidaBossUI;

    ControlaJogadorMouseEsquerdo jogador;

    void Start()
    {
        // Prefab não guarda referência da cena, então procuramos em tempo de jogo
        jogador = FindFirstObjectByType<ControlaJogadorMouseEsquerdo>();

        if (textoVidaBossUI == null)
        {
            GameObject obj = GameObject.Find("TextoVidaBoss"); // nome exato na Hierarchy
            if (obj != null) textoVidaBossUI = obj.GetComponent<TextMeshProUGUI>();
        }

        AtualizarTextoVidaBoss();
    }

    void AtualizarTextoVidaBoss()
    {
        if (textoVidaBossUI != null)
        {
            textoVidaBossUI.text = "Vida do Boss: " + vidaBoss;
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("bala"))
        {
            vidaBoss--;
            Destroy(outro.gameObject);
            AtualizarTextoVidaBoss();

            if (vidaBoss <= 0)
            {
                VencerJogo();
            }
        }
    }

    void VencerJogo()
    {
        if (textoVidaBossUI != null)
        {
            textoVidaBossUI.gameObject.SetActive(false);
        }

        if (jogador != null)
        {
            jogador.Vitoria();
        }

        Destroy(gameObject);
    }
}