using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000029 RID: 41
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html#unityUIDialogueUITypewriterEffect")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Unity UI Typewriter Effect")]
	[DisallowMultipleComponent]
	public class UnityUITypewriterEffect : MonoBehaviour
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000059EC File Offset: 0x00003BEC
		public bool IsPlaying
		{
			get
			{
				return this.typewriterCoroutine != null;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000059F8 File Offset: 0x00003BF8
		public void Awake()
		{
			this.control = base.GetComponent<Text>();
			if (this.removeDuplicateTypewriterEffects)
			{
				this.RemoveIfDuplicate();
			}
			if (this.audioSource == null)
			{
				this.audioSource = base.GetComponent<AudioSource>();
			}
			if (this.audioSource == null && (this.audioClip != null || (this.alternateAudioClips != null && this.alternateAudioClips.Length != 0)))
			{
				this.audioSource = base.gameObject.AddComponent<AudioSource>();
				this.audioSource.playOnAwake = false;
				this.audioSource.panStereo = 0f;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00005A94 File Offset: 0x00003C94
		private void RemoveIfDuplicate()
		{
			UnityUITypewriterEffect[] components = base.GetComponents<UnityUITypewriterEffect>();
			if (components.Length > 1)
			{
				UnityUITypewriterEffect unityUITypewriterEffect = components[0];
				for (int i = 1; i < components.Length; i++)
				{
					if (components[i].GetInstanceID() < unityUITypewriterEffect.GetInstanceID())
					{
						unityUITypewriterEffect = components[i];
					}
				}
				for (int j = 0; j < components.Length; j++)
				{
					if (components[j] != unityUITypewriterEffect)
					{
						Object.Destroy(components[j]);
					}
				}
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005AF8 File Offset: 0x00003CF8
		public void Start()
		{
			if (this.control != null)
			{
				this.control.supportRichText = true;
			}
			if (!this.IsPlaying && this.playOnEnable)
			{
				this.original = null;
				this.StopTypewriterCoroutine();
				this.StartTypewriterCoroutine();
			}
			this.started = true;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005B49 File Offset: 0x00003D49
		public void OnEnable()
		{
			if (!this.IsPlaying && this.playOnEnable && this.started)
			{
				this.original = null;
				this.StopTypewriterCoroutine();
				this.StartTypewriterCoroutine();
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00005B76 File Offset: 0x00003D76
		public void OnDisable()
		{
			this.Stop();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005B7E File Offset: 0x00003D7E
		public void Pause()
		{
			this.paused = true;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005B87 File Offset: 0x00003D87
		public void Unpause()
		{
			this.paused = false;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005B90 File Offset: 0x00003D90
		public void PlayText(string text)
		{
			this.StopTypewriterCoroutine();
			this.original = text;
			this.StartTypewriterCoroutine();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005BA8 File Offset: 0x00003DA8
		private void StartTypewriterCoroutine()
		{
			if (this.coroutineController == null || !this.coroutineController.gameObject.activeInHierarchy)
			{
				MonoBehaviour monoBehaviour = base.GetComponentInParent<UnityUIDialogueUI>();
				if (monoBehaviour == null)
				{
					monoBehaviour = DialogueManager.Instance;
				}
				this.coroutineController = monoBehaviour;
			}
			this.typewriterCoroutine = this.coroutineController.StartCoroutine(this.Play());
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005C09 File Offset: 0x00003E09
		public IEnumerator Play()
		{
			if (this.control != null && this.charactersPerSecond > 0f)
			{
				this.InitAutoScroll();
				if (this.waitOneFrameBeforeStarting)
				{
					yield return null;
				}
				if (this.audioSource != null)
				{
					this.audioSource.clip = this.audioClip;
				}
				this.onBegin.Invoke();
				this.paused = false;
				float delay = 1f / this.charactersPerSecond;
				float lastTime = DialogueTime.time;
				float elapsed = 0f;
				int charactersTyped = 0;
				if (this.original == null)
				{
					this.original = this.control.text;
				}
				this.tokens = this.Tokenize(this.original);
				this.openTokenTypes = new List<UnityUITypewriterEffect.TokenType>();
				this.current = new StringBuilder();
				while (this.tokens.Count > 0)
				{
					if (!this.paused)
					{
						float num = DialogueTime.time - lastTime;
						elapsed += num;
						float goal = elapsed * this.charactersPerSecond;
						bool flag = false;
						while (((float)charactersTyped < goal || flag) && this.tokens.Count > 0)
						{
							UnityUITypewriterEffect.Token nextToken = this.GetNextToken(this.tokens);
							switch (nextToken.tokenType)
							{
							case UnityUITypewriterEffect.TokenType.Character:
							{
								if (this.rightToLeft)
								{
									this.current.Insert(0, nextToken.character);
								}
								else
								{
									this.current.Append(nextToken.character);
								}
								if (!this.IsSilentCharacter(nextToken.character))
								{
									this.PlayCharacterAudio();
								}
								this.onCharacter.Invoke();
								int num2 = charactersTyped;
								charactersTyped = num2 + 1;
								break;
							}
							case UnityUITypewriterEffect.TokenType.BoldOpen:
							case UnityUITypewriterEffect.TokenType.ItalicOpen:
							case UnityUITypewriterEffect.TokenType.ColorOpen:
							case UnityUITypewriterEffect.TokenType.SizeOpen:
								this.OpenRichText(this.current, nextToken, this.openTokenTypes);
								break;
							case UnityUITypewriterEffect.TokenType.BoldClose:
							case UnityUITypewriterEffect.TokenType.ItalicClose:
							case UnityUITypewriterEffect.TokenType.ColorClose:
							case UnityUITypewriterEffect.TokenType.SizeClose:
								this.CloseRichText(this.current, nextToken, this.openTokenTypes);
								break;
							case UnityUITypewriterEffect.TokenType.Quad:
								this.current.Append(nextToken.code);
								break;
							case UnityUITypewriterEffect.TokenType.Pause:
							{
								this.control.text = this.GetCurrentText(this.current, this.openTokenTypes, this.tokens, false);
								this.paused = true;
								float continueTime = DialogueTime.time + nextToken.duration;
								int pauseSafeguard = 0;
								while (DialogueTime.time < continueTime && pauseSafeguard < 999)
								{
									int num2 = pauseSafeguard;
									pauseSafeguard = num2 + 1;
									yield return null;
								}
								this.paused = false;
								break;
							}
							case UnityUITypewriterEffect.TokenType.InstantOpen:
								this.AddInstantText(this.current, this.openTokenTypes, this.tokens);
								break;
							}
							flag = this.tokens.Count > 0 && this.tokens[0].tokenType > UnityUITypewriterEffect.TokenType.Character;
						}
					}
					this.control.text = this.GetCurrentText(this.current, this.openTokenTypes, this.tokens, false);
					this.HandleAutoScroll();
					lastTime = DialogueTime.time;
					float delayTime = DialogueTime.time + delay;
					int delaySafeguard = 0;
					while (DialogueTime.time < delayTime && delaySafeguard < 999)
					{
						int num2 = delaySafeguard;
						delaySafeguard = num2 + 1;
						yield return null;
					}
				}
			}
			this.Stop();
			yield break;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00005C18 File Offset: 0x00003E18
		private void PlayCharacterAudio()
		{
			if (this.audioClip == null || this.audioSource == null)
			{
				return;
			}
			AudioClip audioClip = null;
			if (this.alternateAudioClips != null && this.alternateAudioClips.Length != 0)
			{
				int num = Random.Range(0, this.alternateAudioClips.Length + 1);
				audioClip = ((num < this.alternateAudioClips.Length) ? this.alternateAudioClips[num] : this.audioClip);
			}
			if (this.interruptAudioClip)
			{
				if (this.audioSource.isPlaying)
				{
					this.audioSource.Stop();
				}
				if (audioClip != null)
				{
					this.audioSource.clip = audioClip;
				}
				this.audioSource.Play();
				return;
			}
			if (!this.audioSource.isPlaying)
			{
				if (audioClip != null)
				{
					this.audioSource.clip = audioClip;
				}
				this.audioSource.Play();
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005CF0 File Offset: 0x00003EF0
		private bool IsSilentCharacter(char c)
		{
			return !string.IsNullOrEmpty(this.silentCharacters) && this.silentCharacters.Contains(c.ToString());
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00005D14 File Offset: 0x00003F14
		private UnityUITypewriterEffect.Token GetNextToken(List<UnityUITypewriterEffect.Token> tokens)
		{
			if (tokens.Count == 0)
			{
				return null;
			}
			int num = (this.rightToLeft ? (tokens.Count - 1) : 0);
			UnityUITypewriterEffect.Token token = tokens[num];
			tokens.RemoveAt(num);
			return token;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00005D50 File Offset: 0x00003F50
		private void OpenRichText(StringBuilder current, UnityUITypewriterEffect.Token token, List<UnityUITypewriterEffect.TokenType> openTokens)
		{
			switch (token.tokenType)
			{
			case UnityUITypewriterEffect.TokenType.BoldOpen:
				current.Append("<b>");
				break;
			case UnityUITypewriterEffect.TokenType.ItalicOpen:
				current.Append("<i>");
				break;
			case UnityUITypewriterEffect.TokenType.ColorOpen:
			case UnityUITypewriterEffect.TokenType.SizeOpen:
				current.Append(token.code);
				break;
			}
			openTokens.Insert(0, token.tokenType);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00005DC0 File Offset: 0x00003FC0
		private void CloseRichText(StringBuilder current, UnityUITypewriterEffect.Token token, List<UnityUITypewriterEffect.TokenType> openTokens)
		{
			UnityUITypewriterEffect.TokenType tokenType = UnityUITypewriterEffect.TokenType.BoldOpen;
			switch (token.tokenType)
			{
			case UnityUITypewriterEffect.TokenType.BoldClose:
				current.Append("</b>");
				tokenType = UnityUITypewriterEffect.TokenType.BoldOpen;
				break;
			case UnityUITypewriterEffect.TokenType.ItalicClose:
				current.Append("</i>");
				tokenType = UnityUITypewriterEffect.TokenType.ItalicOpen;
				break;
			case UnityUITypewriterEffect.TokenType.ColorClose:
				current.Append("</color>");
				tokenType = UnityUITypewriterEffect.TokenType.ColorOpen;
				break;
			case UnityUITypewriterEffect.TokenType.SizeClose:
				current.Append("</size>");
				tokenType = UnityUITypewriterEffect.TokenType.SizeOpen;
				break;
			}
			int num = -1;
			for (int i = 0; i < openTokens.Count; i++)
			{
				if (openTokens[i] == tokenType)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				openTokens.RemoveAt(num);
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005E68 File Offset: 0x00004068
		private void AddInstantText(StringBuilder current, List<UnityUITypewriterEffect.TokenType> openTokenTypes, List<UnityUITypewriterEffect.Token> tokens)
		{
			int num = 0;
			while (tokens.Count > 0 && num < this.MaxSafeguard)
			{
				num++;
				UnityUITypewriterEffect.Token nextToken = this.GetNextToken(tokens);
				switch (nextToken.tokenType)
				{
				case UnityUITypewriterEffect.TokenType.Character:
					current.Append(nextToken.character);
					break;
				case UnityUITypewriterEffect.TokenType.BoldOpen:
				case UnityUITypewriterEffect.TokenType.ItalicOpen:
				case UnityUITypewriterEffect.TokenType.ColorOpen:
				case UnityUITypewriterEffect.TokenType.SizeOpen:
					this.OpenRichText(current, nextToken, openTokenTypes);
					break;
				case UnityUITypewriterEffect.TokenType.BoldClose:
				case UnityUITypewriterEffect.TokenType.ItalicClose:
				case UnityUITypewriterEffect.TokenType.ColorClose:
				case UnityUITypewriterEffect.TokenType.SizeClose:
					this.CloseRichText(current, nextToken, openTokenTypes);
					break;
				case UnityUITypewriterEffect.TokenType.InstantClose:
					return;
				}
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005F04 File Offset: 0x00004104
		private string GetCurrentText(StringBuilder current, List<UnityUITypewriterEffect.TokenType> openTokenTypes, List<UnityUITypewriterEffect.Token> tokens, bool withoutTransparentText = false)
		{
			if (current == null)
			{
				return string.Empty;
			}
			if (openTokenTypes == null || tokens == null)
			{
				return current.ToString();
			}
			StringBuilder stringBuilder = new StringBuilder(current.ToString());
			for (int i = 0; i < openTokenTypes.Count; i++)
			{
				switch (openTokenTypes[i])
				{
				case UnityUITypewriterEffect.TokenType.BoldOpen:
					stringBuilder.Append("</b>");
					break;
				case UnityUITypewriterEffect.TokenType.ItalicOpen:
					stringBuilder.Append("</i>");
					break;
				case UnityUITypewriterEffect.TokenType.ColorOpen:
					stringBuilder.Append("</color>");
					break;
				case UnityUITypewriterEffect.TokenType.SizeOpen:
					stringBuilder.Append("</size>");
					break;
				}
			}
			if (withoutTransparentText)
			{
				return stringBuilder.ToString();
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			if (!this.autoScrollSettings.autoScrollEnabled || !(this.autoScrollSettings.sizerText == null))
			{
				stringBuilder2.Append("<color=#00000000>");
				for (int j = openTokenTypes.Count - 1; j >= 0; j--)
				{
					UnityUITypewriterEffect.TokenType tokenType = openTokenTypes[j];
					if (tokenType != UnityUITypewriterEffect.TokenType.BoldOpen)
					{
						if (tokenType == UnityUITypewriterEffect.TokenType.ItalicOpen)
						{
							stringBuilder2.Append("<i>");
						}
					}
					else
					{
						stringBuilder2.Append("<b>");
					}
				}
				for (int k = 0; k < tokens.Count; k++)
				{
					UnityUITypewriterEffect.Token token = tokens[k];
					switch (token.tokenType)
					{
					case UnityUITypewriterEffect.TokenType.Character:
						stringBuilder2.Append(token.character);
						break;
					case UnityUITypewriterEffect.TokenType.BoldOpen:
						stringBuilder2.Append("<b>");
						break;
					case UnityUITypewriterEffect.TokenType.BoldClose:
						stringBuilder2.Append("</b>");
						break;
					case UnityUITypewriterEffect.TokenType.ItalicOpen:
						stringBuilder2.Append("<i>");
						break;
					case UnityUITypewriterEffect.TokenType.ItalicClose:
						stringBuilder2.Append("</i>");
						break;
					}
				}
				stringBuilder2.Append("</color>");
				if (this.rightToLeft)
				{
					stringBuilder.Insert(0, stringBuilder2);
				}
				else
				{
					stringBuilder.Append(stringBuilder2);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00006100 File Offset: 0x00004300
		private List<UnityUITypewriterEffect.Token> Tokenize(string text)
		{
			List<UnityUITypewriterEffect.Token> list = new List<UnityUITypewriterEffect.Token>();
			string text2 = text;
			int num = 0;
			while (!string.IsNullOrEmpty(text2) && num < this.MaxSafeguard)
			{
				num++;
				UnityUITypewriterEffect.Token token = null;
				if (text2.StartsWith("<"))
				{
					token = this.TryTokenize("<b>", UnityUITypewriterEffect.TokenType.BoldOpen, 0f, ref text2);
					if (token == null)
					{
						token = this.TryTokenize("</b>", UnityUITypewriterEffect.TokenType.BoldClose, 0f, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenize("<i>", UnityUITypewriterEffect.TokenType.ItalicOpen, 0f, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenize("</i>", UnityUITypewriterEffect.TokenType.ItalicClose, 0f, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenize("</color>", UnityUITypewriterEffect.TokenType.ColorClose, 0f, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenize("</size>", UnityUITypewriterEffect.TokenType.SizeClose, 0f, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenizeColorOpen(ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenizeSizeOpen(ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenizeQuad(ref text2);
					}
				}
				else if (text2.StartsWith("\\"))
				{
					token = this.TryTokenize("\\.", UnityUITypewriterEffect.TokenType.Pause, this.fullPauseDuration, ref text2);
					if (token == null)
					{
						token = this.TryTokenize("\\,", UnityUITypewriterEffect.TokenType.Pause, this.quarterPauseDuration, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenize("\\>", UnityUITypewriterEffect.TokenType.InstantOpen, 0f, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenize("\\<", UnityUITypewriterEffect.TokenType.InstantClose, 0f, ref text2);
					}
					if (token == null)
					{
						token = this.TryTokenize("\\^", UnityUITypewriterEffect.TokenType.InstantOpen, 0f, ref text2);
					}
				}
				if (token == null)
				{
					token = new UnityUITypewriterEffect.Token(UnityUITypewriterEffect.TokenType.Character, text2[0], string.Empty, 0f);
					text2 = text2.Remove(0, 1);
				}
				list.Add(token);
			}
			return list;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000062A9 File Offset: 0x000044A9
		private UnityUITypewriterEffect.Token TryTokenize(string code, UnityUITypewriterEffect.TokenType tokenType, float duration, ref string remainder)
		{
			if (remainder.StartsWith(code))
			{
				remainder = remainder.Remove(0, code.Length);
				return new UnityUITypewriterEffect.Token(tokenType, ' ', string.Empty, duration);
			}
			return null;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000062D8 File Offset: 0x000044D8
		private UnityUITypewriterEffect.Token TryTokenizeColorOpen(ref string remainder)
		{
			if (remainder.StartsWith("<color="))
			{
				string text = remainder.Substring(0, remainder.IndexOf('>') + 1);
				remainder = remainder.Remove(0, text.Length);
				return new UnityUITypewriterEffect.Token(UnityUITypewriterEffect.TokenType.ColorOpen, ' ', text, 0f);
			}
			return null;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006328 File Offset: 0x00004528
		private UnityUITypewriterEffect.Token TryTokenizeSizeOpen(ref string remainder)
		{
			if (remainder.StartsWith("<size="))
			{
				string text = remainder.Substring(0, remainder.IndexOf('>') + 1);
				remainder = remainder.Remove(0, text.Length);
				return new UnityUITypewriterEffect.Token(UnityUITypewriterEffect.TokenType.SizeOpen, ' ', text, 0f);
			}
			return null;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006378 File Offset: 0x00004578
		private UnityUITypewriterEffect.Token TryTokenizeQuad(ref string remainder)
		{
			if (remainder.StartsWith("<quad "))
			{
				string text = remainder.Substring(0, remainder.IndexOf('>') + 1);
				remainder = remainder.Remove(0, text.Length);
				return new UnityUITypewriterEffect.Token(UnityUITypewriterEffect.TokenType.Quad, ' ', text, 0f);
			}
			return null;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000063C8 File Offset: 0x000045C8
		public static string StripRPGMakerCodes(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}
			if (!s.Contains("\\"))
			{
				return s;
			}
			return s.Replace("\\,", string.Empty).Replace("\\.", string.Empty).Replace("\\^", string.Empty)
				.Replace("\\>", string.Empty)
				.Replace("\\<", string.Empty);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000643C File Offset: 0x0000463C
		private void StopTypewriterCoroutine()
		{
			if (this.typewriterCoroutine == null)
			{
				return;
			}
			if (this.coroutineController == null)
			{
				base.StopCoroutine(this.typewriterCoroutine);
			}
			else
			{
				this.coroutineController.StopCoroutine(this.typewriterCoroutine);
			}
			this.typewriterCoroutine = null;
			this.coroutineController = null;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00006490 File Offset: 0x00004690
		public void Stop()
		{
			if (this.IsPlaying)
			{
				this.onEnd.Invoke();
			}
			this.StopTypewriterCoroutine();
			if (this.control != null)
			{
				this.control.text = UnityUITypewriterEffect.StripRPGMakerCodes(this.original);
			}
			this.original = null;
			if (this.autoScrollSettings.autoScrollEnabled)
			{
				if (this.current != null && this.autoScrollSettings.sizerText != null)
				{
					this.current = new StringBuilder(this.control.text);
					if (base.enabled && base.gameObject.activeInHierarchy)
					{
						base.StartCoroutine(this.HandleAutoScrollAfterOneFrame());
					}
				}
				this.HandleAutoScroll();
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00006548 File Offset: 0x00004748
		private void InitAutoScroll()
		{
			if (this.autoScrollSettings.autoScrollEnabled && this.autoScrollSettings.sizerText != null)
			{
				this.autoScrollSettings.sizerText.color = new Color(0f, 0f, 0f, 0f);
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000065A0 File Offset: 0x000047A0
		private void HandleAutoScroll()
		{
			if (!this.autoScrollSettings.autoScrollEnabled)
			{
				return;
			}
			if (this.autoScrollSettings.sizerText != null)
			{
				this.autoScrollSettings.sizerText.text = this.GetCurrentText(this.current, this.openTokenTypes, this.tokens, true);
			}
			if (this.autoScrollSettings.scrollRect != null)
			{
				this.autoScrollSettings.scrollRect.normalizedPosition = Vector2.zero;
			}
			if (this.autoScrollSettings.scrollbarEnabler != null)
			{
				this.autoScrollSettings.scrollbarEnabler.CheckScrollbar();
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00006642 File Offset: 0x00004842
		private IEnumerator HandleAutoScrollAfterOneFrame()
		{
			yield return null;
			this.HandleAutoScroll();
			yield break;
		}

		// Token: 0x040000A9 RID: 169
		[Tooltip("Tick for right-to-left text such as Arabic.")]
		public bool rightToLeft;

		// Token: 0x040000AA RID: 170
		[Tooltip("How fast to type. This is separate from Dialogue Manager > Subtitle Settings > Chars Per Second.")]
		public float charactersPerSecond = 50f;

		// Token: 0x040000AB RID: 171
		[Tooltip("Optional audio clip to play with each character.")]
		public AudioClip audioClip;

		// Token: 0x040000AC RID: 172
		[Tooltip("If specified, randomly use these clips or the main Audio Clip.")]
		public AudioClip[] alternateAudioClips = new AudioClip[0];

		// Token: 0x040000AD RID: 173
		[Tooltip("Optional audio source through which to play the clip.")]
		public AudioSource audioSource;

		// Token: 0x040000AE RID: 174
		[Tooltip("If audio clip is still playing from previous character, stop and restart it when typing next character.")]
		public bool interruptAudioClip;

		// Token: 0x040000AF RID: 175
		[Tooltip("Don't play audio on these characters.")]
		public string silentCharacters = string.Empty;

		// Token: 0x040000B0 RID: 176
		[Tooltip("Duration to pause on when text contains '\\.'")]
		public float fullPauseDuration = 1f;

		// Token: 0x040000B1 RID: 177
		[Tooltip("Duration to pause when text contains '\\,'")]
		public float quarterPauseDuration = 0.25f;

		// Token: 0x040000B2 RID: 178
		[Tooltip("Ensure this GameObject has only one typewriter effect.")]
		public bool removeDuplicateTypewriterEffects = true;

		// Token: 0x040000B3 RID: 179
		[Tooltip("Play using the current text content whenever component is enabled.")]
		public bool playOnEnable = true;

		// Token: 0x040000B4 RID: 180
		[Tooltip("Wait one frame to allow layout elements to setup first.")]
		public bool waitOneFrameBeforeStarting;

		// Token: 0x040000B5 RID: 181
		public UnityUITypewriterEffect.AutoScrollSettings autoScrollSettings = new UnityUITypewriterEffect.AutoScrollSettings();

		// Token: 0x040000B6 RID: 182
		public UnityEvent onBegin = new UnityEvent();

		// Token: 0x040000B7 RID: 183
		public UnityEvent onCharacter = new UnityEvent();

		// Token: 0x040000B8 RID: 184
		public UnityEvent onEnd = new UnityEvent();

		// Token: 0x040000B9 RID: 185
		private const string RichTextBoldOpen = "<b>";

		// Token: 0x040000BA RID: 186
		private const string RichTextBoldClose = "</b>";

		// Token: 0x040000BB RID: 187
		private const string RichTextItalicOpen = "<i>";

		// Token: 0x040000BC RID: 188
		private const string RichTextItalicClose = "</i>";

		// Token: 0x040000BD RID: 189
		private const string RichTextColorOpenPrefix = "<color=";

		// Token: 0x040000BE RID: 190
		private const string RichTextColorClose = "</color>";

		// Token: 0x040000BF RID: 191
		private const string RichTextSizeOpenPrefix = "<size=";

		// Token: 0x040000C0 RID: 192
		private const string RichTextSizeClose = "</size>";

		// Token: 0x040000C1 RID: 193
		private const string QuadPrefix = "<quad ";

		// Token: 0x040000C2 RID: 194
		private const string RPGMakerCodeQuarterPause = "\\,";

		// Token: 0x040000C3 RID: 195
		private const string RPGMakerCodeFullPause = "\\.";

		// Token: 0x040000C4 RID: 196
		private const string RPGMakerCodeSkipToEnd = "\\^";

		// Token: 0x040000C5 RID: 197
		private const string RPGMakerCodeInstantOpen = "\\>";

		// Token: 0x040000C6 RID: 198
		private const string RPGMakerCodeInstantClose = "\\<";

		// Token: 0x040000C7 RID: 199
		private Text control;

		// Token: 0x040000C8 RID: 200
		private bool started;

		// Token: 0x040000C9 RID: 201
		private bool paused;

		// Token: 0x040000CA RID: 202
		private string original;

		// Token: 0x040000CB RID: 203
		private Coroutine typewriterCoroutine;

		// Token: 0x040000CC RID: 204
		private MonoBehaviour coroutineController;

		// Token: 0x040000CD RID: 205
		private StringBuilder current;

		// Token: 0x040000CE RID: 206
		private List<UnityUITypewriterEffect.TokenType> openTokenTypes;

		// Token: 0x040000CF RID: 207
		private List<UnityUITypewriterEffect.Token> tokens;

		// Token: 0x040000D0 RID: 208
		private int MaxSafeguard = 16384;

		// Token: 0x02000069 RID: 105
		[Serializable]
		public class AutoScrollSettings
		{
			// Token: 0x04000247 RID: 583
			[Tooltip("Automatically scroll to bottom of scroll rect. Useful for long text. Works best with left justification. Make sure the text has a Content Size Fitter.")]
			public bool autoScrollEnabled;

			// Token: 0x04000248 RID: 584
			public ScrollRect scrollRect;

			// Token: 0x04000249 RID: 585
			[Tooltip("If assigned, the Scrollbar Enabler will be updated with each character to determine if it needs to show the scrollbar.")]
			public UnityUIScrollbarEnabler scrollbarEnabler;

			// Token: 0x0400024A RID: 586
			[Tooltip("If assigned, this should be a copy of the Text component on this typewriter effect. The Sizer Text should have a Content Size Fitter, but the typewriter Text component should not. Make the Sizer Text a parent of the typewriter Text component.")]
			public Text sizerText;
		}

		// Token: 0x0200006A RID: 106
		private enum TokenType
		{
			// Token: 0x0400024C RID: 588
			Character,
			// Token: 0x0400024D RID: 589
			BoldOpen,
			// Token: 0x0400024E RID: 590
			BoldClose,
			// Token: 0x0400024F RID: 591
			ItalicOpen,
			// Token: 0x04000250 RID: 592
			ItalicClose,
			// Token: 0x04000251 RID: 593
			ColorOpen,
			// Token: 0x04000252 RID: 594
			ColorClose,
			// Token: 0x04000253 RID: 595
			SizeOpen,
			// Token: 0x04000254 RID: 596
			SizeClose,
			// Token: 0x04000255 RID: 597
			Quad,
			// Token: 0x04000256 RID: 598
			Pause,
			// Token: 0x04000257 RID: 599
			InstantOpen,
			// Token: 0x04000258 RID: 600
			InstantClose
		}

		// Token: 0x0200006B RID: 107
		private class Token
		{
			// Token: 0x060002B1 RID: 689 RVA: 0x0000DC9B File Offset: 0x0000BE9B
			public Token(UnityUITypewriterEffect.TokenType tokenType, char character, string code, float duration)
			{
				this.tokenType = tokenType;
				this.character = character;
				this.code = code;
				this.duration = duration;
			}

			// Token: 0x04000259 RID: 601
			public UnityUITypewriterEffect.TokenType tokenType;

			// Token: 0x0400025A RID: 602
			public char character;

			// Token: 0x0400025B RID: 603
			public string code;

			// Token: 0x0400025C RID: 604
			public float duration;
		}
	}
}
