using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000260 RID: 608
	public static class Tools
	{
		// Token: 0x06001A2A RID: 6698 RVA: 0x0002C544 File Offset: 0x0002A744
		public static bool IsPrefab(GameObject go)
		{
			if (go == null)
			{
				return false;
			}
			if (go.activeInHierarchy)
			{
				return false;
			}
			if (go.transform.parent != null && go.transform.parent.gameObject.activeSelf)
			{
				return false;
			}
			GameObject[] array = Object.FindObjectsOfType<GameObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == go)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x0002C5CC File Offset: 0x0002A7CC
		public static byte HexToByte(string hex)
		{
			return byte.Parse(hex, NumberStyles.HexNumber);
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x0002C5DC File Offset: 0x0002A7DC
		public static bool IsNumber(object o)
		{
			return o is int || o is float || o is double;
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x0002C60C File Offset: 0x0002A80C
		public static int StringToInt(string s)
		{
			int num = 0;
			int.TryParse(s, out num);
			return num;
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x0002C628 File Offset: 0x0002A828
		public static float StringToFloat(string s)
		{
			float num = 0f;
			float.TryParse(s, out num);
			return num;
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x0002C648 File Offset: 0x0002A848
		public static bool StringToBool(string s)
		{
			return string.Compare(s, "True", StringComparison.OrdinalIgnoreCase) == 0;
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x0002C65C File Offset: 0x0002A85C
		public static bool IsStringNullOrEmptyOrWhitespace(string s)
		{
			return string.IsNullOrEmpty(s) || string.IsNullOrEmpty(s.Trim());
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x0002C678 File Offset: 0x0002A878
		public static string GetObjectName(Object o)
		{
			return (!(o != null)) ? "null" : o.name;
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x0002C698 File Offset: 0x0002A898
		public static string GetGameObjectName(Component c)
		{
			return (!(c == null)) ? c.name : string.Empty;
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x0002C6B8 File Offset: 0x0002A8B8
		public static string GetFullName(GameObject go)
		{
			string text = string.Empty;
			if (go != null)
			{
				text = go.name;
				Transform transform = go.transform.parent;
				while (transform != null)
				{
					text = transform.name + '.' + text;
					transform = transform.parent;
				}
			}
			return text;
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x0002C718 File Offset: 0x0002A918
		public static Transform Select(params Transform[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] != null)
				{
					return args[i];
				}
			}
			return null;
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x0002C74C File Offset: 0x0002A94C
		public static MonoBehaviour Select(params MonoBehaviour[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] != null)
				{
					return args[i];
				}
			}
			return null;
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x0002C780 File Offset: 0x0002A980
		public static void SendMessageToEveryone(string message)
		{
			foreach (GameObject gameObject in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				gameObject.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x0002C7C4 File Offset: 0x0002A9C4
		public static void SendMessageToEveryone(string message, string arg)
		{
			foreach (GameObject gameObject in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				gameObject.SendMessage(message, arg, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x0002C808 File Offset: 0x0002AA08
		public static IEnumerator SendMessageToEveryoneAsync(string message, int gameObjectsPerFrame)
		{
			GameObject[] gameObjects = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
			int count = 0;
			foreach (GameObject go in gameObjects)
			{
				go.SendMessage(message, SendMessageOptions.DontRequireReceiver);
				count++;
				if (count >= gameObjectsPerFrame)
				{
					count = 0;
					yield return null;
				}
			}
			yield break;
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x0002C838 File Offset: 0x0002AA38
		public static void SetGameObjectActive(Component component, bool value)
		{
			if (component != null)
			{
				component.gameObject.SetActive(value);
			}
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x0002C854 File Offset: 0x0002AA54
		public static bool ApproximatelyZero(float x)
		{
			return x < 0.0001f;
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x0002C860 File Offset: 0x0002AA60
		public static Color WebColor(string colorCode)
		{
			byte b = ((colorCode.Length <= 2) ? 0 : Tools.HexToByte(colorCode.Substring(1, 2)));
			byte b2 = ((colorCode.Length <= 4) ? 0 : Tools.HexToByte(colorCode.Substring(3, 2)));
			byte b3 = ((colorCode.Length <= 6) ? 0 : Tools.HexToByte(colorCode.Substring(5, 2)));
			return new Color32(b, b2, b3, byte.MaxValue);
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x0002C8E0 File Offset: 0x0002AAE0
		public static string ToWebColor(Color color)
		{
			return string.Format("#{0:x2}{1:x2}{2:x2}{3:x2}", new object[]
			{
				(int)(255f * color.r),
				(int)(255f * color.g),
				(int)(255f * color.b),
				(int)(255f * color.a)
			});
		}

		// Token: 0x06001A3D RID: 6717 RVA: 0x0002C958 File Offset: 0x0002AB58
		public static string StripRichTextCodes(string s)
		{
			if (!s.Contains("<"))
			{
				return s;
			}
			return Regex.Replace(s, "<b>|</b>|<i>|</i>|<color=[#]\\w+>|</color>", string.Empty);
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x0002C988 File Offset: 0x0002AB88
		public static bool IsClipInAnimations(Animation animation, string clipName)
		{
			if (animation != null)
			{
				foreach (object obj in animation)
				{
					AnimationState animationState = (AnimationState)obj;
					if (string.Equals(animationState.name, clipName))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x0002CA14 File Offset: 0x0002AC14
		public static GameObject GameObjectHardFind(string str)
		{
			GameObject gameObject = null;
			foreach (GameObject gameObject2 in Object.FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				if (gameObject2.transform.parent == null)
				{
					gameObject = Tools.GameObjectHardFind(gameObject2, str, 0, 0);
					if (gameObject != null)
					{
						break;
					}
				}
			}
			return gameObject;
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x0002CA84 File Offset: 0x0002AC84
		public static GameObject GameObjectHardFind(string str, string tag)
		{
			GameObject gameObject = null;
			foreach (GameObject gameObject2 in GameObject.FindGameObjectsWithTag(tag))
			{
				gameObject = Tools.GameObjectHardFind(gameObject2, str, 0, 0);
				if (gameObject != null)
				{
					break;
				}
			}
			return gameObject;
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x0002CAD0 File Offset: 0x0002ACD0
		private static GameObject GameObjectHardFind(GameObject item, string str, int index, int recursionDepth)
		{
			if (recursionDepth > Tools.maxHardFindRecursion)
			{
				return null;
			}
			if (index == 0 && item.name == str)
			{
				return item;
			}
			if (index >= item.transform.childCount)
			{
				return null;
			}
			GameObject gameObject = Tools.GameObjectHardFind(item.transform.GetChild(index).gameObject, str, 0, recursionDepth + 1);
			if (gameObject == null)
			{
				return Tools.GameObjectHardFind(item, str, ++index, recursionDepth + 1);
			}
			return gameObject;
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x0002CB50 File Offset: 0x0002AD50
		public static T GetComponentAnywhere<T>(GameObject gameObject) where T : Component
		{
			if (!gameObject)
			{
				return (T)((object)null);
			}
			T t = gameObject.GetComponentInChildren<T>();
			if (t)
			{
				return t;
			}
			Transform transform = gameObject.transform.parent;
			while (!t && transform)
			{
				t = transform.GetComponentInChildren<T>();
				transform = transform.parent;
			}
			return t;
		}

		// Token: 0x06001A43 RID: 6723 RVA: 0x0002CBC4 File Offset: 0x0002ADC4
		public static float GetGameObjectHeight(GameObject gameObject)
		{
			CharacterController component = gameObject.GetComponent<CharacterController>();
			if (component != null)
			{
				return component.height;
			}
			CapsuleCollider component2 = gameObject.GetComponent<CapsuleCollider>();
			if (component2 != null)
			{
				return component2.height;
			}
			BoxCollider component3 = gameObject.GetComponent<BoxCollider>();
			if (component3 != null)
			{
				return component3.center.y + component3.size.y;
			}
			SphereCollider component4 = gameObject.GetComponent<SphereCollider>();
			if (component4 != null)
			{
				return component4.center.y + component4.radius;
			}
			return 0f;
		}

		// Token: 0x06001A44 RID: 6724 RVA: 0x0002CC68 File Offset: 0x0002AE68
		public static void SetComponentEnabled(Component component, Toggle state)
		{
			if (component == null)
			{
				return;
			}
			bool flag;
			if (component is Renderer)
			{
				Renderer renderer = component as Renderer;
				flag = ToggleTools.GetNewValue(renderer.enabled, state);
				renderer.enabled = flag;
			}
			else if (component is Collider)
			{
				Collider collider = component as Collider;
				flag = ToggleTools.GetNewValue(collider.enabled, state);
				collider.enabled = flag;
			}
			else if (component is Animation)
			{
				Animation animation = component as Animation;
				flag = ToggleTools.GetNewValue(animation.enabled, state);
				animation.enabled = flag;
			}
			else if (component is Animator)
			{
				Animator animator = component as Animator;
				flag = ToggleTools.GetNewValue(animator.enabled, state);
				animator.enabled = flag;
			}
			else if (component is AudioSource)
			{
				AudioSource audioSource = component as AudioSource;
				flag = ToggleTools.GetNewValue(audioSource.enabled, state);
				audioSource.enabled = flag;
			}
			else
			{
				if (!(component is Behaviour))
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Don't know how to enable/disable {1}.{2}", new object[]
						{
							"Dialogue System",
							component.name,
							component.GetType().Name
						}));
					}
					return;
				}
				Behaviour behaviour = component as Behaviour;
				flag = ToggleTools.GetNewValue(behaviour.enabled, state);
				behaviour.enabled = flag;
			}
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: {1}.{2}.enabled = {3}", new object[]
				{
					"Dialogue System",
					component.name,
					component.GetType().Name,
					flag
				}));
			}
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x0002CE14 File Offset: 0x0002B014
		public static bool IsCursorActive()
		{
			return Tools.IsCursorVisible() && !Tools.IsCursorLocked();
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x0002CE2C File Offset: 0x0002B02C
		public static void SetCursorActive(bool value)
		{
			Tools.ShowCursor(value);
			Tools.LockCursor(!value);
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x0002CE40 File Offset: 0x0002B040
		public static bool IsCursorVisible()
		{
			return Cursor.visible;
		}

		// Token: 0x06001A48 RID: 6728 RVA: 0x0002CE48 File Offset: 0x0002B048
		public static bool IsCursorLocked()
		{
			return Cursor.lockState != CursorLockMode.None;
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x0002CE58 File Offset: 0x0002B058
		public static void ShowCursor(bool value)
		{
			Cursor.visible = value;
		}

		// Token: 0x06001A4A RID: 6730 RVA: 0x0002CE60 File Offset: 0x0002B060
		public static void LockCursor(bool value)
		{
			if (!value && Tools.IsCursorLocked())
			{
				Tools.previousLockMode = Cursor.lockState;
			}
			Cursor.lockState = ((!value) ? CursorLockMode.None : Tools.previousLockMode);
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x0002CEA0 File Offset: 0x0002B0A0
		public static void LoadLevel(int index)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log("Dialogue System: Loading level #" + index);
			}
			SceneManager.LoadScene(index);
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x0002CEC8 File Offset: 0x0002B0C8
		public static void LoadLevel(string name)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log("Dialogue System: Loading level " + name);
			}
			SceneManager.LoadScene(name);
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x0002CEF8 File Offset: 0x0002B0F8
		public static AsyncOperation LoadLevelAsync(string name)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log("Dialogue System: Asynchronously loading level " + name);
			}
			return SceneManager.LoadSceneAsync(name);
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x0002CF28 File Offset: 0x0002B128
		public static AsyncOperation LoadLevelAsync(int index)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log("Dialogue System: Asynchronously loading level " + index);
			}
			return SceneManager.LoadSceneAsync(index);
		}

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06001A4F RID: 6735 RVA: 0x0002CF50 File Offset: 0x0002B150
		public static string loadedLevelName
		{
			get
			{
				return SceneManager.GetActiveScene().name;
			}
		}

		// Token: 0x04000EF8 RID: 3832
		public static int maxHardFindRecursion = 256;

		// Token: 0x04000EF9 RID: 3833
		private static CursorLockMode previousLockMode = CursorLockMode.Locked;
	}
}
