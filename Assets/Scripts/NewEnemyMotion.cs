using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyMotion : MonoBehaviour
{
    public NavMeshAgent agent;

    //public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(GameObject.Find("END").GetComponent<Transform>().position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
