using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200009A RID: 154
	[Serializable]
	public struct InteraccionStartParams
	{
		// Token: 0x06000611 RID: 1553 RVA: 0x0001DEBA File Offset: 0x0001C0BA
		public InteraccionStartParams(int Prioridad, float Duracion, ControllerPrioridadConfig PriConfig, float InitialVelocidadInMod, float VelocidadInMod, float VelocidadOutMod, bool usarTransicionEntreInteracionesEnMismoLayerSiDisponible)
		{
			this.m_prioridad = Prioridad;
			this.m_duracion = Duracion;
			this.m_priConfig = PriConfig;
			this.m_initialVelocidadInMod = InitialVelocidadInMod;
			this.m_velocidadInMod = VelocidadInMod;
			this.m_velocidadOutMod = VelocidadOutMod;
			this.m_usarTransicionEntreInteracionesEnMismoLayerSiDisponible = usarTransicionEntreInteracionesEnMismoLayerSiDisponible;
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x0001DEF1 File Offset: 0x0001C0F1
		public bool usarTransicionEntreInteracionesEnMismoLayerSiDisponible
		{
			get
			{
				return this.m_usarTransicionEntreInteracionesEnMismoLayerSiDisponible;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x0001DEF9 File Offset: 0x0001C0F9
		public int prioridad
		{
			get
			{
				return this.m_prioridad;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x0001DF01 File Offset: 0x0001C101
		public float duracion
		{
			get
			{
				return this.m_duracion;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x0001DF09 File Offset: 0x0001C109
		public ControllerPrioridadConfig priConfig
		{
			get
			{
				return this.m_priConfig;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x0001DF11 File Offset: 0x0001C111
		public float initialVelocidadInMod
		{
			get
			{
				return this.m_initialVelocidadInMod;
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x0001DF19 File Offset: 0x0001C119
		public float velocidadInMod
		{
			get
			{
				return this.m_velocidadInMod;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x0001DF21 File Offset: 0x0001C121
		public float velocidadOutMod
		{
			get
			{
				return this.m_velocidadOutMod;
			}
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001DF2C File Offset: 0x0001C12C
		public InteraccionStartParams Modificado(InteraccionStartParamsModificadores modificador)
		{
			InteraccionStartParams interaccionStartParams = this;
			interaccionStartParams.m_duracion *= modificador.duracion;
			interaccionStartParams.m_velocidadInMod *= modificador.velocidadIn;
			interaccionStartParams.m_velocidadOutMod *= modificador.velocidadOut;
			return interaccionStartParams;
		}

		// Token: 0x0400043B RID: 1083
		[ReadOnlyUI]
		[SerializeField]
		private bool m_usarTransicionEntreInteracionesEnMismoLayerSiDisponible;

		// Token: 0x0400043C RID: 1084
		[ReadOnlyUI]
		[SerializeField]
		private int m_prioridad;

		// Token: 0x0400043D RID: 1085
		[ReadOnlyUI]
		[SerializeField]
		private float m_duracion;

		// Token: 0x0400043E RID: 1086
		[ReadOnlyUI]
		[SerializeField]
		private ControllerPrioridadConfig m_priConfig;

		// Token: 0x0400043F RID: 1087
		[ReadOnlyUI]
		[SerializeField]
		private float m_initialVelocidadInMod;

		// Token: 0x04000440 RID: 1088
		[ReadOnlyUI]
		[SerializeField]
		private float m_velocidadInMod;

		// Token: 0x04000441 RID: 1089
		[ReadOnlyUI]
		[SerializeField]
		private float m_velocidadOutMod;
	}
}
