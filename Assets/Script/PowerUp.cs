using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;

    public enum effects
    {
        turretUpgrade,
        missleUpgrade,
        orbiterUpgrade,
        heal
    };

    public effects effect;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            switch (effect)
            {
                case effects.turretUpgrade:
                    player.WeaponUpgrade();
                    break;
                case effects.missleUpgrade:
                    player.MissleUpgrade();
                    break;
                case effects.orbiterUpgrade:
                    player.SpawnOrbiters();
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
