using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public static Ball instance; // instance = Singleton: create a version of this script that only one version of it can exist
  public Rigidbody2D rigidBody;
  public SpringJoint2D springJoint;

  void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  public void SetPosition(Vector3 pos)
  {
    rigidBody.position = pos;
  }

  public void EnableKinematic()
  {
    rigidBody.isKinematic = true; // no longer affected by physics system;
  }

  public void DisableKinematic()
  {
    rigidBody.isKinematic = false;
  }

  public void Launch(float delayDuration)
  {
    rigidBody.isKinematic = false; // affected by physics system
    rigidBody = null; // clear the reference

    Invoke(nameof(Detach), delayDuration);
  }


  public void Detach()
  {
    springJoint.enabled = false; // it won't try to pull the ball anymore;
    springJoint = null;
  }
}
