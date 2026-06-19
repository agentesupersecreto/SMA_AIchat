using System;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000CE RID: 206
	[Serializable]
	public abstract class ByInteraccionEnScenaEffecto<T, TArg> : Efecto<T, TArg> where T : ByInteraccionEnScenaEffecto<T, TArg> where TArg : class, IByInteraccionEnScenaArg
	{
		// Token: 0x06000444 RID: 1092 RVA: 0x00017DB4 File Offset: 0x00015FB4
		protected void UpdateQualityAndVisibility(BuffEvento buff, float min, float med, float max, float value, float outPower, bool notInverted)
		{
			float num;
			this.UpdateQuality(buff, min, med, max, value, outPower, notInverted, out num);
			if (buff is DisplayableBuff)
			{
				DisplayableBuff displayableBuff = (DisplayableBuff)buff;
				if (MathfExtension.AlmostEqual(med, 1f, 0.001f))
				{
					displayableBuff.hideFromUI = value > 0.99f && value < 1.01f;
					return;
				}
				if (MathfExtension.AlmostEqual(med, 0f, 0.001f))
				{
					displayableBuff.hideFromUI = value > -0.01f && value < 0.01f;
					return;
				}
				displayableBuff.hideFromUI = (double)Mathf.Abs(num - 0.5f) < 0.000567;
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00017E60 File Offset: 0x00016060
		protected void UpdateQuality(BuffEvento buff, float min, float med, float max, float value, float outPower, bool notInverted, out float weight)
		{
			weight = MathfExtension.InverseLerpConMedio(min, med, max, value);
			buff.quality = (ItemQuality)Mathf.RoundToInt(MathfExtension.LerpConMedio((float)((!notInverted) ? 13 : 1), 7f, (float)((!notInverted) ? 1 : 13), weight.InInOutOutPow(outPower, outPower, 0.5f)));
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00017EB8 File Offset: 0x000160B8
		private void CheckVisibility(TArg arg, object buff)
		{
			if (arg.buffIsOutOfContext)
			{
				BuffEvento buffEvento = buff as BuffEvento;
				if (buffEvento != null)
				{
					buffEvento.forceVolatil = true;
				}
				if (buff is DisplayableBuff)
				{
					((DisplayableBuff)buff).hideFromUI = true;
				}
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00017EF8 File Offset: 0x000160F8
		public sealed override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			TArg targ = argument as TArg;
			if (targ == null)
			{
				Debug.LogException(new ArgumentNullException());
				return;
			}
			if (!targ.byInteraccionEnScenaBuffIsValid)
			{
				Debug.LogError("Effecto Argumento " + argument.id + " tiene buff por interaccion de scena invalido, en Effecto " + this.id);
				BuffEvento buffEvento = buff as BuffEvento;
				if (buffEvento != null)
				{
					buffEvento.forceVolatil = true;
					Debug.LogError("buff " + buffEvento.id + " se declaro volatil para intentar remover argumento averiado");
				}
				return;
			}
			this.OnApply(affected, targ, buff, caster);
			this.CheckVisibility(targ, buff);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00017F94 File Offset: 0x00016194
		public sealed override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			TArg targ = argument as TArg;
			if (targ == null)
			{
				Debug.LogException(new ArgumentNullException());
				return;
			}
			if (!targ.byInteraccionEnScenaBuffIsValid)
			{
				Debug.LogError("Effecto Argumento " + argument.id + " tiene buff por interaccion de scena invalido, en Effecto " + this.id);
				return;
			}
			this.OnStay(affected, targ, buff, caster);
			this.CheckVisibility(targ, buff);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00018004 File Offset: 0x00016204
		public sealed override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			TArg targ = argument as TArg;
			if (targ == null)
			{
				Debug.LogException(new ArgumentNullException());
				return;
			}
			if (!targ.byInteraccionEnScenaBuffIsValid)
			{
				Debug.LogError("Effecto Argumento " + argument.id + " tiene buff por interaccion de scena invalido, en Effecto " + this.id);
				return;
			}
			this.OnRemove(affected, targ, buff, caster);
		}

		// Token: 0x0600044A RID: 1098
		protected abstract void OnApply(object affected, TArg argument, object buff, object caster);

		// Token: 0x0600044B RID: 1099
		protected abstract void OnStay(object affected, TArg argument, object buff, object caster);

		// Token: 0x0600044C RID: 1100
		protected abstract void OnRemove(object affected, TArg argument, object buff, object caster);
	}
}
