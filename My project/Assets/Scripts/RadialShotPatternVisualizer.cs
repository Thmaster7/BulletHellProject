using UnityEngine;
using static UnityEngine.UI.Image;

public class RadialShotPatternVisualizer : MonoBehaviour
{
    [SerializeField] private RadialShotPattern _pattern;
    [SerializeField] private float _radius;
    [SerializeField] private Color _color;
    [SerializeField, Range(0f, 5f)] private float _testTime;

    private void OnDrawGizmos()
    {

        if(_pattern == null)
        {
            return;
        }
        Gizmos.color = _color;

        int lap = 0;
        Vector2 aimDirection = transform.up;
        Vector2 center = transform.position;

        float timer = _testTime;

        

        while (timer > 0f && lap < _pattern.Repetitions)
        {
            for (int i = 0; i < _pattern.PatternSettings.Length; i++)
            {
                if(timer <0f)
                {
                    break;
                }
                DrawRadialShot(_pattern.PatternSettings[i], timer, aimDirection);
                timer -= _pattern.PatternSettings[i].cooldownAfterShot;
            }
            lap++;
        }

    }

    private void DrawRadialShot(RadialShotSettings settings, float lifeTime, Vector2 aimDirection)
    {
        float angleBetweenBullets = 360f / settings.numberOfBullets;
        if (settings.AngleOffset != 0 || settings.PhaseOffset != 0f)
        {
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset * angleBetweenBullets));
        }
        for (int i = 0; i < settings.numberOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;

            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            Vector2 bulletPosition = (Vector2)transform.position + (bulletDirection * settings.bulletSpeed * lifeTime);
            Gizmos.DrawSphere(bulletPosition, _radius);
        }
    }
}
