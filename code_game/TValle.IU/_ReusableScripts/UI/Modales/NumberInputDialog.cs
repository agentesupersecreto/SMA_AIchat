using System;
using System.Globalization;
using Assets.TValle.IU.Runtime;
using TMPro;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Modales
{
	// Token: 0x02000018 RID: 24
	public class NumberInputDialog : CustomMonobehaviour
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003211 File Offset: 0x00001411
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003219 File Offset: 0x00001419
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00003221 File Offset: 0x00001421
		public Button cancelar
		{
			get
			{
				return this.m_cancelar;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00003229 File Offset: 0x00001429
		public TMP_InputField inputField
		{
			get
			{
				return this.m_InputField;
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003234 File Offset: 0x00001434
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
			if (this.inputField == null)
			{
				throw new ArgumentNullException("inputField", "inputField null reference.");
			}
			if (this.m_increaseBoton == null)
			{
				throw new ArgumentNullException("m_increaseBoton", "m_increaseBoton null reference.");
			}
			if (this.m_reduceBoton == null)
			{
				throw new ArgumentNullException("m_reduceBoton", "m_reduceBoton null reference.");
			}
			this.m_reduceBoton.sostenido += this.OnReduced;
			this.m_increaseBoton.sostenido += this.OnIncreased;
			this.m_InputField.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			this.m_InputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003361 File Offset: 0x00001561
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.LoadConfig();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000336F File Offset: 0x0000156F
		public void LoadConfig()
		{
			if (this.decimalCount <= 0)
			{
				this.m_InputField.contentType = TMP_InputField.ContentType.IntegerNumber;
			}
			else
			{
				this.m_InputField.contentType = TMP_InputField.ContentType.DecimalNumber;
			}
			if (this.ObtenerValor() < this.minValue)
			{
				this.SetValor(this.minValue);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000033AE File Offset: 0x000015AE
		private void OnValueChanged(string value)
		{
			this.Check(value);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000033B7 File Offset: 0x000015B7
		private void OnEndEdit(string value)
		{
			this.Check(value);
			this.ChangeNumber(0f);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000033CB File Offset: 0x000015CB
		private void Check(string value)
		{
			this.aceptar.interactable = !string.IsNullOrWhiteSpace(value);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000033E4 File Offset: 0x000015E4
		private void LateUpdate()
		{
			if (!this.m_increasing && this.m_increasingCoolDownNext != this.maxCoolDown)
			{
				this.m_increasingCoolDownNext = this.maxCoolDown;
				this.m_increasingCoolDown.Clear();
			}
			if (!this.m_decreasing && this.m_decreasingCoolDownNext != this.maxCoolDown)
			{
				this.m_decreasingCoolDownNext = this.maxCoolDown;
				this.m_decreasingCoolDown.Clear();
			}
			this.m_decreasing = false;
			this.m_increasing = false;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000345C File Offset: 0x0000165C
		private void OnReduced()
		{
			this.m_decreasingCoolDownNext -= this.coolDownChange * Time.deltaTime;
			this.m_decreasingCoolDownNext = Mathf.Clamp(this.m_decreasingCoolDownNext, this.minCoolDown, this.maxCoolDown);
			this.m_decreasing = true;
			if (this.m_decreasingCoolDown.isOn)
			{
				return;
			}
			this.ChangeNumber(-this.incremento);
			this.m_decreasingCoolDown.ApplyNext(this.m_decreasingCoolDownNext);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000034D4 File Offset: 0x000016D4
		private void OnIncreased()
		{
			this.m_increasingCoolDownNext -= this.coolDownChange * Time.deltaTime;
			this.m_increasingCoolDownNext = Mathf.Clamp(this.m_increasingCoolDownNext, this.minCoolDown, this.maxCoolDown);
			this.m_increasing = true;
			if (this.m_increasingCoolDown.isOn)
			{
				return;
			}
			this.ChangeNumber(this.incremento);
			this.m_increasingCoolDown.ApplyNext(this.m_increasingCoolDownNext);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000354C File Offset: 0x0000174C
		private void ChangeNumber(float change)
		{
			float num = this.ObtenerValor();
			num += change;
			this.SetValor(num);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000356B File Offset: 0x0000176B
		private float LoadNumber(float number)
		{
			number = (float)Math.Round((double)number, this.decimalCount, MidpointRounding.AwayFromZero);
			number = Mathf.Clamp(number, this.minValue, this.maxValue);
			return number;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003593 File Offset: 0x00001793
		public void SetValor(float valor)
		{
			valor = this.LoadNumber(valor);
			this.m_InputField.text = valor.ToString("N" + this.decimalCount.ToString(), CultureInfo.InvariantCulture);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000035CC File Offset: 0x000017CC
		public float ObtenerValor()
		{
			float num;
			if (string.IsNullOrWhiteSpace(this.m_InputField.text) || !float.TryParse(this.m_InputField.text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out num))
			{
				num = 0f;
				this.m_InputField.text = "0";
			}
			this.LoadNumber(num);
			return num;
		}

		// Token: 0x04000040 RID: 64
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x04000041 RID: 65
		[SerializeField]
		private Button m_aceptar;

		// Token: 0x04000042 RID: 66
		[SerializeField]
		private Button m_cancelar;

		// Token: 0x04000043 RID: 67
		[SerializeField]
		private TMP_InputField m_InputField;

		// Token: 0x04000044 RID: 68
		[SerializeField]
		private BotonSostenible m_increaseBoton;

		// Token: 0x04000045 RID: 69
		[SerializeField]
		private BotonSostenible m_reduceBoton;

		// Token: 0x04000046 RID: 70
		public int decimalCount = 2;

		// Token: 0x04000047 RID: 71
		public float incremento = 0.01f;

		// Token: 0x04000048 RID: 72
		public float minValue;

		// Token: 0x04000049 RID: 73
		public float maxValue = 1f;

		// Token: 0x0400004A RID: 74
		public float maxCoolDown = 0.666f;

		// Token: 0x0400004B RID: 75
		public float minCoolDown = 0.05f;

		// Token: 0x0400004C RID: 76
		public float coolDownChange = 0.2f;

		// Token: 0x0400004D RID: 77
		private bool m_increasing;

		// Token: 0x0400004E RID: 78
		private bool m_decreasing;

		// Token: 0x0400004F RID: 79
		private CoolDown m_increasingCoolDown = new CoolDown();

		// Token: 0x04000050 RID: 80
		private CoolDown m_decreasingCoolDown = new CoolDown();

		// Token: 0x04000051 RID: 81
		private float m_increasingCoolDownNext;

		// Token: 0x04000052 RID: 82
		private float m_decreasingCoolDownNext;
	}
}
