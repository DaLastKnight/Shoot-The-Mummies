using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // -16.3 to -22
    public GameObject Enemy;
    [SerializeField] float xPos;
    [SerializeField] float zPos;
    [SerializeField] int EnemyCount;
    public int maxEnemyCount;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < maxEnemyCount)
        {
            xPos = Random.Range(-60, -65);
            zPos = Random.Range(-10, -25);
            Instantiate(Enemy, new Vector3(xPos, -22, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
            EnemyCount += 1;

        }


    }


    
}
