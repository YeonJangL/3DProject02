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

    public static int item_cnt; // ���ӿ��� üũ�� ������ ��
    public static int current_stage; // ���� Ŭ������ �������� ����
    public static int DeathCount; // ���� ī��Ʈ

    [Header("Data")]
    public int need_itme_cnt; // �䱸�ϴ� ������ ��
    public int Max_stage = 5; // �ִ� �������� ����

    public Item[] items; // ������ �迭

    // Start is called before the first frame update
    void Start()
    {
        items = FindObjectsOfType<Item>();
        // ������ Ÿ���� ������Ʈ���� ���� ������ ã�� ������ �迭�� ���
        need_itme_cnt = items.Length;
    }

    // Update is called once per frame
    void Update()
    {
        QuestText.text = $"Item : {item_cnt} / {need_itme_cnt}";
        StageText.text = $"Stage : {current_stage} / {Max_stage}";
        DeathCountText.text = $"Death Count : {DeathCount}";

        // �������� ������ 0�� ��� ��ü Ȱ��ȭ
        if (item_cnt == 0)
        {
            for(int i = 0; i < need_itme_cnt; i++)
            {
                items[i].GetComponent<GameObject>().SetActive(true);
            }
        }
    }
}
