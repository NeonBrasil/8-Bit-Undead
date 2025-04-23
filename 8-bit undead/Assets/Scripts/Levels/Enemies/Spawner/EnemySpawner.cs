using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabInimigo;
    public Transform[] waypoints;
    public float tempoEntreSpawns = 2f;
    public int quantidadeMaxima = 10;

    private int inimigosGerados = 0;

    void Start()
    {
        StartCoroutine(Spawnar());
    }

    IEnumerator Spawnar()
    {
        while (inimigosGerados < quantidadeMaxima)
        {
            GameObject inimigo = Instantiate(prefabInimigo, transform.position, Quaternion.identity);
            inimigo.GetComponent<EnemyMovement>().waypoints = waypoints;
            inimigosGerados++;

            yield return new WaitForSeconds(tempoEntreSpawns);
        }
    }
}
