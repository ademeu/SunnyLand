using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class SettingsController : MonoBehaviour
{
    [SerializeField] InputField _createDate, _playerInput, _playerId;
    
    private void Awake()
    {
        GetPlayerInfo();
    }

    #region Playfab'den bir şeyler çekıyoz
    void GetPlayerInfo()
    {
        GetAccountInfoRequest _request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(_request, Success, Error);
    }
    private void Error(PlayFabError obj)
    {
        Debug.Log(obj);
    }

    private void Success(GetAccountInfoResult obj)
    {
        _createDate.text = obj.AccountInfo.Created.Date.ToString();
        _playerInput.text = obj.AccountInfo.TitleInfo.DisplayName;
        _playerId.text = obj.AccountInfo.PlayFabId;
    } 
    #endregion

    #region Display ismi degistiren button
    private void SetPlayerInfo()
    {
        UpdateUserTitleDisplayNameRequest _request = new UpdateUserTitleDisplayNameRequest() { DisplayName = _playerInput.text };
        PlayFabClientAPI.UpdateUserTitleDisplayName(_request, SahneGecisSucces, Error);
    } 
   

    private void SahneGecisSucces(UpdateUserTitleDisplayNameResult obj)
    {
        SceneManager.LoadScene(1);
    }
    #endregion
}

