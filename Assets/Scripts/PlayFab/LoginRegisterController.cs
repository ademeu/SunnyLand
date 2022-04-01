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
    [SerializeField] public Text _resultText, _titleText, _orloginRegister;
    [SerializeField] Button _button;

    public void Login() =>   _loginRegisterBaseClass.LoginEmail(_emailInput, _passwordInput);
    public void Register() => _loginRegisterBaseClass.Register(_usernameInput, _emailInput, _passwordInput);

    public void SwitchPanel()
    {
        switch (_emailInput.gameObject.activeInHierarchy)
        {
            case true:
                //login panel
                _emailInput.gameObject.SetActive(false);
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(Login);
                _button.GetComponentInChildren<Text>().text = "Login";
                _orloginRegister.text = "Or Register";
                _titleText.text = "LOGIN";
                break;

            case false:
                //Register panel
                _emailInput.gameObject.SetActive(true);
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(Register);
                _button.GetComponentInChildren<Text>().text = "Register";
                _orloginRegister.text = "Or Login";
                _titleText.text = "REGISTER";
                break;
        }
    }
}
