using System.Collections;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
   public CanvasGroup Screen;

   private void Awake()
   {
      DontDestroyOnLoad(this);
   }

   public void Show()
   {
      gameObject.SetActive(true);
      Screen.alpha = 1;
   }

   public void Hide() => StartCoroutine(FadeIn());

   //for simplicity I used coroutine here. But I prefer tweeners for things like that
   private IEnumerator FadeIn()
   {
      while (Screen.alpha > 0)
      {
         Screen.alpha -= 0.03f;
         yield return new WaitForSeconds(0.03f);
      }
      
      gameObject.SetActive(false);
   }
}
