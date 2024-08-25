using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthValue;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().Health += healthValue;
            var totalHealth = collision.gameObject.GetComponent<PlayerMovement>().Health;
            UiManager.instance.ShowHealthBar(totalHealth);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().Health += healthValue;
            var totalHealth = collision.gameObject.GetComponent<PlayerMovement>().Health;
            UiManager.instance.ShowHealthBar(totalHealth);
            Destroy(this.gameObject);
        }
    }

}
