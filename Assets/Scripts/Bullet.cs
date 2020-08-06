using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string targetTag;
    public TargetToDestroy target;
    public GameObject bulletDestroyedPrefab;
    public GameObject enemyDestroyedPrefab;

    public enum TargetToDestroy { Player, Enemy }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == targetTag)
        {
            if (target == TargetToDestroy.Enemy)
            {
                Destroy(collider.gameObject);
                Instantiate(enemyDestroyedPrefab, collider.transform.position, Quaternion.identity);

                if (FindObjectOfType<PlayerScore>() != null)
                    FindObjectOfType<PlayerScore>().IncreaseScore();
            }
            else if (target == TargetToDestroy.Player)
            {
                collider.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(10);
            }
        }

        Instantiate(bulletDestroyedPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}