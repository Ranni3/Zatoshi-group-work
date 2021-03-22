using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public float reactionDistance;
    public enum enemyState { idle, chasing };
    public enemyState currentState = enemyState.idle;

    public float currentDistance;
    public PlayerMovement playerData;

    public Animator anim;

    public float enemyHealth = 100f;
    public bool isDead = false;

    //public LevelUp zombieCheck;

    public AudioSource Audio;
    public AudioClip bloodSound, attackSound ;

       void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Decision());
       
    }

    public void damage()
    {
        if (playerData.playerHealth > 0)
        {
            playerData.playerHealth -= 20.0f;
            Audio.PlayOneShot(attackSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Attack", true);
           
        }
        if (other.tag == "Bullet")
        {
            enemyHealth -= 20;
            Audio.PlayOneShot(bloodSound);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Attack", false);
        }
    }


    void Update()
    {
        if (enemyHealth <= 0)
        {
            anim.SetBool("Die", true);
            isDead = true;
            this.gameObject.tag = "Dead";
        }
        

    }

    


    IEnumerator Decision()
    {
        while (true)
        {
           
            if (isDead == false)
            {
                agent.SetDestination(player.position);
            }

            if (isDead == true)
            {
                agent.speed = 0f;
                
                isDead = false;
               
            }
            yield return new WaitForSeconds(0.1f);
        }
       

    }
}


