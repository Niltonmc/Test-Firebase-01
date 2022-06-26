using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public string name;
    public string password;

    public UserData()
    {

    }
    public UserData(string name, string password) 
    {
        this.name = name;
        this.password = password;
    }
}
