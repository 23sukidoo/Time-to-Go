using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn2 : MonoBehaviour
{

    public GameObject [] hearts;
    private int life;

    private float checkPointPositionX, checkPointPositiony;

    public Animator animator;
    
    void Start()
    {

        life = hearts.Length;
       
        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
         
    }

    private void CheckLife() 
    {
        if (life <1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("muerte_principal");
            //GameController.gameOn = false;
            Invoke("ChangeDead2", 1);
        }    
        else if (life <2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("muerte_principal");
            //GameController.gameOn = false;
            //Invoke("ChangeDead", 1);
        }
        else if (life <3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("muerte_principal");
            //GameController.gameOn = false;
            //Invoke("ChangeDead", 1);
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY",y);
    }

    public void PlayerDamaged()
    {
        animator.Play("muerte_principal");
        GameController.gameOn = false;
        Invoke("ChangeDead2", 1);
        
    }
    void ChangeDead()
    {
        life--;
        CheckLife();
        
    }

     void ChangeDead2()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
