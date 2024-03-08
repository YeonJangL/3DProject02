using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �浹 ���� �۾�
    public Transform respawn; // ���� ��ġ(���� ����)

    // �÷��̾ ���� ������ ó��
    // �÷��̾ �浹�ϴ� ���� ���� ó��

    // �浹 ��� -> Rigidbody ��� ������ �ڵ� �ۼ��� ����
    // ���� �̹� ����ó�� Transform�� ���� �����̸� �÷��̾ �ƴ� ��ü�� Rigidbody����

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 2) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            UIManager.item_cnt++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Trap")
        {
            UIManager.item_cnt = 0;
            UIManager.DeathCount++;
            // ��ֹ��� �ε��� ��� ������������ �̵�
            gameObject.transform.position = respawn.position;
        }
    }
}
