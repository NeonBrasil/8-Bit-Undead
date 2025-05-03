using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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
            if(Mathf.Abs(direcao.y) > 0.1){
                transform.rotation = Quaternion.Euler(0, 0, 90*direcao.y);

            }
            if(Mathf.Abs(direcao.x) > 0.1){
                if(direcao.x > 0){
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }else{
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                
            }
            
            transform.position += direcao * velocidade * Time.deltaTime;

            if (Vector3.Distance(transform.position, alvo.position) < 0.1f)
            {
                pontoAtual++;
            }
        }
    }
}
