using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mPrefabsList;
    public int maxNum, currentNum;
    private bool canSpawn;
    public TextMeshProUGUI cNumText;

    [SerializeField]
    private float minX, maxX, minZ, maxZ;
    private void Start()
    {
        Spawn();
        Spawn();
        Spawn();
    }
    private void Update()
    {
        if (currentNum >=maxNum)
        {
            canSpawn = false;
        }else
        {
            canSpawn = true;
        }

        cNumText.text = "On Stage: " + currentNum;
    }
    public void Spawn()
    {
        if (mPrefabsList.Count > 0)
        {
            int randomIndex = Random.Range(0, mPrefabsList.Count);

            GameObject prefabToSpawn = mPrefabsList[randomIndex];

            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            Vector3 randomSpawnPosition = new Vector3(randomX, -3, randomZ);

            GameObject spawnedMusician = Instantiate(prefabToSpawn, randomSpawnPosition, Quaternion.identity);
            currentNum++;
        }
    }

}
