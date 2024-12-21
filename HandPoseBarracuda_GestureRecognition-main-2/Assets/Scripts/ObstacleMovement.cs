using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Vector3 moveDirection = new Vector3(1f, 0, 0);
    [SerializeField]
    private float moveDistance = 0.8f;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _tempPos;

    void Awake()
    {
        _startPos = transform.position;
        _endPos = transform.position + moveDirection * moveDistance;
    }

    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        
    }

    IEnumerator Move()
    {
        float distance = Vector3.Distance(_startPos, _endPos);
        float remainingDistance = distance;

        while(remainingDistance > 0)
        {
            transform.position = Vector3.Lerp(_startPos, _endPos, 1 - (remainingDistance / distance));
            remainingDistance -= moveSpeed * Time.deltaTime;
            yield return null;
        }

        _tempPos = _startPos;
        _startPos = _endPos;
        _endPos = _tempPos;

        StartCoroutine(Move());
    }


}
