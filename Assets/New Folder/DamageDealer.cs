using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerStats stats = collision.GetComponent<PlayerStats>();
        if (stats == null)
            return;

        stats.TakeDamage(damage);
    }
}