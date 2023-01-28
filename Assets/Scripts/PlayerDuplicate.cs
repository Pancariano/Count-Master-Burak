using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDuplicate : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public Transform player;
    private int childNumber;
    [SerializeField] public TextMeshPro childNumberText;
    private Gate gate;

    void Start()
    {
        childNumber = transform.childCount;
        childNumberText.text = childNumber.ToString();


    }
    void Update()
    {
        
    }

    private void NumberToCreateChild(int childNumberToCreate)
    {
        for (int i =0; i<childNumberToCreate; i++)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity, transform);
        }
        childNumber = transform.childCount;
        childNumberText.text= childNumber.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("gate"))
        {
            gate = other.GetComponent<Gate>();

            if (gate.isNumber)
            {
                NumberToCreateChild(childNumber * gate.addNumber[gate.AddRandomNumber()]);
            }

            if (!gate.isNumber)
            {
                NumberToCreateChild(childNumber * gate.multiplyNumber[gate.MultiplyRandomNumber()]);
            }
        }
    }
}
