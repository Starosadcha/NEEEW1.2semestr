using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int heal = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(1);

            PlayerStats stats = other.GetComponent<PlayerStats>();
            if (stats != null && stats.GetHealth() < stats.GetMaxHealth())
            {
                stats.Heal(heal);
            }

            Destroy(gameObject);
        }
    }
}