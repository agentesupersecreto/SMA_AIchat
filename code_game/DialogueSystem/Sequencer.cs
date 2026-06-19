using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PixelCrushers.DialogueSystem.SequencerCommands;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000235 RID: 565
	public class Sequencer : MonoBehaviour
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06001942 RID: 6466 RVA: 0x00025C38 File Offset: 0x00023E38
		// (remove) Token: 0x06001943 RID: 6467 RVA: 0x00025C54 File Offset: 0x00023E54
		public event Action FinishedSequenceHandler;

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x06001944 RID: 6468 RVA: 0x00025C70 File Offset: 0x00023E70
		public bool IsPlaying
		{
			get
			{
				return this.isPlaying;
			}
		}

		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x06001945 RID: 6469 RVA: 0x00025C78 File Offset: 0x00023E78
		public GameObject CameraAngles
		{
			get
			{
				return this.cameraAngles;
			}
		}

		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x06001946 RID: 6470 RVA: 0x00025C80 File Offset: 0x00023E80
		public Camera SequencerCamera
		{
			get
			{
				return this.sequencerCamera;
			}
		}

		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x06001947 RID: 6471 RVA: 0x00025C88 File Offset: 0x00023E88
		public Transform SequencerCameraTransform
		{
			get
			{
				return (!(this.alternateSequencerCameraObject != null)) ? this.sequencerCamera.transform : this.alternateSequencerCameraObject.transform;
			}
		}

		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x06001948 RID: 6472 RVA: 0x00025CC4 File Offset: 0x00023EC4
		public Transform Speaker
		{
			get
			{
				return this.speaker;
			}
		}

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x06001949 RID: 6473 RVA: 0x00025CCC File Offset: 0x00023ECC
		public Transform Listener
		{
			get
			{
				return this.listener;
			}
		}

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x0600194A RID: 6474 RVA: 0x00025CD4 File Offset: 0x00023ED4
		public Vector3 OriginalCameraPosition
		{
			get
			{
				return this.originalCameraPosition;
			}
		}

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x0600194B RID: 6475 RVA: 0x00025CDC File Offset: 0x00023EDC
		public Quaternion OriginalCameraRotation
		{
			get
			{
				return this.originalCameraRotation;
			}
		}

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x0600194C RID: 6476 RVA: 0x00025CE4 File Offset: 0x00023EE4
		public float OriginalOrthographicSize
		{
			get
			{
				return this.originalOrthographicSize;
			}
		}

		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x0600194D RID: 6477 RVA: 0x00025CEC File Offset: 0x00023EEC
		// (set) Token: 0x0600194E RID: 6478 RVA: 0x00025CF4 File Offset: 0x00023EF4
		public float SubtitleEndTime { get; set; }

		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x0600194F RID: 6479 RVA: 0x00025D00 File Offset: 0x00023F00
		// (set) Token: 0x06001950 RID: 6480 RVA: 0x00025D08 File Offset: 0x00023F08
		public string entrytag { get; set; }

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x06001951 RID: 6481 RVA: 0x00025D14 File Offset: 0x00023F14
		public string entrytaglocal
		{
			get
			{
				return (!Localization.IsDefaultLanguage) ? (this.entrytag + "_" + Localization.Language) : this.entrytag;
			}
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00025D4C File Offset: 0x00023F4C
		public static void Message(string message)
		{
			DialogueManager.Instance.SendMessage("OnSequencerMessage", message, SendMessageOptions.DontRequireReceiver);
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00025D60 File Offset: 0x00023F60
		public void UseCamera(Camera sequencerCamera, GameObject cameraAngles)
		{
			this.UseCamera(sequencerCamera, null, cameraAngles);
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00025D6C File Offset: 0x00023F6C
		public void UseCamera(Camera sequencerCamera, GameObject alternateSequencerCameraObject, GameObject cameraAngles)
		{
			this.originalCamera = Camera.main;
			this.sequencerCameraSource = sequencerCamera;
			this.alternateSequencerCameraObject = alternateSequencerCameraObject;
			this.cameraAngles = cameraAngles;
			this.GetCamera();
			this.GetCameraAngles();
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x00025DA8 File Offset: 0x00023FA8
		private void GetCameraAngles()
		{
			if (this.cameraAngles == null)
			{
				this.cameraAngles = DialogueManager.LoadAsset("Default Camera Angles") as GameObject;
			}
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00025DDC File Offset: 0x00023FDC
		private void GetCamera()
		{
			if (this.sequencerCamera == null)
			{
				if (this.alternateSequencerCameraObject != null)
				{
					this.isUsingMainCamera = true;
					this.sequencerCamera = this.alternateSequencerCameraObject.GetComponent<Camera>();
				}
				else if (this.sequencerCameraSource != null)
				{
					GameObject gameObject = this.sequencerCameraSource.gameObject;
					GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject, gameObject.transform.position, gameObject.transform.rotation);
					this.sequencerCamera = gameObject2.GetComponent<Camera>();
					if (this.sequencerCamera != null)
					{
						this.sequencerCamera.transform.parent = base.transform;
						this.sequencerCamera.gameObject.SetActive(false);
						this.isUsingMainCamera = false;
					}
					else
					{
						Object.Destroy(gameObject2);
					}
				}
				if (this.sequencerCamera == null)
				{
					this.sequencerCamera = Camera.main;
					this.isUsingMainCamera = true;
				}
				if (this.sequencerCamera == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning("Dialogue System: No MainCamera found in scene. Creating one for the Sequencer Camera.", this);
					}
					GameObject gameObject3 = new GameObject("Sequencer Camera", new Type[]
					{
						typeof(Camera),
						typeof(AudioListener)
					});
					this.sequencerCamera = gameObject3.GetComponent<Camera>();
					this.isUsingMainCamera = true;
				}
			}
			if (Camera.main == null && this.sequencerCamera != null)
			{
				this.sequencerCamera.tag = "MainCamera";
				this.isUsingMainCamera = true;
			}
		}

		// Token: 0x06001957 RID: 6487 RVA: 0x00025F78 File Offset: 0x00024178
		private void DestroyCamera()
		{
			if (this.sequencerCamera != null && !this.isUsingMainCamera)
			{
				this.sequencerCamera.gameObject.SetActive(false);
				Object.Destroy(this.sequencerCamera.gameObject, 1f);
				this.sequencerCamera = null;
			}
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x00025FD0 File Offset: 0x000241D0
		private IEnumerator RestoreCamera()
		{
			yield return null;
			yield return null;
			this.ReleaseCameraControl();
			yield break;
		}

		// Token: 0x06001959 RID: 6489 RVA: 0x00025FEC File Offset: 0x000241EC
		public void SwitchCamera(Camera newCamera)
		{
			if (this.sequencerCamera != null && !this.isUsingMainCamera)
			{
				Object.Destroy(this.sequencerCamera.gameObject, 1f);
			}
			this.ReleaseCameraControl();
			this.hasCameraControl = false;
			this.originalCamera = null;
			this.originalCameraPosition = Vector3.zero;
			this.originalCameraRotation = Quaternion.identity;
			this.originalOrthographicSize = 16f;
			this.sequencerCameraSource = null;
			this.sequencerCamera = null;
			this.alternateSequencerCameraObject = null;
			this.isUsingMainCamera = false;
			this.UseCamera(newCamera, this.cameraAngles);
			this.TakeCameraControl();
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x00026090 File Offset: 0x00024290
		public void TakeCameraControl()
		{
			if (this.hasCameraControl)
			{
				return;
			}
			this.hasCameraControl = true;
			if (this.alternateSequencerCameraObject != null)
			{
				this.originalCamera = this.sequencerCamera;
				this.originalCameraPosition = this.alternateSequencerCameraObject.transform.position;
				this.originalCameraRotation = this.alternateSequencerCameraObject.transform.rotation;
			}
			else
			{
				this.originalCamera = Camera.main;
				if (Camera.main != null)
				{
					this.originalCameraPosition = Camera.main.transform.position;
					this.originalCameraRotation = Camera.main.transform.rotation;
					this.originalCamera.gameObject.SetActive(false);
				}
				this.originalOrthographicSize = this.sequencerCamera.orthographicSize;
				this.sequencerCamera.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x00026178 File Offset: 0x00024378
		private void ReleaseCameraControl()
		{
			if (!this.hasCameraControl)
			{
				return;
			}
			this.hasCameraControl = false;
			if (this.alternateSequencerCameraObject != null)
			{
				this.alternateSequencerCameraObject.transform.position = this.originalCameraPosition;
				this.alternateSequencerCameraObject.transform.rotation = this.originalCameraRotation;
			}
			else
			{
				this.sequencerCamera.transform.position = this.originalCameraPosition;
				this.sequencerCamera.transform.rotation = this.originalCameraRotation;
				this.sequencerCamera.orthographicSize = this.originalOrthographicSize;
				this.sequencerCamera.gameObject.SetActive(false);
				this.originalCamera.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x0002623C File Offset: 0x0002443C
		public void Open()
		{
			this.entrytag = string.Empty;
			this.GetCamera();
			this.hasCameraControl = false;
			this.GetCameraAngles();
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x0002625C File Offset: 0x0002445C
		public void Close()
		{
			if (this.FinishedSequenceHandler != null)
			{
				this.FinishedSequenceHandler();
			}
			this.FinishedSequenceHandler = null;
			this.Stop();
			base.StartCoroutine(this.RestoreCamera());
			Object.Destroy(this, 1f);
		}

		// Token: 0x0600195E RID: 6494 RVA: 0x000262A4 File Offset: 0x000244A4
		public void OnDestroy()
		{
			this.DestroyCamera();
		}

		// Token: 0x0600195F RID: 6495 RVA: 0x000262AC File Offset: 0x000244AC
		public void Update()
		{
			if (this.isPlaying)
			{
				this.CheckQueuedCommands();
				this.CheckActiveCommands();
				if (this.queuedCommands.Count == 0 && this.activeCommands.Count == 0)
				{
					this.FinishSequence();
				}
			}
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x000262F8 File Offset: 0x000244F8
		private void FinishSequence()
		{
			this.isPlaying = false;
			if (this.FinishedSequenceHandler != null)
			{
				this.FinishedSequenceHandler();
			}
			if (this.informParticipants)
			{
				this.InformParticipants("OnSequenceEnd");
			}
			if (this.closeWhenFinished)
			{
				this.FinishedSequenceHandler = null;
				this.Close();
			}
		}

		// Token: 0x06001961 RID: 6497 RVA: 0x00026350 File Offset: 0x00024550
		public void SetParticipants(Transform speaker, Transform listener)
		{
			this.speaker = speaker;
			this.listener = listener;
		}

		// Token: 0x06001962 RID: 6498 RVA: 0x00026360 File Offset: 0x00024560
		private void InformParticipants(string message)
		{
			if (this.speaker != null)
			{
				this.speaker.BroadcastMessage(message, this.speaker, SendMessageOptions.DontRequireReceiver);
				if (this.listener != null && this.listener != this.speaker)
				{
					this.listener.BroadcastMessage(message, this.speaker, SendMessageOptions.DontRequireReceiver);
				}
			}
			if (DialogueManager.Instance.transform != this.speaker && DialogueManager.Instance.transform != this.listener)
			{
				DialogueManager.Instance.BroadcastMessage(message, this.speaker, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x00026414 File Offset: 0x00024614
		public void PlaySequence(string sequence)
		{
			this.isPlaying = true;
			if (string.IsNullOrEmpty(sequence))
			{
				return;
			}
			sequence = FormattedText.ParseCode(sequence);
			if (!string.IsNullOrEmpty(this.entrytag) && sequence.Contains("entrytag"))
			{
				sequence = sequence.Replace("entrytaglocal", this.entrytaglocal).Replace("entrytag", this.entrytag);
			}
			if (!this.useOldParser)
			{
				List<QueuedSequencerCommand> list = this.parser.Parse(sequence);
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						this.PlayCommand(list[i]);
					}
				}
			}
			else
			{
				string[] array = Regex.Split(sequence, "\\s*;\\s*");
				foreach (string text in array)
				{
					string text2 = null;
					if (text.Contains("->Message("))
					{
						string text3 = text.Substring(text.IndexOf("->Message("));
						text2 = text3.Substring("->Message(".Length, text3.Length - ("->Message(".Length + 1));
						text2.Trim();
					}
					string[] array3 = Regex.Split(text, "\\s*\\(|\\)|\\s*\\@");
					string[] array4 = array3[0].Split(null);
					if (1 > array4.Length || array4.Length > 2)
					{
						if (DialogueDebug.LogWarnings)
						{
							Debug.LogWarning(string.Format("{0}: Sequence syntax error: {1}", new object[] { "Dialogue System", text }));
						}
					}
					else
					{
						bool flag = string.Compare(array4[0], "required", StringComparison.OrdinalIgnoreCase) == 0;
						string text4 = array4[array4.Length - 1].Trim();
						string[] array5 = ((array3.Length < 2) ? null : Regex.Split(array3[1], "\\s*,\\s*"));
						float num = 0f;
						string text5 = null;
						if (array3.Length >= 4)
						{
							if (string.Equals(array3[3].Trim(), "Message", StringComparison.OrdinalIgnoreCase))
							{
								if (array3.Length < 5)
								{
									if (DialogueDebug.LogWarnings)
									{
										Debug.LogWarning(string.Format("{0}: Sequence syntax error in @Message((): {1}", new object[] { "Dialogue System", text }));
									}
									goto IL_026F;
								}
								text5 = array3[4].Trim();
								num = ((!string.IsNullOrEmpty(text5)) ? 31536000f : 0f);
							}
							else
							{
								float.TryParse(array3[3], out num);
							}
						}
						this.PlayCommand(text4, flag, num, text5, text2, array5);
					}
					IL_026F:;
				}
			}
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x000266A4 File Offset: 0x000248A4
		public void PlaySequence(string sequence, bool informParticipants, bool destroyWhenDone)
		{
			this.closeWhenFinished = destroyWhenDone;
			this.informParticipants = informParticipants;
			if (informParticipants)
			{
				this.InformParticipants("OnSequenceStart");
			}
			this.PlaySequence(sequence);
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x000266D8 File Offset: 0x000248D8
		public void PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants, bool destroyWhenDone)
		{
			this.SetParticipants(speaker, listener);
			this.PlaySequence(sequence, informParticipants, destroyWhenDone);
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x000266F0 File Offset: 0x000248F0
		public void PlaySequence(string sequence, Transform speaker, Transform listener, bool informParticipants, bool destroyWhenDone, bool delayOneFrame)
		{
			if (delayOneFrame)
			{
				base.StartCoroutine(this.PlaySequenceAfterOneFrame(sequence, speaker, listener, informParticipants, destroyWhenDone));
			}
			else
			{
				this.PlaySequence(sequence, speaker, listener, informParticipants, destroyWhenDone);
			}
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x0002672C File Offset: 0x0002492C
		public IEnumerator PlaySequenceAfterOneFrame(string sequence, Transform speaker, Transform listener, bool informParticipants, bool destroyWhenDone)
		{
			yield return null;
			this.PlaySequence(sequence, speaker, listener, informParticipants, destroyWhenDone);
			yield break;
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x00026794 File Offset: 0x00024994
		public void PlayCommand(string commandName, bool required, float time, string message, string endMessage, params string[] args)
		{
			this.PlayCommand(null, commandName, required, time, message, endMessage, args);
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x000267B4 File Offset: 0x000249B4
		public void PlayCommand(QueuedSequencerCommand commandRecord)
		{
			if (commandRecord == null)
			{
				return;
			}
			this.PlayCommand(commandRecord, commandRecord.command, commandRecord.required, commandRecord.startTime, commandRecord.messageToWaitFor, commandRecord.endMessage, commandRecord.parameters);
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x000267F4 File Offset: 0x000249F4
		public void PlayCommand(QueuedSequencerCommand commandRecord, string commandName, bool required, float time, string message, string endMessage, params string[] args)
		{
			if (DialogueDebug.LogInfo && args != null)
			{
				if (string.IsNullOrEmpty(message) && string.IsNullOrEmpty(endMessage))
				{
					Debug.Log(string.Format("{0}: Sequencer.Play( {1}{2}({3})@{4} )", new object[]
					{
						"Dialogue System",
						(!required) ? string.Empty : "required ",
						commandName,
						string.Join(", ", args),
						time
					}));
				}
				else if (string.IsNullOrEmpty(endMessage))
				{
					Debug.Log(string.Format("{0}: Sequencer.Play( {1}{2}({3})@Message({4}) )", new object[]
					{
						"Dialogue System",
						(!required) ? string.Empty : "required ",
						commandName,
						string.Join(", ", args),
						message
					}));
				}
				else if (string.IsNullOrEmpty(message))
				{
					Debug.Log(string.Format("{0}: Sequencer.Play( {1}{2}({3})->Message({4}) )", new object[]
					{
						"Dialogue System",
						(!required) ? string.Empty : "required ",
						commandName,
						string.Join(", ", args),
						endMessage
					}));
				}
				else
				{
					Debug.Log(string.Format("{0}: Sequencer.Play( {1}{2}({3})@Message({4})->Message({5}) )", new object[]
					{
						"Dialogue System",
						(!required) ? string.Empty : "required ",
						commandName,
						string.Join(", ", args),
						message,
						endMessage
					}));
				}
			}
			this.isPlaying = true;
			if (time <= 0.001f && !this.IsTimePaused() && string.IsNullOrEmpty(message))
			{
				this.ActivateCommand(commandName, endMessage, args);
			}
			else if (commandRecord != null)
			{
				commandRecord.startTime += DialogueTime.time;
				this.queuedCommands.Add(commandRecord);
			}
			else
			{
				this.queuedCommands.Add(new QueuedSequencerCommand(commandName, args, DialogueTime.time + time, message, endMessage, required));
			}
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x00026A14 File Offset: 0x00024C14
		private bool IsTimePaused()
		{
			return DialogueTime.IsPaused;
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x00026A1C File Offset: 0x00024C1C
		private void ActivateCommand(string commandName, string endMessage, string[] args)
		{
			float num = 0f;
			if (!string.IsNullOrEmpty(commandName))
			{
				if (this.HandleCommandInternally(commandName, args, out num))
				{
					if (!string.IsNullOrEmpty(endMessage))
					{
						base.StartCoroutine(this.SendTimedSequencerMessage(endMessage, num));
					}
				}
				else
				{
					Type type = this.FindSequencerCommandType(commandName);
					SequencerCommand sequencerCommand = ((type != null) ? (base.gameObject.AddComponent(type) as SequencerCommand) : null);
					if (sequencerCommand != null)
					{
						sequencerCommand.Initialize(this, endMessage, args);
						this.activeCommands.Add(sequencerCommand);
					}
					else if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Can't find any built-in sequencer command named {1}() or a sequencer command component named SequencerCommand{1}()", new object[] { "Dialogue System", commandName }));
					}
				}
			}
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x00026AE4 File Offset: 0x00024CE4
		private Type FindSequencerCommandType(string commandName)
		{
			if (Sequencer.cachedComponentTypes.ContainsKey(commandName))
			{
				return Sequencer.cachedComponentTypes[commandName];
			}
			Type type = this.FindSequencerCommandType(commandName, "DialogueSystem");
			if (type == null)
			{
				type = this.FindSequencerCommandType(commandName, "Assembly-CSharp");
				if (type == null)
				{
					type = this.FindSequencerCommandType(commandName, "Assembly-CSharp-firstpass");
				}
			}
			if (type != null)
			{
				Sequencer.cachedComponentTypes.Add(commandName, type);
			}
			return type;
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x00026B54 File Offset: 0x00024D54
		private Type FindSequencerCommandType(string commandName, string assemblyName)
		{
			Type type = this.FindSequencerCommandType("PixelCrushers.DialogueSystem.SequencerCommands.", commandName, assemblyName);
			if (type != null)
			{
				return type;
			}
			type = this.FindSequencerCommandType("PixelCrushers.DialogueSystem.", commandName, assemblyName);
			if (type != null)
			{
				return type;
			}
			return this.FindSequencerCommandType(string.Empty, commandName, assemblyName);
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x00026B9C File Offset: 0x00024D9C
		private Type FindSequencerCommandType(string namespacePrefix, string commandName, string assemblyName)
		{
			string text = string.Format("{0}SequencerCommand{1},{2}", new object[] { namespacePrefix, commandName, assemblyName });
			return Type.GetType(text, false);
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x00026BD0 File Offset: 0x00024DD0
		private IEnumerator SendTimedSequencerMessage(string endMessage, float delay)
		{
			yield return base.StartCoroutine(DialogueTime.WaitForSeconds(delay));
			Sequencer.Message(endMessage);
			yield break;
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x00026C08 File Offset: 0x00024E08
		private void ActivateCommand(QueuedSequencerCommand queuedCommand)
		{
			this.ActivateCommand(queuedCommand.command, queuedCommand.endMessage, queuedCommand.parameters);
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x00026C24 File Offset: 0x00024E24
		private void CheckQueuedCommands()
		{
			if (this.queuedCommands.Count > 0 && !this.IsTimePaused())
			{
				float now = DialogueTime.time;
				try
				{
					foreach (QueuedSequencerCommand queuedSequencerCommand in this.queuedCommands)
					{
						if (now >= queuedSequencerCommand.startTime)
						{
							this.ActivateCommand(queuedSequencerCommand.command, queuedSequencerCommand.endMessage, queuedSequencerCommand.parameters);
						}
					}
				}
				catch (InvalidOperationException)
				{
				}
				this.queuedCommands.RemoveAll((QueuedSequencerCommand queuedCommand) => now >= queuedCommand.startTime);
			}
		}

		// Token: 0x06001973 RID: 6515 RVA: 0x00026D14 File Offset: 0x00024F14
		public void OnSequencerMessage(string message)
		{
			try
			{
				if (this.queuedCommands.Count > 0 && !this.IsTimePaused() && !string.IsNullOrEmpty(message))
				{
					int count = this.queuedCommands.Count;
					for (int i = count - 1; i >= 0; i--)
					{
						QueuedSequencerCommand queuedSequencerCommand = this.queuedCommands[i];
						if (string.Equals(message, queuedSequencerCommand.messageToWaitFor))
						{
							this.ActivateCommand(queuedSequencerCommand.command, queuedSequencerCommand.endMessage, queuedSequencerCommand.parameters);
						}
					}
					this.queuedCommands.RemoveAll((QueuedSequencerCommand queuedCommand) => string.Equals(message, queuedCommand.messageToWaitFor));
				}
			}
			catch (Exception ex)
			{
				if (!(ex is InvalidOperationException) && !(ex is ArgumentOutOfRangeException))
				{
					throw;
				}
			}
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x00026E1C File Offset: 0x0002501C
		private void CheckActiveCommands()
		{
			if (this.activeCommands.Count > 0)
			{
				List<SequencerCommand> done = this.activeCommands.FindAll((SequencerCommand command) => !command.IsPlaying);
				if (done.Count > 0)
				{
					foreach (SequencerCommand sequencerCommand in done)
					{
						if (sequencerCommand != null)
						{
							if (!string.IsNullOrEmpty(sequencerCommand.endMessage))
							{
								Sequencer.Message(sequencerCommand.endMessage);
							}
							Object.Destroy(sequencerCommand);
						}
					}
					this.activeCommands.RemoveAll((SequencerCommand command) => done.Contains(command));
				}
			}
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x00026F18 File Offset: 0x00025118
		public void Stop()
		{
			this.StopQueued();
			this.StopActive();
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x00026F28 File Offset: 0x00025128
		public void StopQueued()
		{
			foreach (QueuedSequencerCommand queuedSequencerCommand in this.queuedCommands)
			{
				if (queuedSequencerCommand.required)
				{
					this.ActivateCommand(queuedSequencerCommand.command, queuedSequencerCommand.endMessage, queuedSequencerCommand.parameters);
				}
			}
			this.queuedCommands.Clear();
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x00026FB8 File Offset: 0x000251B8
		public void StopActive()
		{
			foreach (SequencerCommand sequencerCommand in this.activeCommands)
			{
				if (sequencerCommand != null)
				{
					if (!string.IsNullOrEmpty(sequencerCommand.endMessage))
					{
						Sequencer.Message(sequencerCommand.endMessage);
					}
					Object.Destroy(sequencerCommand, 0.1f);
				}
			}
			this.activeCommands.Clear();
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x00027054 File Offset: 0x00025254
		private bool HandleCommandInternally(string commandName, string[] args, out float duration)
		{
			duration = 0f;
			if (this.disableInternalSequencerCommands)
			{
				return false;
			}
			if (string.Equals(commandName, "None") || string.IsNullOrEmpty(commandName))
			{
				return true;
			}
			if (string.Equals(commandName, "Camera"))
			{
				return this.TryHandleCameraInternally(commandName, args);
			}
			if (string.Equals(commandName, "Animation"))
			{
				return this.HandleAnimationInternally(commandName, args, out duration);
			}
			if (string.Equals(commandName, "AnimatorController"))
			{
				return this.HandleAnimatorControllerInternally(commandName, args);
			}
			if (string.Equals(commandName, "AnimatorLayer"))
			{
				return this.TryHandleAnimatorLayerInternally(commandName, args);
			}
			if (string.Equals(commandName, "AnimatorBool"))
			{
				return this.HandleAnimatorBoolInternally(commandName, args);
			}
			if (string.Equals(commandName, "AnimatorInt"))
			{
				return this.HandleAnimatorIntInternally(commandName, args);
			}
			if (string.Equals(commandName, "AnimatorFloat"))
			{
				return this.TryHandleAnimatorFloatInternally(commandName, args);
			}
			if (string.Equals(commandName, "AnimatorTrigger"))
			{
				return this.HandleAnimatorTriggerInternally(commandName, args);
			}
			if (string.Equals(commandName, "AnimatorPlay"))
			{
				return this.HandleAnimatorPlayInternally(commandName, args);
			}
			if (string.Equals(commandName, "Audio"))
			{
				return this.HandleAudioInternally(commandName, args);
			}
			if (string.Equals(commandName, "MoveTo"))
			{
				return this.TryHandleMoveToInternally(commandName, args);
			}
			if (string.Equals(commandName, "LookAt"))
			{
				return this.TryHandleLookAtInternally(commandName, args);
			}
			if (string.Equals(commandName, "SendMessage"))
			{
				return this.HandleSendMessageInternally(commandName, args);
			}
			if (string.Equals(commandName, "SetActive"))
			{
				return this.HandleSetActiveInternally(commandName, args);
			}
			if (string.Equals(commandName, "SetEnabled"))
			{
				return this.HandleSetEnabledInternally(commandName, args);
			}
			if (string.Equals(commandName, "SetPortrait"))
			{
				return this.HandleSetPortraitInternally(commandName, args);
			}
			if (string.Equals(commandName, "SetContinueMode"))
			{
				return this.HandleSetContinueModeInternally(commandName, args);
			}
			if (string.Equals(commandName, "Continue"))
			{
				return this.HandleContinueInternally();
			}
			if (string.Equals(commandName, "SetVariable"))
			{
				return this.HandleSetVariableInternally(commandName, args);
			}
			if (string.Equals(commandName, "ShowAlert"))
			{
				return this.HandleShowAlertInternally(commandName, args);
			}
			return string.Equals(commandName, "UpdateTracker") && this.HandleUpdateTrackerInternally();
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x000272A0 File Offset: 0x000254A0
		private bool TryHandleCameraInternally(string commandName, string[] args)
		{
			float parameterAsFloat = SequencerTools.GetParameterAsFloat(args, 2, 0f);
			if (parameterAsFloat < 0.001f)
			{
				string text = SequencerTools.GetParameter(args, 0, "default");
				Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
				bool flag = string.Equals(text, "default");
				if (flag)
				{
					text = SequencerTools.GetDefaultCameraAngle(subject);
				}
				bool flag2 = string.Equals(text, "original");
				Transform transform = ((!flag2) ? ((!(this.cameraAngles != null)) ? null : this.cameraAngles.transform.Find(text)) : this.originalCamera.transform);
				bool flag3 = true;
				if (transform == null)
				{
					flag3 = false;
					GameObject gameObject = GameObject.Find(text);
					if (gameObject != null)
					{
						transform = gameObject.transform;
					}
				}
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: Camera({1}, {2}, {3}s)", new object[]
					{
						"Dialogue System",
						text,
						Tools.GetObjectName(subject),
						parameterAsFloat
					}));
				}
				if (transform == null && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Camera angle '{1}' wasn't found.", new object[] { "Dialogue System", text }));
				}
				if (subject == null && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Camera subject '{1}' wasn't found.", new object[]
					{
						"Dialogue System",
						SequencerTools.GetParameter(args, 1, null)
					}));
				}
				this.TakeCameraControl();
				if (flag2)
				{
					this.SequencerCameraTransform.rotation = this.OriginalCameraRotation;
					this.SequencerCameraTransform.position = this.OriginalCameraPosition;
				}
				else if (transform != null && subject != null)
				{
					Transform sequencerCameraTransform = this.SequencerCameraTransform;
					if (flag3)
					{
						sequencerCameraTransform.rotation = subject.rotation * transform.localRotation;
						sequencerCameraTransform.position = subject.position + subject.rotation * transform.localPosition;
					}
					else
					{
						sequencerCameraTransform.rotation = transform.rotation;
						sequencerCameraTransform.position = transform.position;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600197A RID: 6522 RVA: 0x000274F8 File Offset: 0x000256F8
		private bool HandleAnimationInternally(string commandName, string[] args, out float duration)
		{
			duration = 0f;
			if (args != null && args.Length > 2)
			{
				return false;
			}
			string parameter = SequencerTools.GetParameter(args, 0, null);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
			Animation animation = ((!(subject == null)) ? subject.GetComponent<Animation>() : null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: Animation({1}, {2})", new object[]
				{
					"Dialogue System",
					parameter,
					Tools.GetObjectName(subject)
				}));
			}
			if (subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Animation() command: subject is null.", new object[] { "Dialogue System" }));
				}
			}
			else if (animation == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Animation() command: no Animation component found on {1}.", new object[] { "Dialogue System", subject.name }));
				}
			}
			else if (string.IsNullOrEmpty(parameter))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: Animation() command: Animation name is blank.", new object[] { "Dialogue System" }));
				}
			}
			else
			{
				animation.CrossFade(parameter);
				duration = animation[parameter].length;
			}
			return true;
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x00027654 File Offset: 0x00025854
		private bool HandleAnimatorControllerInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AnimatorController({1}, {2})", new object[]
				{
					"Dialogue System",
					parameter,
					Tools.GetObjectName(subject)
				}));
			}
			RuntimeAnimatorController runtimeAnimatorController = null;
			try
			{
				runtimeAnimatorController = Object.Instantiate(DialogueManager.LoadAsset(parameter)) as RuntimeAnimatorController;
			}
			catch (Exception)
			{
			}
			if (subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorController() command: subject is null.", new object[] { "Dialogue System" }));
				}
			}
			else if (runtimeAnimatorController == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorController() command: failed to load animator controller '{1}'.", new object[] { "Dialogue System", parameter }));
				}
			}
			else
			{
				Animator componentInChildren = subject.GetComponentInChildren<Animator>();
				if (componentInChildren == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorController() command: No Animator component found on {1}.", new object[] { "Dialogue System", subject.name }));
					}
				}
				else
				{
					componentInChildren.runtimeAnimatorController = runtimeAnimatorController;
				}
			}
			return true;
		}

		// Token: 0x0600197C RID: 6524 RVA: 0x000277B8 File Offset: 0x000259B8
		private bool TryHandleAnimatorLayerInternally(string commandName, string[] args)
		{
			float parameterAsFloat = SequencerTools.GetParameterAsFloat(args, 3, 0f);
			if (parameterAsFloat < 0.001f)
			{
				int parameterAsInt = SequencerTools.GetParameterAsInt(args, 0, 1);
				float parameterAsFloat2 = SequencerTools.GetParameterAsFloat(args, 1, 1f);
				Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 2, null), this.speaker, this.listener, null);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: AnimatorLayer({1}, {2}, {3})", new object[]
					{
						"Dialogue System",
						parameterAsInt,
						parameterAsFloat2,
						Tools.GetObjectName(subject)
					}));
				}
				if (subject == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorLayer() command: subject is null.", new object[] { "Dialogue System" }));
					}
				}
				else
				{
					Animator componentInChildren = subject.GetComponentInChildren<Animator>();
					if (componentInChildren == null)
					{
						if (DialogueDebug.LogWarnings)
						{
							Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorLayer(): No Animator component found on {1}.", new object[] { "Dialogue System", subject.name }));
						}
					}
					else
					{
						componentInChildren.SetLayerWeight(parameterAsInt, parameterAsFloat2);
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600197D RID: 6525 RVA: 0x000278E0 File Offset: 0x00025AE0
		private bool HandleAnimatorBoolInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			bool parameterAsBool = SequencerTools.GetParameterAsBool(args, 1, true);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 2, null), this.speaker, this.listener, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AnimatorBool({1}, {2}, {3})", new object[]
				{
					"Dialogue System",
					parameter,
					parameterAsBool,
					Tools.GetObjectName(subject)
				}));
			}
			if (subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorBool() command: subject is null.", new object[] { "Dialogue System" }));
				}
			}
			else if (string.IsNullOrEmpty(parameter))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorBool() command: animator parameter name is blank.", new object[] { "Dialogue System" }));
				}
			}
			else
			{
				Animator componentInChildren = subject.GetComponentInChildren<Animator>();
				if (componentInChildren == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: No Animator component found on {1}.", new object[] { "Dialogue System", subject.name }));
					}
				}
				else
				{
					componentInChildren.SetBool(parameter, parameterAsBool);
				}
			}
			return true;
		}

		// Token: 0x0600197E RID: 6526 RVA: 0x00027A18 File Offset: 0x00025C18
		private bool HandleAnimatorIntInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			int parameterAsInt = SequencerTools.GetParameterAsInt(args, 1, 1);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 2, null), this.speaker, this.listener, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AnimatorInt({1}, {2}, {3})", new object[]
				{
					"Dialogue System",
					parameter,
					parameterAsInt,
					Tools.GetObjectName(subject)
				}));
			}
			if (subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorInt() command: subject is null.", new object[] { "Dialogue System" }));
				}
			}
			else if (string.IsNullOrEmpty(parameter))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorInt() command: animator parameter name is blank.", new object[] { "Dialogue System" }));
				}
			}
			else
			{
				Animator componentInChildren = subject.GetComponentInChildren<Animator>();
				if (componentInChildren == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: No Animator component found on {1}.", new object[] { "Dialogue System", subject.name }));
					}
				}
				else
				{
					componentInChildren.SetInteger(parameter, parameterAsInt);
				}
			}
			return true;
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x00027B50 File Offset: 0x00025D50
		private bool TryHandleAnimatorFloatInternally(string commandName, string[] args)
		{
			float parameterAsFloat = SequencerTools.GetParameterAsFloat(args, 3, 0f);
			if (parameterAsFloat < 0.001f)
			{
				string parameter = SequencerTools.GetParameter(args, 0, null);
				float parameterAsFloat2 = SequencerTools.GetParameterAsFloat(args, 1, 1f);
				Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 2, null), this.speaker, this.listener, null);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: AnimatorFloat({1}, {2}, {3})", new object[]
					{
						"Dialogue System",
						parameter,
						parameterAsFloat2,
						Tools.GetObjectName(subject)
					}));
				}
				if (subject == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorFloat() command: subject is null.", new object[] { "Dialogue System" }));
					}
				}
				else if (string.IsNullOrEmpty(parameter))
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorFloat() command: animator parameter name is blank.", new object[] { "Dialogue System" }));
					}
				}
				else
				{
					Animator componentInChildren = subject.GetComponentInChildren<Animator>();
					if (componentInChildren == null)
					{
						if (DialogueDebug.LogWarnings)
						{
							Debug.LogWarning(string.Format("{0}: Sequencer: No Animator component found on {1}.", new object[] { "Dialogue System", subject.name }));
						}
					}
					else
					{
						componentInChildren.SetFloat(parameter, parameterAsFloat2);
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x00027CA8 File Offset: 0x00025EA8
		private bool HandleAnimatorTriggerInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
			Animator animator = ((!(subject != null)) ? null : subject.GetComponentInChildren<Animator>());
			if (animator == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.Log(string.Format("{0}: Sequencer: AnimatorTrigger({1}, {2}): No Animator found on {2}", new object[]
					{
						"Dialogue System",
						parameter,
						(!(subject != null)) ? SequencerTools.GetParameter(args, 1, null) : subject.name
					}));
				}
			}
			else if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AnimatorTrigger({1}, {2})", new object[] { "Dialogue System", parameter, subject }));
			}
			if (animator != null)
			{
				animator.SetTrigger(parameter);
			}
			return true;
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x00027D94 File Offset: 0x00025F94
		private bool HandleAnimatorPlayInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
			float parameterAsFloat = SequencerTools.GetParameterAsFloat(args, 2, 0f);
			int parameterAsInt = SequencerTools.GetParameterAsInt(args, 3, -1);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AnimatorPlay({1}, {2}, fade={3}, layer={4})", new object[]
				{
					"Dialogue System",
					parameter,
					Tools.GetObjectName(subject),
					parameterAsFloat,
					parameterAsInt
				}));
			}
			if (subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorPlay() command: subject is null.", new object[] { "Dialogue System" }));
				}
			}
			else if (string.IsNullOrEmpty(parameter))
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorPlay() command: state name is blank.", new object[] { "Dialogue System" }));
				}
			}
			else
			{
				Animator componentInChildren = subject.GetComponentInChildren<Animator>();
				if (componentInChildren == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: No Animator component found on {1}.", new object[] { "Dialogue System", subject.name }));
					}
				}
				else if (Tools.ApproximatelyZero(parameterAsFloat))
				{
					componentInChildren.Play(parameter, parameterAsInt);
				}
				else
				{
					componentInChildren.CrossFade(parameter, parameterAsFloat, parameterAsInt);
				}
			}
			return true;
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x00027F00 File Offset: 0x00026100
		private bool HandleAudioInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
			if (SequencerTools.IsAudioMuted())
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: Audio({1}, {2}): skipping; audio is muted", new object[] { "Dialogue System", parameter, subject }));
				}
				return true;
			}
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: Audio({1}, {2})", new object[] { "Dialogue System", parameter, subject }));
			}
			AudioClip audioClip = DialogueManager.LoadAsset(parameter) as AudioClip;
			if (audioClip == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Audio() command: clip '{1}' could not be found or loaded.", new object[] { "Dialogue System", parameter }));
			}
			if (audioClip != null)
			{
				AudioSource audioSource = SequencerTools.GetAudioSource(subject);
				if (audioSource == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: Audio() command: can't find or add AudioSource to {1}.", new object[] { "Dialogue System", subject.name }));
					}
				}
				else
				{
					audioSource.clip = audioClip;
					audioSource.Play();
				}
			}
			return true;
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x00028040 File Offset: 0x00026240
		private bool TryHandleMoveToInternally(string commandName, string[] args)
		{
			float parameterAsFloat = SequencerTools.GetParameterAsFloat(args, 2, 0f);
			if (parameterAsFloat < 0.001f)
			{
				Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 0, null), this.speaker, this.listener, null);
				Transform subject2 = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: MoveTo({1}, {2}, {3})", new object[] { "Dialogue System", subject, subject2, parameterAsFloat }));
				}
				if (subject2 == null && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: MoveTo() command: subject is null.", new object[] { "Dialogue System" }));
				}
				if (subject == null && DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: MoveTo() command: target is null.", new object[] { "Dialogue System" }));
				}
				if (subject2 != null && subject != null)
				{
					subject2.position = subject.position;
					subject2.rotation = subject.rotation;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x0002816C File Offset: 0x0002636C
		private bool TryHandleLookAtInternally(string commandName, string[] args)
		{
			float parameterAsFloat = SequencerTools.GetParameterAsFloat(args, 2, 0f);
			bool flag = string.Compare(SequencerTools.GetParameter(args, 3, null), "allAxes", StringComparison.OrdinalIgnoreCase) != 0;
			if (parameterAsFloat < 0.001f)
			{
				if (args == null || (args.Length == 1 && string.IsNullOrEmpty(args[0])))
				{
					if (this.speaker != null && this.listener != null)
					{
						if (DialogueDebug.LogInfo)
						{
							Debug.Log(string.Format("{0}: Sequencer: LookAt() [speaker<->listener]", new object[] { "Dialogue System" }));
						}
						this.DoLookAt(this.speaker, this.listener.position, flag);
						this.DoLookAt(this.listener, this.speaker.position, flag);
					}
				}
				else
				{
					Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 0, null), this.speaker, this.listener, null);
					Transform subject2 = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 1, null), this.speaker, this.listener, null);
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Format("{0}: Sequencer: LookAt({1}, {2}, {3})", new object[] { "Dialogue System", subject, subject2, parameterAsFloat }));
					}
					if (subject2 == null && DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: LookAt() command: subject is null.", new object[] { "Dialogue System" }));
					}
					if (subject == null && DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: LookAt() command: target is null.", new object[] { "Dialogue System" }));
					}
					if (subject2 != subject && subject2 != null && subject != null)
					{
						this.DoLookAt(subject2, subject.position, flag);
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x00028350 File Offset: 0x00026550
		private void DoLookAt(Transform subject, Vector3 position, bool yAxisOnly)
		{
			if (yAxisOnly)
			{
				subject.LookAt(new Vector3(position.x, subject.position.y, position.z));
			}
			else
			{
				subject.LookAt(position);
			}
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x00028398 File Offset: 0x00026598
		private bool HandleSendMessageInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			string parameter2 = SequencerTools.GetParameter(args, 1, null);
			string parameter3 = SequencerTools.GetParameter(args, 2, null);
			bool flag = string.Equals(parameter3, "everyone", StringComparison.OrdinalIgnoreCase);
			Transform transform = ((!flag) ? SequencerTools.GetSubject(SequencerTools.GetParameter(args, 2, null), this.speaker, this.listener, null) : DialogueManager.Instance.transform);
			bool flag2 = string.Equals(SequencerTools.GetParameter(args, 3, null), "broadcast", StringComparison.OrdinalIgnoreCase);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: SendMessage({1}, {2}, {3}, {4})", new object[]
				{
					"Dialogue System",
					parameter,
					parameter2,
					transform,
					SequencerTools.GetParameter(args, 3, null)
				}));
			}
			if (transform == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: SendMessage() command: subject is null.", new object[] { "Dialogue System" }));
			}
			if (string.IsNullOrEmpty(parameter) && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: SendMessage() command: message is blank.", new object[] { "Dialogue System" }));
			}
			if (transform != null && !string.IsNullOrEmpty(parameter))
			{
				if (flag)
				{
					Tools.SendMessageToEveryone(parameter, parameter2);
				}
				else if (flag2)
				{
					transform.BroadcastMessage(parameter, parameter2, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					transform.SendMessage(parameter, parameter2, SendMessageOptions.DontRequireReceiver);
				}
			}
			return true;
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x00028504 File Offset: 0x00026704
		private bool HandleSetActiveInternally(string commandName, string[] args)
		{
			GameObject gameObject = SequencerTools.FindSpecifier(SequencerTools.GetParameter(args, 0, null), false);
			string parameter = SequencerTools.GetParameter(args, 1, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: SetActive({1}, {2})", new object[] { "Dialogue System", gameObject, parameter }));
			}
			if (gameObject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: SetActive() command: subject '{1}' is null.", new object[]
					{
						"Dialogue System",
						(args.Length <= 0) ? string.Empty : args[0]
					}));
				}
			}
			else if (gameObject == this.speaker || gameObject == this.listener)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: SetActive() command: subject '{1}' cannot be speaker or listener.", new object[]
					{
						"Dialogue System",
						(args.Length <= 0) ? string.Empty : args[0]
					}));
				}
			}
			else
			{
				bool flag = true;
				if (!string.IsNullOrEmpty(parameter))
				{
					if (string.Equals(parameter.ToLower(), "false"))
					{
						flag = false;
					}
					else if (string.Equals(parameter.ToLower(), "flip"))
					{
						flag = !gameObject.activeSelf;
					}
				}
				gameObject.SetActive(flag);
			}
			return true;
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x00028660 File Offset: 0x00026860
		private bool HandleSetEnabledInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			string parameter2 = SequencerTools.GetParameter(args, 1, null);
			Transform subject = SequencerTools.GetSubject(SequencerTools.GetParameter(args, 2, null), this.speaker, this.listener, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: SetEnabled({1}, {2}, {3})", new object[] { "Dialogue System", parameter, parameter2, subject }));
			}
			if (subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: SetEnabled() command: subject is null.", new object[] { "Dialogue System" }));
				}
			}
			else
			{
				Component component = subject.GetComponent(parameter);
				if (component == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: SetEnabled() command: component '{1}' not found on {2}.", new object[] { "Dialogue System", parameter, subject.name }));
					}
				}
				else
				{
					Toggle toggle = Toggle.True;
					if (!string.IsNullOrEmpty(parameter2))
					{
						if (string.Equals(parameter2.ToLower(), "false"))
						{
							toggle = Toggle.False;
						}
						else if (string.Equals(parameter2.ToLower(), "flip"))
						{
							toggle = Toggle.Flip;
						}
					}
					Tools.SetComponentEnabled(component, toggle);
				}
			}
			return true;
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x000287A0 File Offset: 0x000269A0
		private bool HandleSetPortraitInternally(string commandName, string[] args)
		{
			string parameter = SequencerTools.GetParameter(args, 0, null);
			string parameter2 = SequencerTools.GetParameter(args, 1, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: SetPortrait({1}, {2})", new object[] { "Dialogue System", parameter, parameter2 }));
			}
			Actor actor = DialogueManager.MasterDatabase.GetActor(parameter);
			bool flag = string.Equals(parameter2, "default");
			bool flag2 = parameter2 != null && parameter2.StartsWith("pic=");
			Texture2D texture2D;
			if (flag)
			{
				texture2D = null;
			}
			else if (flag2)
			{
				string text = parameter2.Substring("pic=".Length);
				int asInt;
				if (!int.TryParse(text, out asInt))
				{
					if (DialogueLua.DoesVariableExist(text))
					{
						asInt = DialogueLua.GetVariable(text).AsInt;
					}
					else
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: SetPortrait() command: pic variable '{1}' not found.", new object[] { "Dialogue System", text }));
					}
				}
				texture2D = actor.GetPortraitTexture(asInt);
			}
			else
			{
				texture2D = DialogueManager.LoadAsset(parameter2) as Texture2D;
			}
			if (DialogueDebug.LogWarnings)
			{
				if (actor == null)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: SetPortrait() command: actor '{1}' not found.", new object[] { "Dialogue System", parameter }));
				}
				if (texture2D == null && !flag)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: SetPortrait() command: texture '{1}' not found.", new object[] { "Dialogue System", parameter2 }));
				}
			}
			if (actor != null)
			{
				if (flag)
				{
					DialogueLua.SetActorField(parameter, "Current Portrait", string.Empty);
				}
				else if (texture2D != null)
				{
					DialogueLua.SetActorField(parameter, "Current Portrait", parameter2);
				}
				DialogueManager.Instance.SetActorPortraitTexture(parameter, texture2D);
			}
			return true;
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x00028964 File Offset: 0x00026B64
		private bool HandleSetContinueModeInternally(string commandName, string[] args)
		{
			if (args == null || args.Length < 1)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: SetContinueMode(true|false|original) requires a true/false/original parameter", new object[] { "Dialogue System" }));
				}
				return true;
			}
			string parameter = SequencerTools.GetParameter(args, 0, null);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: SetContinueMode({1})", new object[] { "Dialogue System", parameter }));
			}
			if (DialogueManager.Instance == null || DialogueManager.DisplaySettings == null || DialogueManager.DisplaySettings.subtitleSettings == null)
			{
				return true;
			}
			if (string.Equals(parameter, "true", StringComparison.OrdinalIgnoreCase))
			{
				Sequencer.savedContinueButtonMode = DialogueManager.DisplaySettings.subtitleSettings.continueButton;
				DialogueManager.DisplaySettings.subtitleSettings.continueButton = DisplaySettings.SubtitleSettings.ContinueButtonMode.Always;
			}
			else if (string.Equals(parameter, "false", StringComparison.OrdinalIgnoreCase))
			{
				Sequencer.savedContinueButtonMode = DialogueManager.DisplaySettings.subtitleSettings.continueButton;
				DialogueManager.DisplaySettings.subtitleSettings.continueButton = DisplaySettings.SubtitleSettings.ContinueButtonMode.Never;
			}
			else
			{
				if (!string.Equals(parameter, "original", StringComparison.OrdinalIgnoreCase))
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: SetContinueMode(true|false|original) requires a true/false/original parameter", new object[] { "Dialogue System" }));
					}
					return true;
				}
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: SetContinueMode({1}): Restoring original mode {2}", new object[]
					{
						"Dialogue System",
						parameter,
						Sequencer.savedContinueButtonMode
					}));
				}
				DialogueManager.DisplaySettings.subtitleSettings.continueButton = Sequencer.savedContinueButtonMode;
			}
			if (DialogueManager.ConversationView != null)
			{
				DialogueManager.ConversationView.SetupContinueButton();
			}
			return true;
		}

		// Token: 0x0600198B RID: 6539 RVA: 0x00028B24 File Offset: 0x00026D24
		private bool HandleContinueInternally()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: Continue()", new object[] { "Dialogue System" }));
			}
			DialogueManager.Instance.BroadcastMessage("OnConversationContinueAll", SendMessageOptions.DontRequireReceiver);
			return true;
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x00028B6C File Offset: 0x00026D6C
		private bool HandleSetVariableInternally(string commandName, string[] args)
		{
			if (args == null || args.Length < 2)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: SetVariable(variableName, value) requires two parameters", new object[] { "Dialogue System" }));
				}
			}
			else
			{
				string parameter = SequencerTools.GetParameter(args, 0, null);
				string parameter2 = SequencerTools.GetParameter(args, 1, null);
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Format("{0}: Sequencer: SetVariable({1}, {2})", new object[] { "Dialogue System", parameter, parameter2 }));
				}
				bool flag;
				float num;
				if (bool.TryParse(parameter2, out flag))
				{
					DialogueLua.SetVariable(parameter, flag);
				}
				else if (float.TryParse(parameter2, out num))
				{
					DialogueLua.SetVariable(parameter, num);
				}
				else
				{
					DialogueLua.SetVariable(parameter, parameter2);
				}
			}
			return true;
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x00028C3C File Offset: 0x00026E3C
		private bool HandleShowAlertInternally(string commandName, string[] args)
		{
			bool flag = args.Length > 0 && !string.IsNullOrEmpty(args[0]);
			float num = ((!flag) ? 0f : SequencerTools.GetParameterAsFloat(args, 0, 0f));
			if (DialogueDebug.LogInfo)
			{
				if (flag)
				{
					Debug.Log(string.Format("{0}: Sequencer: ShowAlert({1})", new object[] { "Dialogue System", num }));
				}
				else
				{
					Debug.Log(string.Format("{0}: Sequencer: ShowAlert()", new object[] { "Dialogue System" }));
				}
			}
			try
			{
				string asString = Lua.Run("return Variable['Alert']").AsString;
				if (!string.IsNullOrEmpty(asString))
				{
					Lua.Run("Variable['Alert'] = ''");
					if (flag)
					{
						DialogueManager.ShowAlert(asString, num);
					}
					else
					{
						DialogueManager.ShowAlert(asString);
					}
				}
			}
			catch (Exception)
			{
			}
			return true;
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x00028D40 File Offset: 0x00026F40
		private bool HandleUpdateTrackerInternally()
		{
			Debug.Log(string.Format("{0}: Sequencer: UpdateTracker()", new object[] { "Dialogue System" }));
			DialogueManager.SendUpdateTracker();
			return true;
		}

		// Token: 0x04000E07 RID: 3591
		private const string DefaultCameraAnglesResourceName = "Default Camera Angles";

		// Token: 0x04000E08 RID: 3592
		private const float InstantThreshold = 0.001f;

		// Token: 0x04000E09 RID: 3593
		public bool disableInternalSequencerCommands;

		// Token: 0x04000E0A RID: 3594
		public bool useOldParser;

		// Token: 0x04000E0B RID: 3595
		private bool hasCameraControl;

		// Token: 0x04000E0C RID: 3596
		private Camera originalCamera;

		// Token: 0x04000E0D RID: 3597
		private Vector3 originalCameraPosition = Vector3.zero;

		// Token: 0x04000E0E RID: 3598
		private Quaternion originalCameraRotation = Quaternion.identity;

		// Token: 0x04000E0F RID: 3599
		private float originalOrthographicSize = 16f;

		// Token: 0x04000E10 RID: 3600
		private Transform speaker;

		// Token: 0x04000E11 RID: 3601
		private Transform listener;

		// Token: 0x04000E12 RID: 3602
		private List<QueuedSequencerCommand> queuedCommands = new List<QueuedSequencerCommand>();

		// Token: 0x04000E13 RID: 3603
		private List<SequencerCommand> activeCommands = new List<SequencerCommand>();

		// Token: 0x04000E14 RID: 3604
		private bool informParticipants;

		// Token: 0x04000E15 RID: 3605
		private bool closeWhenFinished;

		// Token: 0x04000E16 RID: 3606
		private Camera sequencerCameraSource;

		// Token: 0x04000E17 RID: 3607
		private Camera sequencerCamera;

		// Token: 0x04000E18 RID: 3608
		private GameObject alternateSequencerCameraObject;

		// Token: 0x04000E19 RID: 3609
		private GameObject cameraAngles;

		// Token: 0x04000E1A RID: 3610
		private bool isUsingMainCamera;

		// Token: 0x04000E1B RID: 3611
		private bool isPlaying;

		// Token: 0x04000E1C RID: 3612
		private static Dictionary<string, Type> cachedComponentTypes = new Dictionary<string, Type>();

		// Token: 0x04000E1D RID: 3613
		private SequenceParser parser = new SequenceParser();

		// Token: 0x04000E1E RID: 3614
		private static DisplaySettings.SubtitleSettings.ContinueButtonMode savedContinueButtonMode = DisplaySettings.SubtitleSettings.ContinueButtonMode.Always;
	}
}
