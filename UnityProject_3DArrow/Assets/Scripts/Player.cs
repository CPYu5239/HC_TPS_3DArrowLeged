using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位宣告
    [Header("移動速度"), Range(15f, 50f)]
    public float speed = 15f;
    private Joystick joy;
    private Rigidbody rig;
    private Transform target;
    private Animator ani;
    #endregion

    #region 事件
    private void Start()
    {
        //取得元件<泛型>()
        rig = GetComponent<Rigidbody>();  //可以直接抓取這個物件的所有元件
        ani = GetComponent<Animator>();  //取得物件的Animator元件
        //target = GameObject.Find("目標").GetComponent<Transform>();  
        target = GameObject.Find("目標").transform;  //只有transform可以直接這樣叫
        joy = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Attack();
        if (Input.GetKeyDown(KeyCode.Alpha2)) Dead();
        //print("虛擬搖桿水平 : " + joy.Horizontal);
        //print("虛擬搖桿垂直 : " + joy.Vertical);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 移動玩家方法
    /// </summary>
    private void PlayerMove()
    {   
        if(joy.Horizontal != 0 || joy.Vertical != 0)
        {
            int H = (joy.Horizontal < 0) ? -1 : 1;
            int V = (joy.Vertical < 0) ? -1 : 1;

            ani.SetBool("跑步開關", true);   //設定動畫變數開關
            rig.AddForce(H * speed, 0, V * speed);
        }
        else
        {
            ani.SetBool("跑步開關", false);   //設定動畫變數開關
            rig.Sleep();
        }

        //控制目標物件
        Vector3 posPlayer = transform.position; //取得玩家座標
        //只有transform可以直接這樣叫 (其他要用 GameObject.Find().GetComponent<>(); )
        Vector3 posTarget = new Vector3(posPlayer.x + joy.Horizontal, posPlayer.y, posPlayer.z + joy.Vertical);  //設定y軸避免角色往地板看吃土

        target.position = posTarget; //設定目標物件位置

        //讓角色看著目標物件
        transform.LookAt(posTarget);
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        ani.SetTrigger("攻擊觸發");  //設定攻擊動畫
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡", true);
    }

    /// <summary>
    /// 被彈
    /// </summary>
    /// <param name="damage">受到的傷害量</param>
    private void Hit(float damage)
    { 

    }
    #endregion
}
