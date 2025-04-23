using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float velocidade = 2f;

    private int pontoAtual = 0;

    void Update()
    {
        if (pontoAtual < waypoints.Length)
        {
            Transform alvo = waypoints[pontoAtual];
            Vector3 direcao = (alvo.position - transform.position).normalized;
            transform.position += direcao * velocidade * Time.deltaTime;

            if (Vector3.Distance(transform.position, alvo.position) < 0.1f)
            {
                pontoAtual++;
            }
        }
    }
}
