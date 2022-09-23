using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject efectoImpacto;
    public void Buscar(Transform _target){
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanciaFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanciaFrame){
            HitTarget();
            return;
        }
        transform.Translate (dir.normalized * distanciaFrame, Space.World);
    }

    void HitTarget(){
        
        GameObject efecto = Instantiate(efectoImpacto, transform.position, transform.rotation);
        Destroy(efecto, 1f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
