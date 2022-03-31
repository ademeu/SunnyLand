using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LoginRegister
{



    public void Register(InputField _username, InputField _password, InputField _email)
    {
        RegisterPlayFabUserRequest _register = new RegisterPlayFabUserRequest()
        {
            Username = _username.text,
            Email = _email.text,
            Password = _password.text            
        };

        PlayFabClientAPI.RegisterPlayFabUser(_register, RegisterSuccess, RegisterError);
    }

    private void RegisterError(PlayFabError obj)
    {
        
    }

    private void RegisterSuccess(RegisterPlayFabUserResult obj)
    {
        
    }

    public void LoginEmail(InputField _email, InputField _password)
    {
        LoginWithEmailAddressRequest _loginEmail = new LoginWithEmailAddressRequest() { Email = _email.text, Password = _password.text };

        PlayFabClientAPI.LoginWithEmailAddress(_loginEmail, LoginSuccess, LoginError);
    }

    public void LoginUsername(InputField _username, InputField _password)
    {
        LoginWithPlayFabRequest _loginUsername = new LoginWithPlayFabRequest() { Username = _username.text, Password = _password.text };

        PlayFabClientAPI.LoginWithPlayFab(_loginUsername, LoginSuccess, LoginError);
    }

    private void LoginError(PlayFabError obj)
    {

    }

    private void LoginSuccess(LoginResult obj)
    {
        SceneManager.LoadScene(1);
    }

    public void Register()
    {

    }
}
