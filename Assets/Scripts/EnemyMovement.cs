using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    public Image HealthBar;
    public int healthValue;
    private int currentHealth;

    private GameObject player;
    public float chaseTime;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthValue;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chasing();
    }

    void Chasing()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) > 2)
            {
                this.transform.position = Vector3.MoveTowards(transform.position,
                        player.transform.position, chaseTime * Time.deltaTime);
            }
           

        }
    }

    public void HealthManage(int damage)
    {
        currentHealth -= damage;
        var valueForHealthBar = (float)currentHealth / (float)healthValue;
        HealthBar.fillAmount = valueForHealthBar;
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
