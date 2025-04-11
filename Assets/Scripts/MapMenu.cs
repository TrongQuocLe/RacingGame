using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    public void OpenMap(int mapId)
    {
        string mapName = "Map " + mapId;
        SceneManager.LoadScene(mapName);
    }
}
