using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Estimulos;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x020002A1 RID: 673
	public class TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque> : EstimuledBy<Ttoque, TtocanteObjeto, TownerSiendoTocado>, ITouchedByCharacter where TtocanteObjeto : TocanteObjeto where TownerSiendoTocado : MonoBehaviour, ISideable, IBoneReferenceable where Tcollision : ColisionBasicaV2, new() where Ttoque : TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.TouchStats, new()
	{
		// Token: 0x06000EFA RID: 3834 RVA: 0x00045604 File Offset: 0x00043804
		public TouchedBy(TownerSiendoTocado owner, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, IHistorialColisiones<Tcollision> historial, TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.Config config)
			: base(owner, PrioridadesDeObjetoEstimulado)
		{
			if (config == null)
			{
				throw new ArgumentNullException("config", "config null reference.");
			}
			if (historial == null)
			{
				throw new ArgumentNullException("historial", "historial null reference.");
			}
			this.m_historial = historial;
			this.m_config = config;
			this.m_poolDeListaDeCollisiones = new SimplePoolDeCollection<List<Tcollision>, Tcollision>();
			this.m_poolDeListaDeTocantes = new SimplePoolDeCollection<List<TtocanteObjeto>, TtocanteObjeto>();
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool clearBeforeUpdating
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000EFC RID: 3836 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool soloUnCalculoPorFrame
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool syncUpdate
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x0002591B File Offset: 0x00023B1B
		protected sealed override float maxTimeWaitingAsyncUpdate
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool AsyncUpdating()
		{
			return false;
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x00045686 File Offset: 0x00043886
		protected sealed override bool OnUpdating()
		{
			return base.OnUpdating() && this.m_historial.lastStateCount > 0;
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x000456A0 File Offset: 0x000438A0
		protected sealed override void LoadEstimulantes(List<TtocanteObjeto> resultado)
		{
			this.m_historial.InLastStateGetBy<TtocanteObjeto>(resultado, this.m_config.buscarEnPadres, this.m_config.buscarEn == TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.BuscarEn.rigids, this.m_listCollisionsTemp);
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x000456CD File Offset: 0x000438CD
		public override bool EstaIgnorandoA(TtocanteObjeto estimulante)
		{
			return base.EstaIgnorandoA(estimulante) || estimulante.deshabilitadoParaTocar;
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x000456E8 File Offset: 0x000438E8
		protected sealed override bool EstimulanteCargadoEsValido(TtocanteObjeto estimulante, int index)
		{
			Tcollision tcollision = this.m_listCollisionsTemp[index];
			List<Tcollision> item = this.m_poolDeListaDeCollisiones.GetItem();
			item.Add(tcollision);
			this.m_collisionesDeTipo.Add(estimulante, item);
			return true;
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x00045724 File Offset: 0x00043924
		protected sealed override void OnEstimulanteDuplicado(TtocanteObjeto estimulante, int index)
		{
			Tcollision tcollision = this.m_listCollisionsTemp[index];
			this.m_collisionesDeTipo[estimulante].Add(tcollision);
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnEstimulanteIgnorado(TtocanteObjeto estimulante)
		{
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x00045750 File Offset: 0x00043950
		protected sealed override void PoblarEstimuloDeEstimulante(TtocanteObjeto estimulante, Ttoque emptyEstimulo)
		{
			List<Tcollision> list = this.m_collisionesDeTipo[estimulante];
			emptyEstimulo.Poblar(estimulante, base.estimulado, base.prioridadesDeObjetoEstimulado, list, true);
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x00045788 File Offset: 0x00043988
		protected sealed override void OnUpdated()
		{
			for (int i = 0; i < this.objetosEstimulantes.Count; i++)
			{
				TtocanteObjeto ttocanteObjeto = this.objetosEstimulantes[i] as TtocanteObjeto;
				TtocanteObjeto ttocanteObjeto2 = ttocanteObjeto;
				ICharacter character = ((ttocanteObjeto2 != null) ? ttocanteObjeto2.character : null);
				if (character != null)
				{
					List<TtocanteObjeto> item;
					if (!this.m_tocantesRegistradosDeCharacter.TryGetValue(character, out item))
					{
						item = this.m_poolDeListaDeTocantes.GetItem();
						this.m_tocantesRegistradosDeCharacter.Add(character, item);
					}
					item.Add(ttocanteObjeto);
				}
			}
			base.OnUpdated();
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x0004580E File Offset: 0x00043A0E
		protected sealed override void FinallyUpdated()
		{
			this.m_listCollisionsTemp.Clear();
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x0004581C File Offset: 0x00043A1C
		public bool ContieneEstimulosDeCharacter<T_estimulo>(ICharacter estimulanteCharacter, List<T_estimulo> estimulosResultado) where T_estimulo : InteracionEstimulanteBasica
		{
			bool flag = false;
			List<TtocanteObjeto> list;
			if (!this.m_tocantesRegistradosDeCharacter.TryGetValue(estimulanteCharacter, out list))
			{
				return false;
			}
			for (int i = 0; i < list.Count; i++)
			{
				TtocanteObjeto ttocanteObjeto = list[i];
				T_estimulo t_estimulo;
				if (base.ContieneEstimuloV3<T_estimulo>(ttocanteObjeto, out t_estimulo))
				{
					estimulosResultado.Add(t_estimulo);
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x00045874 File Offset: 0x00043A74
		public bool TryInyectar<T_estimulo>(ICharacter estimulanteCharacter, TtocanteObjeto tocante, T_estimulo estimulo) where T_estimulo : InteracionEstimulanteBasica
		{
			if (this.estimulosDeObjetosEstimulante.Contains(tocante))
			{
				return false;
			}
			List<TtocanteObjeto> list;
			if (!this.m_tocantesRegistradosDeCharacter.TryGetValue(estimulanteCharacter, out list))
			{
				list = new List<TtocanteObjeto>();
				list.Add(tocante);
				this.m_tocantesRegistradosDeCharacter.Add(estimulanteCharacter, list);
			}
			else if (!list.Contains(tocante))
			{
				list.Add(tocante);
			}
			this.estimulosDeObjetosEstimulante.Add(tocante, estimulo);
			return true;
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x000458EC File Offset: 0x00043AEC
		protected sealed override bool Clearing()
		{
			foreach (KeyValuePair<TtocanteObjeto, List<Tcollision>> keyValuePair in this.m_collisionesDeTipo)
			{
				this.m_poolDeListaDeCollisiones.ReturnItem(keyValuePair.Value);
			}
			this.m_collisionesDeTipo.Clear();
			foreach (KeyValuePair<ICharacter, List<TtocanteObjeto>> keyValuePair2 in this.m_tocantesRegistradosDeCharacter)
			{
				this.m_poolDeListaDeTocantes.ReturnItem(keyValuePair2.Value);
			}
			this.m_tocantesRegistradosDeCharacter.Clear();
			return true;
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void Cleared()
		{
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override object ParceEstimulante(object estimulante)
		{
			return estimulante;
		}

		// Token: 0x04000CA5 RID: 3237
		public static readonly bool esParaCollisionesConPhysicsEngine = typeof(ColisionPhysicaV2).IsAssignableFrom(typeof(Tcollision));

		// Token: 0x04000CA6 RID: 3238
		private IHistorialColisiones<Tcollision> m_historial;

		// Token: 0x04000CA7 RID: 3239
		private TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.Config m_config;

		// Token: 0x04000CA8 RID: 3240
		private SimplePoolDeCollection<List<Tcollision>, Tcollision> m_poolDeListaDeCollisiones;

		// Token: 0x04000CA9 RID: 3241
		private Dictionary<TtocanteObjeto, List<Tcollision>> m_collisionesDeTipo = new Dictionary<TtocanteObjeto, List<Tcollision>>();

		// Token: 0x04000CAA RID: 3242
		private SimplePoolDeCollection<List<TtocanteObjeto>, TtocanteObjeto> m_poolDeListaDeTocantes;

		// Token: 0x04000CAB RID: 3243
		private Dictionary<ICharacter, List<TtocanteObjeto>> m_tocantesRegistradosDeCharacter = new Dictionary<ICharacter, List<TtocanteObjeto>>();

		// Token: 0x04000CAC RID: 3244
		private List<Tcollision> m_listCollisionsTemp = new List<Tcollision>();

		// Token: 0x020002A2 RID: 674
		public class Config
		{
			// Token: 0x04000CAD RID: 3245
			public TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.BuscarEn buscarEn;

			// Token: 0x04000CAE RID: 3246
			public bool buscarEnPadres;
		}

		// Token: 0x020002A3 RID: 675
		public enum BuscarEn
		{
			// Token: 0x04000CB0 RID: 3248
			colliders,
			// Token: 0x04000CB1 RID: 3249
			rigids
		}

		// Token: 0x020002A4 RID: 676
		[Serializable]
		public class TouchStats : Touch, IClearable
		{
			// Token: 0x1700035D RID: 861
			// (get) Token: 0x06000F0F RID: 3855 RVA: 0x000459B0 File Offset: 0x00043BB0
			public TtocanteObjeto subject
			{
				get
				{
					return (TtocanteObjeto)((object)base.estimulante);
				}
			}

			// Token: 0x1700035E RID: 862
			// (get) Token: 0x06000F10 RID: 3856 RVA: 0x000459BD File Offset: 0x00043BBD
			public TownerSiendoTocado touched
			{
				get
				{
					return (TownerSiendoTocado)((object)base.estimulado);
				}
			}

			// Token: 0x1700035F RID: 863
			// (get) Token: 0x06000F11 RID: 3857 RVA: 0x000459CA File Offset: 0x00043BCA
			public Transform touchingTransform
			{
				get
				{
					return base.transformEstimulante;
				}
			}

			// Token: 0x17000360 RID: 864
			// (get) Token: 0x06000F12 RID: 3858 RVA: 0x000459D2 File Offset: 0x00043BD2
			public Transform touchedBone
			{
				get
				{
					return base.transformEstimulado;
				}
			}

			// Token: 0x17000361 RID: 865
			// (get) Token: 0x06000F13 RID: 3859 RVA: 0x000459DA File Offset: 0x00043BDA
			// (set) Token: 0x06000F14 RID: 3860 RVA: 0x000459E2 File Offset: 0x00043BE2
			public List<Tcollision> collisions { get; private set; }

			// Token: 0x06000F15 RID: 3861 RVA: 0x000459EC File Offset: 0x00043BEC
			public override void Clear()
			{
				base.Clear();
				base.maxMaxEmulatedRelativeStepVelocity = 0f;
				base.maxTotalEmulatedRelativeStepVelocity = 0f;
				base.side = Side.none;
				if (base.colliders != null)
				{
					base.colliders.Clear();
				}
				if (base.rigids != null)
				{
					base.rigids.Clear();
				}
				if (this.collisions != null)
				{
					this.collisions.Clear();
				}
				base.tipoDeEstimulo = TipoDeEstimulo.tactil;
			}

			// Token: 0x06000F16 RID: 3862 RVA: 0x00005A42 File Offset: 0x00003C42
			protected virtual void CargarPartesTocadas()
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000F17 RID: 3863 RVA: 0x00045A5C File Offset: 0x00043C5C
			public virtual void Poblar(TtocanteObjeto touchingMono, TownerSiendoTocado touchedMono, IParteDelCuerpoHumanoPrioridades touchedMonoPrioridades, List<Tcollision> collisionesDelToque, bool limpiar)
			{
				if (base.colliders == null)
				{
					base.colliders = new List<Collider>(10);
				}
				if (base.rigids == null)
				{
					base.rigids = new List<Rigidbody>(10);
				}
				if (this.collisions == null)
				{
					this.collisions = new List<Tcollision>(10);
				}
				if (limpiar)
				{
					this.Clear();
				}
				try
				{
					int num = 0;
					float num2 = 0f;
					float num3 = 0f;
					Vector3 vector = Vector3.zero;
					Vector3 vector2 = Vector3.zero;
					Vector3 vector3 = Vector3.zero;
					Vector3 vector4 = default(Vector3);
					Vector3 vector5 = default(Vector3);
					Vector3 vector6 = Vector3.zero;
					Vector3 vector7 = Vector3.zero;
					bool esParaCollisionesConPhysicsEngine = TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.esParaCollisionesConPhysicsEngine;
					if (collisionesDelToque.Count == 0)
					{
						throw new NotSupportedException();
					}
					int num4 = 0;
					for (int i = 0; i < collisionesDelToque.Count; i++)
					{
						Tcollision tcollision = collisionesDelToque[i];
						if (!tcollision.poblado)
						{
							throw new NotSupportedException("no se puede usar una collision no poblada.");
						}
						Vector3 normalized = tcollision.normalDeSuperficie.ObtenerVectorGlobal().normalized;
						Vector3 vector8 = tcollision.point.ObtenerVectorGlobal();
						if (i <= 0 || !(vector5 + normalized == Vector3.zero))
						{
							vector4 += vector8;
							vector5 += normalized;
							num4++;
							if (tcollision.rigidbodyChocandonos != null && TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.TouchStats.RigidTemp.Add(tcollision.rigidbodyChocandonos))
							{
								base.rigids.Add(tcollision.rigidbodyChocandonos);
							}
							if (TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.TouchStats.ColliderTemp.Add(tcollision.colliderChocandonos))
							{
								base.colliders.Add(tcollision.colliderChocandonos);
							}
							this.collisions.Add(tcollision);
							if (num2 < tcollision.velocidadMagEmuladaRelativa)
							{
								num2 = tcollision.velocidadMagEmuladaRelativa;
							}
							vector += tcollision.nosotrosVelocitySaver.metrosPorSegundo;
							vector2 += tcollision.otherVelocitySaver.metrosPorSegundo;
							vector3 += tcollision.velocidadEmuladaRelativa;
							num3 += tcollision.velocidadMagEmuladaRelativa;
							if (TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.esParaCollisionesConPhysicsEngine)
							{
								ColisionPhysicaV2 colisionPhysicaV = tcollision as ColisionPhysicaV2;
								vector6 += colisionPhysicaV.data.impulse;
								vector7 += colisionPhysicaV.data.relativeVelocity;
								num += colisionPhysicaV.data.contactCount;
							}
							else
							{
								num++;
							}
						}
					}
					if (this.collisions.Count == 0 || num4 == 0)
					{
						throw new InvalidOperationException();
					}
					if (vector5 == Vector3.zero)
					{
						throw new NotSupportedException();
					}
					vector5 = vector5.normalized;
					vector4 /= (float)num4;
					vector /= (float)num4;
					vector2 /= (float)num4;
					vector3 /= (float)num4;
					vector6 /= (float)num4;
					vector7 /= (float)num4;
					Transform transform;
					if (base.rigids.Count == 0 || touchingMono.tipo == ObjetoEstimulante.Tipo.collider)
					{
						transform = base.colliders[0].transform;
					}
					else
					{
						transform = base.rigids[0].transform;
					}
					base.DefinirReferencias(touchedMono, touchedMonoPrioridades, touchingMono, transform, null);
					base.DefinirTransformsYVectores(this.touched.bone, new Vector3?(vector5), new Vector3?(vector4), null);
					base.maxMaxEmulatedRelativeStepVelocity = num2;
					base.maxTotalEmulatedRelativeStepVelocity = num3;
					base.side = this.ObtenerSide(touchingMono, touchedMono, collisionesDelToque);
					this.CargarPartesTocadas();
					base.tipoDeEstimulo = TipoDeEstimulo.tactil;
					base.velocidadEstimuladoEmulada = vector;
					base.velocidadEstimulanteEmulada = vector2;
					base.velocidadRelativaEmulada = vector3;
					base.velocidadRelativaPhysics = vector7;
					base.velocidadRelativaPhysicsMagnitud = vector7.magnitude;
					base.impulsoPhysics = vector6;
					base.esDePhysicsEngine = esParaCollisionesConPhysicsEngine;
					base.cantidadDeContanctos = num;
				}
				finally
				{
					TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.TouchStats.RigidTemp.Clear();
					TouchedBy<TtocanteObjeto, TownerSiendoTocado, Tcollision, Ttoque>.TouchStats.ColliderTemp.Clear();
				}
			}

			// Token: 0x06000F18 RID: 3864 RVA: 0x00045E9C File Offset: 0x0004409C
			protected virtual Side ObtenerSide(TtocanteObjeto sub, TownerSiendoTocado owner, List<Tcollision> cols)
			{
				return owner.side;
			}

			// Token: 0x06000F19 RID: 3865 RVA: 0x00045EA9 File Offset: 0x000440A9
			private static float Energia(float sqrVelocidad, float masa)
			{
				return 0.5f * masa * sqrVelocidad;
			}

			// Token: 0x04000CB3 RID: 3251
			private static HashSet<Rigidbody> RigidTemp = new HashSet<Rigidbody>();

			// Token: 0x04000CB4 RID: 3252
			private static HashSet<Collider> ColliderTemp = new HashSet<Collider>();
		}
	}
}
