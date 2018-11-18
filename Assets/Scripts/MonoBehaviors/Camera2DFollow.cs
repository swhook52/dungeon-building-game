using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{

    public string TagNameToFollow = "Hero";
    public float Damping = 0.5f;
    public Transform StartOfLevel;
    public Transform EndOfLevel;

    private Transform[] _targets;
    private int _targetLength;
    private Vector3 _currentVelocity;
    private float _startOfLevelX;
    private float _endOfLevelX;

    // Use this for initialization
    void Start()
    {
        _startOfLevelX = StartOfLevel.position.x;
        _endOfLevelX = EndOfLevel.position.x;
        LookForTargets();
    }

    void Update()
    {
        if (_targets == null || _targets.Length == 0)
        {
            LookForTargets();
            return;
        }

        float minX = _targets[0].position.x;
        float maxX = minX;
        float currentX;

        for (int i = 1; i < _targetLength; i++)
        {
            currentX = _targets[i].position.x;

            if (currentX > maxX)
                maxX = currentX;

            if (currentX < minX)
                minX = currentX;
        }

        var currentPosition = transform.position;
        var distanceBetweenPlayers = maxX - minX;
        var newX = Mathf.Clamp(minX + (distanceBetweenPlayers / 2f), _startOfLevelX, _endOfLevelX);

        var targetPosition = new Vector3(newX, currentPosition.y, currentPosition.z);
        var newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, Damping);

        transform.position = newPosition;
    }

    private void LookForTargets()
    {
        var targetObjects = GameObject.FindGameObjectsWithTag(TagNameToFollow);
        _targetLength = targetObjects.Length;
        _targets = new Transform[_targetLength];
        for (int i = 0; i < _targetLength; i++)
        {
            _targets[i] = targetObjects[i].transform;
        }
    }

    /*
    private void AnotherUpdate()
    {
        // only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target.position - lastTargetPosition).x;
        
        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;
        
               if (updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
                   }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }
        
        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
        newPos.y = newPos.y + offsetY;
        newPos.z = transform.position.z;
        
        transform.position = newPos;
        
        lastTargetPosition = target.position;
        }
    }
    */
}
