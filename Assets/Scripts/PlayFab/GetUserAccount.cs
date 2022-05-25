
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEditor.PackageManager;

public class GetUserAccount : MonoBehaviour
{
    [SerializeField] Text _username;
    void Awake()
    {
        GetMasterPlayerCall();
    }

    void GetMasterPlayerCall()
    {
        //GetPlayerProfileRequest _request = new GetPlayerProfileRequest();
        //PlayFabClientAPI.GetPlayerProfile(_request, Success, Error);

        //_request.ProfileConstraints.ShowLastLogin = true; // noktadan sonra showla baslayanlar true false donduruyor. onlarıda ekranda gosterbılıyoruz

        GetAccountInfoRequest _reqest = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(_reqest, Success, Error);
    }

    private void Error(PlayFabError obj)
    {
        Debug.Log("Veri cekilemedi");
        
    }

    private void Success(GetAccountInfoResult obj)
    {
        //Accountinfo dan title infoyu cekebılıyoruz. ama title infodan account ınfoya ulasamıyoruz.
        //AccountInfo.TitleInfo... gibi.
        _username.text = obj.AccountInfo.TitleInfo.DisplayName;
    }
}
