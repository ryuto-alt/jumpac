using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {
        // ������Ԃł͖��摜���\���ɂ���
        arrowImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
            // �N���b�N���ꂽ����摜��\������
            arrowImage.gameObject.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            // �x�N�g���̒������Z�o
            float size = dist.magnitude;
            // �x�N�g������p�x�i�ʓx�@�j���Z�o
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // ���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
            arrowImage.rectTransform.position = clickPosition;
            // ���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ�����2����]
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            // ���̉摜�̑傫�����h���b�O���������ɍ��킹��
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        if (Input.GetMouseButtonUp(0))
        {
            // �N���b�N�𗣂�������摜���\���ɂ���
            arrowImage.gameObject.SetActive(false);
        }
    }
}
