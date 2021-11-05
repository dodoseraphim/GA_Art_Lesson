using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectin : MonoBehaviour
{
    //particle effect to be used
    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision) {
        //
        Debug.Log("Something");
        //
        Instantiate(reward, transform.position, transform.rotation)
        //
        
    }
}
