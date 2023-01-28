using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float verticalSpeed = 9f;
    [SerializeField] private float horizontalSpeed = 8f;
    private int border = 4;
    private Animator anim;
    private bool isStart;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        isStart = true;
    }


    void Update()
    {
        Move();
        AnimationChanger();
    }

    private void AnimationChanger()
    {
        if (isStart)
            anim.SetBool("isStart", true);
    }

    private void Move()
    {
        transform.Translate(Time.deltaTime * verticalSpeed * Vector3.forward);

        if (Input.GetKey(KeyCode.A) && transform.position.x > -border)
        {
            transform.Translate(Time.deltaTime * horizontalSpeed * Vector3.left);
        }

        else if (Input.GetKey(KeyCode.D) && transform.position.x < border)
        {
            transform.Translate(Time.deltaTime * horizontalSpeed * Vector3.right);
        }
    }
}