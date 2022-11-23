using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
   //タイトルシーン

    public void TitleBottan()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
        Invoke("Title",1.5f);
    }
    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
    
    //メインシーン

    public void MainBottan()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
        Invoke("Main", 1.5f);
    }
    public void Main()
    {
        SceneManager.LoadScene("MainScene");
    }

    //ランキングシーン

    public void RankingBottan()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
        Invoke("Ranking", 1.5f);
    }
    public void Ranking()
    {
        SceneManager.LoadScene("RankingScene");
    }

    //リザルトシーン
        
    public void ResultBottan()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
        Invoke("Result", 1.5f);
    }
    public void Result()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
