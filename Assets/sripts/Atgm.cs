using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atgm : Bullet
{
    private Vector3 _destination;
    private Transform _shootPoint;

    public override void SetVariables(int damage, float lifeTime, bool isCannonDamaged, GameObject cannon)
    {
        transform.rotation = cannon.transform.rotation;
        var cannonColliders = cannon.GetComponents<Collider>();
        if (cannonColliders != null)
        {
            foreach (Collider collider in cannon.GetComponents<Collider>())
            {
                Physics.IgnoreCollision(collider, _collider);
            }
        }
        
        _penetrationDamage = damage;
        m_Rigidbody.AddForce(speed*transform.forward, ForceMode.Impulse);
    }
    public override void Rickoshet(armor_panel arrmor, float anngleKoefecent, Collider collision)
    {
        
    }

    private void FixedUpdate()
    {
        if(_shootPoint == null)
        {
            return;
        }
        var ray = new Ray(_shootPoint.position, _shootPoint.forward);
        _destination = ray.origin + ray.direction* 1000f;
        Debug.DrawLine(_shootPoint.position, _destination, Color.cyan, 0f);
        transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * speed);
    }

    public void SetShootPoint(Transform shootPoint)
    {
        _shootPoint = shootPoint;

    }
}
