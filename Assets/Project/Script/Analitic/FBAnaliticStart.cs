using Firebase;
using Firebase.Analytics;
using UnityEngine;

public class FBAnaliticStart : MonoBehaviour
{

    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => { FirebaseAnalytics.SetAnalyticsCollectionEnabled(true); });
    }

}
