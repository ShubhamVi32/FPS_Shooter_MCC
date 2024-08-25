using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    public Image HealthBar;
    public int healthValue;
    private int currentHealth;

    private GameObject player;
    public float chaseTime;

    public NavMeshAgent agent;
    public float activeRange;
    public float distanceToLose;
    private Vector3 initialPos;
    public GameObject EnemyBullet;
    public bool canShoot;
    [SerializeField] private float Firerate = 0.5f, waitbetweenShoot = 2f, TimetoShoot = 1f;
    [SerializeField] float ShootTimeCounter;
    [SerializeField] float firecount, ShotWaitCounter;
    [SerializeField] Transform Firepoint;
    // Start is called before the first frame update
    void Start()
    {
        ShootTimeCounter = TimetoShoot;
        ShotWaitCounter = waitbetweenShoot;
        agent = this.GetComponent<NavMeshAgent>();
        initialPos = this.transform.position;

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
            
            //if (Vector3.Distance(transform.position, player.transform.position) < distanceToLose)
            //{
            //    ShootTimeCounter = TimetoShoot;
            //    ShotWaitCounter = waitbetweenShoot;
            //}

            if (Vector3.Distance(this.transform.position,player.transform.position) < activeRange)
            {
                agent.destination = player.transform.position;
            }
             if(Vector3.Distance(this.transform.position, player.transform.position) > distanceToLose)
            {
                agent.destination = initialPos;
            }

            //if (canShoot)
            //{
            //    ShootTimeCounter -= Time.deltaTime;
            //    if (ShootTimeCounter > 0)
            //    {
            //        Debug.Log("shoot 1");
            //        firecount -= Time.deltaTime;
            //        if (firecount <= 0)
            //        {
            //            firecount = Firerate;
            //            Firepoint.LookAt(player.transform.position);
            //            Vector3 targetdir = player.transform.position - transform.position;
            //            float angle = Vector3.SignedAngle(targetdir, transform.forward, Vector3.up);
                        
            //            if (Mathf.Abs(angle) < 15f)
            //            {
            //                Instantiate(EnemyBullet, Firepoint.position, Firepoint.rotation);
            //            }
            //            else
            //            {
            //                ShotWaitCounter = waitbetweenShoot;
            //            }
            //        }
            //        //agent.destination = transform.position;
            //    }
            //    else
            //    {
            //        ShotWaitCounter = waitbetweenShoot;
            //    }
            //}
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
