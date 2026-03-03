namespace MovementWithMouseBasedTargetRotationExample
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {   
        [Header("Movement")]
        [SerializeField] float speed = 10;
        private Rigidbody2D rb;
        private float verticalInput;
        private Vector2 mousePos;
        [Header("Shooting")]
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private Transform mouseReticle;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            verticalInput = Input.GetAxisRaw("Vertical");

            // Mouse Position in world space
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Update mouse reticle position
            mouseReticle.position = mousePos;
            Shooting();

        }

        void FixedUpdate()
        {
            //Rotate toward target
            Vector2 direction = mousePos - rb.position;

            if (direction.magnitude > 0.5f)
            {
                float angle = Vector2.SignedAngle(Vector2.up, direction);

                rb.rotation = angle;

                //Move Forward
                Vector2 forward = transform.up;
                rb.MovePosition(rb.position + forward * verticalInput * speed * Time.fixedDeltaTime);
            }
        }

        private void Shooting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(laserPrefab, transform.position, transform.rotation);
            }
        }
    }
}