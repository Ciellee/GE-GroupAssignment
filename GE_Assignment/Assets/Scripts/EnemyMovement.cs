using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Animator anim;
    int speed;
    UnityEngine.AI.NavMeshAgent nav;

    // Use this for initialization

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        nav.SetDestination(player.position);
    }

    public void Pause()
    {
        anim.enabled = false;
        nav.enabled = false;
    }
    public void Restart()
    {
        anim.enabled = true;
        nav.enabled = true;
    }
}
