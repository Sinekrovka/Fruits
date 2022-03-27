
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPointsSlots : MonoBehaviour
{
    [SerializeField] private Transform pointsSpawnMounts;
    [SerializeField] private Transform pointSpawnPlayer;
    [SerializeField] private PairsMountsPlayers pairsData;
    
    private List<Transform> mounts;
    private List<Transform> players;

    public static SpawnerPointsSlots Instance;
    private int counts;

    private void Awake()
    {
        Instance = this;
        counts = pointsSpawnMounts.childCount;
        mounts = new List<Transform>();
        players = new List<Transform>();
        SpawnMounts();
        
    }
    
    public void SpawnMounts()
    {
        if (mounts.Count > 0)
        {
            foreach (var VARIABLE in mounts)
            {
                GameObject v = VARIABLE.gameObject;
                mounts.Remove(VARIABLE);
                Destroy(v);
            }
        }
        mounts = new List<Transform>();
        players = new List<Transform>();
        
        
        Debug.Log(counts);
        for (int i = 0; i < counts; ++i)
        {
            PairsMountsPlayers.Pair pair = pairsData.GetRandomPair();
            GameObject _player = Instantiate(pair.player, pointSpawnPlayer.position + Vector3.right*20, Quaternion.identity);
            GameObject _mount = Instantiate(pair.mount, pointsSpawnMounts.GetChild(i).position, Quaternion.identity);
            mounts.Add(_mount.transform);
            players.Add(_player.transform);
            _player.GetComponent<DragAndDropCurrentObjects>().enabled = false;
            _player.SetActive(false);
        }
        players[0].gameObject.SetActive(true);
        MovingPoints.Inst.SetSelect(players[0], null);
        MovingPoints.Inst.MovePlayerOnStartPoint();
        players.RemoveAt(0);
        StartCoroutine(MovingPoints.Inst.MovingPostSpawn(mounts));
    }

    public void ActivateNewPlayerDrop()
    {
        if (players.Count > 0)
        {
            players[0].gameObject.SetActive(true);
            MovingPoints.Inst.SetSelect(players[0], null);
            MovingPoints.Inst.MovePlayerOnStartPoint();
            players.RemoveAt(0);
        }
        else
        {
           MovingPoints.Inst.MoveForNextLoad(mounts);
        }
    }
}
