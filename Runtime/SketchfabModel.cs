﻿using Newtonsoft.Json;


public class SketchfabModel
{
    //huh
    public string Uid { get; set; }
    public string Name { get; set; }
    public bool IsDownloadable { get; set; }
    public string Description { get; set; }
    public int FaceCount { get; set; }
    public int VertexCount { get; set; }
    public SketchfabThumbnailList Thumbnails { get; set; }
    public string PbrType { get; set; } //save the pbr type to this string. this is mostly a test to extend the model class
    public int LikeCount { get; set; }
    
    public SketchfabUser User { get; set; }
    public override string ToString()
    {
        string modelString = $"Uid: {Uid}\n" +
            $"Name: {Name}\n" +
            $"IsDownloadable: {IsDownloadable}\n" +
            $"Description: {Description}\n" +
            $"Face count: {FaceCount}\n" +
            $"Vertex count: {VertexCount}\n" +
            $"Thumbnails: {Thumbnails}\n" + 
            $"PbrType: {PbrType}\n" +
            $"LikeCount: {LikeCount}\n" +
            $"User: {User}\n";

        return modelString;
    }

    public string GetJsonString ()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static SketchfabModel FromJson(string _data)
    {
        return JsonConvert.DeserializeObject<SketchfabModel>(_data);
    }
}
