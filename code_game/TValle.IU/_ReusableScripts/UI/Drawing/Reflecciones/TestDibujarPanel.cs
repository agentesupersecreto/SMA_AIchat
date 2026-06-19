using System;
using Assets.Base.Plugins.Runtime.UI;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing.Reflecciones
{
	// Token: 0x02000087 RID: 135
	[RequireComponent(typeof(GenericFlotanteUserPanel))]
	public class TestDibujarPanel : AplicableBehaviour
	{
		// Token: 0x06000409 RID: 1033 RVA: 0x0001121F File Offset: 0x0000F41F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_userPanel = base.GetComponent<GenericFlotanteUserPanel>();
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00011233 File Offset: 0x0000F433
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Dibujar",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0001124C File Offset: 0x0000F44C
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Dibijar();
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0001125A File Offset: 0x0000F45A
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar Modelo",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00011273 File Offset: 0x0000F473
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.ActualizarModelo();
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00011281 File Offset: 0x0000F481
		public void Dibijar()
		{
			if (this.m_userPanel.isBinded)
			{
				this.m_userPanel.Clear();
			}
			this.m_userPanel.Bind(this.model, this.model, null);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000112B4 File Offset: 0x0000F4B4
		public void ActualizarModelo()
		{
			if (!this.m_userPanel.isBinded)
			{
				return;
			}
			this.m_userPanel.ActualizarValoresDeModelo();
			Debug.Log(this.model.a.ToString());
			Debug.Log(this.model.b.ToString());
			Debug.Log(this.model.c.ToString());
		}

		// Token: 0x04000156 RID: 342
		public TestDibujarPanel.Model model = new TestDibujarPanel.Model();

		// Token: 0x04000157 RID: 343
		private GenericFlotanteUserPanel m_userPanel;

		// Token: 0x02000192 RID: 402
		[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
		[Label("Panel title ingles", "US")]
		[Modelo]
		[Serializable]
		public class Model
		{
			// Token: 0x06000B38 RID: 2872 RVA: 0x00023BB8 File Offset: 0x00021DB8
			[BotonDePanel]
			public void Boton1()
			{
				Debug.Log("Boton1 undido");
			}

			// Token: 0x06000B39 RID: 2873 RVA: 0x00023BC4 File Offset: 0x00021DC4
			[Label("Guardar TEsting ingles", "US")]
			[BotonDePanel]
			public void Boton2()
			{
				Debug.Log("Boton2 undido");
			}

			// Token: 0x04000526 RID: 1318
			[Descripcion("*a descripcion 1", "US")]
			[Descripcion("*a descripcion 2", "US")]
			[Label("a label ingles", "US")]
			[Deslizable(decimalesDibujar = 0)]
			[Range(0f, 10f)]
			public float a;

			// Token: 0x04000527 RID: 1319
			[Label("b label ingles", "US")]
			[Desplegable]
			public DayOfWeek b;

			// Token: 0x04000528 RID: 1320
			[Descripcion("*c descripcion 1", "US")]
			[Label("c label ingles", "US")]
			[Deslizable(decimalesDibujar = 0)]
			[Range(0f, 10f)]
			public float c;

			// Token: 0x04000529 RID: 1321
			[PanelLayout(alturaMinima = 100f)]
			[Label("Panel Nested title ingles", "US")]
			[Modelo]
			public TestDibujarPanel.Model.ModelNested nested = new TestDibujarPanel.Model.ModelNested();

			// Token: 0x020001DA RID: 474
			[Modelo]
			[Serializable]
			public class ModelNested
			{
				// Token: 0x040005D0 RID: 1488
				[Descripcion("*a Nested descripcion 1", "US")]
				[Descripcion("*a Nested descripcion 2", "US")]
				[Label("a Nested label ingles", "US")]
				[Deslizable(decimalesDibujar = 0)]
				[Range(0f, 10f)]
				public float aNested;

				// Token: 0x040005D1 RID: 1489
				[Descripcion("*b Nested descripcion 1", "US")]
				[Label("b Nested label ingles", "US")]
				[Deslizable(decimalesDibujar = 0)]
				[Range(0f, 10f)]
				public float bNested;

				// Token: 0x040005D2 RID: 1490
				[Label("c Nested label ingles", "US")]
				[Desplegable]
				public DayOfWeek cNested;
			}
		}
	}
}
