using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DapperDino.TooltipUI
{
    public class TooltipPopup : MonoBehaviour
    {
        [SerializeField] private GameObject popupCanvasObject; // to enable and disable popup
        [SerializeField] private RectTransform popupObject;
        [SerializeField] private TextMeshProUGUI infoText;
        [SerializeField] private Vector3 offset; // for mouse position
        [SerializeField] private float padding; // makes popup not leave screen

        private Canvas popupCanvas; 

        private void Awake()
        {
            popupCanvas = popupCanvasObject.GetComponent<Canvas>(); // get actual canvas 
        }

        private void Update()
        {
            FollowCursor();
        }

        private void FollowCursor()
        {
            if (!popupCanvasObject.activeSelf) { return; } 

            Vector3 newPos = Input.mousePosition + offset;
            newPos.z = 0f;
            float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding;
            if (rightEdgeToScreenEdgeDistance < 0)
            {
                newPos.x += rightEdgeToScreenEdgeDistance;
            }
            float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor / 2) + padding;
            if (leftEdgeToScreenEdgeDistance > 0)
            {
                newPos.x += leftEdgeToScreenEdgeDistance;
            }
            float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
            if (topEdgeToScreenEdgeDistance < 0)
            {
                newPos.y += topEdgeToScreenEdgeDistance;
            }
            popupObject.transform.position = newPos;
        }

        public void DisplayInfo(Item item)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<size=15>").Append(item.ColouredName).Append("</size>").AppendLine();
            builder.Append(item.GetTooltipInfoText());

            infoText.text = builder.ToString();

            popupCanvasObject.SetActive(true); // enable popup
            LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject); // ensure size is correct
        }

        public void HideInfo()
        {
            popupCanvasObject.SetActive(false);
        }
    }
}