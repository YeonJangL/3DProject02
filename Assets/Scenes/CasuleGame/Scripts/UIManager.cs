using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI TEXT")]
    public Text QuestText;
    public Text StageText;
    public Text DeathCountText;

    public static int item_cnt; // 게임에서 체크할 아이템 수
    public static int current_stage; // 현재 클리어한 스테이지 정보
    public static int DeathCount; // 데스 카운트

    [Header("Data")]
    public int need_itme_cnt; // 요구하는 아이템 수
    public int Max_stage = 5; // 최대 스테이지 구현

    public Item[] items; // 아이템 배열

    // Start is called before the first frame update
    void Start()
    {
        items = FindObjectsOfType<Item>();
        // 아이템 타입의 오브젝트들을 게임 내에서 찾아 아이템 배열에 등록
        need_itme_cnt = items.Length;
    }

    // Update is called once per frame
    void Update()
    {
        QuestText.text = $"Item : {item_cnt} / {need_itme_cnt}";
        StageText.text = $"Stage : {current_stage} / {Max_stage}";
        DeathCountText.text = $"Death Count : {DeathCount}";

        // 아이템의 개수가 0일 경우 전체 활성화
        if (item_cnt == 0)
        {
            for(int i = 0; i < need_itme_cnt; i++)
            {
                items[i].GetComponent<GameObject>().SetActive(true);
            }
        }
    }
}
