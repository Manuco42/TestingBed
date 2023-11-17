using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //SerializeField crea esta variable en el Editor para modificar facilmente, y creamos "speed" para definir y ser usada abajo
    [SerializeField] float speed = 5f; // Adjust the speed of the paddles as needed

    // Update is called once per frame
    void Update()

    {
        //  Defines the variable with "verticalInput", and "Input.GetAxisRaw" calls for the input as configured in Unity Editor, by default UP and DOWN are "Vertical" and LEFT and RIGHT arre "Horizontal" as those are their axis
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // "transform." corresponde a la Transform tool en el Editor con todos los axis, y "Translate" significa mover el objeto en esos axis
        // (Vector2.up * verticalInput * speed * Time.deltaTime) 
        //Vector2.up is the representation of the Y and X axis in 2d, and ".up" is a short way of saying Vector2(0,1), que es 0 en el X axis, y 1 en el Y axis
        //verticalInput is the variable we defined above which gets the button presses from the UP and DOWN key
        //speed is the variable above so we are multiplying by 5
        //Time.deltaTime is Unity magic to make it work the same in all computers no matter how fast the game runs in it
        // So, we are telling the object to move based on the input being pressed and at a velocity of 5
        transform.Translate(Vector2.up * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);


    }
}
