using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime
{
	// Token: 0x020000C9 RID: 201
	public class MsgFlotanteTemporal : AplicableCustomMonobehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00015A92 File Offset: 0x00013C92
		public static int count
		{
			get
			{
				return MsgFlotanteTemporal.m_count;
			}
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00015A9C File Offset: 0x00013C9C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_transform = base.GetComponent<RectTransform>();
			if (this.m_transform == null)
			{
				throw new ArgumentNullException("m_transform", "m_transform null reference.");
			}
			this.m_CanvasScaler = base.GetComponentInParent<CanvasScaler>();
			if (this.m_CanvasScaler == null)
			{
				throw new ArgumentNullException("m_CanvasScaler", "m_CanvasScaler null reference.");
			}
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00015B03 File Offset: 0x00013D03
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_canHideCursor = Singleton<ConfiguracionGeneralDeMouse>.instance.canHideCursorModificableAnd.ObtenerModificadorNotNull(this);
			MsgFlotanteTemporal.m_count++;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00015B2D File Offset: 0x00013D2D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeBool canHideCursor = this.m_canHideCursor;
			if (canHideCursor != null)
			{
				canHideCursor.TryRemoverDeOwner(true);
			}
			MsgFlotanteTemporal.m_count--;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00015B55 File Offset: 0x00013D55
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00015B60 File Offset: 0x00013D60
		public void Mostrar(string title, string msg, float duracion, bool waitInFront, float? titleFontSize = null, float? msgFontSize = null, Action<object> OnTextClicked = null)
		{
			this.m_title.text = title;
			this.m_text.text = msg;
			this.m_textClickedCallBack = OnTextClicked;
			if (titleFontSize != null)
			{
				this.m_title.enableAutoSizing = false;
				this.m_title.fontSize = titleFontSize.Value;
			}
			if (msgFontSize != null)
			{
				this.m_text.enableAutoSizing = false;
				this.m_text.fontSize = msgFontSize.Value;
			}
			this.m_moveInRutine = base.StartCoroutine(this.MoveIn(duracion, waitInFront));
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00015BF0 File Offset: 0x00013DF0
		public void Ocultar()
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this.MoveOut());
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00015C05 File Offset: 0x00013E05
		private IEnumerator MoveIn(float duracion, bool waitInFront)
		{
			Vector2 target = this.m_transform.anchoredPosition;
			Vector2 targetConver = this.m_transform.anchoredPosition + new Vector2(0f, 100f);
			this.m_transform.anchoredPosition = new Vector2(0f, -this.m_transform.sizeDelta.y + 20f);
			Vector2 vector;
			do
			{
				yield return null;
				vector = (DialogueManager.IsConversationActive ? targetConver : target);
				this.m_transform.anchoredPosition = Vector2.MoveTowards(this.m_transform.anchoredPosition, vector, this.m_CanvasScaler.referenceResolution.y * this.m_velocidad * Time.deltaTime);
			}
			while (!MathfExtension.AlmostEqual(this.m_transform.anchoredPosition, vector, 0.1f));
			Coroutine coroutine = base.StartCoroutine(this.WaitInMoving());
			this.m_moveInRutine = base.StartCoroutine(this.WaitInFront(duracion, waitInFront, coroutine));
			yield break;
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x00015C22 File Offset: 0x00013E22
		private IEnumerator WaitInMoving()
		{
			Vector2 target = this.m_transform.anchoredPosition;
			Vector2 targetConver = this.m_transform.anchoredPosition + new Vector2(0f, 100f);
			for (;;)
			{
				yield return null;
				this.m_transform.anchoredPosition = Vector2.MoveTowards(this.m_transform.anchoredPosition, DialogueManager.IsConversationActive ? targetConver : target, this.m_CanvasScaler.referenceResolution.y * this.m_velocidad * Time.deltaTime);
			}
			yield break;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00015C31 File Offset: 0x00013E31
		private IEnumerator WaitInFront(float duracion, bool waitInFront, Coroutine waitMoving)
		{
			if (waitInFront)
			{
				while (base.transform.parent != null && base.transform.GetSiblingIndex() != base.transform.parent.childCount - 1)
				{
					yield return null;
				}
			}
			WaitForSeconds waitForSeconds = new WaitForSeconds(duracion);
			yield return waitForSeconds;
			base.StopCoroutine(waitMoving);
			base.StartCoroutine(this.MoveOut());
			yield break;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00015C55 File Offset: 0x00013E55
		private IEnumerator MoveOut()
		{
			Vector2 vector;
			do
			{
				yield return null;
				vector = new Vector2(0f, this.m_CanvasScaler.referenceResolution.y);
				this.m_transform.anchoredPosition = Vector2.MoveTowards(this.m_transform.anchoredPosition, vector, this.m_CanvasScaler.referenceResolution.y * this.m_velocidad * Time.deltaTime);
			}
			while (!MathfExtension.AlmostEqual(this.m_transform.anchoredPosition, vector, 0.1f));
			Object.Destroy(base.gameObject);
			yield break;
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00015C64 File Offset: 0x00013E64
		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (this.m_canHideCursor != null)
			{
				this.m_canHideCursor.valor.valor = false;
			}
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00015C7F File Offset: 0x00013E7F
		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (this.m_canHideCursor != null)
			{
				this.m_canHideCursor.valor.valor = true;
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00015C9C File Offset: 0x00013E9C
		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			if (eventData.pointerCurrentRaycast.gameObject == this.m_text.gameObject)
			{
				Action<object> textClickedCallBack = this.m_textClickedCallBack;
				if (textClickedCallBack == null)
				{
					return;
				}
				textClickedCallBack(this);
			}
		}

		// Token: 0x04000224 RID: 548
		private static int m_count;

		// Token: 0x04000225 RID: 549
		[SerializeField]
		private TextMeshProUGUI m_title;

		// Token: 0x04000226 RID: 550
		[SerializeField]
		private TextMeshProUGUI m_text;

		// Token: 0x04000227 RID: 551
		[SerializeField]
		private float m_velocidad = 1f;

		// Token: 0x04000228 RID: 552
		[NonSerialized]
		private bool m_ocultando;

		// Token: 0x04000229 RID: 553
		private RectTransform m_transform;

		// Token: 0x0400022A RID: 554
		private CanvasScaler m_CanvasScaler;

		// Token: 0x0400022B RID: 555
		[SerializeReference]
		private ModificadorDeBool m_canHideCursor;

		// Token: 0x0400022C RID: 556
		private Action<object> m_textClickedCallBack;

		// Token: 0x0400022D RID: 557
		private Coroutine m_moveInRutine;
	}
}
