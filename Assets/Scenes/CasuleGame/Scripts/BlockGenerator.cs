using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // 블록 생성기
    [Header("블록 개수 설정")]
    public int X_BlockCount;
    public int Y_BlockCount;

    [Header("블록 생성 간격")]
    public int Xgap;
    public int Ygap;

    [Header("생성할 블록에 대한 정보")]
    public GameObject[] BlockPrefab;

    // 1. 블록에 대한 배열 생성
    [Header("==블록 리스트==")]
    public GameObject[] X_Blocks;
    public GameObject[] Y_Blocks;

    // Start is called before the first frame update
    void Start()
    {
        // 인스팩터에서 설정한 블록의 수치만큼 블록 배열 생성
        X_Blocks = new GameObject[X_BlockCount];
        Y_Blocks = new GameObject[Y_BlockCount];

        // 블록 배열, 간격, 인덱스 번호를 전달해 블록 생성
        SetBlock(X_Blocks, Xgap, 0);
        SetBlock(Y_Blocks, Ygap, 1);
    }

    private void SetBlock(GameObject[] _Blocks, int xgap, int idx)
    {
        for (int i = 0; i < _Blocks.Length; i++)
        {
            _Blocks[i] = Instantiate(BlockPrefab[idx]); // 0번은 X 블록
            _Blocks[i].transform.position = new Vector3(-4.36f, 1, X_BlockCount - xgap * i);
            // 간격에 맞게 각각의 블록 z축 다르게 설정

            // 가지고 있는 블록이 X 냐 Y 냐에 따라 범위 설정
            if (_Blocks[i].GetComponent<BoxMove>().Position == Position.X_Block)
            {
                _Blocks[i].GetComponent<BoxMove>().length = 5;
                //지그재그로 패턴을 만들기 위해 조건 추가(안넣어도 됨)
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