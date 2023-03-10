using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = default;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projetileParticle = default;

    public Waypoint baseWaypoint; // where tower is standing on

    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FiringAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distanceA = Vector3.Distance(transform.position, transformA.position);
        float distanceB = Vector3.Distance(transform.position, transformB.position);

        if(distanceA < distanceB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FiringAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position,
                                          gameObject.transform.position);

        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
            print("ENEMY NEAR");
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
            var emissionModule = projetileParticle.emission;
            emissionModule.enabled = isActive;
    }
}
