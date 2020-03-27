using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _firteRate = 2f;
    [SerializeField] private float _ammoStartPositionOfsetX = 1;
    [SerializeField] private float _ammoStartPositionOfsetY = .25f;
    private float _nextShootTime = 0;
    public GameObject Ammo;

    public void Shoot(float directionX)
    {
        if (Time.time > _nextShootTime)
        {
            _nextShootTime = Time.time + _firteRate;
            Fire(directionX);
        }

    }

    private void Fire(float directionX)
    {
        Vector3 ammoStartPosition = new Vector3(
            transform.position.x + _ammoStartPositionOfsetX * directionX,
            transform.position.y + _ammoStartPositionOfsetY,
            transform.position.z
            );

        GameObject bullet = Instantiate(Ammo, ammoStartPosition, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.DirectoinX = directionX;
    }
}
