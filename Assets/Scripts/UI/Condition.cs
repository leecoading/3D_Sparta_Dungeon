using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float startValue; //UI Conditions(ü��,���׹̳� �� ���� ��)
    public float passiveValue; // �ֱ������� ���ϴ� �� = ���� �ð����� ���� ���� ���ϰ� ��.
                               // -�� �ϸ� currentValue�� ���������� �����ϰ�
                               //+�� �ϸ� currentValue�� ���������� ����.

    public float currentValue; // ���� ü�°� ���׹̳� ���� ��
    public float maxValue; // ü�°� ���׹̳ʵ� UI�� �ö� �� �ִ� �ִ� ��
    private float minValue; // �ּ� ��

    public Image uiBar; //ü�°� ���׹̳ʹ��� FillAmount��(������ ������ ��)�� ������ ����

    private void Start()
    {
        currentValue = startValue; // ���� ui�� ���� �����ϴ� ���̴�.
    }


    private void Update()
    {
        uiBar.fillAmount = UIPercentage(); // ui���� ü�°� ���׹̳� ���� fillamount����
                                           // ���簪 / �ִ밪�̴�.
    }


    float UIPercentage() //Current value�� maxValue�� ������ 0~1������ ���� ���� �� ����.
                         //0 ~ 1���̸� ���ϴ� ������ image�� fillamount���� 1�� �ִ��̱� ����.
    {
        return currentValue / maxValue;
    }


    public void Add(float value)
    {
        //�ܺο��� add �޼��带 ȣ���ϸ� ���簪�� �����ְ� ���� ���� �����ְ�
        //Add + �Ű����� ��ġ�� ���� ������ ���簪(currentValue)�� ��������.

        currentValue = Mathf.Min(currentValue + value, maxValue);
        //���簪 = ���簪 + Add �Ű������� �Է¹����� vs �ִ밪 �� ���� ���� ����.
        //���� ��� ���� ���� 90�̰� �Ű������� �Է� ���� ���� 20�̸� 110�ε�, �ִ밪��
        //100�̶�� �ִ밪�� 100�� �����ϰ� ��.

    }


    public void Subtract(float value) //Subtract�� ������ ���̴�.
    {
        currentValue -= Mathf.Max(currentValue + value, minValue);
    }
}
