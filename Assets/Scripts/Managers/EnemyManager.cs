using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public PlayerHealthSO playerHP;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField] EnemyPooling spawnEnemy;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

  


    void Spawn ()
    {
        if(playerHP.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        spawnEnemy.SpawnEnemyAtLocation(spawnPoints[spawnPointIndex].position);
    }
}
