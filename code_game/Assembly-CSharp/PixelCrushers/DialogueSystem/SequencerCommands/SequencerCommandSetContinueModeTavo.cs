using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200003F RID: 63
	public class SequencerCommandSetContinueModeTavo : SequencerCommand
	{
		// Token: 0x06000135 RID: 309 RVA: 0x0000B288 File Offset: 0x00009488
		public void Start()
		{
			try
			{
				SequencerCommandSetContinueModeTavo.SetContinueMode(base.GetParameterAsBool(0, true));
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000B2BC File Offset: 0x000094BC
		public static bool GetContinueMode()
		{
			return DialogueManager.Instance.displaySettings.subtitleSettings.continueButton == DisplaySettings.SubtitleSettings.ContinueButtonMode.NotBeforeResponseMenu;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000B2D5 File Offset: 0x000094D5
		public static void SetContinueMode(bool @continue)
		{
			if (@continue)
			{
				DialogueManager.Instance.displaySettings.subtitleSettings.continueButton = DisplaySettings.SubtitleSettings.ContinueButtonMode.NotBeforeResponseMenu;
				SequencerCommandSetContinueModeTavo.ApplyToBotones(true);
				return;
			}
			DialogueManager.Instance.displaySettings.subtitleSettings.continueButton = DisplaySettings.SubtitleSettings.ContinueButtonMode.Never;
			SequencerCommandSetContinueModeTavo.ApplyToBotones(false);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000B314 File Offset: 0x00009514
		public static void ApplyToBotones(bool enabled)
		{
			try
			{
				Transform transform = DialogueManager.Instance.transform;
				transform.GetComponentsInChildren<UnityUIContinueButtonFastForward>(true, SequencerCommandSetContinueModeTavo.m_temp);
				transform.GetComponentsInChildren<UnityUIContinueButtonFastForwardTValle>(true, SequencerCommandSetContinueModeTavo.m_temp2);
				foreach (UnityUIContinueButtonFastForward unityUIContinueButtonFastForward in SequencerCommandSetContinueModeTavo.m_temp)
				{
					unityUIContinueButtonFastForward.gameObject.SetActive(enabled);
				}
				foreach (UnityUIContinueButtonFastForwardTValle unityUIContinueButtonFastForwardTValle in SequencerCommandSetContinueModeTavo.m_temp2)
				{
					unityUIContinueButtonFastForwardTValle.gameObject.SetActive(enabled);
				}
			}
			finally
			{
				SequencerCommandSetContinueModeTavo.m_temp.Clear();
				SequencerCommandSetContinueModeTavo.m_temp2.Clear();
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000B3F0 File Offset: 0x000095F0
		public void Update()
		{
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000B3F2 File Offset: 0x000095F2
		public void OnDestroy()
		{
		}

		// Token: 0x040000AD RID: 173
		private static List<UnityUIContinueButtonFastForward> m_temp = new List<UnityUIContinueButtonFastForward>();

		// Token: 0x040000AE RID: 174
		private static List<UnityUIContinueButtonFastForwardTValle> m_temp2 = new List<UnityUIContinueButtonFastForwardTValle>();
	}
}
