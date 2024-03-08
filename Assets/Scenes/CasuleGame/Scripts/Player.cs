using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 충돌 관련 작업
    public Transform respawn; // 생성 위치(시작 지점)

    // 플레이어에 대한 움직임 처리
    // 플레이어가 충돌하는 값에 대한 처리

    // 충돌 고려 -> Rigidbody 기반 움직임 코드 작성이 좋다
    // 만약 이번 예제처럼 Transform을 통해 움직이면 플레이어가 아닌 물체에 Rigidbody연결

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
            // 장애물에 부딪힐 경우 스폰지역으로 이동
            gameObject.transform.position = respawn.position;
        }
    }
}
