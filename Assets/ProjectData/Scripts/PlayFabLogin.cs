using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
public class PlayFabLogin : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI Logintext;
    public void Login()
    {
        // Here we need to check whether TitleId property is configured in settings or not
    if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            * If not we need to assign it to the appropriate variable manually
            * Otherwise we can just remove this if statement at all
            */
            PlayFabSettings.staticSettings.TitleId = " 27D08";
        }
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "GeekBrainsLesson3",
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made successful API call!");
        Logintext.color = Color.green;
        Logintext.text = "Congratulations, you made successful API call!";
    }
    private void OnLoginFailure(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.LogError($"Something went wrong: {errorMessage}");
        Logintext.color = Color.red;
        Logintext.text = $"Something went wrong: {errorMessage}";
    }
}
