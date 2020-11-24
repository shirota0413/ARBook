﻿using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Dialog : MonoBehaviour {

    public enum DialogResult
    {
        OK,
        Cancel,
    }
    
    // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; set; }
    
    // OKボタンが押されたとき
    public void OnOk()
    {
        this.FixDialog?.Invoke(DialogResult.OK);
        Destroy(this.gameObject);
        SceneManager.LoadScene("SampleScene");
    }
    
    // Cancelボタンが押されたとき
    public void OnCancel()
    {
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke(DialogResult.Cancel);
        gameObject.SetActive(false);
        
    }
}
