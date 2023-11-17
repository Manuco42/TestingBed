using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private float timer;
    public float fireRate;
    public float lifeTime;
    public Color SpawnerColor;
    public Transform SpawnerPosition;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        SpawnerColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        print(SpawnerColor);
        SpawnerPosition = this.gameObject.transform;
    }



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate * Time.deltaTime)
        {
            var bullet = BulletPool.SharedPool.GetBullet();
            if (bullet == null)
            {
                timer = 0;
                return;
            }
            BulletController.Activate(bullet, lifeTime, SpawnerColor, SpawnerPosition);

            timer = 0;
        }

    }
}
