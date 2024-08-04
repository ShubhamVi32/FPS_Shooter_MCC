using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    private GameObject player;
    public float chaseTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chasing();
    }

    void Chasing()
    {
        if(player != null)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, 
                player.transform.position, chaseTime * Time.deltaTime);
        }
    }


}
