using System;
using TMPro;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Handlers
{
	// Token: 0x02000177 RID: 375
	public class SliderValueText : MonoBehaviour
	{
		// Token: 0x06000B2D RID: 2861 RVA: 0x000259E9 File Offset: 0x00023BE9
		private void Awake()
		{
			this.m_Text = base.GetComponent<TextMeshProUGUI>();
			if (this.m_Text == null)
			{
				throw new ArgumentNullException("m_Text", "m_Text null reference.");
			}
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00025A15 File Offset: 0x00023C15
		private void Start()
		{
			this.UpdateSize(this.m_Text.text.Length);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00025A30 File Offset: 0x00023C30
		public void OnSliderValueChange(float value)
		{
			if (this.m_Lastdecimales == null || this.m_Lastdecimales.Value != this.decimales)
			{
				this.m_Lastdecimales = new int?(this.decimales);
				this.m_format = "N" + this.decimales.ToString();
			}
			this.m_Text.text = value.ToString(this.m_format);
			this.UpdateSize(this.m_Text.text.Length);
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x00025AB8 File Offset: 0x00023CB8
		private void UpdateSize(int largo)
		{
			switch (largo)
			{
			case 1:
				this.m_Text.fontSize = 16f;
				return;
			case 2:
				this.m_Text.fontSize = 14f;
				return;
			case 3:
				this.m_Text.fontSize = 10f;
				return;
			default:
				this.m_Text.fontSize = 9f;
				return;
			}
		}

		// Token: 0x04000373 RID: 883
		private TextMeshProUGUI m_Text;

		// Token: 0x04000374 RID: 884
		[Range(0f, 10f)]
		public int decimales;

		// Token: 0x04000375 RID: 885
		private int? m_Lastdecimales;

		// Token: 0x04000376 RID: 886
		private string m_format;
	}
}
