using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Elements = null;
    public Vector2 SpawnRatio = new Vector2(1f, 5f);
    public int Amount = 10;

    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Random.Range(SpawnRatio.x, SpawnRatio.y);
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn -= Time.deltaTime;
        if(nextSpawn <= 0f && Amount > 0)
        {
            int choice = Random.Range(0, Elements.Length);
            Instantiate(Elements[choice], transform.position, transform.rotation);
            nextSpawn = Random.Range(SpawnRatio.x, SpawnRatio.y);
            Amount--;
        }
    }
}
