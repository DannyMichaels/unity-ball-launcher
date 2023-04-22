using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
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
      return;
    }

    // get current touch position
    Vector2 touchPosition = GetCurrentTouchPosition();
    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

    Debug.Log(worldPosition);
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
