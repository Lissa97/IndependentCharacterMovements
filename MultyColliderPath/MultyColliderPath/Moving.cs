//@LissaArt
using UnityEngine;

namespace MultyColliderPath 
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    public class Moving : MonoBehaviour
    {
        Animator _animator;
        Rigidbody _rgb;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _rgb = GetComponent<Rigidbody>();   
        }

        Vector2 _move    = new Vector2(0, 0);

        void FixedUpdate()
        {
            
        }

        public void Forward(bool not = false)
        {
            _move.y = not ? 0 : 1;
        }
        public void Back(bool not = false)
        {
            _move.y = not ? 0 : -1;
        }
        public void Right(bool not = false)
        {
            _move.x = not ? 0 : 1;
        }
        public void Left(bool not = false)
        {
            _move.x = not ? 0 : -1;
        }
    }
}


