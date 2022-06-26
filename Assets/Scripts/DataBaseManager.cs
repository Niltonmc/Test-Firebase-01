using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using TMPro;
using UnityEngine.UI;
using Firebase.Extensions;

public class DataBaseManager : MonoBehaviour
{
    public TextMeshProUGUI debug;
    DatabaseReference reference;
    public bool nuevoUsuario;
    public bool loggeado;

    void Start()
    {
        nuevoUsuario = true;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update()
    {
        
    }

    public void createNewUser(UserData user) 
    {
        nuevoUsuario = true;
        reference.Child("User").GetValueAsync().ContinueWithOnMainThread( task => 
        {
            if (task.IsCompleted) 
            {
                DataSnapshot snapshot = task.Result;
                
                if (snapshot.Exists)
                {
                    foreach (var item in snapshot.Children)
                    {
                        if (user.name == item.Child("name").Value.ToString())
                        {
                            nuevoUsuario = false;


                            debug.text = "el usuario ya existe";
                            Debug.Log("el usuario ya existe");
                        }
                    }


                    if (nuevoUsuario)
                    {
                        string json = JsonUtility.ToJson(user);
                        reference.Child("User").Child(user.name).SetRawJsonValueAsync(json).ContinueWithOnMainThread(tarea =>
                        {
                            if (tarea.IsCompleted)
                            {
                                debug.text = "se completo el registro";
                                Debug.Log("se completo");
                            }
                            else
                            {
                                debug.text = "NO se completo el registro";
                                Debug.Log("NO se completo");
                            }
                        });
                    }
                }

                else 
                {

                }
            }
        });
    }


    public void loginUser(UserData user)
    {
        reference.Child("User").Child(user.name).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                if (snapshot.Exists)
                {
                    if (user.name == snapshot.Child("name").Value.ToString() && user.password == snapshot.Child("password").Value.ToString())
                    {
                        debug.text = "logeado, pase pls";
                        Debug.Log("logeado, pase pls");
                        loggeado = true;
                    }
                    else 
                    {
                        debug.text = "puso algo mal";
                        Debug.Log("puso algo mal");
                    }
                }
                else
                {
                    debug.text = "usuario no existe";
                    Debug.Log("usuario no existe");
                }
            }
        });
    }
    /*public void saveData() 
    {
        UserData user = new UserData();
        string json = JsonUtility.ToJson(user);


        reference.Child("User").Child(user.name).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("se completo");
            }
            else 
            {
                Debug.Log("NO se completo");
            }
        });
    }*/
}
