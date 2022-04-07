using UnityEngine;
using UnityEngine.UI;
using PlayFab; // get işlemi icin yazdık.
using PlayFab.ClientModels; // set işlemi icin yazdık.
using System;
using PlayFab.ProfilesModels;
using PlayFab.LocalizationModels;
using UnityEditor.PackageManager;
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
        
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest() {Username = LoginUsername, Email = Email, Password = Password, DisplayName = DisplayName },
            resault =>
            {
                Debug.Log("Kayit Basarili");
            },
            error =>
            {
                Debug.LogError("Kayit Basarisiz");
            });
    }
    #endregion

    #region Login
    public void Login()
    {
        // Request: istek.
        //Result: Server durumları doner
        //LoginWithPlayFabRequest _loginRequest = new LoginWithPlayFabRequest() { Username = LoginUsername, Password = Password };
        //PlayFabClientAPI.LoginWithPlayFab(_loginRequest, LoginSucces, LoginError);

        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest() {Username = LoginUsername, Password = Password }, 
            resault => 
            {
                Debug.Log("Giris Basarili");
                SceneManager.LoadScene(2);
            }, 
            Error => 
            {
                if (Error.Error == PlayFabErrorCode.AccountBanned)
                {
                    foreach (var item in Error.ErrorDetails)
                    {
                        Debug.Log("Ban nedeni: " + item.Key + "\n" + "Ban süresi" + item.Value[0]);
                    }
                    
                }
            });
       
    }
    #endregion

    #region Ban Chechk
    private void GetChechBanControl()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(),
            Succes =>
            {
                if (Succes.AccountInfo.TitleInfo.isBanned == false)
                {
                    Debug.Log("Banli Degil");
                }
                else
                {
                    Debug.Log("Banlii");
                }
            },
            Error =>
            {
                Debug.Log("Bana Erişemedim.. Başaramdım abi");
            });
    }
    #endregion
}
