using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BackgroundScaler : MonoBehaviour {
    [SerializeField] private Image backgroundImage;
    [SerializeField] private RectTransform rectTransform;
    private float _ratio;

    // Start is called before the first frame update
    void Start() {
        backgroundImage = GetComponent<Image>();
        rectTransform = backgroundImage.rectTransform;
        _ratio = backgroundImage.sprite.bounds.size.x / backgroundImage.sprite.bounds.size.y;
    }

    // Update is called once per frame
    void Update() {
        if (!rectTransform)
            return;

        //Scale image proportionally to fit the screen dimensions, while preserving aspect _ratio
        if (Screen.height * _ratio >= Screen.width) {
            rectTransform.sizeDelta = new Vector2(Screen.height * _ratio, Screen.height);
        }
        else {
            rectTransform.sizeDelta = new Vector2(Screen.width, Screen.width / _ratio);
        }
    }
}