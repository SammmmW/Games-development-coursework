using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StationaryTank : MonoBehaviour
{
    public Transform Target;
    public float attackRange;
    public NavMeshAgent m_Agent;
    private float m_Distance;
    public int timer = 0;
    public bool hasFired = false;

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
            if (!hasFired)
            {
                AITankShooting shot = m_Agent.GetComponent<AITankShooting>();
                shot.Fire();
                hasFired = true;
            }
        }
        else
        {
            if (hasFired)
            {
                hasFired = false;
            }
        }
    }
}
