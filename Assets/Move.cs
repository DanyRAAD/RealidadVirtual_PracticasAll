using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Move : MonoBehaviour
{
    public GameObject model;
    public ObserverBehaviour[] ImageTargets;
    public int currentTarget;
    public float speed = 1.0f;
    private bool isMoving = false;

    // Lista de los índices de los marcadores a los que se moverá el panda
    private List<int> moveSequence = new List<int> { 0, 1, 0, 2, 3, 2, 4 }; // 0: panda, 1: chocolate, 2: fruta, 3: miel, 4: bambú
    private int moveIndex = 0;

    public void MoveToNextMarker()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveModel());
        }
    }

    private IEnumerator MoveModel()
    {
        isMoving = true;

        // Obtener el índice del siguiente objetivo basado en la secuencia
        int targetIndex = moveSequence[moveIndex];

        if (targetIndex < 0 || targetIndex >= ImageTargets.Length)
        {
            Debug.Log("Target index is out of range.");
            isMoving = false;
            yield break;
        }

        ObserverBehaviour target = ImageTargets[targetIndex];
        if (target == null || (target.TargetStatus.Status != Status.TRACKED && target.TargetStatus.Status != Status.EXTENDED_TRACKED))
        {
            Debug.Log("No target detected.");
            isMoving = false;
            yield break;
        }

        Vector3 startPosition = model.transform.position;
        Vector3 endPosition = target.transform.position;

        float journey = 0;

        while (journey <= 1f)
        {
            journey += Time.deltaTime * speed;
            model.transform.position = Vector3.Lerp(startPosition, endPosition, journey);
            yield return null;
        }


        moveIndex = (moveIndex + 1) % moveSequence.Count;

        isMoving = false;
    }
}
