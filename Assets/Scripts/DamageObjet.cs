using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjet : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            animator.SetBool("muerte_principal", true);
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
        
    }
}
