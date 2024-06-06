using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    private float maxSpeed;
    private Rigidbody2D body;
    private Vector2 screenBounds;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        maxSpeed = speed * (float)0.8;
    }
 
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x)
            body.velocity = new Vector2(0, body.velocity.y);
        if (transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
            body.velocity = new Vector2(body.velocity.x, 0);    
        if (body.velocity.y > maxSpeed)
            body.velocity = new Vector2(body.velocity.x, maxSpeed);
        if (body.velocity.y < -maxSpeed / 2)
            body.velocity = new Vector2(body.velocity.x, -maxSpeed/2);
    }
}