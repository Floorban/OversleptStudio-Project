using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mPrefabsList;
    [SerializeField]
    private int maxNum, currentNum;
    private bool canSpawn;
    private void Update()
    {
        if (currentNum >=maxNum)
        {
            canSpawn = false;
        }else
        {
            canSpawn = true;
        }
    }
    public void Spawn(int buttonID)
    {
        if (canSpawn == true)
        {
            if (buttonID >= 0 && buttonID < mPrefabsList.Count)
            {
                GameObject prefabToSpawn = mPrefabsList[buttonID];
                GameObject spawnedMusician = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
                currentNum++;
            }
        }else
        {
            //something to show the player that they can't add more ppl on the stage
        }

    }
}
