using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Huntplayer : MonoBehaviour
{
    public Transform Target;
    public float attackRange;
    public NavMeshAgent m_Agent;
    private float m_Distance;
    public int timer = 0;
    [SerializeField] private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Distance = Vector3.Distance(m_Agent.transform.position, Target.position);
        if (m_Distance < attackRange)
        {
            AITankShooting shot = m_Agent.GetComponent<AITankShooting>();
            shot.Fire();
        }
        else
        {
            m_Agent.speed = speed;
            m_Agent.destination = Target.position;
        }
    }
}
