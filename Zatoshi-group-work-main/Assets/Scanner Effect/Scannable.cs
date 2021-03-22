using UnityEngine;
using System.Collections;

public class Scannable : MonoBehaviour
{
	public GameObject thisone;
	private Vector3 savedvector = new Vector3(4,4,4);
    public float RevealDuration = 5;
    private float revealTime;
    private bool revealed = false;
    private float hmm;
    void Start()
	{
        savedvector = thisone.transform.localScale;
        Debug.Log(savedvector);
		thisone.transform.localScale = new Vector3(0, 0, 0);
	}
    void Update()
    {

        Debug.Log("we here fam");
        Debug.Log(revealed);
        Debug.Log(revealTime + "reveal time");
        if (Time.time > revealTime)
        {
            Debug.Log("we here fam");
            thisone.transform.localScale = new Vector3(0, 0, 0);
            bool revealed = false;
        }
    }
    public void Ping()
	{
        Debug.Log("pung");
        thisone.transform.localScale =  savedvector;
        revealTime = Time.time + RevealDuration;
        bool revealed = true;
    }
}
