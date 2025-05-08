using UnityEngine;
using UnityEngine.UIElements;

public static class ShotAttack
{

    public static void SimpleShot(Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.velocity = velocity;
    }
    public static void RadialShot(Vector2 origin, Vector2 aimDirection, RadialShotSettings settings)
    {
        float angleBetweenBullets = 360f / settings.numberOfBullets;

        if(settings.AngleOffset != 0 || settings.PhaseOffset != 0f)
        {
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset *angleBetweenBullets));
        }

        for(int i = 0; i < settings.numberOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;

            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            SimpleShot(origin, bulletDirection * settings.bulletSpeed);
        }
    }
}
