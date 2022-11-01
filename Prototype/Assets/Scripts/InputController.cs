using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Transform pauseButton;
    [SerializeField] public GameObject startText;

    // Setting time scale to zero
    void Start()
    {
        PauseGame();
        startText.SetActive(true);
    }

    void Update()
    {
        // Raycasting to rotate tracks
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100f);
            if (hit.collider == null) return;
            if (hit.collider.gameObject.layer == 3) hit.collider.GetComponent<TrackController>().RotateTrack();
        }
    }

    public void PauseGame()
    {
        if (startText.activeInHierarchy)
        {
            startText.SetActive(false);
            var cubes = FindObjectsOfType<CubeController>();
            foreach(CubeController cube in cubes) cube.ReturnToStart();
        }
        bool wasPaused = Time.timeScale == 0;
        Time.timeScale = wasPaused ? 1 : 0;
        pauseButton.GetChild(0).gameObject.SetActive(wasPaused);
        pauseButton.GetChild(1).gameObject.SetActive(!wasPaused);
    }

    public void Restart()
    {
        pauseButton.GetChild(0).gameObject.SetActive(false);
        pauseButton.GetChild(1).gameObject.SetActive(true);
        startText.SetActive(true);

        var tracks = FindObjectsOfType<TrackController>();
        foreach(TrackController track in tracks) if (track.enabled) track.RotateTrack(Random.Range(1, 4));

        var cubes = FindObjectsOfType<CubeController>();
        foreach(CubeController cube in cubes) cube.ReturnToStart();

        FindObjectOfType<TargetController>().UpdateScore(-2);
        Time.timeScale = 0;
    }
}
