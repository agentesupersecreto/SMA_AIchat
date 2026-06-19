using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Battlehub.RTCommon;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Emociones
{
	// Token: 0x02000025 RID: 37
	public class ReactorCambioDeConsentPorFotoDespuesDeMoverBones : ReactorACalculoDeEstimulo<ICalculoDeEstimuloVisual>
	{
		// Token: 0x06000170 RID: 368 RVA: 0x000086AC File Offset: 0x000068AC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ConsentToHero = this.GetComponentEnRoot(false);
			if (this.m_ConsentToHero == null)
			{
				throw new ArgumentNullException("m_ConsentToHero", "m_ConsentToHero null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_ConsentPorInteraciones = this.GetComponentEnRoot(false);
			if (this.m_ConsentPorInteraciones == null)
			{
				throw new ArgumentNullException("m_ConsentPorInteraciones", "m_ConsentPorInteraciones null reference.");
			}
			this.m_Char = this.GetComponentEnRoot(false);
			if (this.m_Char == null)
			{
				throw new ArgumentNullException("m_Char", "m_Char null reference.");
			}
			this.m_customPoseBones = this.GetComponentsEnRoot(false);
			if (this.m_customPoseBones == null || this.m_customPoseBones.Length == 0)
			{
				throw new ArgumentNullException("m_customPoseBones", "m_customPoseBones null reference.");
			}
			this.m_guaibleDeSelectable = new Dictionary<ExposeToEditor, BoneGuiable>(this.m_customPoseBones.Length);
			foreach (BoneGuiable boneGuiable in this.m_customPoseBones)
			{
				GizmoDeBone gizmoDeBone = boneGuiable.gizmoDeBone;
				if (!gizmoDeBone.isStared)
				{
					gizmoDeBone.ManualStart();
				}
				this.m_guaibleDeSelectable.Add(gizmoDeBone.selectable, boneGuiable);
			}
			this.m_bonesGuiables = this.m_customPoseBones.Select((BoneGuiable g) => g.boneInfo.humanBone).Distinct<HumanBodyBones>().ToArray<HumanBodyBones>();
			this.m_indexDeHumanBodyBones = new Dictionary<int, int>(this.m_bonesGuiables.Length);
			this.m_currentSession = new float[this.m_bonesGuiables.Length];
			this.m_overall = new float[this.m_bonesGuiables.Length];
			for (int j = 0; j < this.m_bonesGuiables.Length; j++)
			{
				this.m_indexDeHumanBodyBones.Add((int)this.m_bonesGuiables[j], j);
			}
			this.Subscribe();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000088BD File Offset: 0x00006ABD
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.Subscribe();
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000088D3 File Offset: 0x00006AD3
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000088E4 File Offset: 0x00006AE4
		private void Subscribe()
		{
			BoneGuiable[] customPoseBones = this.m_customPoseBones;
			for (int i = 0; i < customPoseBones.Length; i++)
			{
				customPoseBones[i].gizmoDeBone.selectable.transformMoved += this.Selectable_transformMoved;
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00008924 File Offset: 0x00006B24
		private void Unsubscribe()
		{
			foreach (BoneGuiable boneGuiable in this.m_customPoseBones)
			{
				Object @object;
				if (boneGuiable == null)
				{
					@object = null;
				}
				else
				{
					GizmoDeBone gizmoDeBone = boneGuiable.gizmoDeBone;
					@object = ((gizmoDeBone != null) ? gizmoDeBone.selectable : null);
				}
				if (@object != null)
				{
					boneGuiable.gizmoDeBone.selectable.transformMoved -= this.Selectable_transformMoved;
				}
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00008986 File Offset: 0x00006B86
		private bool YaAceptoModelajePosando()
		{
			return MemoriaDeSMAModelosFemeninas.AceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, this.m_Char.ID_UnicoString);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000089A0 File Offset: 0x00006BA0
		private void Selectable_transformMoved(ExposeToEditor obj)
		{
			if (!this.YaAceptoModelajePosando())
			{
				return;
			}
			BoneGuiable boneGuiable;
			if (!this.m_guaibleDeSelectable.TryGetValue(obj, out boneGuiable))
			{
				return;
			}
			HumanBodyBones humanBone = boneGuiable.boneInfo.humanBone;
			int num;
			if (!this.m_indexDeHumanBodyBones.TryGetValue((int)humanBone, out num))
			{
				return;
			}
			float num2;
			float num3;
			obj.CalcularWeigthDeMovimiento(out num2, out num3);
			float num4 = Mathf.InverseLerp(0f, 3f, num2 + num3);
			this.m_currentSession[num] = this.m_currentSession[num] + num4;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00008A18 File Offset: 0x00006C18
		protected override bool CalculoEsValido(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.tipo != TipoDeCalculoDeEstimulo.frame)
			{
				return false;
			}
			if (calculo.estimulo.tipoDeEstimuloVisual != TipoDeEstimuloVisual.fotografiada)
			{
				return false;
			}
			if (calculo.emocion.reaccion != ReaccionHumana.placer)
			{
				return false;
			}
			if (!this.YaAceptoModelajePosando())
			{
				return false;
			}
			float num;
			this.m_ConsentNecesario.EsConsentidoMaximoConJerarquia(calculo, out num, null, null);
			return num >= 0.5f;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00008A80 File Offset: 0x00006C80
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloVisual calculo)
		{
			if (this.m_ConsentPorInteraciones.alMaximo || this.m_ConsentToHero.valueAtMax)
			{
				return false;
			}
			MapaDePersonalidad personalidad = this.m_Personalidad.currentPersonalidad.personalidad;
			if (personalidad == null)
			{
				return false;
			}
			float num = personalidad.CurrentMaxConsentPorInteraciones() / 1.5f / (float)this.m_bonesGuiables.Length;
			float num2 = 0f;
			for (int i = 0; i < this.m_currentSession.Length; i++)
			{
				float num3 = this.m_overall[i];
				if (num3 < 1f)
				{
					float num4 = Mathf.Clamp01(this.m_currentSession[i]) * num;
					this.m_overall[i] = Mathf.Clamp01(num3 + this.m_currentSession[i]);
					this.m_currentSession[i] = 0f;
					num2 += num4;
				}
			}
			if (num2 > 0f)
			{
				this.m_ConsentPorInteraciones.Cambiar(num2, calculo);
				return true;
			}
			return false;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00008B5B File Offset: 0x00006D5B
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008B62 File Offset: 0x00006D62
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x040000DC RID: 220
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x040000DD RID: 221
		private ConsentToHero m_ConsentToHero;

		// Token: 0x040000DE RID: 222
		private Personalidad m_Personalidad;

		// Token: 0x040000DF RID: 223
		private ConsentPorInteraciones m_ConsentPorInteraciones;

		// Token: 0x040000E0 RID: 224
		private BoneGuiable[] m_customPoseBones;

		// Token: 0x040000E1 RID: 225
		private Dictionary<ExposeToEditor, BoneGuiable> m_guaibleDeSelectable;

		// Token: 0x040000E2 RID: 226
		private Dictionary<int, int> m_indexDeHumanBodyBones;

		// Token: 0x040000E3 RID: 227
		[ReadOnlyUI]
		[SerializeField]
		private HumanBodyBones[] m_bonesGuiables;

		// Token: 0x040000E4 RID: 228
		[SerializeField]
		private float[] m_currentSession;

		// Token: 0x040000E5 RID: 229
		[SerializeField]
		private float[] m_overall;

		// Token: 0x040000E6 RID: 230
		private Character m_Char;
	}
}
