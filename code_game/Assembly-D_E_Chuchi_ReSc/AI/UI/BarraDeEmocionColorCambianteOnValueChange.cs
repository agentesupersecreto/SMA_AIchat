using System;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UI
{
	// Token: 0x0200036A RID: 874
	[RequireComponent(typeof(Image))]
	public class BarraDeEmocionColorCambianteOnValueChange : BarraDeEmocion
	{
		// Token: 0x0600130E RID: 4878 RVA: 0x000529F9 File Offset: 0x00050BF9
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_defaultColor = this.m_Image.color;
			this.m_currentTarget = this.m_defaultColor;
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x00052A1E File Offset: 0x00050C1E
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

		// Token: 0x06001310 RID: 4880 RVA: 0x00052A5C File Offset: 0x00050C5C
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
			BarraDeEmocionColorCambianteOnValueChange.ValueChangeTipe valueChangeTipe = this.valueChangeTipe;
			float num;
			if (valueChangeTipe != BarraDeEmocionColorCambianteOnValueChange.ValueChangeTipe.total)
			{
				if (valueChangeTipe != BarraDeEmocionColorCambianteOnValueChange.ValueChangeTipe.valorNoLimitado)
				{
					throw new ArgumentOutOfRangeException(this.valueChangeTipe.ToString());
				}
				num = this.m_emo.clampedValorChangedAmount;
			}
			else
			{
				num = this.m_emo.valueChangedAmount;
			}
			if (this.forceAlterarPositivamente || num > 0f)
			{
				this.m_targetColor = 1;
				this.m_duracionDeAlteracion.ApplyNext(this.duracion);
			}
			else if (this.forceAlterarNegativamente || (num < 0f && this.m_emo.value.value < 100f))
			{
				this.m_targetColor = -1;
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
				this.m_targetColor = 0;
			}
			Color color = this.m_Image.color;
			if (this.m_duracionDeAlteracion.isOn && this.m_targetColor > 0)
			{
				if (this.m_upIcon)
				{
					this.m_upIcon.enabled = true;
				}
				if (this.m_downIcon)
				{
					this.m_downIcon.enabled = false;
				}
				if (color == this.m_defaultColor)
				{
					this.m_currentTarget = this.colorAlteradoPositivamente;
				}
				else
				{
					this.m_currentTarget = this.m_defaultColor;
				}
			}
			else if (this.m_duracionDeAlteracion.isOn && this.m_targetColor < 0)
			{
				if (this.m_downIcon)
				{
					this.m_downIcon.enabled = true;
				}
				if (this.m_upIcon)
				{
					this.m_upIcon.enabled = false;
				}
				if (color == this.m_defaultColor)
				{
					this.m_currentTarget = this.colorAlteradoNegativamente;
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
			if (color == this.m_currentTarget)
			{
				return;
			}
			Color color2 = color;
			float num2 = this.velocidad * Time.deltaTime;
			color2.a = Mathf.MoveTowards(color2.a, this.m_currentTarget.a, num2);
			color2.b = Mathf.MoveTowards(color2.b, this.m_currentTarget.b, num2);
			color2.g = Mathf.MoveTowards(color2.g, this.m_currentTarget.g, num2);
			color2.r = Mathf.MoveTowards(color2.r, this.m_currentTarget.r, num2);
			this.m_Image.color = color2;
		}

		// Token: 0x04000FEC RID: 4076
		public BarraDeEmocionColorCambianteOnValueChange.ValueChangeTipe valueChangeTipe;

		// Token: 0x04000FED RID: 4077
		public Color colorAlteradoPositivamente;

		// Token: 0x04000FEE RID: 4078
		public Color colorAlteradoNegativamente;

		// Token: 0x04000FEF RID: 4079
		public float velocidad = 60f;

		// Token: 0x04000FF0 RID: 4080
		public float duracion = 3f;

		// Token: 0x04000FF1 RID: 4081
		public bool forceAlterarPositivamente;

		// Token: 0x04000FF2 RID: 4082
		public bool forceAlterarNegativamente;

		// Token: 0x04000FF3 RID: 4083
		[ReadOnlyUI]
		[SerializeField]
		private Color m_defaultColor;

		// Token: 0x04000FF4 RID: 4084
		[ReadOnlyUI]
		[SerializeField]
		private Color m_currentTarget;

		// Token: 0x04000FF5 RID: 4085
		[ReadOnlyUI]
		[SerializeField]
		private int m_targetColor;

		// Token: 0x04000FF6 RID: 4086
		private CoolDown m_duracionDeAlteracion = new CoolDown();

		// Token: 0x04000FF7 RID: 4087
		[SerializeField]
		private Image m_upIcon;

		// Token: 0x04000FF8 RID: 4088
		[SerializeField]
		private Image m_downIcon;

		// Token: 0x0200036B RID: 875
		public enum ValueChangeTipe
		{
			// Token: 0x04000FFA RID: 4090
			total,
			// Token: 0x04000FFB RID: 4091
			valorNoLimitado
		}
	}
}
