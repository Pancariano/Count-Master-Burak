using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using System.Reflection.Emit;

public class Gate : MonoBehaviour
{
    [SerializeField] private int[] addNumber = { 10, 20, 30, 50, 70 };
    [SerializeField] private int[] multiplyNumber = { 2, 3, 4 };
    [SerializeField] private bool isNumber;
    [SerializeField] private TextMeshPro gateText;

    public void Awake()
    {
        GenerateGateNumber();
    }

    public void GenerateGateNumber()
    {

        if (isNumber)
        {
            int AddRandomNumber()
            {
                return Random.Range(0, addNumber.Length - 1);       
            }
            gateText.text = addNumber[AddRandomNumber()].ToString();
        }

        else if (!isNumber) 
        {
            int MultiplyRandomNumber()
            {
                return Random.Range(0, multiplyNumber.Length - 1); 
               
            }
            gateText.text = "x" + multiplyNumber[MultiplyRandomNumber()].ToString();
        }
    }
}
