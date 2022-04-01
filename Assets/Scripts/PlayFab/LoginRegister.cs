using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginRegister 
{
    public void Register(InputField _username, InputField _email, InputField _password)
    {
        var a = _username.text + " " + _email.text + " " + _password.text;
        Debug.Log(a);

        RegisterPlayFabUserRequest _register = new RegisterPlayFabUserRequest() { Username = _username.text, Email = _email.text, Password = _password.text};
        PlayFabClientAPI.RegisterPlayFabUser(_register, RegisterSuccess, RegisterError);
    }
    private void RegisterError(PlayFabError obj)
    {
        Debug.Log("Kayıt Yapılamadı" + obj);
    }
    private void RegisterSuccess(RegisterPlayFabUserResult obj)
    {
        Debug.Log("Kayit Basarili");
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
        Debug.Log("Login giris Yapimadi");
    }

    private void LoginSuccess(LoginResult obj)
    {
        Debug.Log("Başarili Giris Yapiliyor..");
        SceneManager.LoadScene(1);
    }
}
