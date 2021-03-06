﻿using UnityEngine;
using System.Collections;

public class MonsterAirBlast : MonoBehaviour {

    public GameObject player;
    public float distanceToPlayer;
    //private Vector3 v_diff;
    //private float atanPlayer;
    private float direction;
    private float blastDirection;

    public Quaternion rotation = Quaternion.identity;

    //audio:
    public AudioClip normalAudio;
    public AudioClip attackAudio;
    public AudioSource source;

    // Use this for initialization
    void Start()
    {
        Debug.Log("AirBlast monster ready");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //v_diff = (player.transform.position - transform.position);
        //atanPlayer = Mathf.Atan2(v_diff.y, v_diff.x);

        if (distanceToPlayer < 10 && distanceToPlayer > 2)
        {

            source.clip = attackAudio;
            if (!source.isPlaying)
            {
                source.Play();
            }

            direction = transform.position.x - player.transform.position.x;
            if (direction > 0)
            {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                transform.rotation = rotation;
                blastDirection = -1;
            }
            else
            {
                rotation.eulerAngles = new Vector3(0, 0, 0);
                transform.rotation = rotation;
                blastDirection = 1;
            }

            //transform.Translate(1 * Time.deltaTime, 0, 0);
            //player.GetComponent<Rigidbody2D>().AddForce(transform.forward * 2);
            player.transform.Translate(blastDirection * Time.deltaTime, 0, 0);
        }

        else
        {
            //Default animation
            source.clip = normalAudio;
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}