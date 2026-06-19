using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.UI
{
	// Token: 0x0200000F RID: 15
	[RequireComponent(typeof(Canvas))]
	public sealed class MainCanvas : Singleton<MainCanvas>
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002B58 File Offset: 0x00000D58
		public static Canvas main
		{
			get
			{
				return Singleton<MainCanvas>.instance.m_MainCanvas;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002B64 File Offset: 0x00000D64
		protected override void InitData(bool esEditorTime)
		{
			this.m_MainCanvas = base.GetComponent<Canvas>();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002B72 File Offset: 0x00000D72
		protected override void Awaking()
		{
			base.Awaking();
			if (this.m_MsgFlotanteTemporal == null)
			{
				throw new ArgumentNullException("m_MsgFlotanteTemporal", "m_MsgFlotanteTemporal null reference.");
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002B98 File Offset: 0x00000D98
		public void MostrartMsg(string title, string msg, float duracion, bool waitInFront, float? titleFontSize = null, float? msgFontSize = null, Action<object> OnTextClicked = null)
		{
			int num = this.m_MainCanvas.transform.childCount - MsgFlotanteTemporal.count;
			MsgFlotanteTemporal msgFlotanteTemporal = Object.Instantiate<MsgFlotanteTemporal>(this.m_MsgFlotanteTemporal, this.m_MainCanvas.transform);
			msgFlotanteTemporal.transform.SetSiblingIndex(num);
			msgFlotanteTemporal.gameObject.SetActive(true);
			msgFlotanteTemporal.Mostrar(title, msg, duracion, waitInFront, titleFontSize, msgFontSize, OnTextClicked);
		}

		// Token: 0x04000027 RID: 39
		private Canvas m_MainCanvas;

		// Token: 0x04000028 RID: 40
		[SerializeField]
		private MsgFlotanteTemporal m_MsgFlotanteTemporal;
	}
}
