using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 clickPosition;
    

    [SerializeField]
    private float jumpPower = 10;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();     // gameObject�͏ȗ��\
        Physics.gravity = new Vector3(0, -9.8f, 0);


    }

    // Update is called once per frame
    void Update()
    {



        // �m�F������폜
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 10, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }




        if (Input.GetMouseButtonUp(0))
        {
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;

            // �N���b�N�ƃ����[�X���������W�Ȃ疳��
            if (dist.sqrMagnitude == 0)
            {
                return;
            }

            // �����𐳋K�����AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
