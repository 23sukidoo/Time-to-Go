using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{

    private float horizontalMove = 0f;

    private float verticalMove = 0f;

    public Joystick joystick;


    public float runSpeedHorizontal = 1;//movimiento horizontal

    public float runSpeed = 1;

    public float jumpSpeed = 2;

    Rigidbody2D rb2D;// es una referencia del Rigidbody2D del unity

    public SpriteRenderer spriteRenderer;//para que la animacion sea de lado a lado

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();//aqui mete el componente en rgb2D
    }


    // Update is called once per frame
    private void Update()
    {
        if(GameController.gameOn)
        {

            


            if (horizontalMove>0)//si precionas la tecla "d" o la "felcha derecha" va a la derecha
            {
                spriteRenderer.flipX = false;
                animator.SetBool("caminar_principal", true);
            }

            else if (horizontalMove<0)//si precionas la tecla "a" o la "felcha izquierda" va a la izquierda
            {
                spriteRenderer.flipX = true;
                animator.SetBool("caminar_principal", true);
            }
            
            else
            {
                animator.SetBool("caminar_principal", false);
            }
            
            
            if (CheckGround.isGrounded==false)
            {
                animator.SetBool("saltar_principal", true);
                animator.SetBool("caminar_principal", false);
            }
            if (CheckGround.isGrounded==true)
            {
                animator.SetBool("saltar_principal", false);
                animator.SetBool("caer_principal", false);

            }

            if (rb2D.velocity.y<0)
            {
                animator.SetBool("caer_principal", true);
            }
            else if (rb2D.velocity.y > 0)
            {
                animator.SetBool("caer_principal", false);
            }

        }    


    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove,0,0) * Time.deltaTime * runSpeed;

    }


    public void Jump()
    {
        if (CheckGround.isGrounded)
            {
                rb2D.velocity=new Vector2(rb2D.velocity.x,jumpSpeed);
            }
        
    }
}
