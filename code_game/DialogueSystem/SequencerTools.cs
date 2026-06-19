using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000236 RID: 566
	public static class SequencerTools
	{
		// Token: 0x06001990 RID: 6544 RVA: 0x00028D74 File Offset: 0x00026F74
		public static Transform GetSubject(string specifier, Transform speaker, Transform listener, Transform defaultSubject = null)
		{
			if (string.IsNullOrEmpty(specifier))
			{
				return defaultSubject ?? speaker;
			}
			if (string.Compare(specifier, "speaker", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return speaker;
			}
			if (string.Compare(specifier, "listener", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return listener;
			}
			GameObject gameObject = SequencerTools.FindSpecifier(specifier, false);
			return (!(gameObject != null)) ? defaultSubject : gameObject.transform;
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x00028DDC File Offset: 0x00026FDC
		public static GameObject FindSpecifier(string specifier, bool onlyActiveInScene = false)
		{
			Transform registeredActorTransform = CharacterInfo.GetRegisteredActorTransform(specifier);
			if (registeredActorTransform != null)
			{
				return registeredActorTransform.gameObject;
			}
			GameObject gameObject = GameObject.Find(specifier);
			if (gameObject != null)
			{
				return gameObject;
			}
			if (onlyActiveInScene)
			{
				return null;
			}
			gameObject = Tools.GameObjectHardFind(specifier);
			if (gameObject != null)
			{
				return gameObject;
			}
			foreach (GameObject gameObject2 in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
			{
				if (string.Compare(specifier, gameObject2.name, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return gameObject2;
				}
			}
			return null;
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x00028E7C File Offset: 0x0002707C
		public static string GetDefaultCameraAngle(Transform subject)
		{
			DefaultCameraAngle defaultCameraAngle = ((!(subject != null)) ? null : subject.GetComponentInChildren<DefaultCameraAngle>());
			return (!(defaultCameraAngle != null)) ? "Closeup" : defaultCameraAngle.cameraAngle;
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00028EC0 File Offset: 0x000270C0
		public static string GetParameter(string[] parameters, int i, string defaultValue = null)
		{
			return (parameters == null || i >= parameters.Length) ? defaultValue : parameters[i];
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x00028EDC File Offset: 0x000270DC
		public static T GetParameterAs<T>(string[] parameters, int i, T defaultValue)
		{
			T t;
			try
			{
				t = ((parameters == null || i >= parameters.Length) ? defaultValue : ((T)((object)Convert.ChangeType(parameters[i], typeof(T)))));
			}
			catch (Exception)
			{
				t = defaultValue;
			}
			return t;
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x00028F4C File Offset: 0x0002714C
		public static float GetParameterAsFloat(string[] parameters, int i, float defaultValue = 0f)
		{
			return SequencerTools.GetParameterAs<float>(parameters, i, defaultValue);
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x00028F58 File Offset: 0x00027158
		public static int GetParameterAsInt(string[] parameters, int i, int defaultValue = 0)
		{
			return SequencerTools.GetParameterAs<int>(parameters, i, defaultValue);
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x00028F64 File Offset: 0x00027164
		public static bool GetParameterAsBool(string[] parameters, int i, bool defaultValue = false)
		{
			return SequencerTools.GetParameterAs<bool>(parameters, i, defaultValue);
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x00028F70 File Offset: 0x00027170
		public static AudioSource GetAudioSource(Transform subject)
		{
			GameObject gameObject = ((!(subject != null)) ? DialogueManager.Instance.gameObject : subject.gameObject);
			AudioSource component = gameObject.GetComponent<AudioSource>();
			return (!(component != null)) ? gameObject.AddComponent<AudioSource>() : component;
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x00028FC0 File Offset: 0x000271C0
		public static bool IsAudioMuted()
		{
			return DialogueLua.GetVariable("Mute").AsBool;
		}
	}
}
