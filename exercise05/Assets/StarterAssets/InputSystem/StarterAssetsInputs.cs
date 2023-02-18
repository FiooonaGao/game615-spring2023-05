using TMPro;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		public float TimeLeft;
		public bool TimerOn = false;
		public TextMeshProUGUI ScoreText;
		public TextMeshProUGUI TimerText;
		public TextMeshProUGUI LooseText;
		public TextMeshProUGUI WinText;
		public int score;
		public int IntTimeLeft;
		public bool GameOn = false;


		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		void Start()
		{
			score = 1;
			TimerOn = true;
			GameOn = true;
			TimeLeft = 60;
			LooseText.enabled = false;
			WinText.enabled = false;
		}


#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if (cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("target"))
			{
				Destroy(other.gameObject);
				ScoreText.text = score.ToString();
				score++;
			}
		}


		void Update()
		{
			if (TimerOn)
			{
				if (TimeLeft > 0 && score < 5)
				{
					TimeLeft -= Time.deltaTime;
					IntTimeLeft = (int)Mathf.Round(TimeLeft);
					TimerText.text = IntTimeLeft.ToString();
				}
				else if (TimeLeft > 0 && score == 5)
				{
					WinText.enabled = true;

					GameOn = false;
				}
				else
				{
					TimeLeft = 0;
					TimerText.text = TimeLeft.ToString();
					IntTimeLeft = (int)Mathf.Round(TimeLeft);
					TimerOn = false;
					LooseText.enabled = true;

					GameOn = false;

				

				}
			}
		}
	}
}