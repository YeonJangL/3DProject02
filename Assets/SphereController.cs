using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    // 트랜스폼(Transform)
    // 위치, 회전, 크기 표현에 사용됨
    // 부모 - 자식 상태 저장에 사용됨
    // 게임 오브젝트에는 항상 하나의 트랜스폼 컴포넌트 존재
    // 트랜스폼이 없는 게임 오브젝트는 생성 불가능

    // Scale은 1이 기본 크기(오브젝트가 import된 크기)이고, 수치에 따라 비례하게 설정
    // Scale 옆 체크를 풀면 비례 스케일링 기능 활성화됨
    // 설정해 놓은 x, y, z를 기준으로 값을 증가시키면 x, y, z에 같이 적용됨 

    // Input.GetKey : 입력 기능중 해당 키를 누르는 동안 표현함
    // Input.GetKeyDown : 그 키를 입력했을때 (1번)
    // Input.GetKeyup : 그 키를 뗏을때 (1번)
    // -> 약간 토글 방식인듯

    Vector3 rotation;

    private void Start()
    {
        rotation = transform.eulerAngles;
        // transform.eulerAngles는 오브젝트의 Transform의 Rotation 값을 Vector3의 형태로 변환하는 코드
        // [오일러 각] -> 디스코드 내용 & 공식 문서 참고
        // 간단 요약 : x, y, z를 기준으로 계산
        // 문제점 : eulerAngles 수치를 직접 증가시킬 경우 오브젝트가 90도 이상은 돌지 않고 떨게 됨
        // 해결법 : 계산식을 적을 때 쿼터니언(Quaternion)으로 계산 처리
        // 쿼터니언은 유니티의 오일러 각이 가지는 짐벌락 현상의 해결책으로 사용됨

        // 쿼터니언(Quaternion) : 사원수
        // 3차원 그래픽에서 회전을 표현할 때 행렬 대신 사용하는 수학적 개념
        // 쿼터니언은 x, y, z 백터와 w(스칼라)를 통해 계산 진행
        // 수학적으로 쿼터니언은 x, y, z와 w를 묶어서 구성한 복소수
        // w(스칼라)는 실수에 해당하고 x, y, z는 허수에 해당함
        
        // 결론 : 쿼터니언을 계산할 경우 x, y, z축을 다 회전하기 쌉가능
    }

    // Update is called once per frame
    void Update()
    {
        // 오브젝트에 대한 이동(Transform)
        // 1. 현재 위치를 다른 지점으로 초기화해 좌표를 이동하는 방식
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + new Vector3(0, 0, 2) * Time.deltaTime;
            // transform.position += new Vector3(0, 0, 2) * Time.deltaTime;
        }

        // 2. transform.Translate(이동할 좌표)를 통해 좌표를 이동하는 방식
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);
        }

        // 오브젝트에 대한 회전 진행
        if(Input.GetKey(KeyCode.A))
        {
            rotation += new Vector3(90, 0, 0) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotation);

            // 쿼터니언 관련 문법
            // Quaternion.LookRotation() 지정된 upwards 방향들로 rotation을 생성하는 코드
            // Quaternion.Euler(); 각 x, y, z축이 회전한 순서대로 Rotation 반환 기능
            // Quaternion.Angle(a, b); 쿼터니언 값 a와 b 사이의 각도 반환 기능
            // Quaternion.Slerp(a, b, t); a와 b 사이를 t간격으로 구형 보간함 => 부드러운 이동
            // 비슷한 형태 Math.Lerp(a, b, t) : a와 b 사이를 t간격으로 선형 보간함
            // Quaternion.identity : 회전 값이 없음(오브젝트가 완벽하게 월드 좌표 / 부모의 축으로 정렬)
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            // Rotate는 오브젝트가 가진 transform에 넣어준 수치만큼 +하는 개념
        }

        if (Input.GetKey(KeyCode.S))
        {
            rotation += new Vector3(0, 0, 90) * Time.deltaTime;
            transform.eulerAngles = rotation; // 오일러 각(절대 각도)에 회전 값 초기화
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += new Vector3(2, 2, 2) * Time.deltaTime;
            // localScale은 물체가 가지는 크기를 의미함
        }
    }
}
