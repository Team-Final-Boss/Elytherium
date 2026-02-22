using System.Collections;
using UnityEngine;

public class ItemCollectable : MonoBehaviour
{
    [Header("Dissolve")]
    [SerializeField] private string dissolveProperty = "_DissolveAmount"; // Propriedade Afetada
    [SerializeField] private float dissolveDuration = 5f; // Tempo de Duração do Efeito

    private Material _material;
    private bool _isCollected;

    void Awake()
    {
        // Cria uma instância do material (IMPORTANTE)
        _material = GetComponent<Renderer>().material;

        // Garante que começa visível
        _material.SetFloat(dissolveProperty, 1f);
        Collect();
    }

    public void Collect()
    {
        if (_isCollected) return;
        _isCollected = true;

        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        float t = 0f; //Tempo de dissolve

        while (t < dissolveDuration)
        {
            t += Time.deltaTime;
            float value = 1f - (t / dissolveDuration);

            _material.SetFloat(dissolveProperty, value);
            yield return null;
        }

        _material.SetFloat(dissolveProperty, 0f);

       
    }
}