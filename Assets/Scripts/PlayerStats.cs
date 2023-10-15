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

    private bool canLevelUp;

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

        canLevelUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player obatins enough experience points, player may level up
        if (playerExp >= expThreshold)
        {
            LevelUp();
        }
               
        // If the player reaches level 5, player wins the game
        if (playerLevel == 5)
        {
            GameWin();
        }

        if (Input.GetKeyDown("e") && (canLevelUp))
        {
            LevelledUp();
        }

        // an If statement that was used to test if input was working
        
        // if (Input.GetKeyDown("g"))
        // {
        //  Debug.Log("Input script is working!");
        // }
    }
   
    // Function that adds a random amount of experience points to player stats
    void ExpGain()
    {
        int expGain = Random.Range(50, 250);
        playerExp = playerExp + expGain;

        Debug.Log($"You have gained {expGain} EXP! ({playerExp}/{expThreshold}\n");

    }

    // Function that allows player to level up when exp threshold is met
    void LevelUp()
    {
        Debug.Log($"You can now level up\nPRESS 'E' TO LEVEL UP");
        canLevelUp = true;
    }

    // Function that levels up the player, increasing their stats and resetting their exp progress
    void LevelledUp()
    {
        playerLevel = playerLevel + 1;
        expThreshold = expThreshold + (expThreshold / 2);
        playerExp = 0;
        attackDamage = attackDamage + (attackDamage * 0.25f);

        Debug.Log($"You levelled up to LVL.{playerLevel}! \nYour Exp Threshold has increased by 50%, and your Attack Damage by 25% !");

    }

    // Function that ends the game when player reaches level 5
    void GameWin()
    {
        Debug.Log("Congratulations, You Win!\n");

        // Show player end stats: total damage done, total exp gained & final score
    }
}
