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
