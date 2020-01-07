using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public NavMeshAgent agent;
    public Transform player;
    public Animator ani;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("玩家").GetComponent<Transform>();
        ani = GetComponent<Animator>();

        agent.speed = enemyData.speed;
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {

    }

    /// <summary>
    /// 移動
    /// </summary>
    public virtual void Move()
    {

    }

    /// <summary>
    /// 被彈
    /// </summary>
    /// <param name="damage">受到的傷害量</param>
    private void Hit(float damage)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Die()
    {

    }
}
