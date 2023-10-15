using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float enemyLevel;
    private float enemyHealth;

    // This is called when the gameobject this script is attached to is enabled
    void OnEnable()
    {
        enemyLevel = Random.Range(1, 5);
        enemyHealth = (enemyLevel * 5) + 5;

        Debug.Log($"A new enemy has appeared! \nThey are LVL.{enemyLevel}, and they have {enemyHealth} HP");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
