using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float startValue; //UI Conditions(체력,스테미너 등 시작 값)
    public float passiveValue; // 주기적으로 변하는 값 = 일정 시간마다 현재 값을 변하게 함.
                               // -로 하면 currentValue가 지속적으로 감소하고
                               //+로 하면 currentValue가 지속적으로 증가.

    public float currentValue; // 현재 체력과 스테미너 등의 값
    public float maxValue; // 체력과 스테미너등 UI가 올라갈 수 있는 최대 값
    private float minValue; // 최소 값

    public Image uiBar; //체력과 스테미너바의 FillAmount값(오르고 내리는 값)을 조절할 변수

    private void Start()
    {
        currentValue = startValue; // 현재 ui의 값은 시작하는 값이다.
    }


    private void Update()
    {
        uiBar.fillAmount = UIPercentage(); // ui에서 체력과 스테미너 바의 fillamount값은
                                           // 현재값 / 최대값이다.
    }


    float UIPercentage() //Current value를 maxValue로 나누면 0~1사이의 값을 구할 수 있음.
                         //0 ~ 1사이를 구하는 이유는 image에 fillamount값이 1이 최대이기 때문.
    {
        return currentValue / maxValue;
    }


    public void Add(float value)
    {
        //외부에서 add 메서드를 호출하면 현재값에 더해주고 싶은 값을 더해주게
        //Add + 매개변수 위치에 값을 넣으면 현재값(currentValue)에 더해진다.

        currentValue = Mathf.Min(currentValue + value, maxValue);
        //현재값 = 현재값 + Add 매개변수에 입력받은값 vs 최대값 중 낮은 값을 선택.
        //예를 들어 현재 값이 90이고 매개변수에 입력 받은 값이 20이면 110인데, 최대값이
        //100이라면 최대값인 100을 선택하게 됨.

    }


    public void Subtract(float value) //Subtract는 빼기라는 뜻이다.
    {
        currentValue -= Mathf.Max(currentValue + value, minValue);
    }
}
