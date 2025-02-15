using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEditor.Progress;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Model
{
    public class InventoryItem 
    {
        private InventoryItemController Controller;
        public Item Item { get; set; }
        public int Quantity { get; set; }

    }

}
