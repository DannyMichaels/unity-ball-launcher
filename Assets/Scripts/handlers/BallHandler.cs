using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{

  private Ball currentBall;
  private Camera mainCamera;
  private bool isDragging;
  public float detachDelayDuration = .5f;

  void Awake()
  {
    currentBall = FindObjectOfType<Ball>();
    mainCamera = Camera.main;
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (!currentBall) return;

    // don't run the rest if we're not touching the touch screen
    if (!IsTouchScreenPressed())
    {
      if (isDragging)
      {
        currentBall.Launch(detachDelayDuration);
      }

      isDragging = false;
      return;
    }

    isDragging = true;
    currentBall.EnableKinematic();

    // get current touch position
    Vector2 touchPosition = GetCurrentTouchPosition(); //  touch position in terms of pixels on the screen
    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition); // position in terms of units inside the game world.


    currentBall.SetPosition(worldPosition);
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
