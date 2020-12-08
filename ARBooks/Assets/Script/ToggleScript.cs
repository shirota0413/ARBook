using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {
    public Graphic offGraphic;

    private bool tag;

    public bool Property {
        get{ return tag; }
        set{ tag = value; }
    }

    void Start() {
        Toggle toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((value) => {
            OnValueChanged(value);
        });
        //初期状態を反映
        offGraphic.enabled = !toggle.isOn;
    }
    
    void OnValueChanged(bool value) {
        Debug.Log(value);
        if (offGraphic != null) {
            offGraphic.enabled = !value;
        }
        tag = value;
    }
}
