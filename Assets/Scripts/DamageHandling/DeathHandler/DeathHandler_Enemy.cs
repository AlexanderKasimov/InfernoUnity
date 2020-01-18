using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler_Enemy : DeathHandler
{
    public DeathObject deathObjectPrefab;

    public override void HandleDeath()
    {        
        DeathObject deathObject = Instantiate(deathObjectPrefab, transform.position, Quaternion.identity);
        deathObject.lookDirection = GetComponent<EnemyController>().movementVector;
        Destroy(gameObject);
    }

}
