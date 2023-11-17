using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private static BulletController _instance; // THis is to be able to call this class from other scripts

    private void Awake() // If there is no instance it instantiates it
    {
        if (_instance == null)
            _instance = this;
    }


    /// <summary>
    /// The Activate method below will activate a bullet, passing parameters
    /// </summary>
    /// <param name="bullet"> This is the GameObject to activate (bullets from the pool)</param> 
    /// <param name="time"> This is the time the GameObject will be active, see lifeTime in BulletSpawner </param>
    /// <param name="color"> This is the color of the GameObject, which is the same as the spawner </param>
    /// <param name="transform"> This is the position to spawn, same as spawner</param>
    public static void Activate(GameObject bullet, float time, Color color, Transform transform)
    {
        if (!bullet.activeInHierarchy)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.gameObject.GetComponent<SpriteRenderer>().color = color;
            bullet.SetActive(true);
        }
        _instance.StartCoroutine(DelayedStartCoroutine(bullet, time));
    }

    /// <summary>
    /// This method deactivates the bullet after a certain time
    /// </summary>
    /// <param name="bullet"> GameOBject to deactivate</param>
    /// <param name="time">time to deactivate</param>
    /// <returns></returns>
    private static IEnumerator DelayedStartCoroutine(GameObject bullet, float time)
    {

        yield return new WaitForSeconds(time);

        bullet.SetActive(false);

        //Do Function here...
    }
}