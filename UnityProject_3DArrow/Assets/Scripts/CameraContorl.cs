using System.Collections;
using UnityEngine;

public class CameraContorl : MonoBehaviour
{
    [Header("速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("上方限制")]
    public float top = -21.4f;
    [Header("下方限制")]
    public float bottom = -18.8f;

    private Transform player;

    private void Start()
    {
        player = GameObject.Find("玩家").transform;
    }

    //在Update後執行 : 適合做攝影機或物件的座標追蹤
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 攝影機追蹤
    /// </summary>
    private void Track()
    { 
        Vector3 posPlayer = player.position;
        Vector3 posCamera = transform.position;

        posPlayer.x = 0;   //限制x在0
        posPlayer.y = 16;  //限制y在16(原攝影機)
        posPlayer.z -= 15; //往玩家後面移動

        posPlayer.z = Mathf.Clamp(posPlayer.z, top, bottom);   //利用Clamp讓攝影機不會超過上下限

        transform.position = Vector3.Lerp(posCamera, posPlayer, 0.5f * Time.deltaTime * speed);
    }
}