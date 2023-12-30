using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChooseController : MonoBehaviour
{
    public ChooseLabelController label;
    public GameController gameController;
    public Image background ; 
    private RectTransform rectTransform;
    private float labelHeight = -1;

    private float labelWidth = -1;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ChooseScene scene)
    {
        background.gameObject.SetActive(true);
        DestroyLabels();

        for (int index = 0; index < scene.labels.Count; index++)
        {

            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();
            newLabel.transform.SetParent(transform);
            if (labelHeight == -1)
            {
                labelHeight = newLabel.GetHeight();
                labelWidth = newLabel.GetWidth();
            }

            newLabel.Setup(scene.labels[index], this, CalculateLabelPosition(index, scene.labels.Count, "vertical"), CalculateLabelPosition(index, scene.labels.Count, "horizontal"));
        }
        Vector2 size = rectTransform.sizeDelta;
        size.y = (scene.labels.Count + 2) * labelHeight;
        rectTransform.sizeDelta = size;
    }

    public void PerformChoose(StoryScene scene)
    {
            background.gameObject.SetActive(false);
        gameController.PlayScene(scene);

    }

    private float CalculateLabelPosition(int labelIndex, int labelCount, string type)
    {

        //fazer a horizontal 

        if (type == "horizontal")
        {
            return 0;
        }
        else
        {
            return (labelCount - labelIndex) * ( labelHeight - 10 );
        }

    }

    public void DestroyLabels()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
