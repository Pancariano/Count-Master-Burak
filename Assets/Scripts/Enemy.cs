using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float minR = 0.5f;
    [SerializeField] float maxR = 3.5f;
    public TextMeshPro enemeyNumberText;
    [SerializeField] private GameObject enemy;
    private Transform player;
    

    // Start is called before the first frame update

    private void Awake()
    {
        SpawnEnemy();
    }
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        for(int i =0; i < Random.Range(10,50); i++)
        {
            {
                float angle = i * Mathf.PI * 2 / Random.Range(10,50);
                float x = Mathf.Cos(angle) * Random.Range(minR, maxR);
                float z = Mathf.Sin(angle) * Random.Range(0.5f, maxR);
                Vector3 randomVec1 = new(x, 0, z);
                Instantiate(enemy, transform.position+randomVec1, transform.rotation, transform);
                transform.LookAt(player);
            }

            enemeyNumberText.text = (transform.childCount - 1).ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
