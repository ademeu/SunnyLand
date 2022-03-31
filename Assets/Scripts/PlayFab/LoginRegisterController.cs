using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LoginRegisterController : MonoBehaviour
{
    LoginRegister _loginRegisterBaseClass = new LoginRegister();
    [SerializeField] InputField _usernameInput, _emailInput, _passwordInput;
    [SerializeField] Text _resultText,  _titleText, _loginRegisterButtonText;
    [SerializeField] Button registerOrLoginBtn;

    public void Login() => _loginRegisterBaseClass.LoginEmail(_emailInput, _passwordInput);

    public void Register() => _loginRegisterBaseClass.Register(_usernameInput, _passwordInput, _emailInput);

    public void SwitchPanel()
    {
        switch (_usernameInput.gameObject.activeInHierarchy)
        {
            case true:
                //login panel
                _usernameInput.gameObject.SetActive(false);
                registerOrLoginBtn.onClick.RemoveAllListeners();
                registerOrLoginBtn.onClick.AddListener(Login);
                registerOrLoginBtn.GetComponentInChildren<Text>().text = "Login";
                _titleText.text = "LOGIN PANEL";
                _loginRegisterButtonText.text = "Or Register";

                break;
            case false:
                //Register panel
                _usernameInput.gameObject.SetActive(true);
                registerOrLoginBtn.onClick.RemoveAllListeners();
                registerOrLoginBtn.onClick.AddListener(Register);
                registerOrLoginBtn.GetComponentInChildren<Text>().text = "Register";
                _titleText.text = "REGISTER PANEL";
                _loginRegisterButtonText.text = "Or Login";

                break;
        }
    }

}
