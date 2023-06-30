using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public                   SpriteRenderer SpriteRenderer;
    private                  Rigidbody2D    _rb2D;
    [SerializeField] private float          jumpForceFirstClick;
    [SerializeField] private float          jumpForceSecondClick;

    [SerializeField] private float          clickResetTime = 0.5f;
    private                  bool           _isFirstClick;
    private                  float          _elapsedTime = 0f;
    private                  SpriteRenderer _spriteRenderer;
    public                   bool           IsGameStarted = false;

    public static Action PlayerTouchObstacle;

    public void StartGame()
    {
        IsGameStarted      = true;
        _rb2D.gravityScale = 1f;
        _rb2D.velocity     = Vector3.zero;
    }

    public void StopGame()
    {
        _rb2D.gravityScale = 0f;
        _rb2D.velocity     = Vector3.zero;
        IsGameStarted      = false;
    }

    private void OnEnable()
    {
        _rb2D          = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsGameStarted)
        {
            _elapsedTime = 0;
            if (_isFirstClick)
            {
                _isFirstClick  = false;
                _rb2D.velocity = new Vector3(0, 1f, 0f) * jumpForceFirstClick;
            }
            else
            {
                _rb2D.velocity = new Vector3(0, 1f, 0f) * jumpForceSecondClick;
            }
        }

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > clickResetTime)
        {
            _isFirstClick = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            StopGame();
            PlayerTouchObstacle?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("ScoreCollider"))
        {
            GameManager.UpdateScore?.Invoke();
        }
    }

    public void ResetPosition()
    {
        transform.position = Vector3.left * 1.35f;
    }
}