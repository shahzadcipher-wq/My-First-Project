using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
