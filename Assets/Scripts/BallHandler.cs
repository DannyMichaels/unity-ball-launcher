using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
  [SerializeField] private Rigidbody2D currentBallRigidBody;

  private Camera mainCamera;

  void Awake()
  {
    mainCamera = Camera.main;
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    // don't run the rest if we're not touching the touch screen
    if (!IsTouchScreenPressed())
    {
      currentBallRigidBody.isKinematic = false; // affected by physics system
      return;
    }

    currentBallRigidBody.isKinematic = true; // no longer affected by physics system;

    // get current touch position
    Vector2 touchPosition = GetCurrentTouchPosition(); //  touch position in terms of pixels on the screen
    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition); // position in terms of units inside the game world.


    currentBallRigidBody.position = worldPosition;
  }

  Vector2 GetCurrentTouchPosition()
  {
    return Touchscreen.current.primaryTouch.position.ReadValue();
  }

  bool IsTouchScreenPressed()
  {
    return Touchscreen.current.primaryTouch.press.isPressed;
  }
}
