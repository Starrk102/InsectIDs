using System;
using System.Text;
using BestHTTP;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenGalleryScreen : MonoBehaviour
{
    [SerializeField] private Button select;
    [SerializeField] private Button send;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image imageResult;

    private ImagesClass imagesClass;
    
    private void Start()
    {
        SetText("null");
        
        select.onClick.AddListener(() =>
        {
            NativeGallery.GetImageFromGallery(Callback);
        });
        
        send.onClick.AddListener(() =>
        { 
            WebRequestSender.Identification(imagesClass, OnResult);
        });
    }

    private void OnResult(HTTPResponse response)
    {
        var responseData = JsonConvert.DeserializeObject<ResponceIdentification>(response.DataAsText);
        StringBuilder sb = new StringBuilder(responseData.result.classification.suggestions[0].name);
        sb.Append("\n");
        sb.Append(responseData.result.classification.suggestions[0].details.description.value);
        SetText(sb.ToString());
    }

    private void SetText(string text)
    {
        this.text.text = text;
    }
    
    private void Callback(string path)
    {
        Texture2D texture = LoadTexture(path);

        LocationService service = new LocationService();
        service.Start();
        
        imagesClass = new ImagesClass
        {
            images = Convert.ToBase64String(texture.EncodeToPNG()),
            longitude = 0.0f,//service.lastData.longitude,
            latitude = 0.0f,//service.lastData.latitude,
            similar_images = true
        };
        
        service.Stop();
        
        var sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        imageResult.sprite = sprite;
        imageResult.type = Image.Type.Simple;
        imageResult.preserveAspect = true;
    }

    private void OnDestroy()
    {
        select.onClick.RemoveAllListeners();
        send.onClick.RemoveAllListeners();
    }
    
    private Texture2D LoadTexture(string path)
    {
        if (System.IO.File.Exists(path))
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(512, 512);
            texture.LoadImage(imageBytes);
            return texture;
        }
        else
        {
            Debug.LogError("File not found: " + path);
            return null;
        }
    }
}
