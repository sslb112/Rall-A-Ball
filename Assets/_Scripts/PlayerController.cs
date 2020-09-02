using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float m_speed = 10;    // 控制小球移动的速度，即力的倍数
    public Text countText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>(); // 获取组件，即sphero小球
        count = 0;
        countText.text = "Count: " + count.ToString();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");      // 获取
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h,0.0f,v);     // 施加力的大小和方向
        rb.AddForce(moveDirection * m_speed);
    }
    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);        // 销毁other
        if(other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);  // 非激活
            count++;
            countText.text = "Count: " + count.ToString();
        }
        
    }
}
