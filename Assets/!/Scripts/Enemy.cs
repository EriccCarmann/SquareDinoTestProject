using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HealthBar healthBar;

    [SerializeField] private int health = 10;

    private void Start()
    {
        SetColliderState(false);
        SetRigidbodyState(true);

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            health -= bullet.Damage;

            healthBar.SetHealth(health);

            if(health <= 0)
            {
                Die();
            }
        }
    }

    private void SetRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = state;
        }
    }

    private void SetColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider col in colliders)
        {
            col.enabled = state;
        }

        GetComponent<Collider>().enabled = true;
    }

    private void Die()
    {
        EventManager.EnemyDied(gameObject);

        SetColliderState(true);
        SetRigidbodyState(false);

        healthBar.gameObject.SetActive(false);
        Destroy(gameObject.GetComponent<Animator>());
        Destroy(gameObject, 1f);
    }
}
