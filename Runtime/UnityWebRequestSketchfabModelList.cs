﻿using System;
using System.Collections.Generic;
using UnityEngine.Networking;

public static class UnityWebRequestSketchfabModelList
{
    public struct Parameters
    {
        public string user;
        public List<string> tags;
        public List<string> categories;
        // only used for search
        public int? minFaceCount;
        public int? maxFaceCount;
        // only used for model list
        public int? maxVertexCount;
        public DateTime? publishedSince;
        public bool? staffpicked;
        public bool? downloadable;
        public bool? animated;
        public bool? hasSound;
        public bool? restricted;

        public string UrlEcnode()
        {
            List<string> urlParameters = new List<string>();
            if (!string.IsNullOrWhiteSpace(user))
            {
                urlParameters.Add($"user={user}");
            }

            if (tags != null &&
                tags.Count != 0)
            {
                foreach (string tag in tags)
                {
                    urlParameters.Add($"tags={tag}");
                }
            }

            if (categories != null &&
                categories.Count != 0)
            {
                foreach (string category in categories)
                {
                    urlParameters.Add($"categories={category}");
                }
            }

            if (minFaceCount != null &&
                minFaceCount > 0)
            {
                urlParameters.Add($"min_face_count={minFaceCount.Value}");
            }

            if (maxFaceCount != null &&
                maxFaceCount > 0)
            {
                urlParameters.Add($"max_face_count={maxFaceCount.Value}");
            }

            if (maxVertexCount != null &&
                maxVertexCount > 0)
            {
                urlParameters.Add($"max_vertex_count={maxVertexCount.Value}");
            }

            if (publishedSince != null)
            {
                urlParameters.Add($"published_since={publishedSince.Value.ToString("yyyyMMddTHH:mm:ssZ")}");
            }

            if (staffpicked != null)
            {
                urlParameters.Add($"staffpicked={staffpicked.Value}");
            }

            if (downloadable != null)
            {
                urlParameters.Add($"downloadable={downloadable.Value}");
            }

            if (animated != null)
            {
                urlParameters.Add($"animated={animated.Value}");
            }

            if (hasSound != null)
            {
                urlParameters.Add($"has_sound={hasSound.Value}");
            }

            if (restricted != null)
            {
                urlParameters.Add($"restricted={restricted.Value}");
            }

            return string.Join("&", urlParameters);
        }
    }

    public static UnityWebRequest Search(Parameters _parameters, params string[] _keywords)
    {
        return UnityWebRequest.Get($"{SketchfabEndpoints.ModelSearchEndpoint}&q={string.Join(" ", _keywords)}&{_parameters.UrlEcnode()}");
    }

    public static UnityWebRequest GetModelList(Parameters _parameters)
    {
        return UnityWebRequest.Get($"{SketchfabEndpoints.ModelEndpoint}?{_parameters.UrlEcnode()}");
    }

    public static UnityWebRequest GetNextModelListPage(SketchfabModelList _previousModelList)
    {
        return UnityWebRequest.Get(_previousModelList.NextPageUrl);
    }
}
