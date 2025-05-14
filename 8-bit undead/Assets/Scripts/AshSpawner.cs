using UnityEngine;

public class AshSpawner : MonoBehaviour
{
    public GameObject ashPrefab; // Prefab da cinza
    public float spawnInterval = 0.1f; // Intervalo entre spawns
    public float minX = -10f;
    public float maxX = 10f;
    public float spawnY = 6f; // Altura de onde nasce
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnAsh();
        }
    }

    void SpawnAsh()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), spawnY, 0f);
        GameObject ash = Instantiate(ashPrefab, spawnPos, Quaternion.identity);
        float fallSpeed = Random.Range(minSpeed, maxSpeed);
        ash.AddComponent<Rigidbody2D>().gravityScale = 0;
        ash.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -fallSpeed);

        Destroy(ash, 10f); // Destroi depois de um tempo pra não pesar
    }
}
