using Assets.Scripts.Helpers;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    private EGameState CurrentGameState = EGameState.FreeRoam;

    [SerializeField] private FeanorController _player;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            CurrentGameState = EGameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if(CurrentGameState == EGameState.Dialog)
            {
                CurrentGameState = EGameState.FreeRoam;
            }
        };

    }
    // Update is called once per frame
    void Update()
    {
        switch(CurrentGameState)
        {
            case (EGameState.FreeRoam):
                {
                    _player.HandleUpdate();
                    break;
                }
            case(EGameState.Dialog): 
                {
                    DialogManager.Instance.HandleUpdate();
                    break;
                }
            case (EGameState.Battle):
                {
                    break;
                }

        }
    }
}
