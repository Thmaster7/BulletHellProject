using UnityEngine;
[System.Serializable]
public class RadialShotSettings
{
    public int numberOfBullets = 5;
    public float bulletSpeed = 10f;
    public float cooldownAfterShot;

    [Range(-1f, 1f)] public float PhaseOffset = 0f;
    [Range(-180f, 180f)] public float AngleOffset = 0f;

}
