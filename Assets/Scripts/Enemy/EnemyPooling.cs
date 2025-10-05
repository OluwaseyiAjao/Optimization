using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyPrefab;
    [SerializeField] private int enemyToSpawn;

    private Queue<EnemyHealth> remainingEnemies = new Queue<EnemyHealth>();
    
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            var b = Instantiate(enemyPrefab);
                b.SetPool(this);
                b.gameObject.SetActive(false);
        }
    }

    public void SpawnEnemyAtLocation(Vector3 location)
    {
        if (remainingEnemies.Count > 0)
        {
            var current = remainingEnemies.Dequeue();
            
            current.gameObject.SetActive(true);
            
            current.transform.position = location;
        }
    }

    public void AddToQueue(EnemyHealth b)
    {
        remainingEnemies.Enqueue(b);
    }
}
