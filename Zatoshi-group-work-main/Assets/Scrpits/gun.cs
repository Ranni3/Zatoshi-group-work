using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public GameObject bullets;
    public GameObject pool;
    public List<GameObject> list;
    void Start()
    {
        
        for(int i = 0; i < 10; i++)
        {
            pool = Instantiate(bullets);
            pool.GetComponent<bullet>().gun = this.transform;
            list.Add(pool);
            pool.SetActive(false);
        }
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentbullet = shoot();
            if(currentbullet !=null)
            {
                currentbullet.transform.position = this.gameObject.transform.position;
                currentbullet.transform.rotation = this.gameObject.transform.rotation;
            }
            
        }
        
    }
    
    public GameObject shoot()
    {
        foreach (GameObject bullet in list)
        {
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                return bullet;
                
            }
            
        }
        return null;
    }
}
