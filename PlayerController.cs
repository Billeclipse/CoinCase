using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public TextMeshProUGUI coins_collected_text;
	public TextMeshProUGUI coins_disposed_text;
	public TextMeshProUGUI speed_text;
	public TextMeshProUGUI won_message;
	public Button main_menu_button;
	public GameObject dispose_effect;

	private Rigidbody rb;
	private int coins_collected = 0;
	private int coins_disposed = 0;
	private float original_speed;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		original_speed = speed;
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);
		coins_collected_text.SetText("Coins Collected: {0}",coins_collected);
		coins_disposed_text.SetText("Coins Disposed: {0}",coins_disposed);
		speed_text.SetText("Speed: {0}%",speed*100/original_speed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Sea")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}else if(other.tag == "Coin")
		{
			if(coins_collected < 99)
			{
				Destroy(other.gameObject);
				coins_collected++;				
				speed -= 0.75f;
				//Debug.Log("Coin Collected" + " Coins: " + coins_collected);
			}			
		}else if(other.tag == "CoinDisposer")
		{
			if(coins_collected > 0)
			{
				Instantiate(dispose_effect, transform.position, transform.rotation);
				coins_disposed += coins_collected;
				if (coins_disposed >= 100)
				{
					won_message.gameObject.SetActive(true);
					main_menu_button.gameObject.SetActive(true);
					Destroy(this);
				}
				coins_collected = 0;
				speed = original_speed;
				//Debug.Log("Coins Disposed" + " Coins: " + coins_collected);
			}
		}
	}
}
