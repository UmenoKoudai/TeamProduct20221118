using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
   //�^�C�g���V�[��

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
    
    //���C���V�[��

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

    //�����L���O�V�[��

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

    //���U���g�V�[��
        
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
