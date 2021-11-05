using UnityEngine;

public class ShooterPlantBullet : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == projectileData._enemyLayer)
        {
            gameObject.SetActive(false);
        }
    }
}
