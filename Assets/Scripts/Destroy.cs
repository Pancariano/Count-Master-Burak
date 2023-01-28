using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public GameObject[] childObjects;

    void OnTriggerEnter(Collider other)
    {
        // Get the child objects
        childObjects = GetChildObjects();

        // Destroy the child objects
        foreach (GameObject child in childObjects)
        {
            Destroy(child);
        }
    }

    GameObject[] GetChildObjects()
    {
        GameObject[] childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
        }

        return childObjects;
    }

}