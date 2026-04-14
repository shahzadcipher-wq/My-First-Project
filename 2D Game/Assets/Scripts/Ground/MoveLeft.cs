using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    void Update()
    {
        if(GameManager.Instance.isGameOver)
        {
            return;
        }
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
