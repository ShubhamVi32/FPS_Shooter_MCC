using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    public int HeadShootDamage;
    public Rigidbody rb;
    public float lifeTime;
    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            PlayerMovement.instance.playerScore += 5;
            UiManager.instance.ShowScore(PlayerMovement.instance.playerScore);
            collision.gameObject.GetComponent<EnemyMovement>().HealthManage(damage);
        }
        Instantiate(hitEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
