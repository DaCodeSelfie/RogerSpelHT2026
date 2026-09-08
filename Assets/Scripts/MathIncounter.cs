using UnityEngine;

public class MathIncounter : MonoBehaviour
{
    public GameObject MathMenuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            MathMenuUI.SetActive(true);
            // Debug.Log("DEN DYCKER UPP");
        }
    }

    public void AnswerRight()
    {
        MathMenuUI.SetActive(false);
        Destroy(this.gameObject);
    }
}
