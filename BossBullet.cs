using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D theRB;

    public int damageAmout;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = transform.position - PlayerHealthController.instance.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        AudioManager.instance.PlaySFXAdjusted(2);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = -transform.right * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer(damageAmout);
        }

        if(impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        AudioManager.instance.PlaySFXAdjusted(3);
    }
}
