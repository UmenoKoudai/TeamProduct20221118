using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    [SerializeField] GameObject _open;
    [SerializeField] GameObject _close;
    [SerializeField] AudioSource _audio;
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
        SceneManager.LoadScene("ScoreRanking");
    }

    public void SceneMove(string scenename)
    {
        _audio.Play();
        SceneManager.LoadScene(scenename);
    }
    public void SetActive()
    {
        if(_audio)
        {
            _audio.Play();
        }
        _open.SetActive(true);
        _close.SetActive(false);
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
