using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;

    EnemyScript enemyScript;
    public GameObject Enemy;

    CombatScript combatScript;
    public GameObject combat;

    public GameObject particlesystem;
    
    public float playerlevel;
    public float playerexp;
    public float playerattackdamage;
    public float expgain;
    public float expthreshold;

    public bool expadded;
    public bool turnend;
    public bool leveledup;
    public bool canlevelup;
    public bool GameWon;

    // Start is called before the first frame update
    void Start()
    {
        combatScript = combat.GetComponent<CombatScript>();
        enemyScript = Enemy.GetComponent<EnemyScript>();

        expadded = false;
        turnend = false;
        leveledup = false;
        GameWon = false;

        // Base stats are generated
        playerlevel = 1f;
        playerexp = 0f;
        expthreshold = 100f;
        playerattackdamage = 10f;
    }

    //Function that triggers when player can level up
    void LevelUp()
    {
        //
    }

    //Function that is called when player reached level 5
    void GameWin()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
       if (combatScript.playerattacked)
        {
            if ((combatScript.AddExp) && (expadded == false))
            {
                //If exp add is called and hasnt already been added this turn
                expgain = Random.Range(50, 250);
                playerexp = playerexp + expgain;
                print($"You have gained {expgain} EXP! ({playerexp}/{expthreshold})\n");
                turnend = true;
                expadded = true;
            }

            if ((playerexp >= expthreshold) && (canlevelup == false))
            {
                //If the player has enough exp and hasnt already been prompted to level up
                print($"You have enough EXP to Level Up!\n");
                print($"PRESS E TO LEVEL UP\n");
                canlevelup = true;
            }

            if (Input.GetKeyDown("e") && (canlevelup))
            {
                //If the player is able to level up, They can press E to do so
                playerlevel = playerlevel + 1;
                expthreshold = expthreshold + (expthreshold);
                playerattackdamage = playerattackdamage + (playerattackdamage * 0.25f);
                print($"You leveled up to Level {playerlevel}!\nYour Threshold has increased by 50%, And Attack Damage by 25%!");
                Enemy.SetActive(true);
                leveledup = true;
                canlevelup = false;
            }

            if ((playerexp < expthreshold) && (expadded))
            {
                //If the player does not have enough exp to level up and they have already gained exp this turn
                if (playerlevel < 5)
                {
                    //If the player is not yet level 5, spawn next enemy to start next turn
                    Enemy.SetActive(true);
                }
            }

            if ((enemyScript.enemyspawned) && (leveledup))
            {
                //If enemy is alive and player has just leveled up, reset current level progress to 0
                playerexp = 0f;
            }
        }    
 
       if (playerlevel == 5)
        {
            //If the player is level 5, player wins
            GameWon = true;  
        }

       if (GameWon)
        {
            print($"Congratulations, You Win!!\n");
            particlesystem.SetActive(true);
            playerlevel = 6;
            GameWon = false;
        }
     
    }

}
