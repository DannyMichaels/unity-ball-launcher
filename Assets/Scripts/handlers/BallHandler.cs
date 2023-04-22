using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour

{
  public GameObject ballPrefab;
  [SerializeField] private Rigidbody2D pivot;
  [SerializeField] private float respawnDelay;
  [SerializeField] private float detachDelayDuration = .5f;
  private Ball currentBall;
  private Camera mainCamera;
  private bool isDragging;

  void Awake()
  {
    mainCamera = Camera.main;
    SpawnNewBall();
  }

  public void SpawnNewBall()
  {
    GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
    currentBall = ballInstance.GetComponent<Ball>();
    currentBall.rigidBody = ballInstance.GetComponent<Rigidbody2D>();
    currentBall.springJoint = ballInstance.GetComponent<SpringJoint2D>();
    currentBall.springJoint.connectedBody = pivot;
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (!pivot) return;

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
