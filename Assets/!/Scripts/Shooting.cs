using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Update()
    {
        if(cam != null)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1.5f));
                Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                
                GameObject bullet = ObjectPool.instance.GetPooledObject();

                if (bullet != null)
                {
                    bullet.transform.position = worldPos;
                    bullet.transform.rotation = cam.rotation;
                    bullet.GetComponent<Bullet>().Dir = targetPos;

                    bullet.SetActive(true);
                }
            }
        }
    }
}
