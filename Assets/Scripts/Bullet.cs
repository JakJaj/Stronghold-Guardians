using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform Target;

    public float speed = 70f;
    public  GameObject impactEffect;

    public void Seek (Transform _target)
    {
        Target = _target;
    }

    void Update () {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget ()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(Target.gameObject);
        Destroy(gameObject);
    }
}