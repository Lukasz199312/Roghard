using UnityEngine;
using System.Collections.Generic;

public class PathDefinition : MonoBehaviour {

    private enum Direction { MOVE, BACK };

    public Transform[] Points;

    private Direction _Direction = Direction.MOVE;

    public IEnumerator<Transform> GetPathEnumerator()
    {
        if (Points == null || Points.Length < 1) yield break;

        var index = 0;
        while(true){
            if (index == Points.Length) yield break;
            yield return Points[index];


            if (index == Points.Length - 1) _Direction = Direction.BACK;
            else if (index == 0) _Direction = Direction.MOVE;


            switch (_Direction)
            {
                case Direction.MOVE: index++; break;
                case Direction.BACK: index--; break;
            }

        }
    }

    public void OnDrawGizmos()
    {
        if (Points == null || Points.Length < 2 )
            return;

        for (var i = 0; i < Points.Length - 1 ; i++)
        {
            Gizmos.DrawLine(Points[i].position, Points[i + 1].position);
        }
    }
}
