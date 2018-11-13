using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderContainer : MonoBehaviour {


    public Slider IncomeSlider;
    public Slider GenderSlider;
    public Slider EducationSlider;
    public Slider ReligionSlider;

    public Text Educate;
    public Text Economy;
    public Text religion;
    public Text Gender;
    // Use this for initialization
    void Start () {

        PlayerGoals.Instance.Play();

        Educate.text = "" +PlayerGoals.Instance.MaxEducationEquality + "%";
        Economy.text = "" + PlayerGoals.Instance.MaxIncomeEquality + "%";
        religion.text = "" + PlayerGoals.Instance.MaxReligionEquality + "%";
        Gender.text = "" + PlayerGoals.Instance.MaxGenderEquality + "%";


        IncomeSlider.maxValue = 100;
        IncomeSlider.minValue = 0;
        IncomeSlider.value = PlayerGoals.Instance.MaxIncomeEquality;

        GenderSlider.maxValue = 100;
        GenderSlider.minValue = 0;
        GenderSlider.value = PlayerGoals.Instance.MaxGenderEquality;

        EducationSlider.maxValue = 100;
        EducationSlider.minValue = 0;
        EducationSlider.value = PlayerGoals.Instance.MaxEducationEquality;

        ReligionSlider.maxValue = 100;
        ReligionSlider.minValue = 0;
        ReligionSlider.value = PlayerGoals.Instance.MaxReligionEquality;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
