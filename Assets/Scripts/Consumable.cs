using System.Text;
using UnityEngine;

namespace DapperDino.TooltipUI
{
    [CreateAssetMenu(fileName = "New Consumable", menuName = "Items/Consumable")] // creating a new instance in unity
    public class Consumable : Item // inherits Item
    {
        [SerializeField] private Rarity rarity;
        [SerializeField] private string useText = "Something";

        public Rarity Rarity { get { return rarity; } }

        public override string ColouredName
        {
            get
            {
                string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColour); // turn this string into HTML? 
                return $"<color=#{hexColour}>{Name}</color>"; // use the html/string to change the color of the text/name dynamically
            }
        }

        public override string GetTooltipInfoText() // override just like java, define method details
        {
            StringBuilder builder = new StringBuilder(); // works like java as well

            builder.Append(Rarity.Name).AppendLine(); // AppendLine() creates a new line
            builder.Append("<color=green>Use: ").Append(useText).Append("</color>").AppendLine();
            builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

            return builder.ToString();
        }
    }
}