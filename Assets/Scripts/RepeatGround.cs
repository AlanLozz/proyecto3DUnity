using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
  private Vector3 startPosition;
  private float repeatWidth;
  // Start is called before the first frame update
  void Start()
  {
    startPosition = transform.position;
    repeatWidth = GetComponent<BoxCollider>().size.x / 0.6f;
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < startPosition.x - repeatWidth)
    {
      transform.position = startPosition;
    }
  }
}
