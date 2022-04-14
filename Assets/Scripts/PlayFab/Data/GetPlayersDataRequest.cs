using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class GetPlayersDataRequest : MonoBehaviour
{
    private void Awake()
    {
        GetPlayerData();
    }

    void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(),
        result =>
        {
            if (result.Data == null)
            {
                PlayersDataCall();
            }
        },
        error =>
        {
            Debug.Log("------ özlelıkler eklenemedi");
        });
        
    }
    void PlayersDataCall()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
               
                Data = new Dictionary<string, string>() {{"hp" , "100"}, {"mp", "100"} }  // pleyerın canını felan otamatık ekledi.
            },
            result =>
            {
                Debug.Log("özellikler eklendi");
            },
            error =>
            {
                Debug.Log("********özlelıkler eklenemedi");
            });
    }
}
