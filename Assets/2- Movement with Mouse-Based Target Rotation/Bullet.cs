namespace MovementWithMouseBasedTargetRotationExample
{
    using UnityEngine;
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [Header("Movement")]
        private Rigidbody2D rb;
        [SerializeField] private float speed = 20;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, 4f);
        }

        // Update is called once per frame
        void Update()
        {
            //transform.Translate(Vector3.up * 100 * Time.deltaTime);
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.fixedDeltaTime);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}

