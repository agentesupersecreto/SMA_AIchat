using System;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x02000369 RID: 873
	[RequireComponent(typeof(Image))]
	public sealed class BarraDeEmocionColorCambianteOnRange : BarraDeEmocion
	{
		// Token: 0x0600130A RID: 4874 RVA: 0x00052678 File Offset: 0x00050878
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_defaultColor = this.m_Image.color;
			this.m_currentTarget = this.m_defaultColor;
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x0005269D File Offset: 0x0005089D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_upIcon)
			{
				this.m_upIcon.enabled = false;
			}
			if (this.m_downIcon)
			{
				this.m_downIcon.enabled = false;
			}
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x000526D8 File Offset: 0x000508D8
		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (this.m_emo == null)
			{
				if (this.m_upIcon)
				{
					this.m_upIcon.enabled = false;
				}
				if (this.m_downIcon)
				{
					this.m_downIcon.enabled = false;
				}
				return;
			}
			Color color = this.m_Image.color;
			float total = this.m_emo.value.total;
			if (this.forceChange || (total >= this.min && total <= this.max))
			{
				if (color == this.m_defaultColor)
				{
					this.m_currentTarget = this.maxColor;
				}
				else
				{
					this.m_currentTarget = this.m_defaultColor;
				}
			}
			else
			{
				this.m_currentTarget = this.m_defaultColor;
			}
			bool flag = this.m_emo.valueChangedAmount > 0f;
			bool flag2 = this.m_emo.valueChangedAmount < 0f;
			if ((flag || flag2) && Mathf.Abs(this.m_emo.valueChangedAmount) / Mathf.Clamp(Time.deltaTime, 1E-07f, 3.4028235E+38f) < this.valueChagedThresholdPerSecond)
			{
				flag = (flag2 = false);
			}
			if (this.forceAlterarPositivamente || flag)
			{
				this.m_duracionDeAlteracion.ApplyNext(this.duracion);
			}
			else if (this.forceAlterarNegativamente || flag2)
			{
				this.m_duracionDeAlteracion.ApplyNext(this.duracion);
			}
			if (!this.m_duracionDeAlteracion.isOn)
			{
				if (this.m_upIcon)
				{
					this.m_upIcon.enabled = false;
				}
				if (this.m_downIcon)
				{
					this.m_downIcon.enabled = false;
				}
			}
			if (this.m_duracionDeAlteracion.isOn && flag)
			{
				if (this.m_upIcon)
				{
					this.m_upIcon.enabled = true;
				}
				if (this.m_downIcon)
				{
					this.m_downIcon.enabled = false;
				}
			}
			else if (this.m_duracionDeAlteracion.isOn && flag2)
			{
				if (this.m_downIcon)
				{
					this.m_downIcon.enabled = true;
				}
				if (this.m_upIcon)
				{
					this.m_upIcon.enabled = false;
				}
			}
			if (color == this.m_currentTarget)
			{
				return;
			}
			Color color2 = color;
			float num = this.velocidad * Time.deltaTime;
			color2.a = Mathf.MoveTowards(color2.a, this.m_currentTarget.a, num);
			color2.b = Mathf.MoveTowards(color2.b, this.m_currentTarget.b, num);
			color2.g = Mathf.MoveTowards(color2.g, this.m_currentTarget.g, num);
			color2.r = Mathf.MoveTowards(color2.r, this.m_currentTarget.r, num);
			this.m_Image.color = color2;
		}

		// Token: 0x04000FDE RID: 4062
		public Color maxColor;

		// Token: 0x04000FDF RID: 4063
		[Range(0f, 100f)]
		public float min = 100f;

		// Token: 0x04000FE0 RID: 4064
		[Range(0f, 100f)]
		public float max = 100f;

		// Token: 0x04000FE1 RID: 4065
		public float velocidad = 60f;

		// Token: 0x04000FE2 RID: 4066
		public bool forceChange;

		// Token: 0x04000FE3 RID: 4067
		public float duracion = 3f;

		// Token: 0x04000FE4 RID: 4068
		[ReadOnlyUI]
		[SerializeField]
		private Color m_defaultColor;

		// Token: 0x04000FE5 RID: 4069
		[ReadOnlyUI]
		[SerializeField]
		private Color m_currentTarget;

		// Token: 0x04000FE6 RID: 4070
		public bool forceAlterarPositivamente;

		// Token: 0x04000FE7 RID: 4071
		public bool forceAlterarNegativamente;

		// Token: 0x04000FE8 RID: 4072
		public float valueChagedThresholdPerSecond = 0.5f;

		// Token: 0x04000FE9 RID: 4073
		private CoolDown m_duracionDeAlteracion = new CoolDown();

		// Token: 0x04000FEA RID: 4074
		[SerializeField]
		private Image m_upIcon;

		// Token: 0x04000FEB RID: 4075
		[SerializeField]
		private Image m_downIcon;
	}
}
