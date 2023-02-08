using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitsToDeath = 5;
    [SerializeField] ParticleSystem hitParticlesPrefab = default;
    [SerializeField] ParticleSystem enemyDeathParticlesPrefab = default;


    void Start()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitsToDeath < 1)
        {
            KillEnemy();
        }
    }
    private void ProcessHit()
    {
        hitsToDeath--;
        hitParticlesPrefab.Play();
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(enemyDeathParticlesPrefab, transform.position, Quaternion.identity);
        vfx.Play();

        float vfxDuration = vfx.main.duration;
        Destroy(vfx.gameObject, vfxDuration);

        Destroy(gameObject);
    }
}
