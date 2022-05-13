using UnityEngine;

public class Player_Move : MonoBehaviour
{  

    [SerializeField] private float speed,jumpPower;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCol;
    [SerializeField]private LayerMask groundLayer, wallLayer;
    private float wallJumpCD, horizontalInput;

    private void Awake()
    {
        //take reff
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip
        if (horizontalInput> 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        //set anim
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Landing", isLanding());

        //wall Logic
        if (wallJumpCD > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            if(touchWall() && !isLanding())
            {
                body.gravityScale=0;
                body.velocity= Vector2.zero;
            }
            else
            {
                body.gravityScale = 2.5f;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {Jump();}
            
        }
        else
        {
            wallJumpCD += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if(isLanding())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
        else if(touchWall() && !isLanding())
        {
            if(horizontalInput == 0)
            {
                body.velocity= new Vector2(-Mathf.Sign(transform.localScale.x)*10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y,transform.localScale.z);
            }
            else
            {
                body.velocity= new Vector2(-Mathf.Sign(transform.localScale.x)* 2.5f,5);
            }
            wallJumpCD = 0;

        }

    }

    private bool isLanding()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }

    private bool touchWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size,0, new Vector2(transform.localScale.x,0),0.1f,wallLayer);
        return raycastHit.collider != null;
    }

    public bool slashAtt()
    {
        return horizontalInput == 0 && isLanding() && !touchWall();
    }


}
