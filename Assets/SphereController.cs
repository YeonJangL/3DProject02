using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Ʈ������(Transform)
    // ��ġ, ȸ��, ũ�� ǥ���� ����
    // �θ� - �ڽ� ���� ���忡 ����
    // ���� ������Ʈ���� �׻� �ϳ��� Ʈ������ ������Ʈ ����
    // Ʈ�������� ���� ���� ������Ʈ�� ���� �Ұ���

    // Scale�� 1�� �⺻ ũ��(������Ʈ�� import�� ũ��)�̰�, ��ġ�� ���� ����ϰ� ����
    // Scale �� üũ�� Ǯ�� ��� �����ϸ� ��� Ȱ��ȭ��
    // ������ ���� x, y, z�� �������� ���� ������Ű�� x, y, z�� ���� ����� 

    // Input.GetKey : �Է� ����� �ش� Ű�� ������ ���� ǥ����
    // Input.GetKeyDown : �� Ű�� �Է������� (1��)
    // Input.GetKeyup : �� Ű�� ������ (1��)
    // -> �ణ ��� ����ε�

    Vector3 rotation;

    private void Start()
    {
        rotation = transform.eulerAngles;
        // transform.eulerAngles�� ������Ʈ�� Transform�� Rotation ���� Vector3�� ���·� ��ȯ�ϴ� �ڵ�
        // [���Ϸ� ��] -> ���ڵ� ���� & ���� ���� ����
        // ���� ��� : x, y, z�� �������� ���
        // ������ : eulerAngles ��ġ�� ���� ������ų ��� ������Ʈ�� 90�� �̻��� ���� �ʰ� ���� ��
        // �ذ�� : ������ ���� �� ���ʹϾ�(Quaternion)���� ��� ó��
        // ���ʹϾ��� ����Ƽ�� ���Ϸ� ���� ������ ������ ������ �ذ�å���� ����

        // ���ʹϾ�(Quaternion) : �����
        // 3���� �׷��ȿ��� ȸ���� ǥ���� �� ��� ��� ����ϴ� ������ ����
        // ���ʹϾ��� x, y, z ���Ϳ� w(��Į��)�� ���� ��� ����
        // ���������� ���ʹϾ��� x, y, z�� w�� ��� ������ ���Ҽ�
        // w(��Į��)�� �Ǽ��� �ش��ϰ� x, y, z�� ����� �ش���
        
        // ��� : ���ʹϾ��� ����� ��� x, y, z���� �� ȸ���ϱ� �԰���
    }

    // Update is called once per frame
    void Update()
    {
        // ������Ʈ�� ���� �̵�(Transform)
        // 1. ���� ��ġ�� �ٸ� �������� �ʱ�ȭ�� ��ǥ�� �̵��ϴ� ���
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + new Vector3(0, 0, 2) * Time.deltaTime;
            // transform.position += new Vector3(0, 0, 2) * Time.deltaTime;
        }

        // 2. transform.Translate(�̵��� ��ǥ)�� ���� ��ǥ�� �̵��ϴ� ���
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);
        }

        // ������Ʈ�� ���� ȸ�� ����
        if(Input.GetKey(KeyCode.A))
        {
            rotation += new Vector3(90, 0, 0) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotation);

            // ���ʹϾ� ���� ����
            // Quaternion.LookRotation() ������ upwards ������ rotation�� �����ϴ� �ڵ�
            // Quaternion.Euler(); �� x, y, z���� ȸ���� ������� Rotation ��ȯ ���
            // Quaternion.Angle(a, b); ���ʹϾ� �� a�� b ������ ���� ��ȯ ���
            // Quaternion.Slerp(a, b, t); a�� b ���̸� t�������� ���� ������ => �ε巯�� �̵�
            // ����� ���� Math.Lerp(a, b, t) : a�� b ���̸� t�������� ���� ������
            // Quaternion.identity : ȸ�� ���� ����(������Ʈ�� �Ϻ��ϰ� ���� ��ǥ / �θ��� ������ ����)
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            // Rotate�� ������Ʈ�� ���� transform�� �־��� ��ġ��ŭ +�ϴ� ����
        }

        if (Input.GetKey(KeyCode.S))
        {
            rotation += new Vector3(0, 0, 90) * Time.deltaTime;
            transform.eulerAngles = rotation; // ���Ϸ� ��(���� ����)�� ȸ�� �� �ʱ�ȭ
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += new Vector3(2, 2, 2) * Time.deltaTime;
            // localScale�� ��ü�� ������ ũ�⸦ �ǹ���
        }
    }
}
