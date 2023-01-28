using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using System.Reflection.Emit;

public class Gate : MonoBehaviour
{
    public int[] addNumber = { 5, 10, 15 ,20};
    public int[] multiplyNumber = { 2, 3 };
    public bool isNumber;
    [SerializeField] private TextMeshPro gateText;

    public void Awake()
    {
        GenerateGateNumber();
    }

    public void GenerateGateNumber()
    {
        if (isNumber)
        {
            AddRandomNumber();          
            gateText.text = addNumber[AddRandomNumber()].ToString();
        }

        else if (!isNumber) 
        {
            MultiplyRandomNumber();
            gateText.text = "x" + multiplyNumber[MultiplyRandomNumber()].ToString();
        }
    }

    public int AddRandomNumber()
    {
        return Random.Range(0, addNumber.Length - 1);
    }

    public int MultiplyRandomNumber()
    {
        return Random.Range(0, multiplyNumber.Length - 1);
    }
}
