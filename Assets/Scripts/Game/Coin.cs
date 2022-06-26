using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Incubadora incubadora;
    public ObjectPool poolReference;
    public Rigidbody2D rb;

    private void Start()
    {
        incubadora = FindObjectOfType<Incubadora>();
    }
    public void setObjectPool(ObjectPool op) 
    {
        poolReference = op;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Incubadora"))
        {
            incubadora.entroCoin();
            poolReference.guardarCoin(this);
        }

        if (collision.gameObject.CompareTag("Suelo"))
        {
            poolReference.guardarCoin(this);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("anahnashei");
        incubadora.entroCoin();
        poolReference.guardarCoin(this);
    }
}
