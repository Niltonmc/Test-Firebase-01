using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonSend : MonoBehaviour
{
    public DataBaseManager dataBase;
    public TMP_InputField name_;
    public TMP_InputField password_;

    public UserData user;
    public void register() 
    {
        user = new UserData(this.name_.text, this.password_.text);
        dataBase.createNewUser(this.user);
    }

    public void login() 
    {
        user = new UserData(this.name_.text, this.password_.text);

        dataBase.loginUser(this.user);
    }

    private void Update()
    {
        if (dataBase.loggeado) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            dataBase.loggeado = false;
        }
    }

}
