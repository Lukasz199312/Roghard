using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player_Scripts
{

    public enum Sequence
    {
        FIRST,SECOND,BUSY
    }

    class Jump
    {
        public static bool IsJumping;
        public static bool Improve;

        private static float PowerFirst;
        private static float PowerSecond;
        private static float LastGroundCheckPosition;
        private static Legs LegController;
        private static Vector2 ForceVelocity;
        private static Rigidbody2D rigidbody2D;
        public static Sequence sequence;

        private static float time;
        private static float ImproveTime;

        public static void Initialize(float _PowerFirst, float _PowerSecond, Rigidbody2D _rigidbody2D, Legs _LegsController, Vector2 _ForceVelocity)
        {
            PowerFirst = _PowerFirst;
            PowerSecond = _PowerSecond;

            rigidbody2D = _rigidbody2D;
            ForceVelocity = _ForceVelocity;
            LegController = _LegsController;
            sequence = Sequence.FIRST;


        }

        public static void Start()
        {
            IsJumping = true;

            if (sequence == Sequence.FIRST)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);

                rigidbody2D.AddForce(new Vector2(ForceVelocity.x, ForceVelocity.y * PowerFirst));
                sequence = Sequence.SECOND;
                LegController.isTouchGround = false;
                Debug.Log("Sekwencja 1");
            }

            else if (sequence == Sequence.SECOND)
            {
                ControllVelocity();
                rigidbody2D.AddForce(new Vector2(ForceVelocity.x, ForceVelocity.y * PowerSecond));
                sequence = Sequence.BUSY;

                Debug.Log("Sekwencja 2");
            }

        }

        public static void UpdateStatus()
        {
            
            if (LegController.isTouchGround == true && (Time.time - time) > 0.5f)
            {
                time = Time.time;
                sequence = Sequence.FIRST;
                IsJumping = false;

            }

            else if (LegController.isTouchGround == false && IsJumping == false)
            {
                sequence = Sequence.SECOND;
            }

            if (LegController.isTouchGround == true && (Time.time - ImproveTime) > 0.6f)
            {
                ImproveTime = Time.time;
                Improve = true;

            }
        }

        private static void ControllVelocity()
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0.5f);
        }

    }


}








    //    private static bool isDoubleJumpReady;
    //    private static float PowerFirst;
    //    private static float PowerSecond;
    //    private static float LastGroundCheckPosition;
    //    private static Legs LegController;
    //    private static Vector2 ForceVelocity;
    //    private static Rigidbody2D rigidbody2D;

    //    public static Sequence sequence = Sequence.FIRST;

    //    public static void Initialize(float _PowerFirst, float _PowerSecond, Rigidbody2D _rigidbody2D, Legs _LegsController, Vector2 _ForceVelocity)
    //    {
    //        PowerFirst = _PowerFirst;
    //        PowerSecond = _PowerSecond;

    //        rigidbody2D = _rigidbody2D;
    //        ForceVelocity = _ForceVelocity;
    //        LegController = _LegsController;
    //        isDoubleJumpReady = true;

            
    //    }



    //    public static void Start()
    //    {

        

    //        if (isCanJump())
    //        {
               
    //            WhichIsJump();
    //        }
    //    }

    //    private static bool isCanJump() 
    //    {

    //        if (sequence == Sequence.NONE)
    //        {

    //            int a;
    //            Debug.Log("as");
    //        }

    //        if (LegController.isTouchGround == true && sequence == Sequence.NONE) sequence = Sequence.FIRST;

    //        if (sequence == Sequence.FIRST || sequence == Sequence.SECOND) return true;
    //        else return false;
    //    }

    //    private static void WhichIsJump()
    //    {
    //        if (sequence == Sequence.FIRST) FirstJump();
    //        else DoubleJump();
    //    }

    //    private static void FirstJump()
    //    {

    //        sequence = Sequence.SECOND;
    //        rigidbody2D.AddForce(new Vector2(ForceVelocity.x, ForceVelocity.y * PowerFirst));

    //    }

    //    private static void DoubleJump()
    //    {
    //        ControllVelocity();
    //        rigidbody2D.AddForce(new Vector2(ForceVelocity.x, ForceVelocity.y * PowerSecond));
    //        sequence = Sequence.NONE;
    //        Debug.Log("Second Jump");
    //    }

    //    private static void ControllVelocity()
    //    {
    //        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0.5f);
    //    }

    //    public static void UpdateDoubleJumpStatus()
    //    {
    //        if (isDoubleJumpReady == false && LegController.isTouchedGround() == true) isDoubleJumpReady = true;
    //    }

    //}