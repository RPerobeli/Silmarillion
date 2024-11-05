using Assets.Scripts.Helpers;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    private EGameState CurrentGameState = EGameState.FreeRoam;
    private EStoryState _currentStoryState = EStoryState.BeforeMelkor;

    public EStoryState CurrentStoryState => _currentStoryState;

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

        InventoryManager.Instance.OnShowInventory += () =>
        {
            CurrentGameState = EGameState.Inventory;
            if (!InventoryManager.Instance.InventoryBox.activeSelf)
            {
                InventoryManager.Instance.InventoryBox.SetActive(true);
            }

        };
        InventoryManager.Instance.OnHideInventory += () =>
        {
            if (CurrentGameState == EGameState.Inventory)
                CurrentGameState = EGameState.FreeRoam;
            
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
            case (EGameState.Inventory):
                {
                    InventoryManager.Instance.HandleUpdate();
                    break;
                }

        }
    }


    public static GameStateHandler Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
