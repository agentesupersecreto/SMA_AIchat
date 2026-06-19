using System;
using Assets._ReusableScripts.Bones.V2;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Componentes;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Alteradores.Componentes
{
	// Token: 0x02000132 RID: 306
	public sealed class ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje> : ScaladorLocalDeBone<TAlteradorPorcentaje> where TAlteradorPorcentaje : AlteradorPorcentaje
	{
		// Token: 0x06000623 RID: 1571 RVA: 0x000227C1 File Offset: 0x000209C1
		public ScaladorDeColliderPrincipalDeParte(TAlteradorPorcentaje alterador, Transform transform, Muscle musculo, float musculoMod)
			: base(alterador, transform)
		{
			if (musculo == null)
			{
				throw new ArgumentNullException("musculo", "musculo null reference.");
			}
			this.m_musculoMod = musculoMod;
			this.m_musculo = musculo;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x000227F0 File Offset: 0x000209F0
		public void ScalarParte()
		{
			if (this.m_scaler == null)
			{
				return;
			}
			switch (this.m_scaler.tipo)
			{
			case TipoDeCollider.sphere:
				this.m_SphereMods.radius.valor.valor = Mathf.Lerp(1f, base.DiferenciaModificadorDelAxisMenor(), this.m_musculoMod);
				return;
			case TipoDeCollider.capsule:
			{
				float num = Mathf.Lerp(1f, base.DiferenciaModificador(), this.m_musculoMod);
				this.m_CapsuleMods.radius.valor.valor = num;
				if (this.cambiarAlturaDeCollider)
				{
					this.m_CapsuleMods.height.valor.valor = num;
					return;
				}
				break;
			}
			case TipoDeCollider.box:
			{
				float num2;
				float num3;
				float num4;
				base.DiferenciaModificadorDeAxis(out num2, out num3, out num4);
				if (this.cambiarAlturaDeCollider)
				{
					this.m_BoxMods.sizeX.valor.valor = Mathf.Lerp(1f, num2, this.m_musculoMod);
					this.m_BoxMods.sizeY.valor.valor = Mathf.Lerp(1f, num3, this.m_musculoMod);
					this.m_BoxMods.sizeZ.valor.valor = Mathf.Lerp(1f, num4, this.m_musculoMod);
					return;
				}
				if (this.m_rootBone != null)
				{
					if (this.m_rootBone.forwardAxis != RootBone.ForwardAxis.x)
					{
						this.m_BoxMods.sizeX.valor.valor = Mathf.Lerp(1f, num2, this.m_musculoMod);
					}
					if (this.m_rootBone.forwardAxis != RootBone.ForwardAxis.y)
					{
						this.m_BoxMods.sizeY.valor.valor = Mathf.Lerp(1f, num3, this.m_musculoMod);
					}
					if (this.m_rootBone.forwardAxis != RootBone.ForwardAxis.z)
					{
						this.m_BoxMods.sizeZ.valor.valor = Mathf.Lerp(1f, num4, this.m_musculoMod);
						return;
					}
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(this.m_scaler.tipo.ToString());
			}
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00022A00 File Offset: 0x00020C00
		protected sealed override void OnStart()
		{
			base.OnStart();
			if (this.m_musculo.colliders[0].transform != this.m_musculo.rigidbody.transform)
			{
				throw new InvalidOperationException();
			}
			this.m_scaler = this.m_musculo.rigidbody.GetComponent<PuppetPartMainColliderVolumer>();
			if (this.m_scaler == null)
			{
				throw new ArgumentNullException("m_scaler", "m_scaler null reference.");
			}
			if (!this.m_scaler.isStared)
			{
				throw new NotSupportedException("este start debe ser despues de PuppetPartMainColliderScaler start");
			}
			switch (this.m_scaler.tipo)
			{
			case TipoDeCollider.sphere:
				this.m_SphereMods = new ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.SphereMods();
				this.m_SphereMods.radius = this.m_scaler.sphereModificable.radius.modificable.ObtenerModificadorNotNull(this.alterador.nombre);
				break;
			case TipoDeCollider.capsule:
				this.m_CapsuleMods = new ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.CapsuleMods();
				this.m_CapsuleMods.radius = this.m_scaler.capsuleModificable.radius.modificable.ObtenerModificadorNotNull(this.alterador.nombre);
				this.m_CapsuleMods.height = this.m_scaler.capsuleModificable.height.modificable.ObtenerModificadorNotNull(this.alterador.nombre);
				break;
			case TipoDeCollider.box:
				this.m_BoxMods = new ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.BoxMods();
				this.m_BoxMods.sizeX = this.m_scaler.boxModificable.sizeX.modificable.ObtenerModificadorNotNull(this.alterador.nombre);
				this.m_BoxMods.sizeY = this.m_scaler.boxModificable.sizeY.modificable.ObtenerModificadorNotNull(this.alterador.nombre);
				this.m_BoxMods.sizeZ = this.m_scaler.boxModificable.sizeZ.modificable.ObtenerModificadorNotNull(this.alterador.nombre);
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_scaler.tipo.ToString());
			}
			Muscle musculo = this.m_musculo;
			RootBone rootBone;
			if (musculo == null)
			{
				rootBone = null;
			}
			else
			{
				Transform target = musculo.target;
				rootBone = ((target != null) ? target.GetComponentInParent<RootBone>() : null);
			}
			this.m_rootBone = rootBone;
			if (this.m_rootBone == null)
			{
				throw new ArgumentNullException("m_rootBone", "m_rootBone null reference.");
			}
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00022C80 File Offset: 0x00020E80
		protected override void Destroyed(bool quitting)
		{
			base.Destroyed(quitting);
			try
			{
				ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.BoxMods boxMods = this.m_BoxMods;
				if (boxMods != null)
				{
					ModificadorDeFloat sizeX = boxMods.sizeX;
					if (sizeX != null)
					{
						sizeX.TryRemoverDeOwner(true);
					}
				}
				ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.BoxMods boxMods2 = this.m_BoxMods;
				if (boxMods2 != null)
				{
					ModificadorDeFloat sizeY = boxMods2.sizeY;
					if (sizeY != null)
					{
						sizeY.TryRemoverDeOwner(true);
					}
				}
				ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.BoxMods boxMods3 = this.m_BoxMods;
				if (boxMods3 != null)
				{
					ModificadorDeFloat sizeZ = boxMods3.sizeZ;
					if (sizeZ != null)
					{
						sizeZ.TryRemoverDeOwner(true);
					}
				}
				ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.SphereMods sphereMods = this.m_SphereMods;
				if (sphereMods != null)
				{
					ModificadorDeFloat radius = sphereMods.radius;
					if (radius != null)
					{
						radius.TryRemoverDeOwner(true);
					}
				}
				ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.SphereMods sphereMods2 = this.m_SphereMods;
				if (sphereMods2 != null)
				{
					ModificadorDeFloat radius2 = sphereMods2.radius;
					if (radius2 != null)
					{
						radius2.TryRemoverDeOwner(true);
					}
				}
				ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.CapsuleMods capsuleMods = this.m_CapsuleMods;
				if (capsuleMods != null)
				{
					ModificadorDeFloat height = capsuleMods.height;
					if (height != null)
					{
						height.TryRemoverDeOwner(true);
					}
				}
			}
			catch (Exception ex)
			{
				TAlteradorPorcentaje talteradorPorcentaje = this.alterador;
				Debug.LogException(ex, (talteradorPorcentaje != null) ? talteradorPorcentaje.holder : null);
			}
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00022D78 File Offset: 0x00020F78
		[Obsolete]
		private static TipoDeCollider GetTipo(Collider collider)
		{
			if (collider is BoxCollider)
			{
				return TipoDeCollider.box;
			}
			if (collider is CapsuleCollider)
			{
				return TipoDeCollider.capsule;
			}
			if (collider is SphereCollider)
			{
				return TipoDeCollider.sphere;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x040004F6 RID: 1270
		private ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.BoxMods m_BoxMods;

		// Token: 0x040004F7 RID: 1271
		private ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.SphereMods m_SphereMods;

		// Token: 0x040004F8 RID: 1272
		private ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.CapsuleMods m_CapsuleMods;

		// Token: 0x040004F9 RID: 1273
		public bool cambiarAlturaDeCollider;

		// Token: 0x040004FA RID: 1274
		private float m_musculoMod;

		// Token: 0x040004FB RID: 1275
		private Muscle m_musculo;

		// Token: 0x040004FC RID: 1276
		private PuppetPartMainColliderVolumer m_scaler;

		// Token: 0x040004FD RID: 1277
		[Obsolete]
		private ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.ColliderInfo m_main;

		// Token: 0x040004FE RID: 1278
		private RootBone m_rootBone;

		// Token: 0x02000133 RID: 307
		public class BoxMods
		{
			// Token: 0x040004FF RID: 1279
			public ModificadorDeFloat sizeX;

			// Token: 0x04000500 RID: 1280
			public ModificadorDeFloat sizeY;

			// Token: 0x04000501 RID: 1281
			public ModificadorDeFloat sizeZ;
		}

		// Token: 0x02000134 RID: 308
		public class SphereMods
		{
			// Token: 0x04000502 RID: 1282
			public ModificadorDeFloat radius;
		}

		// Token: 0x02000135 RID: 309
		public class CapsuleMods
		{
			// Token: 0x04000503 RID: 1283
			public ModificadorDeFloat radius;

			// Token: 0x04000504 RID: 1284
			public ModificadorDeFloat height;
		}

		// Token: 0x02000136 RID: 310
		[Obsolete]
		private class ColliderInfo
		{
			// Token: 0x0600062B RID: 1579 RVA: 0x00022DA0 File Offset: 0x00020FA0
			public void Init(ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje> parent, Collider collider, Transform bone)
			{
				if (this.m_parent != null)
				{
					throw new InvalidOperationException();
				}
				if (parent == null)
				{
					throw new ArgumentNullException("parent", "parent null reference.");
				}
				this.m_parent = parent;
				if (collider == null)
				{
					throw new ArgumentNullException("collider", "collider null reference.");
				}
				this.m_collider = collider;
				this.m_tipoDeCollider = ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje>.GetTipo(this.m_collider);
				switch (this.m_tipoDeCollider)
				{
				case TipoDeCollider.sphere:
					this.m_defaultRadius = ((CapsuleCollider)this.m_collider).radius;
					return;
				case TipoDeCollider.capsule:
					this.m_defaultRadius = ((CapsuleCollider)this.m_collider).radius;
					this.m_defaultAltura = ((CapsuleCollider)this.m_collider).height;
					return;
				case TipoDeCollider.box:
					this.m_defaultSize = ((BoxCollider)this.m_collider).size;
					return;
				default:
					throw new ArgumentOutOfRangeException(this.m_tipoDeCollider.ToString());
				}
			}

			// Token: 0x0600062C RID: 1580 RVA: 0x00022E94 File Offset: 0x00021094
			public void Apply()
			{
				switch (this.m_tipoDeCollider)
				{
				case TipoDeCollider.sphere:
					this.ApplyToCollider((SphereCollider)this.m_collider);
					return;
				case TipoDeCollider.capsule:
					this.ApplyToCollider((CapsuleCollider)this.m_collider);
					return;
				case TipoDeCollider.box:
					this.ApplyToCollider((BoxCollider)this.m_collider);
					return;
				default:
					throw new ArgumentOutOfRangeException(this.m_tipoDeCollider.ToString());
				}
			}

			// Token: 0x0600062D RID: 1581 RVA: 0x00022F08 File Offset: 0x00021108
			private void ApplyToCollider(CapsuleCollider collider)
			{
				float num = Mathf.Lerp(1f, this.m_parent.DiferenciaModificador(), this.m_parent.m_musculoMod);
				collider.radius = this.m_defaultRadius * num;
				if (this.m_parent.cambiarAlturaDeCollider)
				{
					collider.height = this.m_defaultAltura * num;
				}
			}

			// Token: 0x0600062E RID: 1582 RVA: 0x00022F60 File Offset: 0x00021160
			private void ApplyToCollider(SphereCollider collider)
			{
				float num = Mathf.Lerp(1f, this.m_parent.DiferenciaModificadorDelAxisMenor(), this.m_parent.m_musculoMod);
				collider.radius = this.m_defaultRadius * num;
			}

			// Token: 0x0600062F RID: 1583 RVA: 0x00022F9C File Offset: 0x0002119C
			private void ApplyToCollider(BoxCollider collider)
			{
				float num;
				float num2;
				float num3;
				this.m_parent.DiferenciaModificadorDeAxis(out num, out num2, out num3);
				num = Mathf.Lerp(1f, num, this.m_parent.m_musculoMod);
				num2 = Mathf.Lerp(1f, num2, this.m_parent.m_musculoMod);
				num3 = Mathf.Lerp(1f, num3, this.m_parent.m_musculoMod);
				collider.size = new Vector3(this.m_defaultSize.x * num, this.m_defaultSize.y * num2, this.m_defaultSize.z * num3);
			}

			// Token: 0x04000505 RID: 1285
			public Collider m_collider;

			// Token: 0x04000506 RID: 1286
			private float m_defaultRadius;

			// Token: 0x04000507 RID: 1287
			private float m_defaultAltura;

			// Token: 0x04000508 RID: 1288
			private Vector3 m_defaultSize;

			// Token: 0x04000509 RID: 1289
			private TipoDeCollider m_tipoDeCollider;

			// Token: 0x0400050A RID: 1290
			private ScaladorDeColliderPrincipalDeParte<TAlteradorPorcentaje> m_parent;
		}
	}
}
