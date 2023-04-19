using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velCaminar = 4f;
    [SerializeField] private float velInicialDeSalto = 5.0f;
    private float jumpHeight = 10.0f;
    // Start is called before the first frame update
    [SerializeField] private LayerMask ground;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private int extraJumps;
    public int maxJumps;
    public Transform isInGround;
    public float checkRadius;
    private bool isGrounded;
    //Animations
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // boxCollider= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        flipCharacter();
        isGrounded = Physics2D.OverlapCircle(isInGround.position, checkRadius, ground);

        if(isGrounded)
        {
            extraJumps = maxJumps;
        }
    }
    public void MoveOnX(float movimientoX)
    {      
        rb.velocity = new Vector2(movimientoX * velCaminar, rb.velocity.y);
    }

    public void Saltar(bool valor)
    {
       if(valor && extraJumps> 0)
        {
             rb.velocity = new Vector2(rb.velocity.x, velInicialDeSalto);
            //rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpHeight));
            extraJumps--;
        }else if (valor && extraJumps == 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, velInicialDeSalto);
        }
      
    }

    public void flipCharacter()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX= true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
    }
    public int capacidadSalto = 0;
    public float incrementoVelocidad = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            capacidadSalto++;
            maxJumps = maxJumps + capacidadSalto++;
            other.gameObject.GetComponent<fruitcollector>().DestruirFruta();
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            
            velCaminar = velCaminar + incrementoVelocidad;
            other.gameObject.GetComponent<fruitcollector>().DestruirFruta();
        }

    }
}
