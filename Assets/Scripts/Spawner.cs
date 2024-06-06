using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Bomb bombObject;
    [SerializeField] private int bombsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Boss wave

        if (Random.Range(0, 10) > 8 && Bomb.numberSpawned < bombsToSpawn) {
            GameObject Bomb = Instantiate(
                bombObject.gameObject, 
                transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, 0.0f), 
                Quaternion.identity
                );
        }
        // else if (Time.time % sineWaveInterval == 0) {
        //     GameObject waveSine = Instantiate(
        //         moveSine.gameObject, 
        //         transform.position, 
        //         Quaternion.identity
        //         );
        // }
    }
}
