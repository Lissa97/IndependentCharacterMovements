//@LissaArt
using UnityEngine;

namespace SingleColliderPath
{
    [RequireComponent(typeof(Moving))]
    internal class PlayerController: MonoBehaviour
    {
        Moving _move;
        private void Start()
        {
            _move = GetComponent<Moving>();
        }

        void FixedUpdate()
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                _move.Right();
                ForceRight = true;
            }
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                _move.Left();
                ForceLeft = true;
            }
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                _move.Forward();
                ForceForward = true;
            }
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                _move.Back();
                ForceBack = true;
            }

            if (Input.GetAxis("Horizontal") == 0)
            {
                _move.Right(true);
                _move.Left(true);

                ForceRight = false;
                ForceLeft = false;

            }

            if (Input.GetAxis("Vertical") == 0)
            {
                _move.Forward(true);
                _move.Back(true);

                ForceForward = false;
                ForceBack = false;

            }
        }

        [HideInInspector]
        public bool ForceForward = false;
        [HideInInspector]
        public bool ForceBack = false;
        [HideInInspector]
        public bool ForceRight = false;
        [HideInInspector]
        public bool ForceLeft = false;
    }
}
