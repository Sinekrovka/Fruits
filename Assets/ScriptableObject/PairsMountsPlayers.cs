using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(order = 51, fileName = "pairsMounts", menuName = "MyTools/Pairs")]
public class PairsMountsPlayers : ScriptableObject
{
    [Serializable]
    public struct Pair
    {
        public GameObject player;
        public GameObject mount;
    }

    [SerializeField] private List<Pair> Pairs;

    public Pair GetRandomPair()
    {
        int index = Random.Range(0, Pairs.Count);
        return Pairs[index];
    }
}
