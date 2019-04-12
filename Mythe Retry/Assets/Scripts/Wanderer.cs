using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour {
    #region Public Fields
    public GameObject target { get; private set; }
    #endregion

    #region Private Fields
    [SerializeField] private GameObject targetPrefab;
    private Bubble bubble;
    #endregion

    #region Unity Methods
    private void Awake() {
        bubble = GetComponent<Bubble>();
    }

    void Start() {
        target = Instantiate(targetPrefab, new Vector3(GetRandomLocation().x, GetRandomLocation().y, 0), Quaternion.identity);
        target.GetComponent<Target>().showSprite = false;
        bubble.SetTarget(target.GetComponent<Target>());
        bubble.Arrived += OnArrival;
    }

    void Update() {

    }

    private void OnEnable() {
        if(target != null) {
            bubble.SetTarget(target.GetComponent<Target>());
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void OnArrival() {
        if(!bubble.dragging) {
            target.transform.position = new Vector3(GetRandomLocation().x, GetRandomLocation().y, 0);
        }
    }

    private Vector2 GetRandomLocation() {
        var random = new Vector2(10, 4);
        random.x = Random.Range(-random.x, random.x);
        random.y = Random.Range(-random.y, random.y);

        return random;
    }
    #endregion
}
