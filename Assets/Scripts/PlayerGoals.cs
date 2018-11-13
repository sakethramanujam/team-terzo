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

    public Slider IncomeSlider;
    public Slider GenderSlider;
    public Slider EducationSlider;
    public Slider ReligionSlider;

    public Text Educate;
    public Text Economy;
    public Text religion;
    public Text Gender;

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

       StartCoroutine( Loadscene());

        MaxIncomeEquality = (int)Random.Range(70, 90);
        MaxGenderEquality = (int)Random.Range(70, 90);
        MaxReligionEquality = (int)Random.Range(70, 90);
        MaxEducationEquality = (int)Random.Range(70, 90);

        Educate.text = "" + MaxEducationEquality+"%";
        Economy.text = "" + MaxIncomeEquality + "%";
        religion.text = "" + MaxReligionEquality + "%";
        Gender.text = "" + MaxGenderEquality + "%";


        IncomeSlider.maxValue = 100;
        IncomeSlider.minValue = 0;
        IncomeSlider.value = MaxIncomeEquality;

        GenderSlider.maxValue = 100;
        GenderSlider.minValue = 0;
        GenderSlider.value = MaxGenderEquality;

        EducationSlider.maxValue = 100;
        EducationSlider.minValue = 0;
        EducationSlider.value = MaxEducationEquality;

        ReligionSlider.maxValue = 100;
        ReligionSlider.minValue = 0;
        ReligionSlider.value = MaxReligionEquality;

    }

    IEnumerator Loadscene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Game");
    }

}
