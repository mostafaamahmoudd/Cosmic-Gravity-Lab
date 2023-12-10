using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 2000f;
    [SerializeField] private float sideSpeed = 100f;
    [SerializeField] private float jumpForce = 5f;

    private float horizontalInput;
    //private float forwardInput;

    [SerializeField] private bool isOnGround = true;

    private PlayerMovement1 Movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);

        // get player input
        horizontalInput = Input.GetAxis("Horizontal"); // return a value between 1 and -1
        //forwardInput = Input.GetAxis("Vertical");      // return a value between 1 and -1

        // move player
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * sideSpeed * horizontalInput);

        // let player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;
        }

        if (transform.position.y <= 0)
        {
            Movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
