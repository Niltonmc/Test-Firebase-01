using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Incubadora : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public ObjectPool objectPool;
    public int contador;

    public SpriteRenderer dragon;
    void Start()
    {
        objectPool.fullStartPool(2);

        StartCoroutine(getCoin());
    }

    public void entroCoin()
    {
        contador++;
        coins.text = "Coins: " + contador.ToString();
    }

    IEnumerator getCoin() 
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            objectPool.getObject();
        }

    }
    
}
