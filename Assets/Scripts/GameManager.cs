using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool collider1Hit, collider2Hit;
    [SerializeField]
    private float startTime;
    [SerializeField]
    private TextMeshProUGUI text;
    void Update()
    {
        text.text = startTime.ToString("0.00");

        if (collider1Hit || collider2Hit)
        {
            startTime += Time.deltaTime;
        }

        if (collider1Hit && collider2Hit)
        {  
            text.color = Color.green;
            collider1Hit = false;
            collider2Hit = false;
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!collider1Hit && !collider2Hit)
        {
            collider1Hit = true;
            startTime = 0f;
            text.color = Color.white;
        }
        else if (collider1Hit && !collider2Hit)
        {
            collider2Hit = true;
        }
    }
}
