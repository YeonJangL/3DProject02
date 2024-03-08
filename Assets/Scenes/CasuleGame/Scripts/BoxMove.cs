using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// ����� ������ ���� ǥ���ϱ����� Enum���
public enum Position
{
    X_Block, Y_Block
}

public class BoxMove : MonoBehaviour
{
    public Position Position; // ����� ��ġ�� ���� ǥ��
    public bool flipx; // x�� ���� ����

    [Range(1, 5)] public float speed; // ��� �ӵ�
    public float length = 0.0f; // ��� �̵� ����(+, -)

    private float run_time = 0.0f; // ������Ʈ���� üũ�� �ð� ��ġ
    private float Pos = 0.0f; // ��ġ

    void Update()
    {
        // ����� ���� �����ǿ� ���� ������ ���� ó���ϵ��� ����
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
