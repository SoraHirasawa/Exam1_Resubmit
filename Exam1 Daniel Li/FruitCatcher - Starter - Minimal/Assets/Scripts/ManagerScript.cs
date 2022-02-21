using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ManagerScript : NetworkBehaviour
{
	System.Random _rand;
	public GameObject _fruitPrefab;
	public Text _hostScoreText;
	public Text _clientScoreText;
	/*[SyncVar(hook = nameof(updateScore))]
	int _hostScore = 0;
	[SyncVar(hook = nameof(updateScore))]
	int _clientScore = 0;*/


	// Start is called before the first frame update
	void Start()
    {
		_rand = new System.Random();
		

	}

	// Update is called once per frame
	void FixedUpdate()
    {
		int next = _rand.Next(100);
		if (next == 0)
		{
			Instantiate(_fruitPrefab, new Vector3(_rand.Next(7) - 3, 5), Quaternion.identity);
		}
	}

	public void updateScore(bool ser, int score)
    {
		if (ser)
        {
			_hostScoreText.text = score.ToString();
		}
		else
        {
			_clientScoreText.text = score.ToString();

		}
	}

	/*public void updateScore(int oldScore, int newScore)
    {
		_hostScoreText.text = _hostScore.ToString();
		_clientScoreText.text = _clientScore.ToString();
	}

	public void setScore(bool cli)
    {
		if (cli)
        {
			_clientScore++;
        }
		else
        {
			_hostScore++;
        }
    }*/

}
