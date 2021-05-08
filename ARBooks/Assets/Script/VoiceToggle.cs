using UnityEngine;
using UnityEngine.UI;

public class VoiceToggle : MonoBehaviour {
    public Graphic offGraphic;

    private bool voiceTag;

    public bool VoiceProperty {
        get{ return voiceTag; }
        set{ voiceTag = value; }
    }

    void Start() {
        Toggle voiceToggle = GetComponent<Toggle>();
        voiceToggle.onValueChanged.AddListener((value) => {
            OnValueChanged(value);
        });
        //初期状態を反映
        offGraphic.enabled = !voiceToggle.isOn;
    }
    
    //toggleの状態が変化したときに呼ぶイベント関数
    void OnValueChanged(bool value) {
        Debug.Log(value);
        if (offGraphic != null) {
            offGraphic.enabled = !value;
        }
        voiceTag = value;
    }
}
