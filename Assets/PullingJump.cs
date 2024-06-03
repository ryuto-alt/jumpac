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
        // rb = GetComponent<Rigidbody>();     // gameObjectは省略可能
        Physics.gravity = new Vector3(0, -9.8f, 0);


    }

    // Update is called once per frame
    void Update()
    {



        // 確認したら削除
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
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;

            // クリックとリリースが同じ座標なら無視
            if (dist.sqrMagnitude == 0)
            {
                return;
            }

            // 差分を正規化し、jumpPowerをかけ合わせた値を移動量とする
            rb.velocity = dist.normalized * jumpPower;
        }
    }
}
