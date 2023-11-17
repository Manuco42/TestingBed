using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositCollision : MonoBehaviour
{
    public Color DepositColor;
    public Color PlayerStartColor;


    // Start is called before the first frame update
    void Start()
    {
        DepositColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        PlayerStartColor = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<SpriteRenderer>().color;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Color PlayerCurrentColor = other.gameObject.GetComponent<SpriteRenderer>().color;

        this.gameObject.GetComponent<SpriteRenderer>().color = PlayerCurrentColor;
        other.gameObject.GetComponent<SpriteRenderer>().color = PlayerStartColor;

    }
}
