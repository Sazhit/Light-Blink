using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamping : MonoBehaviour
{
    [SerializeField] float right;
    [SerializeField] float left;
    [SerializeField ]float up;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * right, ForceMode2D.Impulse);
            //col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * left, ForceMode2D.Impulse);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * up, ForceMode2D.Impulse);
            StartCoroutine(Animka());
            IEnumerator Animka()
            {
                yield return new WaitForSeconds(0.1f);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * left, ForceMode2D.Impulse);
            }
        }

     
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * right, ForceMode2D.Impulse);
    //        col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * left, ForceMode2D.Impulse);
    //        col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * up, ForceMode2D.Impulse);
    //    }
    //}
}
