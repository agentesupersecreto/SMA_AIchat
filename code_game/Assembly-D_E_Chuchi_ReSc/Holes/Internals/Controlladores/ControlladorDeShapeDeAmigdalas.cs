using System;
using System.Collections.Generic;
using Assets.Base.Controllers;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores
{
	// Token: 0x020001BB RID: 443
	public class ControlladorDeShapeDeAmigdalas : ControllerGenericoDeShapesKey
	{
		// Token: 0x06000A74 RID: 2676 RVA: 0x0002F7A4 File Offset: 0x0002D9A4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			IFemaleSkins componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("femSkins", "femSkins null reference.");
			}
			this.m_amigdalas = componentEnRoot.amigdalas;
			if (this.m_amigdalas == null)
			{
				throw new ArgumentNullException("m_amigdalas", "m_amigdalas null reference.");
			}
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0002F7FC File Offset: 0x0002D9FC
		protected override SkinnedMeshRenderer GetRenderer()
		{
			return this.m_amigdalas;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0002F804 File Offset: 0x0002DA04
		protected override void InstantiateShapeKeys(List<IShapeKey> resultado)
		{
			resultado.Add(new ShapeKey("FACE_AmigInflaA"));
			resultado.Add(new ShapeKey("FACE_AmigInflaB"));
			resultado.Add(new ShapeKey("FACE_AmigInflaC"));
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0002F836 File Offset: 0x0002DA36
		protected override void ProducirGrupos()
		{
			base.ProducirGrupos();
			base.AgruparNormalizandoExagerado(4f, new string[] { "FACE_AmigInflaA", "FACE_AmigInflaB", "FACE_AmigInflaC" });
		}

		// Token: 0x04000863 RID: 2147
		private SkinnedMeshRenderer m_amigdalas;

		// Token: 0x04000864 RID: 2148
		public const string A = "FACE_AmigInflaA";

		// Token: 0x04000865 RID: 2149
		public const string B = "FACE_AmigInflaB";

		// Token: 0x04000866 RID: 2150
		public const string C = "FACE_AmigInflaC";
	}
}
