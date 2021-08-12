using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;

    float moveForce;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveForce = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * moveForce * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Obstacle>())
        {
            GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>(); //TODO: <---- !!!!!!!!!!!!!!!
            gm.EndGame();

            Debug.Log("Player bumped");
        }
    }

}
