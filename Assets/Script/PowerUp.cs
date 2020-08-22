using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;

    public enum effects
    {
        turretUpgrade,
        missleUpgrade,
        orbiterUpgrade,
        heal,
        mainGunUpgrade,
        auxillaryGunUprade,
        barrageUpgrade
    };

    public effects effect;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Upgradeable player = other.GetComponent<Upgradeable>();

            switch (effect)
            {
                case effects.mainGunUpgrade:
                    player.MainGunUpgrade();
                    break;
                case effects.auxillaryGunUprade:
                    player.AuxillaryGunUpgrade();
                    break;
                case effects.barrageUpgrade:
                    player.BarrageUpgrade();
                    break;
                case effects.heal:
                    player.Heal();
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
