using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformAden : RaycastControllerAden
{
    public LayerMask passengerMask;
    public float speed;

    public Vector3 start;
    public Vector3 destination;

    Vector3 currentDestination;

    public override void Start()
    {
        transform.position = start;
        currentDestination = start;

        base.Start();
    }

    void Update()
    {
        UpdateRaycastOrigins();

        if (transform.position != currentDestination)
        {
            Vector3 velocity = CalculateVelocity();

            MovePassengers(velocity);
            transform.Translate(velocity);
        }
    }

    Vector3 CalculateVelocity()
    {
        float distToMove = Time.deltaTime * speed;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, currentDestination, distToMove);
        return newPosition - transform.position;
    }

    void MovePassengers(Vector3 velocity)
    {
        HashSet<Transform> movedPassengers = new HashSet<Transform>();

        float xDir = Mathf.Sign(velocity.x);
        float yDir = Mathf.Sign(velocity.y);

        if (velocity.y != 0.0f)
        {
            float rayLength = Mathf.Abs(velocity.y) + skinWidth + extraInnerRayDist;

            for (int i = 0; i < numVerticalRays; ++i)
            {
                Vector2 rayOrigin = (yDir == 1) ? raycastOrigins.topLeft : raycastOrigins.bottomLeft;
                rayOrigin.x += i * verticalRaySpacing;
                rayOrigin.y += -yDir * extraInnerRayDist;
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * yDir, rayLength, passengerMask);

                Debug.DrawRay(rayOrigin, Vector2.up * yDir, Color.red);

                if (hit && !movedPassengers.Contains(hit.transform))
                {
                    movedPassengers.Add(hit.transform);
                    float pushX = (yDir == 1) ? velocity.x : 0.0f;
                    float pushY = velocity.y - (hit.distance - skinWidth - extraInnerRayDist) * yDir;

                    hit.transform.Translate(new Vector3(pushX, pushY));
                }
            }
        }

        if (velocity.x != 0.0f)
        {
            float rayLength = Mathf.Abs(velocity.x) + skinWidth + extraInnerRayDist;

            for (int i = 0; i < numHorizontalRays; ++i)
            {
                Vector2 rayOrigin = (xDir == 1) ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;
                rayOrigin.x += -xDir * extraInnerRayDist;
                rayOrigin.y += i * horizontalRaySpacing;
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * xDir, rayLength, passengerMask);

                Debug.DrawRay(rayOrigin, Vector2.right * xDir, Color.red);

                if (hit && !movedPassengers.Contains(hit.transform))
                {
                    movedPassengers.Add(hit.transform);
                    float pushX = velocity.x - (hit.distance - skinWidth - extraInnerRayDist) * xDir;

                    hit.transform.Translate(new Vector3(pushX, 0.0f));
                }
            }
        }

        // Platform moving down or only horizontally
        if (yDir == -1.0f || (velocity.y == 0.0f && velocity.x != 0.0f))
        {
            float rayLength = skinWidth * 2 + extraInnerRayDist;

            for (int i = 0; i < numVerticalRays; ++i)
            {
                Vector2 rayOrigin = raycastOrigins.topLeft;
                rayOrigin.x += i * verticalRaySpacing;
                rayOrigin.y -= extraInnerRayDist;

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);

                Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.red);

                if (hit && !movedPassengers.Contains(hit.transform))
                {
                    movedPassengers.Add(hit.transform);
                    float pushX = velocity.x;
                    float pushY = velocity.y;

                    hit.transform.Translate(new Vector3(pushX, pushY));
                }
            }
        }

        // Wall jumping check
        {
            float rayLength = skinWidth * 2 + extraInnerRayDist;

            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < numHorizontalRays; ++j)
                {
                    Vector2 rayOrigin = (i == 0) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
                    rayOrigin.x += (i == 0) ? extraInnerRayDist : -extraInnerRayDist;
                    rayOrigin.y += j * horizontalRaySpacing;

                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, (i == 0) ? Vector2.left : Vector2.right, rayLength, passengerMask);

                    Debug.DrawRay(rayOrigin, ((i == 0) ? Vector2.left : Vector2.right) * rayLength, Color.red);

                    if (hit && !movedPassengers.Contains(hit.transform) && hit.transform.gameObject.GetComponent<PlayerControllerAden>().IsWallHanging())
                    {
                        movedPassengers.Add(hit.transform);
                        float pushX = velocity.x;
                        float pushY = velocity.y;

                        hit.transform.Translate(new Vector3(pushX, pushY));
                    }
                }
            }
        }
    }

    public void MoveToStart()
    {
        currentDestination = start;
    }

    public void MoveToDestination()
    {
        currentDestination = destination;
    }

    struct PassengerMovement
    {
        public Transform transform;
        public Vector3 velocity;
        public bool standingOnPlatform;
        public bool moveBeforePlatform;

        public PassengerMovement(Transform _transform, Vector3 _velocity, bool _standingOnPlatform, bool _moveBeforePlatform)
        {
            transform = _transform;
            velocity = _velocity;
            standingOnPlatform = _standingOnPlatform;
            moveBeforePlatform = _moveBeforePlatform;
        }
    }
}
