using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;

namespace Assets.Scripts.Interfaces
{
    public class CharacterController : MonoBehaviour
    {
        public float MoveSpeed;
        protected Vector3 Position;
        protected bool IsMoving;
        protected Animator Animator;
        protected SpriteRenderer SpriteRenderer;
        public float ConstCollision = 0.01f;

        public LayerMask SolidObjectsLayer;
        public LayerMask InteractableLayer;


        protected bool IsWalkable(Vector3 targetPos)
        {
            if (Physics2D.OverlapCircle(targetPos, ConstCollision, SolidObjectsLayer | InteractableLayer) is not null)
                return false;
            return true;
        }

        

        protected IEnumerator Move(Vector3 targetPos)
        {
            IsMoving = true;
            while ((targetPos - Position).sqrMagnitude > Mathf.Epsilon)
            {
                transform.position = Vector3.MoveTowards(Position, targetPos, MoveSpeed * Time.deltaTime);
                yield return null;
            }
            Position = targetPos;
            IsMoving = false;
        }
    }
}
