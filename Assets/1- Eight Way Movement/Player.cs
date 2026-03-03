namespace EightWayMovementExample
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private int speed = 5;

        private Vector2 direction;
        private Rigidbody2D rb;
        
        [Header("Shooting")]
        [SerializeField] private GameObject laserPrefab;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            Shooting();
        }

        private void Movement()
        {
            float directionY = Input.GetAxisRaw("Vertical");
            float directionX = Input.GetAxisRaw("Horizontal");
            direction = new Vector3(directionX, directionY, 0);

            // Normalize to prevent faster diagonal movement
            direction = direction.normalized;
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }

        private void Shooting()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(laserPrefab, transform.position, transform.rotation);
            }
        }
    }
}
