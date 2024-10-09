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
        public List<string> Lines;
        public string ActorName;
    }
}
