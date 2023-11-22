using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ResponceIdentification
{
    public string access_token { get; set; }
    public string model_version { get; set; }
    public object custom_id { get; set; }
    public Input input { get; set; }
    public Result result { get; set; }
    public string status { get; set; }
    public bool sla_compliant_client { get; set; }
    public bool sla_compliant_system { get; set; }
    public double created { get; set; }
    public double completed { get; set; }
}
[Serializable]
    public class Classification
    {
        public List<Suggestion> suggestions { get; set; }
    }
[Serializable]
    public class Description
    {
        public string value { get; set; }
        public string citation { get; set; }
        public string license_name { get; set; }
        public string license_url { get; set; }
    }
[Serializable]
    public class Details
    {
        public List<string> common_names { get; set; }
        public string url { get; set; }
        public Description description { get; set; }
        public ImageResult ImageResult { get; set; }
        public string language { get; set; }
        public string entity_id { get; set; }
    }
[Serializable]
    public class ImageResult
    {
        public Sprite sprite;
        public string value { get; set; }
        public string citation { get; set; }
        public string license_name { get; set; }
        public string license_url { get; set; }
    }
[Serializable]
    public class Input
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public bool similar_images { get; set; }
        public List<string> images { get; set; }
        public DateTime datetime { get; set; }
    }
[Serializable]
    public class Result
    {
        public Classification classification { get; set; }
    }
[Serializable]
    public class SimilarImage
    {
        public string id { get; set; }
        public string url { get; set; }
        public string license_name { get; set; }
        public string license_url { get; set; }
        public string citation { get; set; }
        public double similarity { get; set; }
        public string url_small { get; set; }
    }
[Serializable]
    public class Suggestion
    {
        public string id { get; set; }
        public string name { get; set; }
        public double probability { get; set; }
        public List<SimilarImage> similar_images { get; set; }
        public Details details { get; set; }
    }

