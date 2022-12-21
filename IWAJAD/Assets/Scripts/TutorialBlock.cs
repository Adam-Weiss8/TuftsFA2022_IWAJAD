using UnityEngine;

public class TutorialBlock : MonoBehaviour
{
    // Define a string to hold the tutorial text that you want to display
    public string tutorialText = "This is the tutorial text";

    // Define a boolean variable to track whether the player character is standing in front of the block
    private bool playerInTrigger = false;

    // Define a GUI style to customize the appearance of the tutorial text and background
    private GUIStyle tutorialStyle = new GUIStyle();

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered the trigger is the player character
        if (other.CompareTag("Player"))
        {
            // Set the playerInTrigger variable to true
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collider that exited the trigger is the player character
        if (other.CompareTag("Player"))
        {
            // Set the playerInTrigger variable to false
            playerInTrigger = false;
        }
    }

    private void OnGUI()
{
    // Check if the player character is standing in front of the block
    if (playerInTrigger)
    {
        // Set the tutorialStyle properties to customize the appearance of the tutorial text and background
        tutorialStyle.normal.textColor = Color.black;
        tutorialStyle.normal.background = MakeTexture(400, 100, Color.white);
        tutorialStyle.alignment = TextAnchor.MiddleCenter;
        tutorialStyle.wordWrap = true;

        // Set the font size to a small starting value
        tutorialStyle.fontSize = 16;

        // Calculate the size of the text with the current font size
        Vector2 textSize = tutorialStyle.CalcSize(new GUIContent(tutorialText));

        // Increment the font size until the text exceeds the size of the background box
        while (textSize.x <= 200 && textSize.y <= 50)
        {
            tutorialStyle.fontSize++;
            textSize = tutorialStyle.CalcSize(new GUIContent(tutorialText));
        }

        // Decrement the font size to the last size that fit within the background box
        tutorialStyle.fontSize--;

        // Calculate the width and height of the background box based on the screen size
        float backgroundWidth = Screen.width * 0.2f;
        float backgroundHeight = Screen.height * 0.2f;

        // Calculate the position of the background box based on the screen size
        float backgroundX = Screen.width * 0.8f - backgroundWidth / 2;
        float backgroundY = Screen.height * 0.8f - backgroundHeight / 2;

        // Display the tutorial text on the screen using GUI.Label with the tutorialStyle
        GUI.Label(new Rect(backgroundX, backgroundY, backgroundWidth, backgroundHeight), tutorialText, tutorialStyle);
    }
}






    // Helper function to create a texture with a solid color
    private Texture2D MakeTexture(int width, int height, Color color)
    {
        Color[] pix = new Color[width * height];

        for (int i = 0; i < pix.Length; i++)
        {
            pix[i] = color;
        }

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}

