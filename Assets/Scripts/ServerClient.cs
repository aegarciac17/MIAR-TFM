using UnityEngine;
using LLMUnity;
using UnityEngine.UI;


public class ServerClientInteraction
{
    
    LLMClient llm;

    public ServerClientInteraction(LLMClient llm)
    {
        this.llm = llm;
    }

    public async void StartInteraction(string message, Callback<string> responseHandler)
    {
        await llm.Chat(message, responseHandler);
    }

}

/*public class ServerClient : MonoBehaviour
{
    public LLM llm;
    public Text AIText1;
    ServerClientInteraction interaction1;

    public LLMClient llmClient;
    public Text AIText2;
    ServerClientInteraction interaction2;


}*/
