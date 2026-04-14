using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    public bool isAlive=true;


    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isAlive ==false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true || Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        } 

        if(collision.gameObject.CompareTag("Hurdle"))
        {
            isAlive = false;
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
