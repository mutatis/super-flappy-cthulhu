using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour
{
    public void Open(string url)
    {
        Application.OpenURL(url);
    }
}
