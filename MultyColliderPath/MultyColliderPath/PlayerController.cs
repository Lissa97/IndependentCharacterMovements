//@LissaArt
using UnityEngine;


namespace MultyColliderPath
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

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                _move.Forward();
                ForceForward = true;
            }

            if (Input.GetAxis("Vertical") == 0)
            {
                _move.Forward(true);

                ForceForward = false;

            }
        }

        [HideInInspector]
        public bool ForceForward = false;

    }
}
