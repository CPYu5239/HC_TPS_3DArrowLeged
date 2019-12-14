using UnityEngine;

public class Player : MonoBehaviour
{
    private Joystick joy;
    [Header("移動速度")]
    [Range(15f,50f)]
    public float speed = 15f;

    private Rigidbody rig;

    private Transform target;

    private void Start()
    {
        //取得元件<泛型>()
        rig = GetComponent<Rigidbody>();  //可以直接抓取這個物件的所有元件
        //target = GameObject.Find("目標").GetComponent<Transform>();  
        target = GameObject.Find("目標").transform;  //只有transform可以直接這樣叫
        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
    }

    private void Update()
    {
        //print("虛擬搖桿水平 : " + joy.Horizontal);
        //print("虛擬搖桿垂直 : " + joy.Vertical);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    /// <summary>
    /// 移動玩家方法
    /// </summary>
    private void PlayerMove()
    {   
        if(joy.Horizontal != 0 || joy.Vertical != 0)
        {
            int H = (joy.Horizontal < 0) ? -1 : 1;
            int V = (joy.Vertical < 0) ? -1 : 1;

            rig.AddForce(H * speed, 0, V * speed);
        }
        else
        {
            rig.Sleep();
        }

        //控制目標物件
        Vector3 posPlayer = transform.position; //取得玩家座標
        //只有transform可以直接這樣叫 (其他要用 GameObject.Find().GetComponent<>(); )
        Vector3 posTarget = new Vector3(posPlayer.x + joy.Horizontal, target.position.y, posPlayer.z + joy.Vertical);

        target.position = posTarget; //設定目標物件位置

        //讓角色看著目標物件
        transform.LookAt(target);
    }
}
