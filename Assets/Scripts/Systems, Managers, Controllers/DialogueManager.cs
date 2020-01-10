using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool enableNameTextBox = false;

    [Header("Text Boxes")]
    public Text nameBox;
    public Text textBox;
    public Text contTextBox;

    public Image cutSceneHolder;

    private Queue<string> names;
    private Queue<string> sentences;
    private Queue<Sprite> cutSceneImages;
    private bool cutsceneEnabled;
    private int transitionToSceneNumber;

	void Awake () {
        names = new Queue<string>();
		sentences = new Queue<string>();
        cutSceneImages = new Queue<Sprite>();
	}

    public void StartDialogue(Dialogue dialogue, bool cutscene, int _transitionToSceneNumber)
    {
        cutsceneEnabled = cutscene;
        transitionToSceneNumber = _transitionToSceneNumber;
        nameBox.text = "";
        textBox.text = "";
        
        names.Clear();
        sentences.Clear();
        cutSceneImages.Clear();
        
        if(enableNameTextBox && nameBox != null)
        {
            foreach (var dialougeName in dialogue.names)
            {
                names.Enqueue(dialougeName);
            }
        }

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if(cutsceneEnabled)
        {
            foreach(var image in dialogue.imageData)
            {
                cutSceneImages.Enqueue(image);
            }        
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 1)
        {
            contTextBox.text = "End";
        }
        else if(sentences.Count == 0)
        {
            if(cutsceneEnabled)
            {
                names.Clear();
                sentences.Clear();
                cutSceneImages.Clear();
                SceneSystem.instance.ChangeScene(transitionToSceneNumber);
            }
            else
            {
                cutsceneEnabled = false;
                transitionToSceneNumber = 0;
                return;
            }
        }

        textBox.text = "";
        nameBox.text = "";

        string dialougeName = names.Dequeue();
        string sentence = sentences.Dequeue();
        Sprite cutSceneImage = cutSceneImages.Dequeue();
        StopAllCoroutines();
        StartCoroutine(ReadOutSentence(dialougeName, sentence, cutSceneImage));
    }

    IEnumerator ReadOutSentence(string name, string sentence, Sprite image)
    {
        if(image != null)
            cutSceneHolder.sprite = image;

        if(name != null)
            nameBox.text = name;
        
        foreach (var letter in sentence.ToCharArray())
        {
            textBox.text += letter;
            yield return null;
        }
    }
}
