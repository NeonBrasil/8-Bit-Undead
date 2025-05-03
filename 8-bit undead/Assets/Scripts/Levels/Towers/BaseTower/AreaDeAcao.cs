using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AreaDeAcao : MonoBehaviour
{
    public float range = 5f;
    private CircleCollider2D meuCollider;
    public int segmentos = 100;
    public float espessura = 0.05f;
    public Color cor = Color.white;
    private LineRenderer line;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuCollider = GetComponent<CircleCollider2D>();
        if (meuCollider != null)
        {
            meuCollider.radius = range;
        }

        line = GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.loop = true;
        line.positionCount = segmentos;
        line.startWidth = espessura;
        line.endWidth = espessura;
        line.material = new Material(Shader.Find("Sprites/Default")); // Necessário para cor funcionar
        line.startColor = cor;
        line.endColor = cor;

        DesenharCirculo();
        line.enabled = false;
    }

    void DesenharCirculo()
    {
        float angulo = 0f;
        for (int i = 0; i < segmentos; i++)
        {
            float x = Mathf.Cos(angulo) * range;
            float y = Mathf.Sin(angulo) * range;

            line.SetPosition(i, new Vector3(x, y, 0));
            angulo += 2 * Mathf.PI / segmentos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (spriteRenderer.bounds.Contains(posMouse))
            {
                line.enabled = !line.enabled;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
