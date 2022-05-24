using UnityEngine;

public class SelectableCharacter : MonoBehaviour {

    public SpriteRenderer selectImage;

    private void Awake() {
        selectImage.enabled = false;
    }

    //Turns off the sprite renderer
    public void TurnOffSelector()
    {
        selectImage.enabled = false;
        if(Resources.SelectedUnits.Contains(transform.parent.gameObject))
            Resources.SelectedUnits.Remove(transform.parent.gameObject);
    }

    //Turns on the sprite renderer
    public void TurnOnSelector()
    {
        selectImage.enabled = true;
        if (!Resources.SelectedUnits.Contains(transform.parent.gameObject))
            Resources.SelectedUnits.Add(transform.parent.gameObject);
    }

}
