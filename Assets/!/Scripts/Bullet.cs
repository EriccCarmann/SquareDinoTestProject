using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRB;
    private Vector3 dir;

    private float speed = 15f;
    [SerializeField] private int damage = 2;

    public int Damage { get { return damage; } }
    public Vector3 Dir { set {  dir = value; } }

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        bulletRB.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        if (bulletRB.position == dir) gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            gameObject.SetActive(false);
        }
    }
}
