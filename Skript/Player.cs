using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    [Header("Move Info")]
    [SerializeField] private  float speedX;
    [SerializeField] private  float speedY;

    [Header(" ")]
    [SerializeField] private float xMargin = 2;
    [SerializeField] private float yMargin = 2;
    [SerializeField] private float yYMargin = 2;
   
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //_rb.velocity = new Vector2(speed, _rb.velocity.y);
        _rb.velocity = new Vector2( speedX * Time.deltaTime, speedY * Time.deltaTime);
        float posX = transform.position.x;
        float posY = transform.position.z;
        posX = Mathf.Clamp(posX, -xMargin, xMargin);
        posY = Mathf.Clamp(posX, -yMargin, yYMargin);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }

    public void Move()
    {
        speedX *= -1;
      
        if (speedX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
        
        ScoreController.Instance.StartScript();
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("boost"))
        {
            Time.timeScale = 3;
            Speed();
            Destroy(other.gameObject);
        }
    }

    private void Speed()
    {
        StartCoroutine(StartBoost());
        
        IEnumerator StartBoost()
        {
            yield return new WaitForSeconds(5);
            Time.timeScale = 1;
        }
    }
    
}
