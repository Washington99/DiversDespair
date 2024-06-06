using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Bomb bombObject;
    [SerializeField] private int bombsToSpawn;

    private List<Bomb> bombs;

    // Start is called before the first frame update
    void Start()
    {
        bombs = new List<Bomb>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        if (Random.Range(0, 10) > 8 && bombs.Count < bombsToSpawn) {
            GameObject bomb = Instantiate(
                bombObject.gameObject, 
                transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            bomb.transform.parent = gameObject.transform;


            bombs.Add(bomb.GetComponent<Bomb>());
        }

        // Remove all Destroyed bombs
        bombs.RemoveAll(GameObject => GameObject == null);

    }
}
