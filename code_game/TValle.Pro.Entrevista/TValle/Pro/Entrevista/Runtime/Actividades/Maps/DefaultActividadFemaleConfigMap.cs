using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.CustomPoses;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades.Maps
{
	// Token: 0x02000139 RID: 313
	[CreateAssetMenu(fileName = "DefaultActividadFemaleConfigMap", menuName = "Objetos/Activities/DefaultActividadFemaleConfigMap")]
	public class DefaultActividadFemaleConfigMap : ActividadFemaleConfigMap
	{
		// Token: 0x06000B04 RID: 2820 RVA: 0x0003A070 File Offset: 0x00038270
		public override void SetConfig(Character character)
		{
			Transform childNotNull = character.transform.GetChildNotNull("ActividadLogic", true);
			if (this.m_NoReducirMaxEmocionValueHastaSalirDeConversacion.activar)
			{
				ReductorDeEmocionValueEnMaxEmocionValue[] componentsInChildren = character.GetComponentsInChildren<ReductorDeEmocionValueEnMaxEmocionValue>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].GetComponentNotNull<BlockearReduccionDeEmocionMaxValueEnConversacion>();
				}
			}
			if (this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.activar)
			{
				foreach (ICalculadorDeEstimuloClasificable calculadorDeEstimuloClasificable in character.GetComponentsInChildren<ICalculadorDeEstimuloClasificable>())
				{
					if (!this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable.direccionDeEstimulo) && !this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.ignorarTipos.Contains(calculadorDeEstimuloClasificable.tipoDeEstimulo) && !this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.ignorarReacciones.Contains(calculadorDeEstimuloClasificable.reaccion))
					{
						CalculoDeEstimuloEnFrame calculoDeEstimuloEnFrame = calculadorDeEstimuloClasificable as CalculoDeEstimuloEnFrame;
						if (calculoDeEstimuloEnFrame != null)
						{
							calculoDeEstimuloEnFrame.GetComponentNotNull<BlockearActualizacionDeCalculoDeEstimuloEnConversacion>();
							calculoDeEstimuloEnFrame.UpdateCheckers();
						}
					}
				}
			}
			if (this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.activar)
			{
				ICalculadorDeEstimuloClasificable[] array = character.GetComponentsInChildren<ICalculadorDeEstimuloClasificable>();
				int i = 0;
				while (i < array.Length)
				{
					ICalculadorDeEstimuloClasificable calculadorDeEstimuloClasificable2 = array[i];
					if (!this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.invertido)
					{
						if (!this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable2.direccionDeEstimulo) && !this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarTipos.Contains(calculadorDeEstimuloClasificable2.tipoDeEstimulo))
						{
							if (!this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarReacciones.Contains(calculadorDeEstimuloClasificable2.reaccion))
							{
								goto IL_01A2;
							}
						}
					}
					else if (this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable2.direccionDeEstimulo) || this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarTipos.Contains(calculadorDeEstimuloClasificable2.tipoDeEstimulo) || this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarReacciones.Contains(calculadorDeEstimuloClasificable2.reaccion))
					{
						goto IL_01A2;
					}
					IL_01CE:
					i++;
					continue;
					IL_01A2:
					CalculoDeEstimuloEnFrame calculoDeEstimuloEnFrame2 = calculadorDeEstimuloClasificable2 as CalculoDeEstimuloEnFrame;
					if (calculoDeEstimuloEnFrame2 != null)
					{
						if (calculoDeEstimuloEnFrame2.tipoDeEstimulo == TipoDeEstimulo.visual)
						{
							calculoDeEstimuloEnFrame2.GetComponentNotNull<BlockearActualizacionDeCalculoDeEstimuloEnEditarPose>();
						}
						calculoDeEstimuloEnFrame2.UpdateCheckers();
						goto IL_01CE;
					}
					goto IL_01CE;
				}
			}
			foreach (GameObject gameObject in this.m_extraObjectsPrefabs)
			{
				Object.Instantiate<GameObject>(gameObject, character.transform.position, character.transform.rotation, childNotNull).SetActive(true);
			}
		}

		// Token: 0x0400056F RID: 1391
		[SerializeField]
		private DefaultActividadFemaleConfigMap.NoReducirMaxEmocionValueHastaSalirDeConversacion m_NoReducirMaxEmocionValueHastaSalirDeConversacion = new DefaultActividadFemaleConfigMap.NoReducirMaxEmocionValueHastaSalirDeConversacion();

		// Token: 0x04000570 RID: 1392
		[Tooltip("la razon por la q hay glitches es q algunas penticiones o forzamients se ejecutan justo despues de la conversacion y otros en medio de esta, por eso hay q ignorarlos")]
		[SerializeField]
		private DefaultActividadFemaleConfigMap.DeshabilitarCalculadoresDeEstimulosEnConversacion m_DeshabilitarCalculadoresDeEstimulosEnConversacion = new DefaultActividadFemaleConfigMap.DeshabilitarCalculadoresDeEstimulosEnConversacion();

		// Token: 0x04000571 RID: 1393
		[Tooltip("si esta editando pose, es mejor des activar algunos AI")]
		[SerializeField]
		private DefaultActividadFemaleConfigMap.DeshabilitarCalculadoresDeEstimulosEnEdicionPose m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose = new DefaultActividadFemaleConfigMap.DeshabilitarCalculadoresDeEstimulosEnEdicionPose();

		// Token: 0x04000572 RID: 1394
		[Header("Extra Objects")]
		[SerializeField]
		private List<GameObject> m_extraObjectsPrefabs = new List<GameObject>();

		// Token: 0x020002E9 RID: 745
		[Serializable]
		public class DeshabilitarCalculadoresDeEstimulosEnConversacion
		{
			// Token: 0x04000D3A RID: 3386
			public bool activar = true;

			// Token: 0x04000D3B RID: 3387
			public List<DireccionDeEstimulo> ignorarDirecciones = new List<DireccionDeEstimulo>();

			// Token: 0x04000D3C RID: 3388
			public List<TipoDeEstimulo> ignorarTipos = new List<TipoDeEstimulo>();

			// Token: 0x04000D3D RID: 3389
			public List<ReaccionHumana> ignorarReacciones = new List<ReaccionHumana>();
		}

		// Token: 0x020002EA RID: 746
		[Serializable]
		public class DeshabilitarCalculadoresDeEstimulosEnEdicionPose
		{
			// Token: 0x04000D3E RID: 3390
			public bool activar = true;

			// Token: 0x04000D3F RID: 3391
			[Tooltip("en lugar de ignorar, lo que hace es que solo se aplican a los establecidos")]
			public bool invertido;

			// Token: 0x04000D40 RID: 3392
			public List<DireccionDeEstimulo> ignorarDirecciones = new List<DireccionDeEstimulo>();

			// Token: 0x04000D41 RID: 3393
			public List<TipoDeEstimulo> ignorarTipos = new List<TipoDeEstimulo>();

			// Token: 0x04000D42 RID: 3394
			public List<ReaccionHumana> ignorarReacciones = new List<ReaccionHumana>();
		}

		// Token: 0x020002EB RID: 747
		[Serializable]
		public class NoReducirMaxEmocionValueHastaSalirDeConversacion
		{
			// Token: 0x04000D43 RID: 3395
			public bool activar = true;
		}
	}
}
