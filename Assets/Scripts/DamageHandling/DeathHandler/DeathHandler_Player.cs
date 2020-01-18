using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler_Player : DeathHandler
{
    public DeathObject deathObjectPrefab;

    public override void HandleDeath()
    {
        DeathObject deathObject = Instantiate(deathObjectPrefab, transform.position, Quaternion.identity);
        deathObject.lookDirection = GetComponentInChildren<Weapon>().shootDirection;
        //фикс даст эффекта
        gameObject.GetComponent<RigidbodyMover>().SetMovementVector(Vector2.zero);

        gameObject.SetActive(false);
        //Нельзя дестроить если нужен invoke
        //Destroy(gameObject); 
        Invoke("RestartLevel", 5f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
