using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHit : MonoBehaviour {

    public float range = 500f;

    Ray shootRay;
    int shootable;
    RaycastHit shootHit;
    LineRenderer LightLine;
    float timer;
    float hittimer;
    float timebetween = 0.15f;
    float effectsDisplayTime = 0.2f;


    // Use this for initialization
    void Start () {
        LightLine = GetComponent<LineRenderer>();
        shootable = LayerMask.GetMask("shootable");
        hittimer = 0f;
        timer = 0f;

    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetButton("Fire1"))
        {
            Stop();
        }
        if (hittimer >= timebetween *effectsDisplayTime)
        {
            DisableEffects();
        }
        if (timer >= 1.0f)
        {
            if (Physics.Raycast(shootRay, out shootHit, range, shootable))
            {
                EnemyMovement Enemymovement = shootHit.collider.GetComponent<EnemyMovement>();
                Enemymovement.Start();
                Enemymovement.Update();
            }
        }
    }

    void Stop()
    {
        timer = 0f;
        LightLine.enabled = true;
        LightLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast (shootRay, out shootHit, range, shootable))
        {
            EnemyMovement Enemymovement = shootHit.collider.GetComponent<EnemyMovement>();
            if (Enemymovement != null)
            {
                timer += Time.deltaTime;
                Enemymovement.Pause();
            }
            LightLine.SetPosition(1, shootHit.point);
        }
        else
        {
            LightLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    public void DisableEffects()
    {
        LightLine.enabled = false;
    }
}
