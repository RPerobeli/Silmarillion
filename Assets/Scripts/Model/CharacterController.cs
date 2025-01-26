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
        public SpriteRenderer SpriteRenderer;
        public float ConstCollision = 0.5f;

        public LayerMask SolidObjectsLayer;
        public LayerMask InteractableLayer;
        protected Transform PlayerTransform;

        protected bool IsWalkable(Vector3 targetPos)
        {
            if (Physics2D.OverlapCircle(targetPos, ConstCollision, SolidObjectsLayer | InteractableLayer) is not null)
                return false;
            return true;
        }

        protected void LookAtPlayer()
        {
            AtualizarPositionMainChar();

            // Calcula a direção do jogador em relação ao NPC
            Vector3 direction = PlayerTransform.position - transform.position;

            // Normaliza a direção para um vetor de unidade (magnitude = 1)
            direction.Normalize();

            // Verifica se o NPC deve virar para a esquerda ou para a direita
            Animator.SetFloat(nameof(direction.x), direction.x);
            Animator.SetFloat(nameof(direction.y), direction.y);
        }

        protected void AtualizarPositionMainChar()
        {
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                PlayerTransform = player.transform;
            }
            else
            {
                Debug.LogError("Feanor não encontrado na cena!");
            }
        }

        protected IEnumerator Move(Vector3 targetPos)
        {
            IsMoving = true;
            while ((targetPos - Position).sqrMagnitude > Mathf.Epsilon)
            {
                SpriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 1);
                transform.position = Vector3.MoveTowards(Position, targetPos, MoveSpeed * Time.deltaTime);
                yield return null;
            }
            Position = targetPos;
            IsMoving = false;
        }
    }
}
