using UnityEngine;

public class MoveFundo : MonoBehaviour
{
    Renderer grafico;
    Material material;
    public float velocidadeMovimento = 0.5f;

    void Start()
    {
        grafico = GetComponent<Renderer>();
        material = grafico.material; // cria uma cópia só deste objeto

        // Garante que a textura repete em vez de esticar
        if (material.mainTexture != null)
            material.mainTexture.wrapMode = TextureWrapMode.Repeat;
    }

    void Update()
    {
        if (material == null) return;

        float offset = (Time.time * velocidadeMovimento) % 1f;
        Vector2 deslocamento = new Vector2(offset, 0);

        material.mainTextureOffset = deslocamento;

        if (material.HasProperty("_BaseMap"))
            material.SetTextureOffset("_BaseMap", deslocamento);
        if (material.HasProperty("_MainTex"))
            material.SetTextureOffset("_MainTex", deslocamento);
    }
}