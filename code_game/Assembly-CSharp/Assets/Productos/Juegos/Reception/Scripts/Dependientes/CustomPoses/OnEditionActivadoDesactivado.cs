using System;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Battlehub.RTHandles;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.CustomPoses
{
	// Token: 0x020000C1 RID: 193
	public class OnEditionActivadoDesactivado : CustomMonobehaviour
	{
		// Token: 0x06000489 RID: 1161 RVA: 0x0001663A File Offset: 0x0001483A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_canHideCursor = Singleton<ConfiguracionGeneralDeMouse>.instance.canHideCursorModificableAnd.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00016658 File Offset: 0x00014858
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<SkeletonEditorMode>.instance.onModoChanging += this.Instance_onModoChanging;
			Singleton<SkeletonEditorMode>.instance.onModoChanged += this.Instance_onModoChanged;
			Singleton<MainDialogueSystemEvents>.instance.conversacionStart += this.Instance_conversacionStart;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000166B0 File Offset: 0x000148B0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<SkeletonEditorMode>.IsInScene)
			{
				Singleton<SkeletonEditorMode>.instance.onModoChanging -= this.Instance_onModoChanging;
				Singleton<SkeletonEditorMode>.instance.onModoChanged -= this.Instance_onModoChanged;
			}
			if (Singleton<MainDialogueSystemEvents>.IsInScene)
			{
				Singleton<MainDialogueSystemEvents>.instance.conversacionStart -= this.Instance_conversacionStart;
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00016714 File Offset: 0x00014914
		private void Instance_onModoChanging(SkeletonEditorMode obj)
		{
			if (!obj.activado)
			{
				foreach (BaseHandle baseHandle in obj.boneEditionRoot.GetComponentsInChildren<BaseHandle>())
				{
					if (baseHandle != null)
					{
						baseHandle.EndDrag();
					}
				}
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00016754 File Offset: 0x00014954
		private void Instance_onModoChanged(SkeletonEditorMode obj)
		{
			bool activado = obj.activado;
			Singleton<PlayerInputProxy>.instance.activado = !activado;
			this.m_canHideCursor.valor.valor = !activado;
			if (!Singleton<SkeletonEditorMode>.instance.activado)
			{
				Singleton<SkeletonEditorMode>.instance.editor.Selection.activeGameObject = null;
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000167AB File Offset: 0x000149AB
		private void Instance_conversacionStart()
		{
			Singleton<SkeletonEditorMode>.instance.DesactivarParaTodos(false);
		}

		// Token: 0x0400020D RID: 525
		private ModificadorDeBool m_canHideCursor;
	}
}
