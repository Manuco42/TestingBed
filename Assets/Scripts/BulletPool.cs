using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public static BulletPool bulletPoolInstance;// bullet pool instance variable

    [SerializeField] private GameObject pooledBullet;// pooledBullet represents a particular bullet which is put in the pool


    private bool notEnoughBulletsPool = true; //This will help us put more bullets in the pool if necessary

    private List<GameObject> bullets; // List of game objects, our pool, named bullets

    private void Awake()
    {

        bulletPoolInstance = this; //Here we assign the instance to this so we can use it in different scripts
    }


    // Start is called before the first frame update
    void Start()
    {

        bullets = new List<GameObject>(); //assigning the list on start so it can be filled with bullets
    }


    //This method is invoked when we need a bullet
    public GameObject GetBullet()
    {
        if (bullets.Count > 0) //First it checks if there are bullets in the pool already
        {
            for (int i = 0; i < bullets.Count; i++)// This will go through the existing bullets list
            {
                if (!bullets[i].activeInHierarchy)//and find one that is inactive
                {
                    return bullets[i];//When it finds one inactive, it returns it.
                }
            }
        }// If there are no bullets in the pool, which happens when the scene just started or all bullets are active in the heriarchy, ie being used at the moment
        //it means there are no bullets and we need to add more
        if (notEnoughBulletsPool)
        {
            GameObject bul = Instantiate(pooledBullet);//We instantiate a bullet
            bul.SetActive(false); // Set it as inactive
            bullets.Add(bul); // add it to the pool
            return bul; // return it
        }
        return null;



    }
    // Update is called once per frame
    void Update()
    {

    }
}
