using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// 블록이 움직일 패턴 표현하기위해 Enum사용
public enum Position
{
    X_Block, Y_Block
}

public class BoxMove : MonoBehaviour
{
    public Position Position; // 블록의 위치에 대한 표현
    public bool flipx; // x축 방향 반전

    [Range(1, 5)] public float speed; // 블록 속도
    public float length = 0.0f; // 블록 이동 범위(+, -)

    private float run_time = 0.0f; // 업데이트에서 체크할 시간 수치
    private float Pos = 0.0f; // 위치

    void Update()
    {
        // 블록이 가진 포지션에 따라 로직을 각각 처리하도록 설계
        switch (Position)
        {
            case Position.X_Block:
                MoveX();
                break;
            case Position.Y_Block:
                MoveY();
                break;
        }
    }

    private void MoveX()
    {
        run_time += Time.deltaTime * speed;
        Pos = Mathf.Sin(run_time) * length;
        // Debug.Log(run_time);
        if(! flipx )
        {
            transform.position = new Vector3(Pos, gameObject.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(-Pos, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }

    private void MoveY()
    {
        run_time += Time.deltaTime * speed;
        Pos = Mathf.Sin(run_time) * length;
        transform.position = new Vector3(gameObject.transform.position.x, Pos, gameObject.transform.position.z);
    }
}
