using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDuplicate : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public Transform player;
    private int childNumber;
    public TextMeshPro childNumberText;

    [SerializeField] float minR = 0.5f;
    [SerializeField] float maxR = 3.5f;

    void Start()
    {
        player = transform;
        childNumber = transform.childCount-1;
        childNumberText.text = childNumber.ToString();
    }

    private void CreateChild(int childNumberToCreate)
    {
        for (int i = 0; i<childNumberToCreate; i++)
        {
            float angle = i * Mathf.PI * 2 / childNumberToCreate;
            float x = Mathf.Cos(angle) * Random.Range(minR, maxR);
            float z = Mathf.Sin(angle) * Random.Range(0.5f, maxR);
            Vector3 randomVec1 = new(x, 0, z);
            Instantiate(playerPrefab, transform.position+ randomVec1, Quaternion.identity, transform);
        }
        childNumber = transform.childCount -1;
        childNumberText.text= childNumber.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("gate"))
        {
            other.transform.parent.GetChild(0).GetComponent <BoxCollider>().enabled = false;
            other.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false;
            

            var gate = other.GetComponent<Gate>();

            if (gate.isNumber)
            {
                CreateChild(childNumber + gate.addNumber[gate.AddRandomNumber()]);
            }

            else if (gate.isNumber == false)
            {
                CreateChild(childNumber * gate.multiplyNumber[gate.MultiplyRandomNumber()]);
            }
        }
    }
}