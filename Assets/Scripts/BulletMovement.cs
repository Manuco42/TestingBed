using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Random.insideUnitCircle.normalized;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

    }
}
