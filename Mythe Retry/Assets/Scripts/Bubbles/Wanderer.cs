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

    private static float minX = -9.81f;
    private static float maxX = 9.69f;
    private static float minY = 6.2f;
    private static float maxY = 0.59f;
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

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minX, minY), new Vector3(maxX, minY));
        Gizmos.DrawLine(new Vector3(maxX, minY), new Vector3(maxX, maxY));
        Gizmos.DrawLine(new Vector3(maxX, maxY), new Vector3(minX, maxY));
        Gizmos.DrawLine(new Vector3(minX, maxY), new Vector3(minX, minY));
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
        var random = new Vector2();
        random.x = Random.Range(minX, maxX);
        random.y = Random.Range(minY, maxY);

        return random;
    }
    #endregion
}
