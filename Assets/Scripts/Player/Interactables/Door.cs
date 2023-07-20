using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : InteractableObject
{
    [SerializeField] private string _sceneName;
    public override void Interact(GameObject player)
    {
        SceneManager.LoadScene(_sceneName);
    }
}