using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour {

    public void Instagram()
    {
        Application.OpenURL("instagram://user?username=atisapp");
    }

    public void Telegram()
    {
        Application.OpenURL("https://t.me/atisapp");
    }

    public void AtisApp()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.atisapp.android&hl=en");
    }
}
