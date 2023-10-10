using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int playerLevel;
    private int playerExp;
    private int expThreshold;
    private float attackDamage;

    private float totalDamageDone;
    private int totalExpGained;
    private int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        //Base stats are generated
        playerLevel = 1;
        playerExp = 0;
        expThreshold = 100;
        attackDamage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerExp >= expThreshold)
        {
            LevelUp();
        }
                
        
        if (playerLevel == 5)
        {
            GameWin();
        }
    }

    //Function that allows player to level up when exp threshold is met
    void LevelUp()
    {
        int expGain = Random.Range(50, 250);
        playerExp = playerExp + expGain;

        Debug.Log($"You have gained {expGain} EXP! ({playerExp}/{expThreshold}\n");
    }

    //Function that ends the game when player reaches level 5
    void GameWin()
    {
        Debug.Log("Congratulations, You Win!\n");

        //Show player end stats: total damage done, total exp gained & final score
    }
}
