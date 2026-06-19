using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public class EstimuloVisual : InteracionEstimulanteBasica
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002F10 File Offset: 0x00001110
		public static void PoblarEstimuloDeObservador(EstimuloVisual emptyEstimulo, IParteDelCuerpoHumanoPrioridades EstimuladoPrioridades, bool enRango, AnimatorCharacter observadorMain, Component observadorSlave, MonoBehaviour observado, Transform boneObservado, Vector3 puntoVisualDeObservador, Vector3 direccionVisualDeObservador, Vector3? normalDePuntoSiendoVisto, Vector3 puntoSiendoVisto, ParteDelCuerpoHumano parteSiendoVista, Side sideSiendoVista, DireccionDeEstimulo direccion)
		{
			emptyEstimulo.tipoDeEstimulo = TipoDeEstimulo.visual;
			emptyEstimulo.m_DataVisual.outOfRange = !enRango;
			emptyEstimulo.side = sideSiendoVista;
			Component component;
			Transform transform;
			Transform transform2;
			if (observadorSlave == null)
			{
				component = observadorMain;
				if (observadorMain.cameraAtadaTransform)
				{
					transform = observadorMain.cameraAtadaTransform;
					transform2 = observadorMain.bones.head.transform;
				}
				else
				{
					transform = observadorMain.bones.eyeL.transform;
					transform2 = observadorMain.bones.eyeR.transform;
				}
			}
			else
			{
				component = observadorSlave;
				transform = observadorSlave.transform;
				transform2 = null;
			}
			emptyEstimulo.DefinirReferencias(observado, EstimuladoPrioridades, component, transform, transform2);
			if (normalDePuntoSiendoVisto == null || normalDePuntoSiendoVisto.Value == Vector3.zero)
			{
				emptyEstimulo.DefinirTransformEstimuladoYVectoresDeEstimuloVisual(boneObservado, emptyEstimulo.transformEstimulante, -direccionVisualDeObservador, puntoSiendoVisto, puntoVisualDeObservador, null, emptyEstimulo.transformEstimulanteSegundario);
			}
			else
			{
				emptyEstimulo.DefinirTransformEstimuladoYVectoresDeEstimuloVisual(boneObservado, emptyEstimulo.transformEstimulante, normalDePuntoSiendoVisto.Value, puntoSiendoVisto, puntoVisualDeObservador, null, emptyEstimulo.transformEstimulanteSegundario);
			}
			emptyEstimulo.tipo = direccion;
			emptyEstimulo.AddParteEstimulada(parteSiendoVista);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600002B RID: 43 RVA: 0x0000301A File Offset: 0x0000121A
		public bool outOfRange
		{
			get
			{
				return this.m_DataVisual.outOfRange;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00003027 File Offset: 0x00001227
		public float distancia
		{
			get
			{
				return Vector3.Distance(this.puntoEstimulante, base.posicionGlobalDelEstimulo);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000303A File Offset: 0x0000123A
		public Vector3 direccionHaciaPosicionGlobalDelEstimulo
		{
			get
			{
				return base.posicionGlobalDelEstimulo - this.puntoEstimulante;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000304D File Offset: 0x0000124D
		public float angleDesdePuntoVisual
		{
			get
			{
				return Vector3.Angle(this.direccionHaciaPosicionGlobalDelEstimulo, -base.normalGlobalDelEstimulo);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00003065 File Offset: 0x00001265
		public Vector3 puntoEstimulante
		{
			get
			{
				return this.m_DataVisual.puntoEstimulante.ObtenerVectorGlobal();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00003077 File Offset: 0x00001277
		public TipoDeEstimuloVisual tipoDeEstimuloVisual
		{
			get
			{
				return this.m_DataVisual.tipoDeEstimuloVisual;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003084 File Offset: 0x00001284
		public void SetTipoDeEstimuloVisual(TipoDeEstimuloVisual tipo)
		{
			this.m_DataVisual.tipoDeEstimuloVisual = tipo;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003092 File Offset: 0x00001292
		public void DefinirTransformEstimuladoYVectoresDeEstimuloVisual(Transform TransformEstimulado, Transform TransformEstimulante, Vector3 NormalGlobalDelEstimulo, Vector3 PosicionGlobalDelEstimulo, Vector3 puntoVisual, Transform TransformEstimuladoSegundario = null, Transform TransformEstimulanteSegundario = null)
		{
			base.DefinirTransformsYVectores(TransformEstimulado, new Vector3?(NormalGlobalDelEstimulo), new Vector3?(PosicionGlobalDelEstimulo), TransformEstimuladoSegundario);
			this.m_DataVisual.puntoEstimulante.Poblar(Vector.TipoDeVector.punto, puntoVisual, TransformEstimulante);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000030C0 File Offset: 0x000012C0
		protected override bool ConvinableCon(InteracionEstimulanteBasica other)
		{
			EstimuloVisual estimuloVisual = other as EstimuloVisual;
			return estimuloVisual != null && estimuloVisual.m_DataVisual.tipoDeEstimuloVisual == this.m_DataVisual.tipoDeEstimuloVisual;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000030F1 File Offset: 0x000012F1
		public Transform PuntoVisualTransform()
		{
			return this.m_DataVisual.puntoEstimulante.referencia;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003103 File Offset: 0x00001303
		public sealed override void Clear()
		{
			base.Clear();
			this.m_DataVisual.tipoDeEstimuloVisual = TipoDeEstimuloVisual.None;
			this.m_DataVisual.puntoEstimulante.Clear();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003128 File Offset: 0x00001328
		public sealed override void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			base.CopiarA(resultado, convinarPartesEstimuladas);
			EstimuloVisual estimuloVisual = resultado as EstimuloVisual;
			if (estimuloVisual == null)
			{
				return;
			}
			estimuloVisual.m_DataVisual = this.m_DataVisual;
		}

		// Token: 0x04000002 RID: 2
		[SerializeField]
		private EstimuloVisual.DataVisual m_DataVisual;

		// Token: 0x02000026 RID: 38
		[Serializable]
		private struct DataVisual
		{
			// Token: 0x0400007F RID: 127
			public TipoDeEstimuloVisual tipoDeEstimuloVisual;

			// Token: 0x04000080 RID: 128
			public Vector puntoEstimulante;

			// Token: 0x04000081 RID: 129
			public bool outOfRange;
		}
	}
}
