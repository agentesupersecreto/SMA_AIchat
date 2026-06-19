using System;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime
{
	// Token: 0x020000CB RID: 203
	public class TextCountDown : MonoBehaviour
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060005B7 RID: 1463 RVA: 0x00015DD4 File Offset: 0x00013FD4
		// (remove) Token: 0x060005B8 RID: 1464 RVA: 0x00015E0C File Offset: 0x0001400C
		public event Action<TextCountDown> onZero;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060005B9 RID: 1465 RVA: 0x00015E44 File Offset: 0x00014044
		// (remove) Token: 0x060005BA RID: 1466 RVA: 0x00015E7C File Offset: 0x0001407C
		public event Action _onZero;

		// Token: 0x060005BB RID: 1467 RVA: 0x00015EB1 File Offset: 0x000140B1
		private void Awake()
		{
			this.m_text = base.GetComponent<TextMeshProUGUI>();
			if (this.m_text == null)
			{
				throw new ArgumentNullException("m_text", "m_text null reference.");
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00015EE0 File Offset: 0x000140E0
		private void OnEnable()
		{
			this.current = this.start;
			this.m_text.text = Mathf.CeilToInt(this.current).ToString();
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00015F17 File Offset: 0x00014117
		private void OnDisable()
		{
			this.current = -1f;
			this.m_text.text = "0";
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00015F34 File Offset: 0x00014134
		private void Update()
		{
			if (this.current <= 0f)
			{
				return;
			}
			this.current -= Time.deltaTime;
			this.m_text.text = Mathf.CeilToInt(this.current).ToString();
			if (this.current <= 0f)
			{
				this.m_text.text = "0";
				this.current = 0f;
				Action<TextCountDown> action = this.onZero;
				if (action != null)
				{
					action(this);
				}
				Action action2 = this._onZero;
				if (action2 == null)
				{
					return;
				}
				action2();
			}
		}

		// Token: 0x04000231 RID: 561
		public float start = 15f;

		// Token: 0x04000232 RID: 562
		public float current = -1f;

		// Token: 0x04000235 RID: 565
		private TextMeshProUGUI m_text;
	}
}
