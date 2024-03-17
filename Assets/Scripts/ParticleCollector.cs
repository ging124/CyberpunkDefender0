using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollector : MonoBehaviour
{
    ParticleSystem ps;

    List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle>();
    Transform playerTransform;

    void Awake()
    {
        playerTransform = GameObject.Find("Character").transform;
    }

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.trigger.AddCollider(playerTransform);
    }

    private void OnParticleTrigger()
    {
        int triggeredParticles = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);

        for (int i = 0; i < triggeredParticles; i++)
        {
            ParticleSystem.Particle p = particles[i];
            p.remainingLifetime = 0;
            PlayerController.instance.playerLevel.ExpGain(1);
            particles[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);

        Invoke(nameof(DestroyObject), 1.2f);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
