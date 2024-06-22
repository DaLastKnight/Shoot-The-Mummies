using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    // -16.3 to -22
    public GameObject Enemy1;
    [SerializeField] float xPos1;
    [SerializeField] float zPos1;
    [SerializeField] int EnemyCount1;
    public int maxEnemyCount1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies1());
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator SpawnEnemies1()
    {
        while (EnemyCount1 < maxEnemyCount1)
        {
            xPos1 = Random.Range(-102, -120);
            zPos1 = Random.Range(20, 36);
            Instantiate(Enemy1, new Vector3(xPos1, -14, zPos1), Quaternion.identity);
            yield return new WaitForSeconds(1);
            EnemyCount1 += 1;

        }


    }



}
