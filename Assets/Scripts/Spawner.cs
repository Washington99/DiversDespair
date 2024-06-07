using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Bomb bombObject;
    [SerializeField] private int bombsToSpawn;


    [SerializeField] private Coin coinObject;
    [SerializeField] private int coinsToSpawn;

    [SerializeField] private Oxygen oxygenObject;
    [SerializeField] private int oxygenToSpawn;

    [SerializeField] private Trap trapObject;
    [SerializeField] private int trapToSpawn;
    [SerializeField] private int collectibleSpawnRate;
    [SerializeField] private int spawnWidth;
    private List<Bomb> bombs;
    private List<Coin> coins;
    private List<Oxygen> oxygen;
    private List<Trap> traps;

    // Start is called before the first frame update
    void Start()
    {
        bombs = new List<Bomb>();
        coins = new List<Coin>();
        oxygen = new List<Oxygen>();
        traps = new List<Trap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        spawnHazard();
        spawnCollectible();

    }

    void spawnHazard()
    {
        float spawnSeed = Random.Range(0, 10);

        if (spawnSeed > 8 && bombs.Count < bombsToSpawn) {
            GameObject bomb = Instantiate(
                bombObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            bomb.transform.parent = gameObject.transform;

            bombs.Add(bomb.GetComponent<Bomb>());
        }

        if (spawnSeed < 8 && traps.Count < trapToSpawn) {
            GameObject trap = Instantiate(
                trapObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            trap.transform.parent = gameObject.transform;

            traps.Add(trap.GetComponent<Trap>());
        }

        // Remove all Destroyed bombs
        bombs.RemoveAll(GameObject => GameObject == null);
        traps.RemoveAll(GameObject => GameObject == null);
    }

    void spawnCollectible()
    {
        float spawnSeed = Random.Range(0, 10);
        
        if (coins.Count < coinsToSpawn && spawnSeed > collectibleSpawnRate) {
            GameObject coin = Instantiate(
                coinObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            coin.transform.parent = gameObject.transform;

            coins.Add(coin.GetComponent<Coin>());
        }

        if (oxygen.Count < oxygenToSpawn && spawnSeed <= collectibleSpawnRate) {
            GameObject o2 = Instantiate(
                oxygenObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            o2.transform.parent = gameObject.transform;

            oxygen.Add(o2.GetComponent<Oxygen>());
        }

        // Remove all Destroyed collectible
        
        coins.RemoveAll(GameObject => GameObject == null);
        oxygen.RemoveAll(GameObject => GameObject == null);
    }
}
