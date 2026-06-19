using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000059 RID: 89
	public class PersonalidadInfo : AplicableCustomMonobehaviour
	{
		// Token: 0x060001D3 RID: 467 RVA: 0x0000DD20 File Offset: 0x0000BF20
		public void Actualizar()
		{
			Personalidad componentEnRoot = this.GetComponentEnRoot(false);
			this.m_perverticidad = componentEnRoot.perverticidad;
			this.m_exhibicionismo = componentEnRoot.exhibicionismo;
			this.m_honestidad = componentEnRoot.honestidad;
			this.m_deshonestidad = componentEnRoot.deshonestidad;
			this.m_extroversion = componentEnRoot.extroversion;
			this.m_sumicion = componentEnRoot.sumicion;
			this.m_optimismo = componentEnRoot.optimismo;
			this.m_timidez = componentEnRoot.timidez;
			this.m_respeto = componentEnRoot.respeto;
			this.m_iRespeto = componentEnRoot.iRespeto;
			this.m_dominancia = componentEnRoot.dominanciaPorPersonalidad;
			this.m_masiquismo = componentEnRoot.masoquismoPorPersonalidad;
			this.m_sumicion = componentEnRoot.sumicionPorPersonalidad;
			this.m_hibristofilia = componentEnRoot.hibristofiliaPorPersonalidad;
			this.m_pervertido = componentEnRoot.pervertido;
			this.m_exhibicionista = componentEnRoot.exhibicionista;
			this.m_honesto = componentEnRoot.honesto;
			this.m_deshonesto = componentEnRoot.deshonesto;
			this.m_extrovertido = componentEnRoot.extrovertido;
			this.m_sumiso = componentEnRoot.sumiso;
			this.m_optimista = componentEnRoot.optimista;
			this.m_timido = componentEnRoot.timido;
			this.m_respetuoso = componentEnRoot.respetuoso;
			this.m_grosero = componentEnRoot.grosero;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000DE55 File Offset: 0x0000C055
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar",
				editorTimeVisible = false
			};
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000DE6E File Offset: 0x0000C06E
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.Actualizar();
		}

		// Token: 0x040000DD RID: 221
		[Header("Flotantes")]
		[ReadOnlyUI]
		[SerializeField]
		private float m_perverticidad;

		// Token: 0x040000DE RID: 222
		[ReadOnlyUI]
		[SerializeField]
		private float m_exhibicionismo;

		// Token: 0x040000DF RID: 223
		[ReadOnlyUI]
		[SerializeField]
		private float m_honestidad;

		// Token: 0x040000E0 RID: 224
		[ReadOnlyUI]
		[SerializeField]
		private float m_deshonestidad;

		// Token: 0x040000E1 RID: 225
		[ReadOnlyUI]
		[SerializeField]
		private float m_extroversion;

		// Token: 0x040000E2 RID: 226
		[ReadOnlyUI]
		[SerializeField]
		private float m_optimismo;

		// Token: 0x040000E3 RID: 227
		[ReadOnlyUI]
		[SerializeField]
		private float m_timidez;

		// Token: 0x040000E4 RID: 228
		[ReadOnlyUI]
		[SerializeField]
		private float m_respeto;

		// Token: 0x040000E5 RID: 229
		[ReadOnlyUI]
		[SerializeField]
		private float m_iRespeto;

		// Token: 0x040000E6 RID: 230
		[Header("Sex Flotantes")]
		[ReadOnlyUI]
		[SerializeField]
		private float m_dominancia;

		// Token: 0x040000E7 RID: 231
		[ReadOnlyUI]
		[SerializeField]
		private float m_masiquismo;

		// Token: 0x040000E8 RID: 232
		[ReadOnlyUI]
		[SerializeField]
		private float m_hibristofilia;

		// Token: 0x040000E9 RID: 233
		[ReadOnlyUI]
		[SerializeField]
		private float m_sumicion;

		// Token: 0x040000EA RID: 234
		[Header("Boleans")]
		[ReadOnlyUI]
		[SerializeField]
		private bool m_pervertido;

		// Token: 0x040000EB RID: 235
		[ReadOnlyUI]
		[SerializeField]
		private bool m_exhibicionista;

		// Token: 0x040000EC RID: 236
		[ReadOnlyUI]
		[SerializeField]
		private bool m_honesto;

		// Token: 0x040000ED RID: 237
		[ReadOnlyUI]
		[SerializeField]
		private bool m_deshonesto;

		// Token: 0x040000EE RID: 238
		[ReadOnlyUI]
		[SerializeField]
		private bool m_extrovertido;

		// Token: 0x040000EF RID: 239
		[ReadOnlyUI]
		[SerializeField]
		private bool m_sumiso;

		// Token: 0x040000F0 RID: 240
		[ReadOnlyUI]
		[SerializeField]
		private bool m_optimista;

		// Token: 0x040000F1 RID: 241
		[ReadOnlyUI]
		[SerializeField]
		private bool m_timido;

		// Token: 0x040000F2 RID: 242
		[ReadOnlyUI]
		[SerializeField]
		private bool m_respetuoso;

		// Token: 0x040000F3 RID: 243
		[ReadOnlyUI]
		[SerializeField]
		private bool m_grosero;
	}
}
