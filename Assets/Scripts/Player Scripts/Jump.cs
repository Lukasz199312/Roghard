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
        public static bool Improve = true;

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
            
            if (LegController.isTouchGround == true && (Time.time - time) > 0.6f)
            {
                time = Time.time;
                sequence = Sequence.FIRST;
                IsJumping = false;

            }

            else if (LegController.isTouchGround == false && IsJumping == false)
            {
                sequence = Sequence.SECOND;
            }

            if (LegController.isTouchGround == true && (Time.time - ImproveTime) > 1.0f)
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
