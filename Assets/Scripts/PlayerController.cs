using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameMenu;
    [SerializeField]
    private GameObject _loseMenu;


    private bool _onClick;
    private bool _moveOnStrat = false;
    private Vector2 screenHalfWidthInWorldUnits;
    private float _inputX = 0;
    private float _speed = 7;

    void Start()
    {
        screenHalfWidthInWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void FixedUpdate()
    {
        if (_moveOnStrat)
        {
            Debug.Log("move on start");
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
            if (transform.position.y < -screenHalfWidthInWorldUnits.y+2f)
            {
                _moveOnStrat = false;
            }
        }
        if (_onClick)
        {
            transform.Translate(Vector2.right * _inputX * _speed * Time.deltaTime);
            if(transform.position.x< -screenHalfWidthInWorldUnits.x)
            {
                transform.position = new Vector2(screenHalfWidthInWorldUnits.x, transform.position.y);
            }
            if(transform.position.x > screenHalfWidthInWorldUnits.x)
            {
                transform.position = new Vector2(-screenHalfWidthInWorldUnits.x, transform.position.y);
            }
        }
    }
    
    public void OnButtonDown()
    {
        _onClick = true;
    }
    public void OnButtonUp()
    {
        _inputX = 0;
        _onClick = false;
    }
    public void MoveOnStart()
    {
        _moveOnStrat = true;
    }

    public void InputChange(float x)
    {
        _inputX = x;
    }
    public void Lose()
    {
        _gameMenu.SetActive(false);
        InputChange(0);
        _loseMenu.SetActive(true);
        transform.position = new Vector3(0, 0, 0);
    }
}
