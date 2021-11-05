using System.Collections;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected ProjectilesData projectileData;
    protected virtual void OnEnable()
    {
        StartCoroutine("Despawn");
    }
    protected virtual void OnDisable()
    {
        StopCoroutine("Despawn");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(projectileData._timeToDespawn);
        gameObject.SetActive(false);
    }
}
