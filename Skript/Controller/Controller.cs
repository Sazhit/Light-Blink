using UnityEngine;

public class Controller : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;

    [SerializeField] private float Speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        int dirx = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Application.isEditor)
        {
            if (Input.GetKey(KeyCode.D))
            {
                dirx = 1;
                transform.rotation = Quaternion.Euler(0, 0, -30);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                dirx = -1;
                transform.rotation = Quaternion.Euler(0, 0, 30);
            }
        }
        else
        {
            if (Input.touches.Length > 0)
            {
                Vector3 touchPosition = Input.touches[0].position;
                touchPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                if (touchPosition.x > 0)
                {
                    dirx = 1;
                }
                else
                {
                    dirx = -1;
                }
            } 
        }

        rb.velocity = new Vector2(dirx * Speed * Time.deltaTime, 0);
        Time.timeScale = 1;
    }

   
}