using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    [Serializable]
    public class Dialog
    {
        [TextArea(3,10)]
        public string Text;
        public string ActorName;
    }


    [CreateAssetMenu(fileName = "NewDialogueData", menuName = "Dialogue/Multiple Dialogue Data")]
    public class MultiDialogueData : ScriptableObject
    {
        // Lista de diálogos para diferentes momentos ou personagens
        public List<DialogueSet> DialogueSets;
    }

    [System.Serializable]
    public class DialogueSet
    {
        public string NpcName;  // Chave de identificação (ex: nome do personagem ou momento da história)
        public List<Dialog> Dialogs;  // Lista de falas específicas para este "conjunto"
    }

}
