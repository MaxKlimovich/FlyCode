using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Bird : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Animator _animator;
    [SerializeField] private Spawner _spawner;

    private int _score;
    private int _heart;
    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _heartTxt;
    private Rigidbody2D _rigidbody2D;
    
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _rigidbody2D.gravityScale = 0;
    }
    
    void Update()
    {
        Fly();
    }

    private void Fly()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_rigidbody2D.gravityScale == 0)
            {
                _rigidbody2D.gravityScale = 1f;
                StartCoroutine(_spawner.Spawn());
                StartCoroutine(_spawner.HeartSpawn());
            }
            _rigidbody2D.velocity = Vector2.up * _force;
            _animator.Play("Fly");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            _score++;
            _scoreTxt.text = _score.ToString();
        }
        if (collision.CompareTag("Heart"))
        {
            _heart++;
            _heartTxt.text = _heart.ToString();
        }
        if (collision.CompareTag("Pipe"))
        {
            _heart--;
            _heartTxt.text = _heart.ToString();
            if (_heart < 0)
            {
                SceneManager.LoadScene(0); 
            }
        }
        if (collision.CompareTag("Space"))
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
