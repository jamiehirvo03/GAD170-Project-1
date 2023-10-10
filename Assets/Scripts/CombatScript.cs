using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    PlayerScript playerScript;
    public GameObject player;

    EnemyScript enemyScript;
    public GameObject enemy;

    public bool AddExp;
    public bool LevelUp;
    public bool prompted;
    public bool playerattacked;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        enemyScript = enemy.GetComponent<EnemyScript>();

        enemy.SetActive(true);

        AddExp = false;
        prompted = false;
        playerattacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        //this enters the combat phase, prompting the player to attack
        if ((enemyScript.combatprompt) && (prompted == false) && (playerScript.playerlevel < 6)) 
        {
            print($"Your Stats - |Level:{playerScript.playerlevel}|EXP:{playerScript.playerexp}/{playerScript.expthreshold}|Attack Damage:{playerScript.playerattackdamage}|\nPRESS D TO ATTACK");
            prompted = true;
        }

        //this will only allow the player to attack if the enemy is alive
        if (Input.GetKeyDown("d") && (enemyScript.enemystillalive))
        {
            enemyScript.enemyhp = enemyScript.enemyhp - playerScript.playerattackdamage;

            print($"You attacked the enemy for {playerScript.playerattackdamage} damage!\nThey now have {enemyScript.enemyhp} HP");

            playerattacked = true;
        }

        //this will check the enemyscript to see if it is dead
        if (enemyScript.enemystillalive)
        {
            enemyScript.combatprompt = true;
        }

        if ((enemyScript.enemystillalive == false) && (AddExp))
        {
            enemy.SetActive(false);

            LevelUp = true;
        }
    }


    //Display player stats and intructions


    //Display generated enemy stats

    
    //Combat function


    //Game win function
}
