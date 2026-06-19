using System;
using System.Runtime.CompilerServices;
using Assets.Base.Plugins.Runtime;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers
{
	// Token: 0x02000012 RID: 18
	public abstract class FemaleAnimController : AnimController
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x0000395A File Offset: 0x00001B5A
		public void SetData(object key, object data)
		{
			this.m_data.AddOrUpdate(key, data);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003969 File Offset: 0x00001B69
		public void RemoveData(object key)
		{
			this.m_data.Remove(key);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003978 File Offset: 0x00001B78
		public object GetData(object key)
		{
			object obj;
			if (this.m_data.TryGetValue(key, out obj))
			{
				return obj;
			}
			return null;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00003998 File Offset: 0x00001B98
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x000039A5 File Offset: 0x00001BA5
		public IRecostable currentRecostableOnRange
		{
			get
			{
				return this.m_currentRecostableOnRange as IRecostable;
			}
			private set
			{
				this.m_currentRecostableOnRange = value as Object;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000A5 RID: 165
		// (set) Token: 0x060000A6 RID: 166
		public abstract FemaleAnimatedPoseIDs animatedPoseID { get; set; }

		// Token: 0x060000A7 RID: 167 RVA: 0x000039B4 File Offset: 0x00001BB4
		public bool EstaEnLocomotion()
		{
			return this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion") && !this.animator.IsInTransition(0);
		}

		// Token: 0x060000A8 RID: 168
		public abstract void SetIdlePoseStyle(float value);

		// Token: 0x060000A9 RID: 169
		public abstract void SetIdlePoseEmos(float extro, float grosera, float pervert, float timida, float asustada);

		// Token: 0x060000AA RID: 170
		public abstract void SetFingersIdlePoseEmos(float extro, float grosera, float pervert, float timida, float asustada);

		// Token: 0x060000AB RID: 171 RVA: 0x000039ED File Offset: 0x00001BED
		public virtual bool CanAnimatedTraslate()
		{
			return this.animatedPoseID == FemaleAnimatedPoseIDs.None;
		}

		// Token: 0x060000AC RID: 172
		public abstract void Strafe(float horizontal, float vertical, float magnitude);

		// Token: 0x060000AD RID: 173
		public abstract void Walk(float horizontal, float vertical, float magnitude);

		// Token: 0x060000AE RID: 174
		public abstract void Turn90(float weightPolarizado);

		// Token: 0x060000AF RID: 175
		public abstract void Turn180(float weightPolarizado);

		// Token: 0x060000B0 RID: 176
		public abstract void StopMoving();

		// Token: 0x060000B1 RID: 177 RVA: 0x000039F8 File Offset: 0x00001BF8
		public virtual void ForceIdleState()
		{
			this.animatedPoseID = FemaleAnimatedPoseIDs.None;
			this.animator.Play("Idling", 0, 0f);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003A17 File Offset: 0x00001C17
		public virtual void SetOnRecostableRange(IRecostable silla)
		{
			if (silla == null)
			{
				this.ClearRecostable();
				return;
			}
			if (this.currentRecostableOnRange != null)
			{
				this.ClearRecostable();
			}
			this.currentRecostableOnRange = silla;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003A38 File Offset: 0x00001C38
		public virtual void SetOffRecostableRange(IRecostable silla)
		{
			if (this.currentRecostableOnRange == silla)
			{
				this.ClearRecostable();
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003A49 File Offset: 0x00001C49
		public virtual void ClearRecostable()
		{
			this.currentRecostableOnRange = null;
		}

		// Token: 0x060000B5 RID: 181
		public abstract bool EstaEnRecostadaState();

		// Token: 0x060000B6 RID: 182
		public abstract bool EstaRecostada();

		// Token: 0x060000B7 RID: 183
		public abstract bool EstaRecostada(FemaleAnimatedRecostarseIDs tipoDeRecostamiento);

		// Token: 0x060000B8 RID: 184
		public abstract void RecostarseEnCurrentRecostable(FemaleAnimatedRecostarseIDs tipoDeRecostamiento);

		// Token: 0x060000B9 RID: 185
		public abstract void LevantarseDeCurrentRecostable();

		// Token: 0x060000BA RID: 186 RVA: 0x00003A52 File Offset: 0x00001C52
		public void ForzarRecostarseEn(FemaleAnimatedRecostarseIDs tipoDeRecostamiento, IRecostable silla)
		{
			this.SetOnRecostableRange(silla);
			this.RecostarseEnCurrentRecostable(tipoDeRecostamiento);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003A62 File Offset: 0x00001C62
		protected override CustomMonobehaviourBotonConfig Boton6()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Turn Around 180"
			};
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003A7B File Offset: 0x00001C7B
		protected override void OnAplicar6()
		{
			base.OnAplicar6();
			this.Turn180(1f);
		}

		// Token: 0x0400005B RID: 91
		public const string LocomotionTag = "Locomotion";

		// Token: 0x0400005C RID: 92
		public const string idleStateName = "Idling";

		// Token: 0x0400005D RID: 93
		public const float sentadaAlturaBaja = 0.333f;

		// Token: 0x0400005E RID: 94
		public const float sentadaAlturaMed = 0.49693f;

		// Token: 0x0400005F RID: 95
		public const float sentadaAlturaAlta = 0.7f;

		// Token: 0x04000060 RID: 96
		public const float sentadaAlturaMuyAlta = 1f;

		// Token: 0x04000061 RID: 97
		private ConditionalWeakTable<object, object> m_data = new ConditionalWeakTable<object, object>();

		// Token: 0x04000062 RID: 98
		[ConstraintType(typeof(IRecostable), true)]
		[SerializeField]
		private Object m_currentRecostableOnRange;

		// Token: 0x0200002C RID: 44
		public static class FemaleAnimatorVariables
		{
			// Token: 0x040000AE RID: 174
			public static readonly int L0MotionPhase = Animator.StringToHash("L0MotionPhase");

			// Token: 0x040000AF RID: 175
			public static readonly int EstaSentada = Animator.StringToHash("EstaSentada");

			// Token: 0x040000B0 RID: 176
			public static readonly int WalkLegsStyle = Animator.StringToHash("WalkLegsStyle");

			// Token: 0x040000B1 RID: 177
			public static readonly int RotationDirection = Animator.StringToHash("RotationDirection");

			// Token: 0x040000B2 RID: 178
			public static readonly int Horizontal = Animator.StringToHash("Horizontal");

			// Token: 0x040000B3 RID: 179
			public static readonly int Vertical = Animator.StringToHash("Vertical");

			// Token: 0x040000B4 RID: 180
			public static readonly int Magnitude = Animator.StringToHash("Magnitude");

			// Token: 0x040000B5 RID: 181
			public static readonly int IsRightLegUp = Animator.StringToHash("IsRightLegUp");

			// Token: 0x040000B6 RID: 182
			public static readonly int LegSwitch = Animator.StringToHash("LegSwitch");

			// Token: 0x040000B7 RID: 183
			public static readonly int PoseNormal = Animator.StringToHash("PoseNormal");

			// Token: 0x040000B8 RID: 184
			public static readonly int PoseExtrovertida = Animator.StringToHash("PoseExtrovertida");

			// Token: 0x040000B9 RID: 185
			public static readonly int PoseGrosera = Animator.StringToHash("PoseGrosera");

			// Token: 0x040000BA RID: 186
			public static readonly int PosePervertida = Animator.StringToHash("PosePervertida");

			// Token: 0x040000BB RID: 187
			public static readonly int PoseTimida = Animator.StringToHash("PoseTimida");

			// Token: 0x040000BC RID: 188
			public static readonly int PoseAsustada = Animator.StringToHash("PoseAsustada");

			// Token: 0x040000BD RID: 189
			public static readonly int PoseNormalFingers = Animator.StringToHash("PoseNormalFingers");

			// Token: 0x040000BE RID: 190
			public static readonly int PoseExtrovertidaFingers = Animator.StringToHash("PoseExtrovertidaFingers");

			// Token: 0x040000BF RID: 191
			public static readonly int PoseGroseraFingers = Animator.StringToHash("PoseGroseraFingers");

			// Token: 0x040000C0 RID: 192
			public static readonly int PosePervertidaFingers = Animator.StringToHash("PosePervertidaFingers");

			// Token: 0x040000C1 RID: 193
			public static readonly int PoseTimidaFingers = Animator.StringToHash("PoseTimidaFingers");

			// Token: 0x040000C2 RID: 194
			public static readonly int PoseAsustadaFingers = Animator.StringToHash("PoseAsustadaFingers");

			// Token: 0x040000C3 RID: 195
			public static readonly int TurnMagnitude = Animator.StringToHash("TurnMagnitude");

			// Token: 0x040000C4 RID: 196
			public static readonly int TurnTypeAngle = Animator.StringToHash("TurnTypeAngle");

			// Token: 0x040000C5 RID: 197
			public static readonly int PoseEstimuladaWeight = Animator.StringToHash("PoseEstimuladaWeight");

			// Token: 0x040000C6 RID: 198
			public static readonly int AnimPoseID = Animator.StringToHash("AnimatedPoseValue");

			// Token: 0x040000C7 RID: 199
			public static readonly int HeroineScale = Animator.StringToHash("HeroineScale");

			// Token: 0x040000C8 RID: 200
			public static readonly int SuperficieRecostadaAlturaMod = Animator.StringToHash("SuperficieSentarAlturaMod");

			// Token: 0x040000C9 RID: 201
			public static readonly int Recostada = Animator.StringToHash("Recostada");
		}
	}
}
