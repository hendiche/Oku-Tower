using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Destroy : MonoBehaviour
{
    public Transform explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision) {

      ContactPoint contact = collision.contacts[0];
      Vector3 pos = contact.point;

      if(collision.gameObject.tag != "enemy")
      {
        Instantiate (explosionPrefab, pos, Quaternion.identity);
        Destroy(this.gameObject);

      HandModelBase hand = collision.gameObject.GetComponentInParent<HandModelBase>();
      if(hand != null)
      {
          Debug.Log("collide");
          Instantiate (explosionPrefab, pos, Quaternion.identity);
          Destroy(this.gameObject);
      }
    }

    }

    void OnDestroy() {
      Destroy(transform.parent.gameObject);
    }
}
