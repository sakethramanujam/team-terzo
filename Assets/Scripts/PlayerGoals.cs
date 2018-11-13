using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerGoals : MonoBehaviour {

    public int MaxIncomeEquality;
    public int MaxGenderEquality;
    public int MaxEducationEquality;
    public int MaxReligionEquality;



    public static PlayerGoals Instance ;

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

     

        MaxIncomeEquality = (int)Random.Range(70, 90);
        MaxGenderEquality = (int)Random.Range(70, 90);
        MaxReligionEquality = (int)Random.Range(70, 90);
        MaxEducationEquality = (int)Random.Range(70, 90);

      
    }

  

    public void Play()
    {
      
    }

}
