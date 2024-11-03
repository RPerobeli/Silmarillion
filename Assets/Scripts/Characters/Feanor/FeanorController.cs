using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeanorController : Assets.Scripts.Interfaces.CharacterController, IInteractable
{
    private Vector2 Entrada;
    private LayerMask BattleLayer;


    private bool _isInventario;

    // Start is called before the first frame update
    public void Start()
    {
        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        #region Movement
        Position = transform.position;
        if(!IsMoving)
        {
            Entrada.x = Input.GetAxisRaw("Horizontal");
            Entrada.y = Input.GetAxisRaw("Vertical");

            if (Entrada.x != 0) Entrada.y = 0;
            if(Entrada != Vector2.zero)
            {
                Animator.SetFloat(nameof(Entrada.x), Entrada.x);
                Animator.SetFloat(nameof(Entrada.y), Entrada.y);

                Vector3 targetPos = Position;
                targetPos.x += Entrada.x;
                targetPos.y += Entrada.y;

                if(IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        Animator.SetBool(nameof(IsMoving), IsMoving);
        #endregion

        #region Inventario
        if(!_isInventario)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                
            }
        }
        #endregion

        #region Interact
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
        #endregion
    }
    public void Interact()
    {
        Vector3 facingDirection = new Vector3(Animator.GetFloat(nameof(Entrada.x)), Animator.GetFloat(nameof(Entrada.y)));
        Vector3 interactPosition = Position + facingDirection;

        Debug.DrawLine(Position, interactPosition, Color.red, 1f);
        Collider2D collider = Physics2D.OverlapCircle(interactPosition, 0.2f, InteractableLayer);
        if (collider is not null)
        {
            collider.GetComponent<IInteractable>()?.Interact();
        }
    }
    


}
