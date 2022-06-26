using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Coin prefabCoin;
    public List<Coin> pool;
    public Vector2 posRandom;

    private void Start()
    {
        prefabCoin.incubadora = FindObjectOfType<Incubadora>();
    }
    public void fullStartPool(int cantidadInicial)
    {
        Coin tmp;
        for (int i = 0; i < cantidadInicial; i++)
        {
            tmp = Instantiate(prefabCoin, this.transform.position + new Vector3(Random.Range(posRandom.x,posRandom.y),0,0) , this.transform.rotation);
            pool.Add(tmp);
            tmp.setObjectPool(this);
            tmp.transform.SetParent(this.transform);
            tmp.gameObject.SetActive(false);
        }
    }

    public void guardarCoin(Coin coin) 
    {
        coin.gameObject.SetActive(false);
        coin.transform.position = this.transform.position;
        pool.Add(coin);
    }
    public void getObject()
    {
        Coin tmp;

        if (pool.Count == 0)
        {
            tmp = Instantiate(prefabCoin, this.transform.position + new Vector3(Random.Range(posRandom.x, posRandom.y), 0, 0), this.transform.rotation);
            tmp.transform.SetParent(this.transform);
            tmp.setObjectPool(this);
            tmp.gameObject.SetActive(true);
        }
        else
        {
            tmp = pool[0];
            tmp.transform.position = this.transform.position + new Vector3(Random.Range(posRandom.x, posRandom.y),0,0);
            pool.Remove(tmp);
            tmp.gameObject.SetActive(true);
        }
    }
}
