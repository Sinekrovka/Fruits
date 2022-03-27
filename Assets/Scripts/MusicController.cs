using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource create;

    public static MusicController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayWin()
    {
        win.Play();
    }

    public void PlayCreate()
    {
        create.Play();
    }
}
