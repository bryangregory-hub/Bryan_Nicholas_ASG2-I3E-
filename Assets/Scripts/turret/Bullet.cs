using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    private float e_health;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        if (target.tag=="Player")
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        Vector3 dir = target.position - transform.position;
        float distanceMove = speed * Time.deltaTime;
        if (dir.magnitude <= distanceMove)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceMove, Space.World);
    }
    void HitTarget()
    {
        Destroy(this.gameObject);
    }
    
    // Update is called once per frame
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<PatrolAI>().slow();
            print("eeeeslow");
        }
    }
}
