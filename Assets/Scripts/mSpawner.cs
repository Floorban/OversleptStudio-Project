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
    public Transform spawnPos;
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

            GameObject spawnedMusician = Instantiate(prefabToSpawn, spawnPos.position, Quaternion.identity);
            currentNum++;
        }
    }
}
