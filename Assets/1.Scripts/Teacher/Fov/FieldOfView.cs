using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Header("Sight Elements")]
    public float eyeRadius = 5f;
    [Range(0, 360)]
    public float eyeAngle = 90f;

    [Header("Search Elements")]

    public LayerMask targetLayerMask;
    public LayerMask blockLayerMask;

    private List<Transform> targetLists = new List<Transform>();
    [SerializeField]
    private Transform firstTarget = null;
    public float distanceTarget = 0.0f;

    public List<Transform> TargetLists => targetLists;
    public Transform FirstTarget => firstTarget;
    public float DistanceTarget => distanceTarget;

    public AudioSource audioSource;

    void FindTargets()
    {
        distanceTarget = 0.0f;
        firstTarget = null;
        targetLists.Clear();

        Collider[] overlapSphereTargets = Physics.OverlapSphere(transform.position, eyeRadius, targetLayerMask);

        for (int i = 0; i < overlapSphereTargets.Length; i++)
        {
            Transform target = overlapSphereTargets[i].transform;
            Vector3 LookAtTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, LookAtTarget) < eyeAngle / 2)
            {
                float nowFirstDistanceTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, LookAtTarget, nowFirstDistanceTarget, blockLayerMask))
                {
                    targetLists.Add(target);
                    if (firstTarget == null || (distanceTarget > nowFirstDistanceTarget))
                    {
                        Debug.Log("Find Target!" + target);
                        firstTarget = target;
                        distanceTarget = nowFirstDistanceTarget;
                    }
                }
            }
        }
    }

    public float delayFindTime = 0.2f;

    private void FixedUpdate()
    {
        FindTargets();
    }

    public Vector3 findTargetAngle(float degrees, bool flagGlobalAngle)
    {
        if (!flagGlobalAngle)
        {
            degrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(degrees * Mathf.Deg2Rad), 0, Mathf.Cos(degrees * Mathf.Deg2Rad));
    }
}
