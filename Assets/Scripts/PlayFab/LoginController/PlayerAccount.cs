using UnityEngine;
using UnityEngine.UI;
using PlayFab; // get işlemi icin yazdık.
using PlayFab.ClientModels; // set işlemi icin yazdık.
using System;
using PlayFab.ProfilesModels;
using PlayFab.LocalizationModels;
using UnityEngine.SceneManagement;

public class PlayerAccount
{
    public string PlayerID { get; set; }
    public string DisplayName { get; set; }
    public string LoginUsername { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }


    #region Register
    public void Register()
    {
        RegisterPlayFabUserRequest _registerRequest = new RegisterPlayFabUserRequest() { Username = LoginUsername, Email = Email, Password = Password, DisplayName = DisplayName };

        PlayFabClientAPI.RegisterPlayFabUser(_registerRequest, RegisterSuccess, RegisterError);
    }

    private void RegisterError(PlayFabError obj)
    {
        Debug.LogError("Kayit Basarisiz");
    }

    private void RegisterSuccess(RegisterPlayFabUserResult obj)
    {
        Debug.Log("Kayit Basarili");
    }
    #endregion

    #region Login
    public void Login()
    {
        // Request: istek.
        //Result: Server durumları doner
        LoginWithPlayFabRequest _loginRequest = new LoginWithPlayFabRequest() { Username = LoginUsername, Password = Password };
        PlayFabClientAPI.LoginWithPlayFab(_loginRequest, LoginSucces, LoginError);
       
    }

    private void LoginError(PlayFabError obj)
    {
        Debug.LogError("Giris Basarisiz" + obj);
    }

    private void LoginSucces(LoginResult obj)
    {
        Debug.Log("Giris Basarili");
        SceneManager.LoadScene(2);
    }
    #endregion

    private void GetChechBanControl()
    {
        GetAccountInfoRequest _banRequest = new GetAccountInfoRequest();
        
        PlayFabClientAPI.GetAccountInfo(_banRequest, BanSuccess,BanError);
    }

    private void BanError(PlayFabError obj)
    {
          Debug.Log("Bana Erişemedim.. Başaramdım abi");
    }

    public void BanSuccess(GetAccountInfoResult obj)
    {
        if (obj.AccountInfo.TitleInfo.isBanned == false)
        {
            Debug.Log("Banli Degil");
        }
        else
        {
            Debug.Log("Banlii");
        }
    }
}
