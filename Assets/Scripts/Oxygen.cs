using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D (Collider2D collider) {

        PlayerMovement player = collider.GetComponent<PlayerMovement>();
            
        if (player != null) {

            // Point increase code here

            Destroy(gameObject);
              
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
