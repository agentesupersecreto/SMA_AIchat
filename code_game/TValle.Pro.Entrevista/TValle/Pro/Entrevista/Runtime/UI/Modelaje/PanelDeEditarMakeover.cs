using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje
{
	// Token: 0x0200002C RID: 44
	[RequireComponent(typeof(GenericFlotanteUserPanel))]
	public class PanelDeEditarMakeover : PanelBaseSingleModel<MakeoverToEdit>
	{
		// Token: 0x060001AE RID: 430 RVA: 0x0000A575 File Offset: 0x00008775
		public void SetTarget(FemaleChar Target)
		{
			if (Target == null)
			{
				throw new ArgumentNullException("Target", "Target null reference.");
			}
			this.m_target = Target;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000A598 File Offset: 0x00008798
		protected override void OnBinding()
		{
			base.OnBinding();
			this.m_AlteradoresDeAparienciaFemenina = this.m_target.GetComponentEnRoot<AlteradoresDeAparienciaFemenina>();
			if (this.m_AlteradoresDeAparienciaFemenina == null)
			{
				throw new ArgumentNullException("m_AlteradoresDeAparienciaFemenina", "m_AlteradoresDeAparienciaFemenina null reference.");
			}
			DatosDeHumanBone head = this.m_target.bones.head;
			base.transform.SetPositionAndRotation(head.posicionFinal, head.rotacionFinal * head.offSetToForward);
			this.m_follower = base.gameObject.AddComponent<TrasnformCopier>();
			this.m_follower.Init(false, base.transform, this.m_target.bones.head.transform, new Vector3?(head.offSetToForward.eulerAngles), null, null);
			this.m_model.onModelChanged += this.M_model_onModelChanged;
			this.m_model.accion1 += this.M_model_accion1;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000A698 File Offset: 0x00008898
		private void M_model_onModelChanged(IUIElementoConValor obj, IUIPanel panel)
		{
			IUIElementoConValorModificable iuielementoConValorModificable = obj as IUIElementoConValorModificable;
			if (iuielementoConValorModificable == null)
			{
				return;
			}
			string text;
			int num;
			if (!PanelDeEditarMakeover.TryGetAlteradorDataFromModel(obj, panel, out text, out num))
			{
				return;
			}
			Alterador alterador = this.m_AlteradoresDeAparienciaFemenina.Obtener(text);
			if (alterador == null)
			{
				return;
			}
			try
			{
				alterador.ExportarModificadores(PanelDeEditarMakeover.m_deZeroAUnoModsTemps);
				PanelDeEditarMakeover.m_deZeroAUnoModsTemps[num] = iuielementoConValorModificable.GetValorAsModZeroToOne();
				alterador.Modificar(PanelDeEditarMakeover.m_deZeroAUnoModsTemps);
			}
			finally
			{
				PanelDeEditarMakeover.m_deZeroAUnoModsTemps.Clear();
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000A714 File Offset: 0x00008914
		private void M_model_accion1()
		{
			base.Clear();
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000A71C File Offset: 0x0000891C
		protected override void OnCleared()
		{
			base.OnCleared();
			this.m_model.onModelChanged -= this.M_model_onModelChanged;
			this.m_model.accion1 -= this.M_model_accion1;
			this.m_target = null;
			this.m_AlteradoresDeAparienciaFemenina = null;
			if (this.m_follower != null)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_follower = null;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000A78B File Offset: 0x0000898B
		protected override void OnBinded()
		{
			base.OnBinded();
			this.LoadElementoConSecondaryModel(base.UIPanel, null);
			base.ActualizarValoresDeModelo();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000A7A8 File Offset: 0x000089A8
		public static void SetValoresToAlteradores(MakeoverToEdit model, AlteradoresDeAparienciaFemenina alteradores)
		{
			SecondaryModelAttribute.SecondaryModelEstructura secondaryModelEstructura = SecondaryModelAttribute.GetSecondaryModelEstructura(model, null);
			PanelDeEditarMakeover.setValoresToAlteradores(alteradores, secondaryModelEstructura, null);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000A7C8 File Offset: 0x000089C8
		private static void setValoresToAlteradores(AlteradoresDeAparienciaFemenina alteradores, SecondaryModelAttribute.SecondaryModelEstructura selfSecondaryModelEstructura, SecondaryModelAttribute.SecondaryModelEstructura parentSecondaryModelEstructura)
		{
			PanelDeEditarMakeover.setValoresToAlteradore(alteradores, selfSecondaryModelEstructura, parentSecondaryModelEstructura);
			for (int i = 0; i < selfSecondaryModelEstructura.children.Count; i++)
			{
				SecondaryModelAttribute.SecondaryModelEstructura secondaryModelEstructura = selfSecondaryModelEstructura.children[i];
				PanelDeEditarMakeover.setValoresToAlteradores(alteradores, secondaryModelEstructura, selfSecondaryModelEstructura);
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000A808 File Offset: 0x00008A08
		private static void setValoresToAlteradore(AlteradoresDeAparienciaFemenina alteradores, SecondaryModelAttribute.SecondaryModelEstructura selfSecondaryModelEstructura, SecondaryModelAttribute.SecondaryModelEstructura parentSecondaryModelEstructura)
		{
			string text;
			int num;
			if (!PanelDeEditarMakeover.TryGetAlteradorDataFromModel(selfSecondaryModelEstructura, parentSecondaryModelEstructura, out text, out num))
			{
				return;
			}
			Alterador alterador = alteradores.Obtener(text);
			if (alterador == null)
			{
				return;
			}
			try
			{
				alterador.ExportarModificadores(PanelDeEditarMakeover.m_deZeroAUnoModsTemps);
				float num2 = Convert.ToSingle(selfSecondaryModelEstructura.modelEstructura.GetValue());
				if (alterador.indexMaxCount > 0)
				{
					num2 /= (float)alterador.indexMaxCount;
				}
				else
				{
					num2 /= 100f;
				}
				PanelDeEditarMakeover.m_deZeroAUnoModsTemps[num] = num2;
				alterador.Modificar(PanelDeEditarMakeover.m_deZeroAUnoModsTemps);
			}
			finally
			{
				PanelDeEditarMakeover.m_deZeroAUnoModsTemps.Clear();
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000A8A0 File Offset: 0x00008AA0
		public static void SetValoresAModel(MakeoverToEdit model, AlteradoresDeAparienciaFemenina alteradores)
		{
			SecondaryModelAttribute.SecondaryModelEstructura secondaryModelEstructura = SecondaryModelAttribute.GetSecondaryModelEstructura(model, null);
			PanelDeEditarMakeover.setValoresAModel(alteradores, secondaryModelEstructura, null);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000A8C0 File Offset: 0x00008AC0
		private static void setValoresAModel(AlteradoresDeAparienciaFemenina alteradores, SecondaryModelAttribute.SecondaryModelEstructura selfSecondaryModelEstructura, SecondaryModelAttribute.SecondaryModelEstructura parentSecondaryModelEstructura)
		{
			PanelDeEditarMakeover.setValoresAModelSingle(alteradores, selfSecondaryModelEstructura, parentSecondaryModelEstructura);
			for (int i = 0; i < selfSecondaryModelEstructura.children.Count; i++)
			{
				SecondaryModelAttribute.SecondaryModelEstructura secondaryModelEstructura = selfSecondaryModelEstructura.children[i];
				PanelDeEditarMakeover.setValoresAModel(alteradores, secondaryModelEstructura, selfSecondaryModelEstructura);
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000A900 File Offset: 0x00008B00
		private static void setValoresAModelSingle(AlteradoresDeAparienciaFemenina alteradores, SecondaryModelAttribute.SecondaryModelEstructura selfSecondaryModelEstructura, SecondaryModelAttribute.SecondaryModelEstructura parentSecondaryModelEstructura)
		{
			string text;
			int num;
			if (!PanelDeEditarMakeover.TryGetAlteradorDataFromModel(selfSecondaryModelEstructura, parentSecondaryModelEstructura, out text, out num))
			{
				return;
			}
			Alterador alterador = alteradores.Obtener(text);
			if (alterador == null)
			{
				return;
			}
			try
			{
				alterador.ExportarModificadores(PanelDeEditarMakeover.m_deZeroAUnoModsTemps);
				float num2 = PanelDeEditarMakeover.m_deZeroAUnoModsTemps[num];
				if (alterador.indexMaxCount > 0)
				{
					float num3 = num2 * (float)alterador.indexMaxCount;
					selfSecondaryModelEstructura.modelEstructura.SetValue(num3);
				}
				else
				{
					selfSecondaryModelEstructura.modelEstructura.SetValue(num2 * 100f);
				}
			}
			finally
			{
				PanelDeEditarMakeover.m_deZeroAUnoModsTemps.Clear();
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000A99C File Offset: 0x00008B9C
		private void LoadElementoConSecondaryModel(IUIElemento elemento, IUIPanel parent)
		{
			IUIPanel iuipanel = elemento as IUIPanel;
			if (iuipanel != null)
			{
				using (IEnumerator<KeyValuePair<string, IUIElemento>> enumerator = iuipanel.elementoPorModelo.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, IUIElemento> keyValuePair = enumerator.Current;
						this.LoadElementoConSecondaryModel(keyValuePair.Value, iuipanel);
					}
					return;
				}
			}
			IUIElementoConValorModificable iuielementoConValorModificable = elemento as IUIElementoConValorModificable;
			IUIElementoConValor iuielementoConValor = elemento as IUIElementoConValor;
			if (iuielementoConValorModificable == null)
			{
				return;
			}
			if (iuielementoConValor == null)
			{
				return;
			}
			string text;
			int num;
			if (!PanelDeEditarMakeover.TryGetAlteradorDataFromModel(elemento, parent, out text, out num))
			{
				return;
			}
			Alterador alterador = this.m_AlteradoresDeAparienciaFemenina.Obtener(text);
			if (alterador == null)
			{
				return;
			}
			try
			{
				alterador.ExportarModificadores(PanelDeEditarMakeover.m_deZeroAUnoModsTemps);
				float num2 = PanelDeEditarMakeover.m_deZeroAUnoModsTemps[num];
				if (alterador.indexMaxCount > 0)
				{
					float num3 = num2 * (float)alterador.indexMaxCount;
					iuielementoConValor.SetValor(num3, true);
				}
				else
				{
					iuielementoConValorModificable.SetValorAsModZeroToOne(num2, true);
				}
			}
			finally
			{
				PanelDeEditarMakeover.m_deZeroAUnoModsTemps.Clear();
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000AA9C File Offset: 0x00008C9C
		private static bool TryGetAlteradorDataFromModel(SecondaryModelAttribute.SecondaryModelEstructura selfSecondaryModelEstructura, SecondaryModelAttribute.SecondaryModelEstructura parentSecondaryModelEstructura, out string alteradorName, out int alteradorValueIndex)
		{
			alteradorName = null;
			alteradorValueIndex = -1;
			return selfSecondaryModelEstructura.ownSecondaryModel != null && PanelDeEditarMakeover.TryGetAlteradorDataFromModel(selfSecondaryModelEstructura.ownSecondaryModel.index, selfSecondaryModelEstructura.secondaryModelValueGetter, (parentSecondaryModelEstructura != null) ? parentSecondaryModelEstructura.secondaryModelValueGetter : null, out alteradorName, out alteradorValueIndex);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000AAD4 File Offset: 0x00008CD4
		private static bool TryGetAlteradorDataFromModel(IUIElemento elemento, IUIPanel parent, out string alteradorName, out int alteradorValueIndex)
		{
			alteradorName = null;
			alteradorValueIndex = -1;
			IUIElementoSecondaryBindable iuielementoSecondaryBindable = elemento as IUIElementoSecondaryBindable;
			IUIElementoSecondaryBindable iuielementoSecondaryBindable2 = parent as IUIElementoSecondaryBindable;
			return iuielementoSecondaryBindable != null && PanelDeEditarMakeover.TryGetAlteradorDataFromModel(iuielementoSecondaryBindable.secondaryModelIndex, iuielementoSecondaryBindable.secondaryModeloValueGetter, (iuielementoSecondaryBindable2 != null) ? iuielementoSecondaryBindable2.secondaryModeloValueGetter : null, out alteradorName, out alteradorValueIndex);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000AB1C File Offset: 0x00008D1C
		private static bool TryGetAlteradorDataFromModel(int selfSecondaryModelIndex, Func<object> selfSecondaryModeloValueGetter, Func<object> parentSecondaryModeloValueGetter, out string alteradorName, out int alteradorValueIndex)
		{
			alteradorName = null;
			alteradorValueIndex = -1;
			alteradorValueIndex = selfSecondaryModelIndex;
			if (alteradorValueIndex < 0)
			{
				return false;
			}
			Func<object> func;
			if (selfSecondaryModeloValueGetter != null)
			{
				func = selfSecondaryModeloValueGetter;
			}
			else
			{
				func = parentSecondaryModeloValueGetter;
			}
			if (func == null)
			{
				return false;
			}
			alteradorName = func().ToString();
			return !string.IsNullOrWhiteSpace(alteradorName);
		}

		// Token: 0x040000F7 RID: 247
		[SerializeField]
		[ReadOnlyUI]
		private FemaleChar m_target;

		// Token: 0x040000F8 RID: 248
		[SerializeField]
		[ReadOnlyUI]
		private AlteradoresDeAparienciaFemenina m_AlteradoresDeAparienciaFemenina;

		// Token: 0x040000F9 RID: 249
		[SerializeField]
		[ReadOnlyUI]
		private TrasnformCopier m_follower;

		// Token: 0x040000FA RID: 250
		private static List<float> m_deZeroAUnoModsTemps = new List<float>();
	}
}
