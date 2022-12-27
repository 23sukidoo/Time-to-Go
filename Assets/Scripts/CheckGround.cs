using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;//variable booleana para true y false || el static es para usar una variable en otro script

    private void OnTriggerEnter2D(Collider2D collision)//cuando el cubo de los pies entre dentro de una geometria
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)//cuando el cubo de los pies salga
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
