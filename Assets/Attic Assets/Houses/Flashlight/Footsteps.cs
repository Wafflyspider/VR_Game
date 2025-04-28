using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
  public AudioSource footstepAudioSource;
    public float speedThreshold = 0.1f;
    public float stepDelay = 0.5f;

    private Vector3 lastPosition;
    private float stepTimer;

    void Start()
    {
        lastPosition = transform.position;
        stepTimer = 0f;
    }

    void Update()
    {
        Vector3 movement = transform.position - lastPosition;
        float speed = movement.magnitude / Time.deltaTime;

        stepTimer -= Time.deltaTime;

        if (speed > speedThreshold && stepTimer <= 0f)
        {
            if (footstepAudioSource != null)
            {
                footstepAudioSource.Play();
            }
            stepTimer = stepDelay;
        }

        lastPosition = transform.position;
    }
}