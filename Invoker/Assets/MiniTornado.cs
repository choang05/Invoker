﻿using UnityEngine;
using System.Collections;

public class MiniTornado : MonoBehaviour
{
    // Attributes
    private float liftDuration;
    public float liftHeight;
    private GameObject target;

    // Animation
    private Animator animator;

    // Visuals
    private GameObject particleObject;
    private ParticleSystem particle;

    // Audio
    private AudioSource audioSource;
    public AudioClip tornadoLiftSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        particleObject = transform.FindChild("Particles").gameObject;
        particle = particleObject.GetComponent<ParticleSystem>();
        // Use this for initialization
    }

    void Start () 
    {
        // Visuals
        particle.Play();
        target.transform.position += new Vector3(0, liftHeight, 0);

        // Audio
        audioSource.PlayOneShot(tornadoLiftSound, .5f);

        // Start IEnumerator to destory object after x seconds.
        StartCoroutine(destroy(liftDuration));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 360 * Time.deltaTime, 0);
        particleObject.transform.Rotate(0, 0, 360 * Time.deltaTime);
    }

    // Stop ghost walk after duration is up and return material back to original.
    IEnumerator destroy(float Duration)
    {
        yield return new WaitForSeconds(Duration-1);
        particle.Stop();
        //animator.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        Die();
    }

    // Destory object and return attributes to original state
    public void Die()
    {
        target.transform.SetParent(null);
        Destroy(gameObject);
    }
    // Accessors and Mutators
    public float LiftDuration
    {
        get { return liftDuration; }
        set { liftDuration = value; }
    }
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}