using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E5 RID: 997
	public abstract class ViendoOSiendoVisto<T_Estimulante, T_Estimulado> : EstimuledBy<EstimuloVisual, T_Estimulante, T_Estimulado>, HistorialDeCollidersEnRadius.IListiner where T_Estimulante : Component where T_Estimulado : MonoBehaviour, IViendoOSiendoVistoUser
	{
		// Token: 0x060015A4 RID: 5540 RVA: 0x0005B4A0 File Offset: 0x000596A0
		protected ViendoOSiendoVisto(HistorialDeCollidersEnRadius historial, T_Estimulado estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, LayerMask checkMask)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
			this.m_checkMask = checkMask;
			this.m_historial = historial;
			this.m_pedido = new ViendoOSiendoVisto<T_Estimulante, T_Estimulado>.Pedido();
			this.m_predicate = new HistorialDeCollidersEnRadius.Resultado.PredicateConScore(this.Filtrador);
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x060015A5 RID: 5541
		protected abstract bool buscandoTriggers { get; }

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x060015A6 RID: 5542
		protected abstract bool buscandoColliders { get; }

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x060015A7 RID: 5543
		protected abstract bool descartarSiEstaFueraDeRango { get; }

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x060015A8 RID: 5544
		protected abstract float maxDistanceMod { get; }

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x060015A9 RID: 5545
		protected abstract float distanceIgnorandoAngleMod { get; }

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x060015AA RID: 5546
		protected abstract float maxAngleMod { get; }

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x060015AB RID: 5547 RVA: 0x0005B502 File Offset: 0x00059702
		public ViendoOSiendoVisto<T_Estimulante, T_Estimulado>.Pedido currentPedido
		{
			get
			{
				return this.m_pedido;
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x060015AC RID: 5548 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool clearBeforeUpdating
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x060015AD RID: 5549 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool soloUnCalculoPorFrame
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x060015AE RID: 5550 RVA: 0x0005B50A File Offset: 0x0005970A
		protected sealed override float maxTimeWaitingAsyncUpdate
		{
			get
			{
				return 3f;
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x060015AF RID: 5551 RVA: 0x00004252 File Offset: 0x00002452
		protected sealed override bool syncUpdate
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x0005B514 File Offset: 0x00059714
		private bool Filtrador(Collider collider, out float score)
		{
			if (!this.m_checkMask.Contains(collider.gameObject.layer))
			{
				score = float.MinValue;
				return false;
			}
			Vector3 vector = collider.ClosestPointOnBounds(this.m_pedido.puntoVisual);
			float num;
			float num2;
			if (vector.EnCono(this.m_pedido.puntoVisual, this.m_pedido.direccionVisual, this.m_pedido.maxAngleDeVision, out num, out num2, this.m_pedido.radius))
			{
				score = num * 0.75f + num2 * 0.25f;
				return true;
			}
			float num3;
			if (vector.EnRadius(this.m_pedido.puntoVisual, this.m_pedido.radiusIgnorandoCono, out num3))
			{
				score = num3 * 0.1f;
				return true;
			}
			score = float.MinValue;
			return !this.descartarSiEstaFueraDeRango;
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x0005B5DC File Offset: 0x000597DC
		protected sealed override bool AsyncUpdating()
		{
			if (!this.m_historial || !this.m_historial.isActiveAndEnabled)
			{
				return false;
			}
			if (this.m_historial.ContainsListiner(this))
			{
				return false;
			}
			this.ActualizarPedido();
			this.m_historial.RegisterListinerForNextUpdate(this);
			return true;
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0005B628 File Offset: 0x00059828
		protected sealed override bool OnUpdating()
		{
			return base.OnUpdating() && this.m_historial.lastResultado.Count > 0;
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0005B647 File Offset: 0x00059847
		protected virtual T_Estimulante GetEstimulanteFromColliderInVision(Collider collider)
		{
			return collider.GetComponentInParent<T_Estimulante>();
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0005B650 File Offset: 0x00059850
		protected sealed override void LoadEstimulantes(List<T_Estimulante> resultado)
		{
			try
			{
				this.m_historial.lastResultado.ObtenerCollidersSortPorScoreDESC(this.m_predicate, this.m_temp, this.buscandoColliders, this.buscandoTriggers);
				for (int i = 0; i < this.m_temp.Count; i++)
				{
					Collider collider = this.m_temp[i];
					T_Estimulante estimulanteFromColliderInVision = this.GetEstimulanteFromColliderInVision(collider);
					if (!(estimulanteFromColliderInVision == null) && this.m_filtradorTemp.Add(estimulanteFromColliderInVision))
					{
						this.m_ColliderDeEstimulante.Add(estimulanteFromColliderInVision, collider);
						resultado.Add(estimulanteFromColliderInVision);
					}
				}
			}
			finally
			{
				this.m_filtradorTemp.Clear();
				this.m_temp.Clear();
			}
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0005B70C File Offset: 0x0005990C
		protected sealed override bool EstimulanteCargadoEsValido(T_Estimulante estimulante, int index)
		{
			MonoBehaviour monoBehaviour = estimulante as MonoBehaviour;
			if (monoBehaviour != null && !monoBehaviour.isActiveAndEnabled)
			{
				return false;
			}
			if (this.EstimulanteEsValido(estimulante))
			{
				return true;
			}
			this.m_ColliderDeEstimulante.Remove(estimulante);
			return false;
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnEstimulanteDuplicado(T_Estimulante estimulante, int index)
		{
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnEstimulanteIgnorado(T_Estimulante estimulante)
		{
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x00025C04 File Offset: 0x00023E04
		protected sealed override void OnUpdated()
		{
			base.OnUpdated();
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x0005B751 File Offset: 0x00059951
		protected override void FinallyUpdated()
		{
			this.m_ColliderDeEstimulante.Clear();
		}

		// Token: 0x060015BA RID: 5562
		protected abstract bool EstimulanteEsValido(T_Estimulante estimulante);

		// Token: 0x060015BB RID: 5563
		protected abstract ParteDelCuerpoHumano ObtenerPartesPrincipalAEstimulo(T_Estimulante estimulante, EstimuloVisual estimulo);

		// Token: 0x060015BC RID: 5564
		protected abstract void CargarPartesAEstimulo(T_Estimulante estimulante, EstimuloVisual estimulo);

		// Token: 0x060015BD RID: 5565
		protected abstract DireccionDeEstimulo ObtenerTipoDeEstimulo(T_Estimulante estimulante, EstimuloVisual estimulo);

		// Token: 0x060015BE RID: 5566 RVA: 0x0005B760 File Offset: 0x00059960
		private void CalcularDistancia(out float distancia, out Vector3 puntoVisual, out Vector3 direccionVisual)
		{
			if (base.estimulado.camara != null)
			{
				puntoVisual = base.estimulado.camara.position;
				direccionVisual = base.estimulado.camara.forward;
				distancia = base.estimulado.maxDistance;
				return;
			}
			Vector3 ojoDerechoPosicion = base.estimulado.ojoDerechoPosicion;
			Vector3 ojoIzqierdoPosicion = base.estimulado.ojoIzqierdoPosicion;
			Vector3 ojoDerechoDireccion = base.estimulado.ojoDerechoDireccion;
			Vector3 ojoIzqierdoDireccion = base.estimulado.ojoIzqierdoDireccion;
			puntoVisual = ojoDerechoPosicion + ojoIzqierdoPosicion;
			puntoVisual /= 2f;
			direccionVisual = ojoDerechoDireccion + ojoIzqierdoDireccion;
			direccionVisual = direccionVisual.normalized;
			Vector3 vector;
			Vector3 vector2;
			if (Vector3.Angle(ojoDerechoDireccion, ojoIzqierdoDireccion) > 2f && Math3d.ClosestPointsOnTwoLines(out vector, out vector2, ojoDerechoPosicion, ojoDerechoDireccion, ojoIzqierdoPosicion, ojoIzqierdoDireccion))
			{
				Vector3 vector3 = vector + vector2;
				vector3 /= 2f;
				distancia = Mathf.Clamp((vector3 - puntoVisual).magnitude * 1.05f, 0f, base.estimulado.maxDistance * this.maxDistanceMod);
				return;
			}
			distancia = base.estimulado.maxDistance * this.maxDistanceMod;
		}

		// Token: 0x060015BF RID: 5567 RVA: 0x0005B8E0 File Offset: 0x00059AE0
		private void ActualizarPedido()
		{
			float num;
			Vector3 vector;
			Vector3 vector2;
			this.CalcularDistancia(out num, out vector, out vector2);
			this.m_pedido.incluirTriggers = false;
			this.m_pedido.layerMask = this.m_checkMask;
			this.m_pedido.radius = num;
			this.m_pedido.puntoVisual = vector;
			this.m_pedido.direccionVisual = vector2;
			this.m_pedido.maxAngleDeVision = base.estimulado.maxAngleDeVision * this.maxAngleMod;
			this.m_pedido.radiusIgnorandoCono = Mathf.Min(num * 0.99f, base.estimulado.maxDistanceIgnorandoAngulo * this.distanceIgnorandoAngleMod);
			this.m_pedido.descartarSiEstaFueraDeRango = this.descartarSiEstaFueraDeRango;
			if (this.buscandoTriggers)
			{
				this.m_pedido.incluirTriggers = true;
			}
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void Cleared()
		{
		}

		// Token: 0x060015C1 RID: 5569 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool Clearing()
		{
			return true;
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x060015C2 RID: 5570 RVA: 0x0005B502 File Offset: 0x00059702
		HistorialDeCollidersEnRadius.Pedido HistorialDeCollidersEnRadius.IListiner.pedido
		{
			get
			{
				return this.m_pedido;
			}
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x0005B9AF File Offset: 0x00059BAF
		void HistorialDeCollidersEnRadius.IListiner.HistorialUpdated(HistorialDeCollidersEnRadius.Resultado resultado)
		{
			base.DoUpdate();
		}

		// Token: 0x04001155 RID: 4437
		protected ViendoOSiendoVisto<T_Estimulante, T_Estimulado>.Pedido m_pedido;

		// Token: 0x04001156 RID: 4438
		protected LayerMask m_checkMask;

		// Token: 0x04001157 RID: 4439
		protected HistorialDeCollidersEnRadius m_historial;

		// Token: 0x04001158 RID: 4440
		private HistorialDeCollidersEnRadius.Resultado.PredicateConScore m_predicate;

		// Token: 0x04001159 RID: 4441
		private List<Collider> m_temp = new List<Collider>();

		// Token: 0x0400115A RID: 4442
		private HashSet<T_Estimulante> m_filtradorTemp = new HashSet<T_Estimulante>();

		// Token: 0x0400115B RID: 4443
		protected Dictionary<T_Estimulante, Collider> m_ColliderDeEstimulante = new Dictionary<T_Estimulante, Collider>();

		// Token: 0x020003E6 RID: 998
		public class Pedido : HistorialDeCollidersEnRadius.Pedido
		{
			// Token: 0x0400115C RID: 4444
			public Vector3 puntoVisual;

			// Token: 0x0400115D RID: 4445
			public Vector3 direccionVisual;

			// Token: 0x0400115E RID: 4446
			public float maxAngleDeVision;

			// Token: 0x0400115F RID: 4447
			public float radiusIgnorandoCono;

			// Token: 0x04001160 RID: 4448
			public bool descartarSiEstaFueraDeRango;
		}
	}
}
