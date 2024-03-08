using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialInstance : MonoBehaviour
{
    // ��Ƽ������ ������ �޽� ������
    private MeshRenderer m_MeshRenderer;

    // ������ ��
    [SerializeField]
    private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        // ��� ��������

        m_MeshRenderer.material = Instantiate(m_MeshRenderer.material);
        // ������ ��Ƽ������ Instantiate�� ����(����)

        m_MeshRenderer.material.color = _color;
        // ��Ƽ���� ���� ������ ������ ����
    }
}
