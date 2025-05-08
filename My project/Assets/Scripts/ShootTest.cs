using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shootCooldown;
    //[SerializeField] private float _bulletSpeed;
    [SerializeField] private RadialShotSettings _shotSetting;

    private float _shootCooldownTimer = 0f;
    

    // Update is called once per frame
    void Update()
    {
        _shootCooldownTimer -= Time.deltaTime;

        if(_shootCooldownTimer <= 0f)
        {
            ShotAttack.RadialShot(transform.position, transform.up , _shotSetting);
            _shootCooldownTimer += _shootCooldown;
        }
    }
    
}
