using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Shapes.Abstracts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Shapes
{
	// Token: 0x0200011F RID: 287
	public sealed class MalePuppetModificadorDeVolumenDeMusculos : PuppetModificadorDeVolumenDeMusculos
	{
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x00020D87 File Offset: 0x0001EF87
		public override IReadOnlyList<ModificadorDeVolumenPorShapes.ModificacionInfo> infos
		{
			get
			{
				return this.m_infosJoind;
			}
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00020D90 File Offset: 0x0001EF90
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_infosJoind = new List<MalePuppetModificadorDeVolumenDeMusculos.Info>();
			this.m_infosJoind.AddRange(this.m_infos);
			this.m_infosJoind.AddRange(this.m_infos2);
			this.m_infosJoind.AddRange(this.m_infos3);
			this.m_infosJoind.AddRange(this.m_infos4);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00020D47 File Offset: 0x0001EF47
		public override void OnUpdateEvent1()
		{
			base.Actualizar();
		}

		// Token: 0x04000495 RID: 1173
		[SerializeField]
		private List<MalePuppetModificadorDeVolumenDeMusculos.Info> m_infos = new List<MalePuppetModificadorDeVolumenDeMusculos.Info>();

		// Token: 0x04000496 RID: 1174
		[SerializeField]
		private List<MalePuppetModificadorDeVolumenDeMusculos.Info> m_infos2 = new List<MalePuppetModificadorDeVolumenDeMusculos.Info>();

		// Token: 0x04000497 RID: 1175
		[SerializeField]
		private List<MalePuppetModificadorDeVolumenDeMusculos.Info> m_infos3 = new List<MalePuppetModificadorDeVolumenDeMusculos.Info>();

		// Token: 0x04000498 RID: 1176
		[SerializeField]
		private List<MalePuppetModificadorDeVolumenDeMusculos.Info> m_infos4 = new List<MalePuppetModificadorDeVolumenDeMusculos.Info>();

		// Token: 0x04000499 RID: 1177
		private List<MalePuppetModificadorDeVolumenDeMusculos.Info> m_infosJoind;

		// Token: 0x02000120 RID: 288
		[Serializable]
		public class Info : PuppetModificadorDeVolumenDeMusculos.ModificacionDeParteInfo
		{
			// Token: 0x1700012B RID: 299
			// (get) Token: 0x060005DD RID: 1501 RVA: 0x00020E26 File Offset: 0x0001F026
			public override string normbreDeShape
			{
				get
				{
					return MapaSingleton<MapaDeMaleBlendShapes>.instance.ObtenerValorDeField(this.m_shape);
				}
			}

			// Token: 0x0400049A RID: 1178
			[SerializeField]
			[StringSelector(typeof(MapaDeMaleBlendShapes), "fieldsEditor")]
			private string m_shape;
		}
	}
}
