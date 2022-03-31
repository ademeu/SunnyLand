using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance { get; private set; }

    public int _score;
    public static Func<int> ReturnScore;
    public static Action<int> AddScore;


    public int _kurbagScore;
    public static Action<int> AddKScore;

    [SerializeField] Text kurbagaSayac;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else if (_instance != this)
        {
            Destroy(_instance);
        }
    }
    private void OnEnable()
    {
        ReturnScore += Score; // �ilek scoru
        AddScore += Score;  // �ilek scoru

        AddKScore += KurbagScore; // kurbag scoru
    }
    private void OnDisable()
    {
        ReturnScore -= Score; // �ilek scoru
        AddScore -= Score;  // �ilek scoru
    }
        
    int Score() // �ilek scoru
    {
        return _score;
    }
    void Score(int score) // �ilek scoru
    { 
         _score += score;
    }

    void KurbagScore(int kscore) // kurbag scoru
    {
        _kurbagScore += kscore;
        kurbagaSayac.text = _kurbagScore.ToString();
    }
}
