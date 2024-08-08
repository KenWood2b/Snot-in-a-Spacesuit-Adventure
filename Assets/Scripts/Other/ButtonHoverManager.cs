using UnityEngine;

public class ButtonHoverManager : MonoBehaviour
{
    public RectTransform characterIcon;
    public Vector3 offset = new Vector3(50, 0, 0);

    public void MoveCharacterToButton(RectTransform buttonTransform)
    {
        characterIcon.position = buttonTransform.position + offset;
    }
}
