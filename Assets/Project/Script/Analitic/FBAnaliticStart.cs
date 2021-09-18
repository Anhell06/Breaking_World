using Firebase;
using Firebase.Analytics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBAnaliticStart : MonoBehaviour
{
    
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => { FirebaseAnalytics.SetAnalyticsCollectionEnabled(true); });
    }
    
}
