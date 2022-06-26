using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public DataBaseManager dataBase;

    public void startGameButton() 
    {
        if (dataBase.loggeado == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            Debug.Log("Usted aun no se ha loggeado");
        }
    }
}
