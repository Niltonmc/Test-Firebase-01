using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public struct DragonSelector 
{
    public int index;
    public bool hechizados;
    public bool baby;
}
public class Grow : MonoBehaviour
{
    public Notification notificationReference;
    public Incubadora incubadora;

    public bool canGetOtherDragon;
    public float contadorPorDragon;
    public float coolDown;
    public TextMeshProUGUI textContador;



    public DragonSelector currentDragon;
    public int maxCoinsParaDragon;

    public List<Sprite> huevosNormales;
    public List<Sprite> adultosNormales; 

    public List<Sprite> huevosHechizados;
    public List<Sprite> adultosHechizados;

    private void Start()
    {
        currentDragon.index = 0;
        canGetOtherDragon = true;
        contadorPorDragon = coolDown;
        textContador.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!canGetOtherDragon) 
        {
            contadorPorDragon -= Time.deltaTime;
            textContador.text = "TIME: " + ((int)contadorPorDragon).ToString();
            if (contadorPorDragon < 0) 
            {
                currentDragon.baby = false;
                selectSprite();
                canGetOtherDragon = true;
                contadorPorDragon = coolDown;
                textContador.gameObject.SetActive(false);

                notificationReference.sendNotification();
            }
        }
    }
    public void getRandomEggAndDragon() 
    {
        int numeroRandom = Random.Range(0, 100);
        if (numeroRandom < 21)
        {
            currentDragon.index = Random.Range(0, huevosNormales.Count - 1);
            currentDragon.hechizados = true;
            currentDragon.baby = true;

        }
        else
        {
            currentDragon.index = Random.Range(0, huevosNormales.Count - 1);
            currentDragon.hechizados = false;
            currentDragon.baby = true;
        }

        textContador.gameObject.SetActive(true);
        canGetOtherDragon = false;
    }

    public void getDragon() 
    {
        if (incubadora.contador >= maxCoinsParaDragon && canGetOtherDragon)
        {
            getRandomEggAndDragon();
            incubadora.contador -= maxCoinsParaDragon;
            incubadora.coins.text = "Coins: " + incubadora.contador.ToString();
            selectSprite();
        }

        else 
        {
            Debug.Log("no tienes sufucientes monedas o esta incubando");
        }
    }

    public void selectSprite() 
    {
        if (currentDragon.hechizados)
        {
            if (currentDragon.baby)
            {
                incubadora.dragon.sprite = huevosHechizados[currentDragon.index];
            }
            else 
            {
                incubadora.dragon.sprite = adultosHechizados[currentDragon.index];
            }
            
        }
        else
        {
            if (currentDragon.baby)
            {
                incubadora.dragon.sprite = huevosNormales[currentDragon.index];
            }
            else
            {
                incubadora.dragon.sprite = adultosNormales[currentDragon.index];
            }
        }
    }
}
