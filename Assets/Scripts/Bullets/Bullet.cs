using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public GameObject target;
    [SerializeField] private int damage;
    private float speed = 85f;


    protected virtual void Update()
    {
        if (target == null) return;
        
        if (Vector3.Distance(target.transform.position, transform.position) < 0.1f) 
            gameObject.SetActive(false);
        else
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.forward = direction;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.tag == "Enemy")
        {
            collidedObject.GetComponent<Health>().LoseHealth(damage);   
        }

        if (!other.gameObject.CompareTag("Tower") && !other.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }
}
