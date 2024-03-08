using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // ��� ������
    [Header("��� ���� ����")]
    public int X_BlockCount;
    public int Y_BlockCount;

    [Header("��� ���� ����")]
    public int Xgap;
    public int Ygap;

    [Header("������ ��Ͽ� ���� ����")]
    public GameObject[] BlockPrefab;

    // 1. ��Ͽ� ���� �迭 ����
    [Header("==��� ����Ʈ==")]
    public GameObject[] X_Blocks;
    public GameObject[] Y_Blocks;

    // Start is called before the first frame update
    void Start()
    {
        // �ν����Ϳ��� ������ ����� ��ġ��ŭ ��� �迭 ����
        X_Blocks = new GameObject[X_BlockCount];
        Y_Blocks = new GameObject[Y_BlockCount];

        // ��� �迭, ����, �ε��� ��ȣ�� ������ ��� ����
        SetBlock(X_Blocks, Xgap, 0);
        SetBlock(Y_Blocks, Ygap, 1);
    }

    private void SetBlock(GameObject[] _Blocks, int xgap, int idx)
    {
        for (int i = 0; i < _Blocks.Length; i++)
        {
            _Blocks[i] = Instantiate(BlockPrefab[idx]); // 0���� X ���
            _Blocks[i].transform.position = new Vector3(-4.36f, 1, X_BlockCount - xgap * i);
            // ���ݿ� �°� ������ ��� z�� �ٸ��� ����

            // ������ �ִ� ����� X �� Y �Ŀ� ���� ���� ����
            if (_Blocks[i].GetComponent<BoxMove>().Position == Position.X_Block)
            {
                _Blocks[i].GetComponent<BoxMove>().length = 5;
                //������׷� ������ ����� ���� ���� �߰�(�ȳ־ ��)
                if (i % 2 == 1)
                    _Blocks[i].GetComponent<BoxMove>().flipx = true;
            }

            if (_Blocks[i].GetComponent<BoxMove>().Position == Position.Y_Block)
            {
                _Blocks[i].GetComponent<BoxMove>().length = 3;
            }
        }
    }
}