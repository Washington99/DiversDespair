using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    [SerializeField] public float scrollSpeed;
    private float healAmount = 20f;

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

            player.HealStamina(healAmount);

            Destroy(gameObject);
              
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
