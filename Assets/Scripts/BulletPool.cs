using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedPool; // Unica instancia de BulletPool para usar desde otros scripts
    public GameObject bullet;
    [SerializeField] private int bulletAmount;
    private List<GameObject> bulletPool;

    private void Awake()
    {
        SharedPool = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < bulletAmount; i++)
        {
            var bulletInstance = Instantiate(bullet, this.transform.position, Quaternion.identity);
            bulletInstance.SetActive(false);
            bulletPool.Add(bulletInstance);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool != null && bulletPool.Count > 0)
        {
            for (int i = 0; i < bulletPool.Count; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    return bulletPool[i];
                }
            }
        }
        return null;
    }

}

/*
1. BulletPool creates a pool and fills it with deactivated bullets
2. BulletSpawner will fire a bullet from it's position and its color and set a fire rate and a life time for the bullet
3. 
*/