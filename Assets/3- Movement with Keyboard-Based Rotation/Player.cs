namespace MovementWithKeyboardBasedRotationExample
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed = 10;
        [SerializeField] private float rotationSpeed = 250;
        private float zRotation = 0;
        
        [Header("Shooting")]
        [SerializeField] GameObject laserPrefab;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            Shooting();
        }

        private void Movement()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Rotate
            zRotation += horizontalInput * rotationSpeed * Time.deltaTime * -1;
            transform.eulerAngles = new Vector3(0, 0, zRotation);

            // Move Forward/Back
            transform.Translate(Vector3.up * verticalInput * movementSpeed * Time.deltaTime);
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
