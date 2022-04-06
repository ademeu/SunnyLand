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
    [SerializeField] InputField _createDate, _playerInput;
    
    private void Awake()
    {
        GetPlayerInfo();
    }

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
      //  _playerID = obj.AccountInfo.PlayFabId;
    }

    public void SetPlayerInfo()
    {
        UpdateUserTitleDisplayNameRequest _request = new UpdateUserTitleDisplayNameRequest() { DisplayName = _playerInput.text };
        PlayFabClientAPI.UpdateUserTitleDisplayName(_request, SahneGecisSucces, Error);
    }

    private void SahneGecisSucces(UpdateUserTitleDisplayNameResult obj)
    {
        SceneManager.LoadScene(1);
    }
}

