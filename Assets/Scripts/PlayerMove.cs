using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 1;//movimiento horizontal
    public float jumpSpeed = 2;//
    Rigidbody2D rb2D;// es una referencia del Rigidbody2D del unity

    public bool betterJump = false;//para activar o desactivar salto dinamico
    public float fallMultiplier = 0.5f;//
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;//para que la animacion sea de lado a lado

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();//aqui mete el componente en rgb2D
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameController.gameOn)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))//si precionas la tecla "d" o la "felcha derecha" va a la derecha
            {
                rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
                spriteRenderer.flipX = false;
                animator.SetBool("caminar_principal", true);
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))//si precionas la tecla "a" o la "felcha izquierda" va a la izquierda
            {
                rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
                spriteRenderer.flipX = true;
                animator.SetBool("caminar_principal", true);
            }
            
            else
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);//si no presiona nada esta recto
                animator.SetBool("caminar_principal", false);

            }
            if(Input.GetKey("space")&&CheckGround.isGrounded)
            {
                rb2D.velocity=new Vector2(rb2D.velocity.x,jumpSpeed);
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


            if (betterJump)
            {
                if (rb2D.velocity.y<0)
                {
                    rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
                }
                if (rb2D.velocity.y>0 && !Input.GetKey("space"))
                {
                    rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
                }

            }

        }    


    }
}
