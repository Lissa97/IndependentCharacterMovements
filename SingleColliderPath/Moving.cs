//@LissaArt
using UnityEngine;

namespace SingleColliderPath 
{
    internal class Moving : MonoBehaviour
    {
        Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        Vector2 _move    = new Vector2(0, 0);
        Vector2 _curMove = new Vector2(0, 0);

        void FixedUpdate()
        {
            _curMove.x += (_move.x - _curMove.x) * Time.deltaTime * 10;
            _curMove.y += (_move.y - _curMove.y) * Time.deltaTime * 10;

            _animator.SetFloat("xSpeed", _curMove.x);
            _animator.SetFloat("zSpeed", _curMove.y);
            

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
