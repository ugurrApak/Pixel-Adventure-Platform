using System.Collections;
using UnityEngine;

public class Saw : MonoBehaviour
{
    float speed = 2f;
    bool canHit = true;
    private void Update()
    {
        transform.Rotate(0f,0f,360f * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canHit)
        {
            canHit = false;
            StartCoroutine(WaitAfterHit(collision));
        }
    }
    IEnumerator WaitAfterHit(Collision2D collision)
    {
        IHitable hitable = collision.gameObject.GetComponent<IHitable>();
        if (hitable != null)
        {
            hitable.GetHit(1, gameObject);
        }
        yield return new WaitForSeconds(0.7f);
        canHit = true;
    }
}
