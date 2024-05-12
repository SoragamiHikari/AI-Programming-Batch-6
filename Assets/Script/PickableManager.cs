using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreManager _scoreManager;

    private List<Pickable> pickableList = new List<Pickable>();   

    // Start is called before the first frame update
    void Start()
    {
        InitPickableList();
    }

    void InitPickableList()
    {
        Pickable[] pickableObjeck = pickableObjeck = GameObject.FindObjectsOfType<Pickable>();
        for (int i = 0; i < pickableObjeck.Length; i++)
        {
            pickableList.Add(pickableObjeck[i]);
            pickableObjeck[i].onPick += OnPickablePiked;
        }
        _scoreManager.MaxScore(pickableList.Count);
        Debug.Log("Pickable List: " + pickableList.Count);
    }

    void OnPickablePiked(Pickable p)
    {
        pickableList.Remove(p);
        if(_scoreManager != null)
        {
            _scoreManager.AddScore(1);
        }
        if(p.pickableType == PickableType.PowerUp)
        {
            _player?.PickPowerUp();
        }
        if (pickableList.Count <= 0)
        {
            Debug.Log("WIN");
        }
    }
}
