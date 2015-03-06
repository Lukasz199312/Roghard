using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour
{

    public enum FollowType { MoveToward, LERP };
    public PathDefinition Path;
    public FollowType Type = FollowType.MoveToward;
    [Range(0,30)]
    public float Speed = 5;
    public float DistanceToGoal = 0.1f;

    private Transform Player;
    private Vector3 LastPosition;

    private IEnumerator<Transform> Position;

    // Use this for initialization
    void Start()
    {
        if (Path == null)
        {
            Debug.Log("Path can't be null ", gameObject);
            return;
        }

        Position = Path.GetPathEnumerator();
        
        Position.MoveNext();
        if (Position.Current == null) return;

        transform.position = Position.Current.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Type == FollowType.MoveToward)
            transform.position = Vector2.MoveTowards(transform.position, Position.Current.position, Speed * Time.deltaTime);
        else if (Type == FollowType.LERP)
            transform.position = Vector2.Lerp(transform.position, Position.Current.position, Speed * Time.deltaTime);

        var sqrMagnitude = (transform.position - Position.Current.position).sqrMagnitude;
        if (sqrMagnitude < DistanceToGoal * DistanceToGoal) Position.MoveNext();

        //if (Player != null)
        //{
           
        //    Player.position = Vector2.MoveTowards(Player.position, new Vector2(Player.position.x, Position.Current.position.y), Speed * Time.deltaTime);
        //    Debug.Log(Player.position);
        //}

        if (Player == null) return;

        if (transform.position.y != LastPosition.y)
        {
            var result = transform.position.y - LastPosition.y;

            Player.Translate(new Vector3(0, result, 0));

            LastPosition = new Vector3(LastPosition.x, transform.position.y);
        }

        if (transform.position.x != LastPosition.x)
        {
            var result = transform.position.x - LastPosition.x;

            Player.Translate(new Vector3(result, 0,0));

            LastPosition = new Vector3(transform.position.x, LastPosition.y);
        }
    }

    void LateUpdate() {


        //Player.position = new Vector3(Player.position.x, transform.position.y);

    }



    void OnCollisionStay2D(Collision2D Collision_Object){

        if (Player == null)
        {
            Player = Collision_Object.transform;
            LastPosition = transform.position;

        }
       

    }

    void OnCollisionEnter2D(Collision2D Collision_Object)
    {

        if (Player == null)
        {
            Player = Collision_Object.transform;
            LastPosition = transform.position;
        }

    }
    void OnCollisionExit2D(Collision2D Collision_Object)
    {
        Player = null;

    }
}
