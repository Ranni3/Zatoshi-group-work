using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    public float speed = 0.001f;
    Vector3 lastPosition;
    public float lifetime = 5.0f;
    public Transform gun;
    public GameObject blood;
    public AI enemyData;
    

    // Start is called before the first frame update

    void OnEnable()
    {
        lifetime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //lastPosition = this.transform.position;
        transform.position += transform.forward * speed * Time.deltaTime;
        //transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            this.gameObject.SetActive(false);
            transform.position = gun.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            transform.position = gun.transform.position;
            
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Enemy")
    //    {
    //        Debug.Log(enemyData.enemyHealth);
    //        enemyData.enemyHealth -= 20;
    //        Debug.Log(enemyData.enemyHealth);
    //        Debug.Log("Hit");

    //    }
    //}
}




