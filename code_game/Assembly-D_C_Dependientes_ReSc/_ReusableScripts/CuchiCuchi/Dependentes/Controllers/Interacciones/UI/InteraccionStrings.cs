using System;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI
{
	// Token: 0x020001B6 RID: 438
	[RequireComponent(typeof(Interaccion))]
	public sealed class InteraccionStrings : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000A7A RID: 2682 RVA: 0x00034411 File Offset: 0x00032611
		public IInteraccionesDeCharacter interacciones
		{
			get
			{
				return this.m_interacciones;
			}
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00034419 File Offset: 0x00032619
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
			this.primera.Init(this.m_Interaccion);
			this.segunda.Init(this.m_Interaccion);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0003444F File Offset: 0x0003264F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interaccion.addedTo += this.M_Interaccion_addedTo;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0003446E File Offset: 0x0003266E
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_Interaccion != null)
			{
				this.m_Interaccion.addedTo -= this.M_Interaccion_addedTo;
			}
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0003449C File Offset: 0x0003269C
		private void M_Interaccion_addedTo(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			InteraccionStrings.Persona persona = this.primera;
			InteraccionStrings.Persona persona2 = this.segunda;
			this.m_interacciones = arg2;
			persona2.interaciones = arg2;
			persona.interaciones = arg2;
		}

		// Token: 0x040007EE RID: 2030
		private IInteraccionesDeCharacter m_interacciones;

		// Token: 0x040007EF RID: 2031
		public InteraccionStrings.Persona primera = new InteraccionStrings.Persona();

		// Token: 0x040007F0 RID: 2032
		public InteraccionStrings.Persona segunda = new InteraccionStrings.Persona();

		// Token: 0x040007F1 RID: 2033
		private Interaccion m_Interaccion;

		// Token: 0x020001B7 RID: 439
		[Serializable]
		public class Persona
		{
			// Token: 0x1700025A RID: 602
			// (get) Token: 0x06000A80 RID: 2688 RVA: 0x000344EA File Offset: 0x000326EA
			public INombrableLocalizado start
			{
				get
				{
					return this.m_Start as INombrableLocalizado;
				}
			}

			// Token: 0x1700025B RID: 603
			// (get) Token: 0x06000A81 RID: 2689 RVA: 0x000344F7 File Offset: 0x000326F7
			public INombrableLocalizado stop
			{
				get
				{
					return this.m_Stop as INombrableLocalizado;
				}
			}

			// Token: 0x1700025C RID: 604
			// (get) Token: 0x06000A82 RID: 2690 RVA: 0x00034504 File Offset: 0x00032704
			public string startTextFormal
			{
				get
				{
					if (this.start != null)
					{
						return this.start.ObtenerNombreDeCurrentLocalization(NombrableResult.firstUpper);
					}
					return this.m_Interaccion.name;
				}
			}

			// Token: 0x1700025D RID: 605
			// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00034526 File Offset: 0x00032726
			public string stopTextFormal
			{
				get
				{
					if (this.stop != null)
					{
						return this.stop.ObtenerNombreDeCurrentLocalization(NombrableResult.firstUpper);
					}
					return "Default";
				}
			}

			// Token: 0x1700025E RID: 606
			// (get) Token: 0x06000A84 RID: 2692 RVA: 0x00034542 File Offset: 0x00032742
			public string startTextLower
			{
				get
				{
					if (this.start != null)
					{
						return this.start.ObtenerNombreDeCurrentLocalization(NombrableResult.lower);
					}
					return this.m_Interaccion.name;
				}
			}

			// Token: 0x1700025F RID: 607
			// (get) Token: 0x06000A85 RID: 2693 RVA: 0x00034564 File Offset: 0x00032764
			public string stopTextLower
			{
				get
				{
					if (this.stop != null)
					{
						return this.stop.ObtenerNombreDeCurrentLocalization(NombrableResult.lower);
					}
					return "Default";
				}
			}

			// Token: 0x17000260 RID: 608
			// (get) Token: 0x06000A86 RID: 2694 RVA: 0x00034580 File Offset: 0x00032780
			public bool esPrimaria
			{
				get
				{
					return this.m_esPrimaria;
				}
			}

			// Token: 0x06000A87 RID: 2695 RVA: 0x00034588 File Offset: 0x00032788
			public void Init(Interaccion Inter)
			{
				if (Inter == null)
				{
					throw new ArgumentNullException("Inter", "Inter null reference.");
				}
				this.m_Interaccion = Inter;
				this.m_esPrimaria = this.m_Interaccion.interactionLayer == 0;
			}

			// Token: 0x06000A88 RID: 2696 RVA: 0x000345BE File Offset: 0x000327BE
			public string CurrentTextFormal(bool esDetener)
			{
				if (esDetener)
				{
					return this.stopTextFormal;
				}
				return this.startTextFormal;
			}

			// Token: 0x06000A89 RID: 2697 RVA: 0x000345D0 File Offset: 0x000327D0
			public string CurrentTextLower(bool esDetener)
			{
				if (esDetener)
				{
					return this.stopTextLower;
				}
				return this.startTextLower;
			}

			// Token: 0x06000A8A RID: 2698 RVA: 0x000345E2 File Offset: 0x000327E2
			public bool GenericEsDetener()
			{
				if (!this.m_esPrimaria || this.interaciones == null)
				{
					return this.m_Interaccion.algunaEstaEjecutandose;
				}
				return this.interaciones.ObtenerFirstEjecutandosePrimaria() != null;
			}

			// Token: 0x17000261 RID: 609
			// (get) Token: 0x06000A8B RID: 2699 RVA: 0x00034618 File Offset: 0x00032818
			[Obsolete("se debe especificar por fuera si es stop", true)]
			public string currentTextFormal
			{
				get
				{
					if (!this.m_esPrimaria || this.interaciones == null)
					{
						if (this.m_Interaccion.algunaEstaEjecutandose)
						{
							return this.stopTextFormal;
						}
						return this.startTextFormal;
					}
					else
					{
						if (this.interaciones.ObtenerFirstEjecutandosePrimaria() != null)
						{
							return this.stopTextFormal;
						}
						return this.startTextFormal;
					}
				}
			}

			// Token: 0x17000262 RID: 610
			// (get) Token: 0x06000A8C RID: 2700 RVA: 0x0003466C File Offset: 0x0003286C
			[Obsolete("se debe especificar por fuera si es stop", true)]
			public string currentTextLower
			{
				get
				{
					if (!this.m_esPrimaria || this.interaciones == null)
					{
						if (this.m_Interaccion.algunaEstaEjecutandose)
						{
							return this.stopTextLower;
						}
						return this.startTextLower;
					}
					else
					{
						if (this.interaciones.ObtenerFirstEjecutandosePrimaria() != null)
						{
							return this.stopTextLower;
						}
						return this.startTextLower;
					}
				}
			}

			// Token: 0x040007F2 RID: 2034
			public IInteraccionesDeCharacter interaciones;

			// Token: 0x040007F3 RID: 2035
			private Interaccion m_Interaccion;

			// Token: 0x040007F4 RID: 2036
			[SerializeField]
			[ConstraintType(typeof(INombrableLocalizado))]
			private Object m_Start;

			// Token: 0x040007F5 RID: 2037
			[SerializeField]
			[ConstraintType(typeof(INombrableLocalizado))]
			private Object m_Stop;

			// Token: 0x040007F6 RID: 2038
			[SerializeField]
			[ReadOnlyUI]
			private bool m_esPrimaria;
		}
	}
}
