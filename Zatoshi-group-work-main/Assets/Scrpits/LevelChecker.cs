using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChecker : MonoBehaviour
{

    public int ZombieLeft = 0;
    public GameObject levelUpText, resetText, playAgainButton;
    public Text playerHealth;
    public PlayerMovement health;
    GameObject[] deadZombies, totalZombies;



    public void Start()
    {
        totalZombies = GameObject.FindGameObjectsWithTag("Enemy");
        ZombieLeft = totalZombies.Length;
    }

    public void Update()
    {
        playerHealth.text = "Player Health: " + health.playerHealth;

        if (health.gameOver == true)
        {
           // resetText.SetActive(true);
            StartCoroutine(reset());
        }
        deadZombies = GameObject.FindGameObjectsWithTag("Dead");
        if (deadZombies.Length == 7)
        {
            levelUpText.SetActive(true);
        }


    }
   
    IEnumerator reset()
    {
        yield return new WaitForSeconds(2);
        playAgainButton.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void resetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}