using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000D8 RID: 216
	public class SavingPortraitDialog : CustomMonobehaviour
	{
		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x000176C8 File Offset: 0x000158C8
		public RawImage portrait
		{
			get
			{
				return this.m_Portrait;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x000176D0 File Offset: 0x000158D0
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x000176D8 File Offset: 0x000158D8
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x000176E0 File Offset: 0x000158E0
		public Button cancelar
		{
			get
			{
				return this.m_cancelar;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x000176E8 File Offset: 0x000158E8
		public TMP_InputField inputField
		{
			get
			{
				return this.m_InputField;
			}
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x000176F0 File Offset: 0x000158F0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_pregunta == null)
			{
				throw new ArgumentNullException("m_pregunta", "m_pregunta null reference.");
			}
			if (this.aceptar == null)
			{
				throw new ArgumentNullException("aceptar", "aceptar null reference.");
			}
			if (this.cancelar == null)
			{
				throw new ArgumentNullException("cancelar", "cancelar null reference.");
			}
			if (this.m_InputField != null)
			{
				this.m_InputField.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
				this.m_InputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
			}
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x000177A4 File Offset: 0x000159A4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.preguntaString.HasPlaceholder())
			{
				this.m_pregunta.text = string.Format(this.preguntaString, this.nameDeCosaGuardando);
				return;
			}
			this.m_pregunta.text = this.preguntaString;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x000177F2 File Offset: 0x000159F2
		private void OnValueChanged(string value)
		{
			this.Check(value);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000177FB File Offset: 0x000159FB
		private void OnEndEdit(string value)
		{
			this.Check(value);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00017804 File Offset: 0x00015A04
		private void Check(string value)
		{
			this.aceptar.interactable = !string.IsNullOrWhiteSpace(value);
		}

		// Token: 0x04000266 RID: 614
		[SerializeField]
		private RawImage m_Portrait;

		// Token: 0x04000267 RID: 615
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x04000268 RID: 616
		[SerializeField]
		private TMP_InputField m_InputField;

		// Token: 0x04000269 RID: 617
		[SerializeField]
		private Button m_aceptar;

		// Token: 0x0400026A RID: 618
		[SerializeField]
		private Button m_cancelar;

		// Token: 0x0400026B RID: 619
		public string nameDeCosaGuardando = string.Empty;

		// Token: 0x0400026C RID: 620
		public string preguntaString = "The {0} will be saved to disk using this portrait and name. ¿Are you sure?";
	}
}
