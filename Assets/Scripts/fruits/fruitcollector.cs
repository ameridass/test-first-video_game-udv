using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fruitcollector : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {

        int jumps;
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;

            // Destroy(gameObject);


            jumps = GetComponent<Movimiento>().maxJumps;
            Debug.Log("Choque");
            
        }
    }


}
