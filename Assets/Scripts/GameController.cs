using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount = 10;
    public List<GameObject> hazards = new List<GameObject>();
    public float spawnWait;
    public float startWait;
    public float waveWait;
    

    private void Start()
    {
        StartCoroutine(SpawnWWaves());
    }

    private void Update()
    {
      
    }

    IEnumerator SpawnWWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                hazards.Add(Instantiate(hazard, spawnPosition, spawnRotation));
                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
       
        
        


    }
}
