using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerMovement playerData;
    public void damage()
    {
       // Debug.Log(playerData.playerHealth);
        playerData.playerHealth -= 20.0f;
    }
}
