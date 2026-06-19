using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.TValle.IU.Runtime.Interacciones.Donas
{
	// Token: 0x020000E8 RID: 232
	public abstract class DonaDeInteraccionBase : CustomMonobehaviour
	{
		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060006E9 RID: 1769
		public abstract bool isDrawing { get; }

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060006EA RID: 1770 RVA: 0x0001930C File Offset: 0x0001750C
		// (remove) Token: 0x060006EB RID: 1771 RVA: 0x00019344 File Offset: 0x00017544
		public event DonaDeInteraccionBase.ChangingEventHandler changingState;

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x00019379 File Offset: 0x00017579
		public Component currentUser
		{
			get
			{
				return this.m_currentUser;
			}
		}

		// Token: 0x060006ED RID: 1773
		public abstract void StopDrawing();

		// Token: 0x060006EE RID: 1774 RVA: 0x00019381 File Offset: 0x00017581
		protected void OnStateChanging(bool drawing)
		{
			DonaDeInteraccionBase.ChangingEventHandler changingEventHandler = this.changingState;
			if (changingEventHandler == null)
			{
				return;
			}
			changingEventHandler(drawing, this);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00019398 File Offset: 0x00017598
		protected float angleOfIndex(int cantidadDeOpciones, int index)
		{
			float num = 360f / (float)cantidadDeOpciones;
			float num2 = num * (float)index;
			float num3 = num2 - 45f;
			num3 = num3.ToAngle();
			float num4;
			if (num3 <= 180f)
			{
				num4 = MathfExtension.InverseLerpAlMedio(0f, 90f, 180f, num3);
			}
			else
			{
				num4 = MathfExtension.InverseLerpAlMedio(180f, 270f, 360f, num3);
			}
			float num5 = Mathf.Lerp(this.fixDeAngulosAmount, -this.fixDeAngulosAmount, num4);
			float num6 = ((num5 < 0f) ? (-1f) : 1f);
			num5 = Mathf.Abs(num5).OutPow(this.fixDeAngulosPower) * num6;
			return num2 + num * num5;
		}

		// Token: 0x0400029F RID: 671
		protected Dictionary<IUIElementoConValor, UnityAction<IUIElementoConValor, DonaDeInteraccionBase>> m_callBacksDeItemsDeDona = new Dictionary<IUIElementoConValor, UnityAction<IUIElementoConValor, DonaDeInteraccionBase>>();

		// Token: 0x040002A0 RID: 672
		public RectTransform centroDePuntos;

		// Token: 0x040002A1 RID: 673
		public Vector3 up = Vector3.up;

		// Token: 0x040002A2 RID: 674
		public Vector3 forward = Vector3.forward;

		// Token: 0x040002A3 RID: 675
		[Range(0f, 1f)]
		public float fixDeAngulosAmount = 0.333f;

		// Token: 0x040002A4 RID: 676
		public float fixDeAngulosPower = 2f;

		// Token: 0x040002A5 RID: 677
		public float distanceFromCenter = 100f;

		// Token: 0x040002A6 RID: 678
		public float distancePerItem = 8f;

		// Token: 0x040002A7 RID: 679
		[SerializeField]
		protected Component m_currentUser;

		// Token: 0x040002A8 RID: 680
		[SerializeField]
		protected ModificadorDeBool m_canShowConfigGeneralMod;

		// Token: 0x040002A9 RID: 681
		[SerializeField]
		protected ModificadorDeBool m_canHideCursor;

		// Token: 0x020001B1 RID: 433
		// (Invoke) Token: 0x06000BA8 RID: 2984
		public delegate void ChangingEventHandler(bool drawing, DonaDeInteraccionBase sender);

		// Token: 0x020001B2 RID: 434
		[Serializable]
		public class Item
		{
			// Token: 0x04000575 RID: 1397
			public string text;

			// Token: 0x04000576 RID: 1398
			public bool grayOut;

			// Token: 0x04000577 RID: 1399
			public bool hidden;

			// Token: 0x04000578 RID: 1400
			public UnityAction clickedCallback;

			// Token: 0x04000579 RID: 1401
			public UnityAction<IUIElementoConValor, DonaDeInteraccionBase> clickedCallbackCompleto;

			// Token: 0x0400057A RID: 1402
			public string modelo;

			// Token: 0x0400057B RID: 1403
			public Type modeloInstanceType;
		}
	}
}
