using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{


    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button start = root.Q<Button>("Start");
        Button credits = root.Q<Button>("Credits");
        Button quit = root.Q<Button>("Quit");

        start.clicked += () => Debug.Log($"boink");
    }
}
