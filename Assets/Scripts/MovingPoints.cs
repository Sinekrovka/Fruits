using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingPoints : MonoBehaviour
{
    [SerializeField] private Transform pointSpawnPlayer;
    [SerializeField] private Transform postSpawnPoints;
    
    public static MovingPoints Inst;
    private Transform selectPlayer;
    private Transform selectImage;

    private void Awake()
    {
        Inst = this;
    }

    public void SetSelect(Transform player, Transform other)
    {
        selectPlayer = player;
        selectImage = other;
    }

    public void ReturnOnStartPoint()
    {
        if (selectPlayer != null)
        {
            selectPlayer.DOMove(pointSpawnPlayer.position, 0.5f);
        }
    }

    public void SetInChildren()
    {
        if (selectPlayer != null)
        {
            selectPlayer.SetParent(selectImage);
            selectPlayer.DOMove(selectImage.position, 0.1f);
            selectPlayer.GetComponent<DragAndDropCurrentObjects>().enabled = false;
            MusicController.Instance.PlayWin();
            SpawnerPointsSlots.Instance.ActivateNewPlayerDrop();
        }
    }

    public IEnumerator MovingPostSpawn(List<Transform> spawnObjects)
    {
        for (int i = 0; i < spawnObjects.Count; ++i)
        {
            spawnObjects[i].DOMove(postSpawnPoints.GetChild(i).position, 0.5f).SetEase(Ease.InOutBounce).OnComplete(delegate { MusicController.Instance.PlayCreate(); });
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void MoveForNextLoad(List<Transform> mounts)
    {
        for (int i = 0; i < mounts.Count; ++i)
        {
            mounts[i].DOMoveY(-30f, 0.5f).OnComplete(delegate
            {
                SpawnerPointsSlots.Instance.SpawnMounts();
            });
        }
    }

    public void MovePlayerOnStartPoint()
    {
        selectPlayer.DOMove(pointSpawnPlayer.position, 0.5f).SetEase(Ease.InOutBounce).OnComplete(delegate
        {
            selectPlayer.GetComponent<DragAndDropCurrentObjects>().enabled = true; });
    }
}
