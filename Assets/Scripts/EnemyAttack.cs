using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    
    IEnumerator Attack(HealthBase target, float interval)
    {
        while (target != null)
        {
            target.TakeDamage(1);
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator attack;



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            attack = Attack(collider.gameObject.GetComponent<HealthBase>(), 2.0f);
            StartCoroutine(attack);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StopCoroutine(attack);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
