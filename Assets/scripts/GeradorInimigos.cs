using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Marcador: tudo que tiver isto causa derrota ao encostar no jogador
public class Inimigo : MonoBehaviour { }

public class GeradorInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public GameObject bossPrefab;

    public float intervalo = 3f;

    public float limiteX = 8f;
    public float limiteY = 4f;

    public float velocidade = 3f;

    public float limiteDestruicaoX = -12f;

    [Header("Controle do Boss")]
    public int limiteInimigos = 6;
    private int contadorInimigos = 0;
    private bool bossChamado = false;

    void Start()
    {
        InvokeRepeating("GerarInimigo", 0f, intervalo);
    }

    void GerarInimigo()
    {
        if (contadorInimigos >= limiteInimigos)
        {
            if (!bossChamado)
            {
                bossChamado = true;
                PararEChamarBoss();
            }
            return;
        }

        contadorInimigos++;

        float x = limiteX;
        float y = Random.Range(-limiteY, limiteY);
        Vector2 posicaoAleatoria = new Vector2(x, y);

        GameObject inimigo = Instantiate(inimigoPrefab, posicaoAleatoria, Quaternion.identity);

        if (inimigo.GetComponent<Inimigo>() == null)
            inimigo.AddComponent<Inimigo>();

        StartCoroutine(MoverInimigo(inimigo));
    }

    void PararEChamarBoss()
    {
        CancelInvoke("GerarInimigo");

        if (bossPrefab != null)
        {
            Vector2 posicaoBoss = new Vector2(limiteX, 0f);
            GameObject boss = Instantiate(bossPrefab, posicaoBoss, Quaternion.identity);

            if (boss.GetComponent<Inimigo>() == null)
                boss.AddComponent<Inimigo>();
        }
    }

    IEnumerator MoverInimigo(GameObject inimigo)
    {
        while (inimigo != null)
        {
            inimigo.transform.Translate(Vector2.left * velocidade * Time.deltaTime);

            if (inimigo.transform.position.x < limiteDestruicaoX)
            {
                Destroy(inimigo);
                yield break;
            }
            yield return null;
        }
    }
}