using UnityEngine;

namespace DapperDino.TooltipUI // I don't understand this...
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private int sellPrice;

        public string Name { get { return name; } } // C# get method basically
        public abstract string ColouredName { get; } // don't need to define logic of an abract method
        public int SellPrice { get { return sellPrice; } }

        public abstract string GetTooltipInfoText(); // this class is abstract so anything that inherits this class needs to use this method
    }
}