using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200017C RID: 380
	public sealed class InteractuarSuavizarYEstirarTetas : InteraccionObjectReducirMappingDeMusculosDeAvatarBase
	{
		// Token: 0x06000830 RID: 2096 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnStaring(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0002B3BE File Offset: 0x000295BE
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Character componentInParent = base.GetComponentInParent<Character>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("@character", "@character null reference.");
			}
			componentInParent.GetComponentEnCharacter(false).stared += this.FSkins_stared;
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0002B3FC File Offset: 0x000295FC
		private void FSkins_stared(object obj)
		{
			FemaleSkins femaleSkins = (FemaleSkins)obj;
			this.r = femaleSkins.hitSkins.partes.senos000.r;
			this.l = femaleSkins.hitSkins.partes.senos000.l;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0002B446 File Offset: 0x00029646
		protected override void OnComienza()
		{
			base.OnComienza();
			this.m_lastSmoothTetas = -1f;
			this.m_InteractionObject.applyed += this.InteractionObject_Applyed;
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0002B470 File Offset: 0x00029670
		private void DoSmooth(float progress)
		{
			float comienzaTime = this.comienzaTime;
			float terminaTime = this.terminaTime;
			float num = comienzaTime + this.inTetasDurationNormalized;
			float num2 = this.terminaTime - this.outTetasDurationNormalized;
			int num3;
			float num4;
			if (progress >= num && progress <= num2)
			{
				num3 = 0;
				num4 = 1f;
			}
			else if (progress < num)
			{
				num3 = 1;
				num4 = Mathf.InverseLerp(comienzaTime, num, progress);
			}
			else
			{
				if (progress <= num2)
				{
					throw new ArgumentOutOfRangeException();
				}
				num3 = 2;
				num4 = 1f - Mathf.InverseLerp(num2, terminaTime, progress);
			}
			if (Mathf.Approximately(num4, this.m_lastSmoothTetas))
			{
				return;
			}
			this.m_lastSmoothTetas = num4;
			if (this.r != null && this.l != null)
			{
				float num5;
				switch (num3)
				{
				case 0:
					num5 = num4;
					break;
				case 1:
					num5 = num4.InPow(3f);
					break;
				case 2:
					num5 = num4.OutPow(3f);
					break;
				default:
					throw new ArgumentOutOfRangeException(num3.ToString());
				}
				float num6 = Mathf.Lerp(1f, this.apretandoSpringMod, num5);
				float num7 = Mathf.Lerp(1f, this.apretandoDamperMod, num5);
				float num8 = Mathf.Lerp(1f, this.apretandoPezonDistanceMod, num5);
				this.r.ModCurrentBraState(num6, num7, num8, this);
				this.l.ModCurrentBraState(num6, num7, num8, this);
				this.r.FixTetasSuavizacionYEstiramiento();
				this.l.FixTetasSuavizacionYEstiramiento();
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0002B5E0 File Offset: 0x000297E0
		private void InteractionObject_Applyed(IKSolverFullBodyBiped solver, InteractionEffector interactionEffector, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight)
		{
			this.DoSmooth(interactionEffector.progress);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0002B5F0 File Offset: 0x000297F0
		protected override void OnTermina()
		{
			base.OnTermina();
			this.m_lastSmoothTetas = -1f;
			this.m_InteractionObject.applyed -= this.InteractionObject_Applyed;
			if (this.r != null && this.l != null)
			{
				this.r.ModCurrentBraState(1f, 1f, 1f, this);
				this.l.ModCurrentBraState(1f, 1f, 1f, this);
				this.r.FixTetasSuavizacionYEstiramiento();
				this.l.FixTetasSuavizacionYEstiramiento();
			}
		}

		// Token: 0x04000692 RID: 1682
		[Tooltip("OJO, este valor mas el start time debe ser menor a pause time")]
		public float inTetasDurationNormalized = 0.1f;

		// Token: 0x04000693 RID: 1683
		[Tooltip("OJO, este valor menos el termina time debe ser menor a pause time")]
		public float outTetasDurationNormalized = 0.1f;

		// Token: 0x04000694 RID: 1684
		public float apretandoPezonDistanceMod = 0.65f;

		// Token: 0x04000695 RID: 1685
		public float apretandoSpringMod = 6f;

		// Token: 0x04000696 RID: 1686
		public float apretandoDamperMod = 6f;

		// Token: 0x04000697 RID: 1687
		private BaseDeTetaSkin r;

		// Token: 0x04000698 RID: 1688
		private BaseDeTetaSkin l;

		// Token: 0x04000699 RID: 1689
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastSmoothTetas;
	}
}
