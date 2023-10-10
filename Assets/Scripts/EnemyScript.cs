using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Enemy;

    CombatScript combatScript;
    public GameObject combat;

    PlayerScript playerScript;
    public GameObject player;

    public float enemylevel;
    public float enemyhp;

    public bool enemyspawned;
    public bool combatprompt;
    public bool enemystillalive;
    public bool slainmessage;

    
    //this will trigger whenever the Enemy object is enabled, allowing new stats to generate when new enemy 'spawns'
    void OnEnable()
    {
        combatScript = combat.GetComponent<CombatScript>();
        playerScript = player.GetComponent<PlayerScript>();

        playerScript.canlevelup = false;
        enemystillalive = true;
        slainmessage = false;
        playerScript.turnend = false;
        playerScript.expadded = false;
        combatScript.playerattacked = false;
        enemylevel = Random.Range(1, 5);
        enemyhp = (enemylevel * 5) + 5;
        enemyspawned = true;
        playerScript.leveledup = false;
        print($"A new foe appears!\nThey are Level {enemylevel}, and they have {enemyhp}HP");
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyspawned)
        {
            combatScript.prompted = false;
            combatprompt = true;
            enemyspawned =false;
        }

        if (combatScript.playerattacked)
        {

            if ((enemyhp <= 0) && (slainmessage == false))
            {
                print("The enemy has been slain!\n");
                combatScript.AddExp = true;
                enemystillalive = false;
                slainmessage = true;
            }

            if (enemyhp > 0)
            {
                enemyspawned = true;
                combatScript.playerattacked = false;
            }
        }
    }

    //Enemy generation function


}
